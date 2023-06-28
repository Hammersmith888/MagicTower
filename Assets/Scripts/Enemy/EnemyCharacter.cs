using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UI;

public enum EnemyActionState
{
    spawn,
    move,
    attack,
    shoot,
    summon,
    gotHit,
    jump,
    enrage,
    enrage2,
    dead,
    deadBeforeSpawn
}
public enum EnemyMovementType
{
    stop,
    walk,
    specMove,
    run,
    crawl,
    roll
}


public class EnemyCharacter : MonoBehaviour
{
    #region VARIABLES

    const string DEAD_ENEMY_TAG = "DeadEnemy";
    const string DEAD_ENEMY_MATERIAL_DATA_PATH = "Effects/EnemiesAlphaFadeOutMaterialSettings";
    const float DEAD_BODY_FADEOUT_TIME = 0.75f;

    public bool friendly = false;
    private bool isSummoned = false;

    public EnemyType enemyType = EnemyType.zombie_walk;
    //    [HideInInspector]
    public float damage; // Сколько единиц урона наносит враг
                         //[HideInInspector]
    public float health;
    public float indexFreeze;
    public float freezeTime; // время записываем сюда что бы потом брать отсюда и делить его
    [HideInInspector] 
    public float _slowDownTime =0;
    [HideInInspector]
    public float attackSpeed; // Скорость атаки
    [HideInInspector]
    public float specDamage; // Скорость атаки
                             //[HideInInspector]
    public int coinChance; // Вероятность выпадения монеты 
                           //[HideInInspector]
    public int gold; // Количество золота с монстра

    [SerializeField] private EnemyActionState currentActionState;
    [SerializeField] private EnemyMovementType currentMovementType;

    private int countHitBoss = 0;
    [SerializeField] private GameObject enemyExplosion;
    private static GameObject smallCasket;
    public bool IsMoving
    {
        get
        {
            return currentActionState == EnemyActionState.move;
        }
    }
    public bool IsAttacking
    {
        get
        {
            return currentActionState == EnemyActionState.attack;
        }
    }
    public bool IsGettingHit
    {
        get
        {
            return currentActionState == EnemyActionState.gotHit;
        }
    }
    public bool IsJumping
    {
        get
        {
            return currentActionState == EnemyActionState.jump;
        }
    }
    public bool IsSummoning
    {
        get
        {
            return currentActionState == EnemyActionState.summon;
        }
    }
    public bool IsDead
    {
        get
        {
            return currentActionState == EnemyActionState.dead;
        }
    }
    public bool IsDeadBeforeSpawn
    {
        get
        {
            return currentActionState == EnemyActionState.deadBeforeSpawn;
        }
    }
    public bool IsSpecMove
    {
        get
        {
            return currentMovementType == EnemyMovementType.specMove;
        }
    }

    private GameObject healthConatiner;
    private Vector3 healthConatinerStartLocalPosition;

    public GameObject healthBar, healthBar2, shadow;

    public AnimationClip attackAnimClip;

    [HideInInspector]
    public int casketChance, casketContent;
    private bool getCasket; // Выпадет или нет монета
    private bool getGem; // Выпадет или нет монета

    [HideInInspector]
    public bool getCoin; // Выпадет или нет монета
    private float scaleHealthBar, healthScaleRatio;

    //[HideInInspector]
    private float resistanceFire, resistanceAir, resistanceWater, resistanceEarth;
    // [HideInInspector]
    private float vulnerabilityFire, vulnerabilityAir, vulnerabilityWater, vulnerabilityEarth;

    public GameObject attackedObject;
    public EnemyCharacter attackedCharacter;
    private BarrierScroll attackedBarrier;
    public bool isWallAttack;
    public bool isWallHitted;
    private bool canAttackPlayerFromDistanceNow;
    private bool shouldAttackPlayerWhenHitBarrier;
    private bool shouldJumpForwardWhenHitBarrier;
    private float jumpDistanceWhenHitBarrierRelativeToBarrier;
    private bool shouldJumpForwardWhenHitOtherEnemy;
    private float jumpDistanceWhenHitOtherEnemyRelativeToEnemy;
    private float lastTimeWallAttacked;
    private bool shouldPerformSpawn = false;
    private bool shouldEnrage = false;
    private int enrageType;
    private bool gotHitAnimationTrigger = false;

    // Только для BigZombie
    [HideInInspector]
    public float lowHealth = 50; // Сколько процентов здоровья должно остаться, чтобы движение замедлилось
    private float lowHealthValue; // Сколько единиц здоровья должно остаться, чтобы движение замедлилось
    [HideInInspector]
    public float attackspeed_aura_modifier;
    private float hitpoints_aura_modifier;
    public GameObject KingAura1;
    public GameObject KingAura2;
    private float king_aura_timer;
    //[HideInInspector]
    public bool needAura1, needAura2, canShowAura;
    private EnemiesGenerator enemiesGenerator;
    private int totalAurasOnThisEnemy;

    public int gives_aura_id;

    public EnemyCustomsDropsPack enemyCustomsDropsPack = new EnemyCustomsDropsPack();

    public float currentHealth;
    private bool sendEvent50PercentHp = false;

    public float easyCoef;
    public bool disableDrop;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (LevelSettings.Current.wonFlag || (currentHealth < 0f && enemyType != EnemyType.demon_boss))
            {
                return;
            }
            float lastHealth = currentHealth;
            currentHealth = value;
            if (currentHealth <= health * 0.5f && !sendEvent50PercentHp)
            {
                sendEvent50PercentHp = true;
                Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.ENEMY_50_PERCENT_HEALTH, enemyType);
            }
            // Отображаем изменения здоровья
            float newScaleX = currentHealth * healthScaleRatio;
            if(healthBar.transform.parent.gameObject.activeSelf)
                healthBar.transform.localScale = new Vector3(Mathf.Clamp(newScaleX, 0, 100), healthBar.transform.localScale.y, 1);
            else if(healthBar2 != null)
                healthBar2.transform.localScale = new Vector3(Mathf.Clamp(newScaleX, 0, 100), healthBar2.transform.localScale.y, 1);

            if (lastHealth > lowHealthValue && currentHealth <= lowHealthValue && currentHealth > 0.0f)
            {
                OnLowHealth();
            }

            // Проверяем текущий уровень здоровья
            if (currentHealth <= 0f)
            {
                animator.enabled = true;
                Death();
            }
            
        }
    }

    public Animator animator;
    private List<int> animatorParametersCached;
    private Dictionary<int, string> animationClipNamesCached;
    internal EnemyMover enemyMover;

    private LevelSettings levelSettings;

    private float attackTimer, attackTimerDef, attackAnimLength;

    [HideInInspector]
    public AnimationPropertiesCach.AnimProperty moveType;
    private bool moveTypeInited = false;

    public float invunarableDistance = 9.0f;

    float startHealth = 0;

    public SkinnedMeshRenderer meshRenderer;
    public bool isVisible;
    float timerIsVisible = 0;
    Vector3 curPos;

    public float minActionX;
    public float maxActionX;

    #endregion

    #region PROPERTIES
    private static ShaderWithMaterialPropertiesData deadEnemyMaterialPropData;
    private static ShaderWithMaterialPropertiesData GetDeadEnemyMaterialData
    {
        get
        {
            if (deadEnemyMaterialPropData == null)
            {
                deadEnemyMaterialPropData = Resources.Load<ShaderWithMaterialPropertiesData>(DEAD_ENEMY_MATERIAL_DATA_PATH);
            }
            return deadEnemyMaterialPropData;
        }
    }

    private SpellEffects spellEffects;
    public SpellEffects SpellEffects
    {
        get
        {
            if (spellEffects == null)
            {
                spellEffects = GetComponent<SpellEffects>();
            }
            return spellEffects;
        }
    }

    private EnemySoundsController enemySoundControllerCach;
    public EnemySoundsController getEnemySoundController
    {
        get
        {
            if (enemySoundControllerCach == null)
            {
                enemySoundControllerCach = GetComponent<EnemySoundsController>();
            }
            return enemySoundControllerCach;
        }
    }

    public bool IsOnGameField
    {
        get
        {
            return transform.position.x < invunarableDistance;
        }
    }

    public int AttackedCharacterID { get { return attackedCharacter == null ? 0 : attackedCharacter.GetInstanceID(); } }
    [HideInInspector]
    public bool canBeAutoAttacked = true;
    #endregion

    private void Start()
    {
        if(_mesh != null)
            meshRenderer = _mesh.GetComponent<SkinnedMeshRenderer>();
        enemyMover = GetComponent<EnemyMover>();
        if (animator == null)
            animator = GetComponent<Animator>();

#if LEVEL_EDITOR
        if (SceneManager.GetActiveScene().name == "LevelEditor")
            return;
#endif

        if (friendly)
        {
            transform.rotation = Quaternion.Euler(0f, 120f, 0f);
        }
        else
        {
            EnemiesGenerator.Instance.listObjs.Add(gameObject);
        }


        KingAura1 = transform.Find("Aura1").gameObject;
        KingAura2 = transform.Find("Aura2").gameObject;

        SetAuraModifier(gives_aura_id);
        if (gives_aura_id < 1)
        {
            MakeAurasSmaller();
        }

        animatorParametersCached = new List<int>();
        animationClipNamesCached = new Dictionary<int, string>();
        if (animator != null)
        {
            for (int i = 0; i < animator.parameters.Length; i++)
                animatorParametersCached.Add(animator.parameters[i].nameHash);
        }

        enemyMover.Init(this);
        SpellEffects.Init(this);

        if (!isSummoned)
        {
            currentActionState = EnemyActionState.move;
            currentMovementType = EnemyMovementType.walk;
        }

        if (enemyType == EnemyType.zombie_brain || enemyType == EnemyType.skeleton_tom || 
            (enemyType == EnemyType.skeleton_swordsman || enemyType == EnemyType.skeleton_swordsman_big))
        {
            KingAura1.SetActive(false);
            KingAura2.SetActive(false);
            this.CallActionAfterDelayWithCoroutine(2.5f, InvokeHideSingleAura);
        }
        else
        {
            canShowAura = true;
        }

        if (enemyType.IsJumpingGhoul())
            SetupJumpForwardWhenHitBarrier(true, -1.0f);
        if (enemyType == EnemyType.ghoul_scavenger)
            SetupJumpForwardWhenHitOtherEnemy(true, -2.5f);

        enemiesGenerator = EnemiesGenerator.Instance;
        if (null != attackAnimClip)
        {
            attackAnimLength = attackAnimClip.length;
        }

        // Вычисляем соотношение масштаба бара здоровья по x и его здоровья
        if(healthBar.transform.parent.gameObject.activeSelf)
            scaleHealthBar = healthBar.transform.localScale.x;
        else if(healthBar2 != null)
            scaleHealthBar = healthBar2.transform.localScale.x;
        if (health == 0)
        {
            health = 100;
        }
        healthScaleRatio = scaleHealthBar / health;
        CurrentHealth = health;
        lowHealthValue = health * (lowHealth / 100);

        // немного криво, но не хочу задевать префабы
        healthConatiner = healthBar.transform.parent.gameObject;
        if(healthBar2 != null)
            healthConatiner = healthBar2.transform.parent.gameObject;

        healthConatinerStartLocalPosition = healthConatiner.transform.localPosition;

        forceHideHealthBar();

        // Вычисляем выпадет монета или нет
        getCoin = Random.Range(0, 100) < coinChance;

        // Вычисляем выпадет сундук или нет
        if (enemyCustomsDropsPack != null && enemyCustomsDropsPack.casket_drops != null && enemyCustomsDropsPack.casket_drops.Count != 0)
        {
            CasketDrop tempDrop = enemiesGenerator.CalculatedDrop(enemyCustomsDropsPack.casket_drops);
            casketChance = tempDrop.chance_id;
            casketContent = tempDrop.content_id;
        }
        getCasket = Random.Range(0, 100) < casketChance;

        SetupLockForCharacter();

        levelSettings = LevelSettings.Current;

        easyCoef = levelSettings.easyCoef;
        burnedKing = GetComponent<BurnedKing>();

        if (enemyType == EnemyType.zombie_boss && mainscript.CurrentLvl != 15)
        {
            gold /= 3;
        }
        startHealth = health;
        if (healthBar2 != null)
            healthBar2.transform.parent.gameObject.SetActive(false);
       
        if (enemyType == EnemyType.zombie_boss && mainscript.CurrentLvl == 15)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(true);
        }
        if (enemyType == EnemyType.zombie_boss && mainscript.CurrentLvl == 1)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(false);
        }
        if (enemyType == EnemyType.skeleton_king && mainscript.CurrentLvl == 30)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(true);
        }
        if (enemyType == EnemyType.burned_king && mainscript.CurrentLvl == 45)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(true);
        }
        if (enemyType == EnemyType.ghoul_boss && mainscript.CurrentLvl == 70)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(true);
        }
        if (enemyType == EnemyType.demon_boss && mainscript.CurrentLvl == 95)
        {
            healthBar.transform.parent.gameObject.SetActive(false);
            if (healthBar2 != null)
                healthBar2.transform.parent.gameObject.SetActive(true);
        }

        if (smallCasket == null)
        {
            var casketLoad = Resources.LoadAsync("Bonuses/casket_small");
            casketLoad.completed += (AsyncOperation obj) =>
            {
                smallCasket = casketLoad.asset as GameObject;
            };
        }
    }

    public void InitAsSummoned(float moveAfter, bool useSpawnState = false)
    {
        isSummoned = true;

        if (useSpawnState)
            SetShouldPerformSpawn(true);
        else
            SetActionState(EnemyActionState.move);

        currentMovementType = EnemyMovementType.stop;
        Invoke("InvokeSummonedMove", moveAfter);
    }

    private void InvokeSummonedMove()
    {
        SetShouldPerformSpawn(false);
        SetMovementType(EnemyMovementType.walk);
    }

    public void SetTransparent(bool value)
    {
        
    }

    private void SetupLockForCharacter()
    {
        switch (enemyType)
        {
            case EnemyType.skeleton_tom:
            case EnemyType.zombie_brain:
                getCoin = false;
                getCasket = false;
                break;
        }
    }


    public void DisableEnemy()
    {
        enemyMover.UnregisterFromUpdate();
        animator.StopAnimator();
        animator.enabled = false;
    }

    private bool CanChangeActionStateTo(EnemyActionState newState)
    {
        if (currentActionState == EnemyActionState.dead)
            return false;
        if (currentActionState == newState)
            return false;

        if (currentActionState == EnemyActionState.gotHit && newState == EnemyActionState.attack)
            return false;
        if (currentActionState == EnemyActionState.jump && newState == EnemyActionState.attack)
            return false;
        if (currentActionState == EnemyActionState.summon && newState == EnemyActionState.attack)
            return false;
        if (currentActionState == EnemyActionState.shoot && newState == EnemyActionState.attack)
            return false;
        if (currentActionState == EnemyActionState.enrage && newState == EnemyActionState.attack)
            return false;
        if (currentActionState == EnemyActionState.enrage2 && newState == EnemyActionState.attack)
            return false;

        if (currentActionState == EnemyActionState.enrage && newState == EnemyActionState.enrage2)
            return false;
        if (currentActionState == EnemyActionState.enrage2 && newState == EnemyActionState.enrage)
            return false;

        if (currentActionState == EnemyActionState.deadBeforeSpawn && newState != EnemyActionState.spawn)
            return false;
        if (currentActionState == EnemyActionState.spawn && newState != EnemyActionState.move && newState != EnemyActionState.dead)
            return false;

        return true;
    }

    private bool SetActionState(EnemyActionState newState)
    {
        if (!CanChangeActionStateTo(newState))
            return false;

        OnActionStateExit(currentActionState);
        currentActionState = newState;

        return true;
    }

    private void ArcherKnockBack()
    {
        enemyMover.positionOnPlane = new Vector2(enemyMover.positionOnPlane.x + 0.2f, enemyMover.positionOnPlane.y);
        currentActionState = EnemyActionState.move;
    }

    private void OnActionStateExit(EnemyActionState state)
    {
        if (state == EnemyActionState.attack)
        {
            attackedObject = null;
            attackedCharacter = null;
            attackedBarrier = null;
            isWallAttack = false;
        }

        if (state == EnemyActionState.jump)
        {
            enemyMover.InterruptJump();
        }
    }

    public void SetMovementType(EnemyMovementType newMovementType)
    {
        currentMovementType = newMovementType;
    }

    public void SetPosition(Vector3 newPosition)
    {
        enemyMover.SetPosition(newPosition);
    }

    public void SetTargetPosX(float posX)
    {
        enemyMover.SetTargetPosX(posX);
    }

    public void SetShouldPerformSpawn(bool newShouldPerformSpawn)
    {
        shouldPerformSpawn = newShouldPerformSpawn;
    }

    public void SetShouldEnrage(bool newShouldEnrage, int newEnrageType = 0)
    {
        shouldEnrage = newShouldEnrage;
        enrageType = newEnrageType;
    }

    public void SetMovementCollisionsEnabled(bool newMovementCollisionsEnabled)
    {
        enemyMover.SetMovementCollisionsEnabled(newMovementCollisionsEnabled);
    }

    private void InvokeHideSingleAura()
    {
        if (IsDead)
        {
            return;
        }
        canShowAura = true;
        KingAura1.SetActive(true);
        KingAura2.SetActive(true);
    }

    public void SetAuraModifier(int aura_id)
    {
        if (IsDead)
            return;

        if (aura_id == 1)
        {
            needAura2 = true;
            attackspeed_aura_modifier = 0.2f;
            enemyMover.movespeed_aura_modifier = 0.2f;
        }
        if (aura_id == 2)
        {
            needAura1 = true;
            hitpoints_aura_modifier = 20f;
        }
        if (aura_id == 3)
        {
            needAura1 = true;
            needAura2 = true;
            attackspeed_aura_modifier = 0.2f;
            enemyMover.movespeed_aura_modifier = 0.2f;
            hitpoints_aura_modifier = 20f;
        }
        if (aura_id == 0)
        {
            attackspeed_aura_modifier = 0f;
            enemyMover.movespeed_aura_modifier = 0f;
            hitpoints_aura_modifier = 0f;
        }
    }

    private float hitPointRegenerationTime = 0f;
    private void HitpointsRegeneration()
    {
        if (hitPointRegenerationTime == 0f)
        {
            hitPointRegenerationTime = Time.time;
        }
        if (hitPointRegenerationTime + 1f < Time.time)
        {
            hitPointRegenerationTime = Time.time;
            if (IsDead)
            {
                return;
            }
            CurrentHealth += hitpoints_aura_modifier;
            if (CurrentHealth > health)
            {
                CurrentHealth = health;
            }
        }
    }
    DamageType damageType;
   [SerializeField]
    private GameObject tempAttackedObj;
    [SerializeField]
    GameObject _mesh;

    // атака врага
    public void Damage()
    {
        // Атакуемый объект еще на месте или продолжаем атаковать?
        if (attackedObject != null)
        {
            //if(Vector3.Distance(transform.position, attackedObject.transform.position))
            tempAttackedObj = attackedObject;
            getEnemySoundController.PlayAttackSFX();


            if (attackedCharacter != null)
            {
                attackedCharacter.Hit(damage, !attackedCharacter.spellEffects.FreezedOrParalysed, DamageType.NONE);
            }
            else
            {
                if (attackedObject.CompareTag(GameConstants.WALL_TAG) ||
                attackedObject.CompareTag(GameConstants.PLAYER_TAG))
                {
                    if (IsSpecMove && specDamage != 0)
                    {
                        PlayerController.Instance.CurrentHealth -= specDamage;
                    }
                    else
                    {
                        PlayerController.Instance.CurrentHealth -= damage;
                    }
                }
                else
                {
                    if (attackedBarrier != null)
                    {
                        if (IsSpecMove && specDamage != 0)
                        {
                            attackedBarrier.CurrentHealth -= specDamage;
                        }
                        else
                        {
                            attackedBarrier.CurrentHealth -= damage;
                        }
                    }
                }

                if (IsSpecMove)
                {
                    SetMovementType(EnemyMovementType.walk);
                }
            }
        }
    }

    private bool Attack(GameObject objectToAttack)
    {
        EnemyCharacter characterToAttack = objectToAttack.GetComponent<EnemyCharacter>();
        if (characterToAttack != null && characterToAttack.IsDead)
            return false;

        if (SetActionState(EnemyActionState.attack))
        {
            isWallAttack = false;
            attackedObject = objectToAttack;
            attackedCharacter = characterToAttack;

            if (attackedCharacter == null)
            {
                if (attackedObject.CompareTag(GameConstants.WALL_TAG) ||
                    attackedObject.CompareTag(GameConstants.PLAYER_TAG))
                {
                    isWallAttack = true;
                }
                else if (attackedObject.CompareTag(GameConstants.BARRIER_TAG))
                {
                    attackedBarrier = attackedObject.GetComponent<BarrierScroll>();
                }
            }

            return true;
        }

        return false;
    }

    public void SetCanAttackPlayerFromDistanceNow(bool newCanAttackPlayerFromDistanceNow)
    {
        canAttackPlayerFromDistanceNow = newCanAttackPlayerFromDistanceNow;
    }

    public void SetShouldAttackPlayerWhenHitBarrier(bool newShouldAttackPlayerWhenHitBarrier)
    {
        shouldAttackPlayerWhenHitBarrier = newShouldAttackPlayerWhenHitBarrier;
    }

    public void Shoot()
    {
        SetActionState(EnemyActionState.shoot);
    }

    public void OnShootAnimationFinished()
    {
        SetActionState(EnemyActionState.move);
    }

    public void Summon()
    {
        SetActionState(EnemyActionState.summon);
    }

    public void OnSummonAnimationFinished()
    {
        SetActionState(EnemyActionState.move);
    }

    public void SetupJumpForwardWhenHitBarrier(bool newShouldJumpForwardWhenHitBarrier, float newJumpDistanceWhenHitBarrierRelativeToBarrier = -1.0f)
    {
        shouldJumpForwardWhenHitBarrier = newShouldJumpForwardWhenHitBarrier;
        jumpDistanceWhenHitBarrierRelativeToBarrier = newJumpDistanceWhenHitBarrierRelativeToBarrier;
    }

    public void SetupJumpForwardWhenHitOtherEnemy(bool newShouldJumpForwardWhenHitOtherEnemy, float newJumpDistanceWhenHitOtherEnemyRelativeToEnemy = -1.0f)
    {
        shouldJumpForwardWhenHitOtherEnemy = newShouldJumpForwardWhenHitOtherEnemy;
        jumpDistanceWhenHitOtherEnemyRelativeToEnemy = newJumpDistanceWhenHitOtherEnemyRelativeToEnemy;
    }

    public void SceneJolting()
    {
    }

    // [HideInInspector]
    public BurnedKing burnedKing;

    bool jumpIsPreparing;
    Vector2 cachedJumpDelta;

    private bool CanJumpOnDelta(Vector2 delta)
    {
        return enemyMover.CanJumpOnDelta(delta);
    }

    public void Jump(Vector2 delta)
    {
        if (!CanJumpOnDelta(delta))
            return;

        if (SetActionState(EnemyActionState.jump))
        {
            jumpIsPreparing = true;
            cachedJumpDelta = delta;
        }
    }

    public void OnJumpAnimationStarted()
    {
        jumpIsPreparing = false;
        enemyMover.Jump(cachedJumpDelta);
        getEnemySoundController.PlayJumpSFX();
    } 

    public void ShiftEnemyToScreenBorder(float deltaX)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += deltaX;

        if (enemyMover != null)
            enemyMover.SetPosition(newPosition);
    }

    public void SpawnForSkeletonMage()
    {
    }

    public void SpawnForStrongSkeletonMage()
    {
    }

    public void SpawnForSkeletonKing()
    {
    }

    //[SerializeField]
    public List<GameObject> lowHealthDisableObjs, lowHealthEnableObjs = new List<GameObject>();
    private void OnLowHealth()
    {
        if (!isWallAttack && enemyType == EnemyType.zombie_big)
        {
            SetMovementType(EnemyMovementType.crawl);
        }
        if (enemyType == EnemyType.skeleton_swordsman || enemyType == EnemyType.skeleton_swordsman_big)
        {
            for (int i = 0; i < lowHealthDisableObjs.Count; i++)
            {
                lowHealthDisableObjs[i].SetActive(false);
            }
            for (int i = 0; i < lowHealthEnableObjs.Count; i++)
            {
                lowHealthEnableObjs[i].SetActive(true);
            }
            SetMovementType(EnemyMovementType.specMove);
        }
        if (enemyType == EnemyType.demon_imp)
        {
            SetMovementType(EnemyMovementType.run);
        }
    }

    private void ShowNumAfterDeath()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 1.5f, 0f);
        newPosition = Helpers.getMainCamera.WorldToScreenPoint(newPosition);
        StartCoroutine(SpawnEnemyGold(newPosition, 0));
    }

    private IEnumerator SpawnEnemyGold(Vector3 spawnPosition, float time)
    {
        if (time > 0)
        {
            yield return new WaitForSeconds(time);
        }
        UIControl.SpawnEnemyGoldText(spawnPosition, gold.ToString());
        UIMultiKill.golds.Add(gold);
    }

    private float speedMultiplierByWaterHit = 1.0f;
    private IEnumerator SlowForTimeByWaterHit(float time)
    {
        yield return new WaitForSeconds(1.2f);
        speedMultiplierByWaterHit = 0.4f;
        yield return new WaitForSeconds(time-1.2f);
        speedMultiplierByWaterHit = 1;
    }

    public void Death(bool countAchivements = true)
    {
        if (friendly)
        {
            EnemiesGenerator.Instance.OnFriendlyCharacterDestroyed(this);
            Destroy(gameObject);
            return;
        }

        if (IsDead)
            return;

        if (enemyType == EnemyType.demon_boss)
        {
            DemonBoss demonBoss = gameObject.GetComponent<DemonBoss>();
            if (demonBoss != null && !demonBoss.WasDead)
            {
                SetActionState(EnemyActionState.deadBeforeSpawn);
                demonBoss.OnDiedFirstTime();
                return;
            }
        }

        var replicaPosition = new ReplicaAnchorVectors(new Vector2(1f,1f),
            new Vector2(1f,1f), new Vector2(1f,1f) );
        
        FadeoutAuraParticles();
        if (mainscript.CurrentLvl == 2 && enemyType == EnemyType.zombie_fire)
        {
            AnalyticsController.Instance.LogMyEvent("KillBossLevel2");
            BossDeath();
        }
        if (mainscript.CurrentLvl == 15 && enemyType == EnemyType.zombie_boss)
        {
            BossDeath();

            ReplicaUI.ShowReplica(EReplicaID.Level15_Lose_Boss, UIControl.Current.transform);

            getEnemySoundController.PlayDeathBoss();
            SoundController.Instanse.FadeOutCurrentMusic();
        }
        if (mainscript.CurrentLvl == 30 && enemyType == EnemyType.skeleton_king)
        {
            BossDeath();

            ReplicaUI.ShowReplica(EReplicaID.Level_kill_boss_skelet, UIControl.Current.transform);

            getEnemySoundController.PlayDeathBoss();
            SoundController.Instanse.FadeOutCurrentMusic();
        }
        if (mainscript.CurrentLvl == 45 && enemyType == EnemyType.burned_king)
        {
            ReplicaUI.ShowReplica(EReplicaID.Level_kill_boss_skelet,UIControl.Current.transform);
            
            getEnemySoundController.PlayDeathBoss();
            SoundController.Instanse.FadeOutCurrentMusic();
        }
        if (mainscript.CurrentLvl == 70 && enemyType == EnemyType.ghoul_boss)
        {
            BossDeath();

            ReplicaUI.ShowReplica(EReplicaID.Level_kill_boss_ghul,UIControl.Current.transform);
            getEnemySoundController.PlayDeathBoss();
            SoundController.Instanse.FadeOutCurrentMusic();
        }
        if(mainscript.CurrentLvl == 95 && enemyType == EnemyType.demon_boss)
        {
            GetComponent<DemonBoss>().Replica();
            getEnemySoundController.PlayDeathBoss();
            SoundController.Instanse.FadeOutCurrentMusic();
        }
     
        EnemiesGenerator.Instance.listObjs.Remove(gameObject);

        if (enemiesGenerator != null && enemiesGenerator.multyMessage != null)
            enemiesGenerator.multyMessage.IncKills();

        StopAllCoroutines();
        enemyMover.StopAllCoroutines();
        enemyMover.enabled = false;
        enemyMover.UnregisterFromUpdate();
        if (transform.position.y > 2.86f)
            transform.position = new Vector3(transform.position.x, 2.56f, transform.position.z);

        if (enemyType != EnemyType.zombie_brain)
        {
            if(mainscript.CurrentLvl != 1)
                EnemiesGenerator.Instance.progressBar.MinusHealth(startHealth);
            else
            {
                if(enemyType != EnemyType.zombie_boss)
                    EnemiesGenerator.Instance.progressBar.MinusHealth(startHealth);
            }
        }

        SetActionState(EnemyActionState.dead);
        enemyMover.enabled = false;

        if (countAchivements)
        {
            GetAchieve(); // Даем ачивку за убийство
        }

        ShotController.Current.countKillEnemy++;
        // Отключаем тень и бар здоровья
        shadow.SetActive(false);

        // Выпадение монеты
        if (getCoin)
        {
            float turnAngle = -180;
            if (transform.position.x > maxActionX)
            {
                turnAngle = 0f;
            }
            Vector3 ofsetCoin=Vector3.zero;
            if (transform.position.y > 1.5f)
            {
                ofsetCoin = new Vector3(0,-.5f, 0);
            }

            if (transform.position.y <= -1.5f)
            {
                ofsetCoin = new Vector3(0,.5f, 0);
            }

            Vector3 coinPosition = transform.position + ofsetCoin;
            coinPosition.z = -0.5f;
            EnemiesGenerator.SpawnCoin(coinPosition, Quaternion.Euler(new Vector3(0, turnAngle, 0)));
        }

        // Выпадение сундука, камней, птиц и прочей шушеры
        SpawnDropOnDeath();
        // Добавление золота
        levelSettings.coinsValue.text = (int.Parse(levelSettings.coinsValue.text) + gold).ToString();
        enemyMover.enabled = false;

        healthBar.transform.parent.gameObject.SetActive(false);
        if(healthBar2 != null)
            healthBar2.transform.parent.gameObject.SetActive(false);
        StartCoroutine(InvokeDestroyAfterDelay());
        if (friendly)
        {
            EnemiesGenerator.Instance.OnFriendlyCharacterDestroyed(this);
        }
        else
        {
            EnemiesGenerator.Instance.RemoveEnemy(GetInstanceID());
            Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.ENEMY_DEAD, enemyType);
        }

        if (enemyType == EnemyType.ghoul_boss || enemyType == EnemyType.burned_king)
            getEnemySoundController.PlayDeathBoss();
        else
            getEnemySoundController.PlayDeathSFX();

        gameObject.tag = DEAD_ENEMY_TAG;
        if (burnedKing != null)
        {
            burnedKing.onDeath();
        }
    }

    private void GetAchieve()
    {
        if (enemyType == EnemyType.zombie_walk || enemyType == EnemyType.zombie_murderer || enemyType == EnemyType.zombie_fatty ||
            enemyType == EnemyType.zombie_fire || enemyType == EnemyType.zombie_snapper)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.KillZombie, 1);

        if (enemyType == EnemyType.skeleton_mage || enemyType == EnemyType.skeleton_mage2 || enemyType == EnemyType.skeleton_strong_mage ||
            enemyType == EnemyType.skeleton_strong_mage2)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.AuraCleaner, 1);

        if (enemyType == EnemyType.skeleton_grunt || enemyType == EnemyType.skeleton_swordsman || enemyType == EnemyType.skeleton_archer ||
            enemyType == EnemyType.skeleton_archer_big || enemyType == EnemyType.skeleton_tom)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.KillAllSkeletons, 1);

        if (enemyType == EnemyType.ghoul || enemyType == EnemyType.ghoul_festering || enemyType == EnemyType.ghoul_grotesque ||
            enemyType == EnemyType.ghoul_scavenger)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.GreamRiper, 1);

        if (enemyType == EnemyType.zombie_boss && mainscript.CurrentLvl == 15)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Boss_15, 1);

        if (enemyType == EnemyType.skeleton_king && mainscript.CurrentLvl == 30)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Boss_30, 1);

        if (enemyType == EnemyType.burned_king && mainscript.CurrentLvl == 45)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Boss_45, 1);

        if (enemyType == EnemyType.ghoul_boss && mainscript.CurrentLvl == 70)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Boss_70, 1);

        if (enemyType == EnemyType.demon_boss && mainscript.CurrentLvl == 95)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Boss_95, 1);


        if (damageType == DamageType.FIRE)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Pyromaniac, 1);

        if (damageType == DamageType.AIR)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.TeslaMaster, 1);

        if (damageType == DamageType.EARTH)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.RollingStone, 1);

        if (damageType == DamageType.WATER)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.IceStrike, 1);

        Achievement.AchievementController.Save();

    }

    private void FadeoutAuraParticles()
    {
        if (KingAura1 != null)
        {
            KingAura1.DisableParticlesEmission();
        }
        if (KingAura2 != null)
        {
            KingAura2.DisableParticlesEmission();
        }
    }

    private void SpawnDropOnDeath()
    {
        if (enemyType == EnemyType.skeleton_tom || enemyType == EnemyType.zombie_brain || disableDrop)
            return;
        if (getCasket)
        {
            Vector3 ofsetYup = new Vector3(0,.5f, 0);
            Vector3 ofsetYdown = new Vector3(0,-.5f, 0);
            float xShift = -0.5f;
            if (transform.position.x < maxActionX)
            {
                xShift = 0;
            }

            if (transform.position.x < PlayerController.Instance.transform.position.x + 1.5)
            {
                xShift = 1f;
            }

            if (smallCasket != null)
            {
                Vector3 casketPos = transform.position + new Vector3(xShift, 0f, 0f);
                casketPos.z = -0.5f;
                GameObject casketObj = Instantiate(smallCasket, casketPos, Quaternion.identity) as GameObject;

                if (transform.position.y > 1.5f)
                    casketObj.transform.position += ofsetYdown;
                if (transform.position.y <= -1.5f)
                    casketObj.transform.position += ofsetYup;

                casketObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                EnemiesGenerator.Instance.dropsOnLevel.Add(casketObj);
                casketObj.GetComponent<Casket>().SetCasketContent(casketContent);
                if (casketObj.transform.position.y < -1.5f)
                    casketObj.transform.position += new Vector3(0, .4f, 0);
            }
        }
        if (enemyCustomsDropsPack != null)
        {
            //Debug.Log("TrySpawnGem");
            if(enemyType == EnemyType.zombie_boss ||
                enemyType == EnemyType.demon_boss ||
                enemyType == EnemyType.ghoul_boss ||
                enemyType == EnemyType.burned_king ||
                enemyType == EnemyType.skeleton_king)
            {
                Debug.Log($"GEM BOSS SPAWN: enemyType: {enemyType}, -- {SaveManager.GameProgress.Current.gemBoss11}");
                if (enemyType == EnemyType.zombie_boss && !SaveManager.GameProgress.Current.gemBoss11 && mainscript.CurrentLvl == 15)
                {
                    EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops, true);
                    SaveManager.GameProgress.Current.gemBoss11 = true;
                }
                if (enemyType == EnemyType.demon_boss && !SaveManager.GameProgress.Current.gemBoss22 && mainscript.CurrentLvl == 95)
                {
                    EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops, true);
                    SaveManager.GameProgress.Current.gemBoss22 = true;
                }
                if (enemyType == EnemyType.ghoul_boss && !SaveManager.GameProgress.Current.gemBoss33 && mainscript.CurrentLvl == 70)
                {
                    EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops, true);
                    SaveManager.GameProgress.Current.gemBoss33 = true;
                    GemCollectable.gemCollectableInstance.GetComponent<GemCollectable>().waittime = 5;
                }
                if (enemyType == EnemyType.burned_king && !SaveManager.GameProgress.Current.gemBoss44 && mainscript.CurrentLvl == 45)
                {
                    EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops, true);
                    SaveManager.GameProgress.Current.gemBoss44 = true;
                    GemCollectable.gemCollectableInstance.GetComponent<GemCollectable>().waittime = 5;
                }
                if (enemyType == EnemyType.skeleton_king && !SaveManager.GameProgress.Current.gemBoss55 && mainscript.CurrentLvl == 30)
                {
                    EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops, true);
                    SaveManager.GameProgress.Current.gemBoss55 = true; 
                    GemCollectable.gemCollectableInstance.GetComponent<GemCollectable>().waittime = 5;
                }
            }
            else
                EnemiesGenerator.Instance.TrySpawnGem(transform.position, enemyCustomsDropsPack.gem_drops);
        }
        else
        {
            Debug.Log("TrySpawnGem 2");
            EnemiesGenerator.Instance.TrySpawnGem(transform.position);
        }
        if (enemyCustomsDropsPack != null && enemyCustomsDropsPack.customBirdParams.chanceSpawn != 0)
        {
            BonusBird.Instance.currentParams = BonusBird.Instance.CreateParamsFrom(enemyCustomsDropsPack.customBirdParams);
            BonusBird.Instance.Restart();
        }
    }

    private void BossDeath()
    {
        var enemies = GameObject.FindObjectsOfType<EnemyCharacter>();
        if (enemies != null)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.enemyType == this.enemyType)
                {
                    continue;
                }
                enemy.explosionEffect();
                enemy.Death();
            }
        }
    }

    public void explosionEffect()
    {
        Instantiate(enemyExplosion, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    private bool fadeOutAnimatedPlayed;
    private IEnumerator InvokeDestroyAfterDelay()
    {
        if (enemyType == EnemyType.demon_boss)
        {
            yield return new WaitForSeconds(3.0f);
        }
        else if (enemyType == EnemyType.ghoul_grotesque)
        {
            yield return new WaitForSeconds(1.7f);
        }
        else
        {
            yield return new WaitForSeconds(1.7f);
        }

        SkinnedMeshRenderer[] skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        SetSortingLayerForAll(skinnedMeshRenderers, "Elements");
        SetSortingLayerForAll(meshRenderers, "Elements");

        GetDeadEnemyMaterialData.ApplyProperties(skinnedMeshRenderers);
        GetDeadEnemyMaterialData.ApplyProperties(meshRenderers);

        float timer = 0;
        float animProgress;
        int shaderPropertyID = Shader.PropertyToID("_AlphaMultiplier");
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        bool swapnGold = false;
        float spawnGoldTime = DEAD_BODY_FADEOUT_TIME * 0.5f;

        while (timer < DEAD_BODY_FADEOUT_TIME)
        {
            timer += Time.deltaTime;
            animProgress = 1f - (timer / DEAD_BODY_FADEOUT_TIME);
            ChangePropertyForAllRenderers(skinnedMeshRenderers, propertyBlock, shaderPropertyID, animProgress);
            ChangePropertyForAllRenderers(meshRenderers, propertyBlock, shaderPropertyID, animProgress);

            if (timer >= spawnGoldTime && !swapnGold)
            {
                swapnGold = true;
                ShowNumAfterDeath();
            }
            yield return null;
        }
        fadeOutAnimatedPlayed = true;
        DestroyEnemy();
    }

    private void ChangePropertyForAllRenderers(Renderer[] renderers, MaterialPropertyBlock propertyBlock, int propertyID, float propertyValue)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetPropertyBlock(propertyBlock);
            propertyBlock.SetFloat(propertyID, propertyValue);
            renderers[i].SetPropertyBlock(propertyBlock);
        }
    }

    private void SetSortingLayerForAll(Renderer[] renderers, string layerName)
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].sortingLayerName = layerName;
        }
    }

    // включается в конце анимации смерти
    public void DestroyEnemy()
    {
        if (!fadeOutAnimatedPlayed)//Temporary solution to prevent disabling from animation, need to be removed
        {
            return;
        }
        Destroy(gameObject);
    }

    public void OnFriendlyMovedOtOfScreen()
    {
        Death();
    }

    public IEnumerator DeferredHit(float _damage, bool _anim, DamageType damageType, bool canInterruptAttack = true, float timer = 0.3f, float critOnlyInfo = 0)
    {
        yield return new WaitForSeconds(timer);
        Hit(_damage, _anim, damageType, canInterruptAttack, critOnlyInfo);
    }
    /// <summary>
    /// Персонаж принимает урон (величина урона, анимировать или нет получение урона)
    /// </summary>
    public void Hit(float _damage, bool _anim, DamageType damageType, bool canInterruptCurrentAction = true, float critOnlyInfo = 0, bool isSpell = false, bool delay = false) // 
    {
        if (IsDead || IsDeadBeforeSpawn)
            return;

        if (damageType == DamageType.WATER)
        {
            StartCoroutine(SlowForTimeByWaterHit(_slowDownTime));
        }
        this.damageType = damageType;
        //Debug.Log($"hit", gameObject);
        if(enemyType == EnemyType.ghoul_boss || enemyType == EnemyType.burned_king)
            getEnemySoundController.PlayDamageBoss();
        else
            getEnemySoundController.PlayDamageSFX();

        float calcDamage = (UIControl.Current.x2Power ? _damage * 2 : _damage);

        CalculateSpellDamageModifiers(ref calcDamage, damageType);
        //Debug.Log($"resistanceFire: {resistanceFire}");
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + 1.5f, 0f);
        newPosition = Helpers.getMainCamera.WorldToScreenPoint(newPosition);

        if (CurrentHealth <= (int)calcDamage)
        {
            UIControl.SpawnDamageView(newPosition,
                                      (int)(calcDamage * (critOnlyInfo <= 0 ? 1 : critOnlyInfo)),
                                      new DamageView.DamageViewData()
                                      {
                                          incomingDmgType = damageType,
                                          crit = critOnlyInfo,
                                          target = transform,
                                          isSpell = isSpell
                                      },
                                      true, delay);
        }
        else
        {
            var damageView = GetResistantAndVulnerability(damageType, critOnlyInfo);
            damageView.isSpell = isSpell;
            calcDamage -= calcDamage * damageView.percent;
            calcDamage *= critOnlyInfo <= 0 ? 1 : critOnlyInfo;
            UIControl.SpawnDamageView(newPosition, (int)calcDamage, damageView, delay: delay); 

            bool shouldChangeStateToGotHit = true;
            if (!canInterruptCurrentAction)
            {
                shouldChangeStateToGotHit = false;
            }
            if (!_anim)
            {
                shouldChangeStateToGotHit = false;
            }
            if (IsSpecMove)
            {
                shouldChangeStateToGotHit = false;
            }
            if (enemyType == EnemyType.skeleton_king ||
                enemyType == EnemyType.burned_king)
            {
                shouldChangeStateToGotHit = false;
            }

            if (enemyType == EnemyType.ghoul_boss ||
                enemyType == EnemyType.zombie_boss ||
                enemyType == EnemyType.demon_boss || 
                (mainscript.CurrentLvl == 2 && enemyType == EnemyType.zombie_fire) ||
                friendly)
            {
                if (countHitBoss >= 6)
                {
                    countHitBoss = 0;
                    shouldChangeStateToGotHit = true;
                }
                else
                {
                    countHitBoss++;
                    shouldChangeStateToGotHit = false;
                }
            }

            if (shouldChangeStateToGotHit)
            {
                SetActionState(EnemyActionState.gotHit);
                if (currentActionState == EnemyActionState.gotHit)
                    gotHitAnimationTrigger = true;
            }
        }

        CurrentHealth -= (int)calcDamage;
        AnimateHealthBar();

    }

    public void OnGetHitAnimationFinished()
    {
        SetActionState(EnemyActionState.move);
    }

    private void CalculateSpellDamageModifiers(ref float spellDamage, DamageType damageType)
    {
        //Debug.Log($"spellDamage before: {spellDamage}");
        if (BuffsLoader.Instance != null)
        {
            spellDamage += spellDamage * BuffsLoader.Instance.GetBuffValue(BuffType.spellDamage) / 100f;
        }
        //Debug.Log($"spellDamage: {spellDamage}, index: {(BuffsLoader.Instance.GetBuffValue(BuffType.spellDamage) / 100f)}");
        switch (damageType)
        {
            case DamageType.AIR:
                CalculateSpellDamageBySpellDamageType(ref spellDamage, vulnerabilityAir, resistanceAir, BuffType.electroDamage);
                break;

            case DamageType.EARTH:
                CalculateSpellDamageBySpellDamageType(ref spellDamage, vulnerabilityEarth, resistanceEarth, BuffType.earthDamage);
                break;

            case DamageType.FIRE:
                CalculateSpellDamageBySpellDamageType(ref spellDamage, vulnerabilityFire, resistanceFire, BuffType.fireDamage);
                break;

            case DamageType.WATER:
                CalculateSpellDamageBySpellDamageType(ref spellDamage, vulnerabilityWater / 100f, resistanceWater / 100f, BuffType.iceDamage);
                break;
        }
        //Debug.LogFormat("[{0}] FinalDamage: {1} {2}", gameObject.name, spellDamage, damageType);
    }

    private void CalculateSpellDamageBySpellDamageType(ref float spellDamage, float vunerability, float resistance, BuffType baffType)
    {
        if (BuffsLoader.Instance != null)
        {
            spellDamage += spellDamage * BuffsLoader.Instance.GetBuffValue(baffType);
            //Debug.Log($"spellDamage: {spellDamage}, BuffsLoader.Instance.GetBuffValue(baffType): {BuffsLoader.Instance.GetBuffValue(baffType)}, resistance: {resistance}, vunerability: {vunerability}");
        }
    }

    private void AutoChangeKingAuras()
    {
        if (KingAura1 != null)
        {
            if (needAura1 && needAura2)
            {
                if (king_aura_timer + 2f < Time.time || king_aura_timer == 0)
                {
                    king_aura_timer = Time.time;
                    if (KingAura1.activeSelf)
                    {
                        this.CallActionAfterDelayWithCoroutine(0.5f, InvokeDisable1);
                        KingAura2.SetActive(true);
                    }
                    else
                    {
                        KingAura1.SetActive(true);
                        this.CallActionAfterDelayWithCoroutine(0.5f, InvokeDisable2);
                    }
                }
            }
            else
            {
                if (needAura1)
                {
                    if (KingAura2.activeSelf)
                        KingAura2.SetActive(false);
                    if (KingAura1.activeSelf != (_mesh != null ? _mesh.activeSelf : true))
                        KingAura1.SetActive(_mesh != null ? _mesh.activeSelf : true);
                }
                else
                {
                    if (needAura2)
                    {
                        if (KingAura2.activeSelf != (_mesh != null ? _mesh.activeSelf : true))
                            KingAura2.SetActive(_mesh != null ? _mesh.activeSelf : true);
                        if (KingAura1.activeSelf)
                            KingAura1.SetActive(false);
                    }
                    else
                    {
                        if (KingAura2.activeSelf)
                            KingAura2.SetActive(false);
                        if (KingAura1.activeSelf)
                            KingAura1.SetActive(false);
                    }
                }
            }
        }
    }

    private void InvokeDisable1()
    {
        KingAura1.SetActive(false);
    }

    private void InvokeDisable2()
    {
        KingAura2.SetActive(false);
    }

#if LEVEL_EDITOR || UNITY_EDITOR
    private bool sceneCheckCached = false;
    private bool isLevelEditorScene;
    private bool IsLevelEditorScene
    {
        get
        {
            if (!sceneCheckCached)
            {
                sceneCheckCached = true;
                isLevelEditorScene = SceneManager.GetActiveScene().name == "LevelEditor";
            }
            return isLevelEditorScene;
        }
    }
#endif


    private void Update()
    {
#if LEVEL_EDITOR
        if (SceneManager.GetActiveScene().name == "LevelEditor")
            return;
#endif

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            if (!IsDead)
            {
                Death();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && Input.GetKey(KeyCode.LeftShift))
        {
            if (!IsDead && enemyType == EnemyType.demon_boss)
            {
                Death();
            }
        }
#endif
        UpdateActionState();
        UpdateMovingSpeed();
        UpdateAnimator();

        if (healthBar2 != null )
        {
            healthConatiner.transform.localPosition = healthConatinerStartLocalPosition;
            healthConatiner.transform.position = new Vector3(
               healthConatiner.transform.position.x,
               Mathf.Min(healthConatiner.transform.position.y, 3.8f),
               healthConatiner.transform.position.z);
        }
    }

    private void UpdateActionState()
    {
        isWallHitted = false;

        GameObject targetObjectForAttack = null;
        if (enemyMover.HittedObj != null)
        {
            if (!friendly)
            {
                if (enemyMover.HittedObj.CompareTag(GameConstants.BARRIER_TAG))
                {
                    if (shouldAttackPlayerWhenHitBarrier)
                        targetObjectForAttack = PlayerController.Instance.WallObject;
                    else
                        targetObjectForAttack = enemyMover.HittedObj;
                }
                else if (enemyMover.HittedObj.CompareTag(GameConstants.WALL_TAG))
                {
                    targetObjectForAttack = PlayerController.Instance.WallObject;
                    isWallHitted = true;
                }
                else if (enemyMover.HittedObj.CompareTag(GameConstants.FRIENDLY_ENEMY_TAG))
                {
                    EnemyCharacter otherEnemyCharacter = enemyMover.HittedObj.GetComponent<EnemyCharacter>();
                    if (otherEnemyCharacter != null && otherEnemyCharacter.attackedCharacter == this)
                        targetObjectForAttack = enemyMover.HittedObj;
                }
            }
            else
            {
                if (enemyMover.HittedObj.CompareTag(GameConstants.ENEMY_TAG))
                {
                    EnemyMover otherEnemyMover = enemyMover.HittedObj.GetComponent<EnemyMover>();
                    if (otherEnemyMover != null && Mathf.Abs(enemyMover.positionOnPlane.y - otherEnemyMover.positionOnPlane.y) < enemyMover.movementRadius * 1.4f)
                        targetObjectForAttack = enemyMover.HittedObj;
                }
            }
        }

        if (canAttackPlayerFromDistanceNow)
            targetObjectForAttack = PlayerController.Instance.WallObject;

        if (IsJumping)
        {
            if (!jumpIsPreparing && !enemyMover.IsJumping())
                SetActionState(EnemyActionState.move);
        }

        if (IsAttacking)
        {
            bool shouldEndAttack = false;
            if (targetObjectForAttack == null)
            {
                shouldEndAttack = true;
            }
            if (attackedObject != targetObjectForAttack)
            {
                shouldEndAttack = true;
            }
            else if (attackedCharacter != null && attackedCharacter.CurrentHealth <= 0)
            {
                shouldEndAttack = true;
            }

            if (shouldEndAttack)
                SetActionState(EnemyActionState.move);
        }

        if (!IsAttacking && targetObjectForAttack != null)
        {
            if (Attack(targetObjectForAttack))
            {
                if (IsSpecMove)
                    Damage();
            }
        }

        if (!IsJumping && enemyMover.HittedObj != null && enemyMover.HittedObj.CompareTag(GameConstants.BARRIER_TAG) 
            && shouldJumpForwardWhenHitBarrier && BarrierScroll.CheckBarrierPositionForJump(enemyMover.HittedObj.transform.position))
        {
            float jumpDistance = enemyMover.HittedObj.transform.position.x - transform.position.x;
            jumpDistance += jumpDistanceWhenHitBarrierRelativeToBarrier;
            Jump(new Vector2(jumpDistance, 0.0f));
        }

        if (!IsJumping && enemyMover.HittedObj != null && enemyMover.HittedObj.CompareTag(GameConstants.ENEMY_TAG) && shouldJumpForwardWhenHitOtherEnemy)
        {
            float jumpDistance = enemyMover.HittedObj.transform.position.x - transform.position.x;
            jumpDistance += jumpDistanceWhenHitOtherEnemyRelativeToEnemy;
            Jump(new Vector2(jumpDistance, 0.0f));
        }

        if ((currentActionState == EnemyActionState.move || currentActionState == EnemyActionState.deadBeforeSpawn) && shouldPerformSpawn)
        {
            SetActionState(EnemyActionState.spawn);
        }

        if (currentActionState == EnemyActionState.spawn && !shouldPerformSpawn)
        {
            SetActionState(EnemyActionState.move);
        }

        if (currentActionState == EnemyActionState.move && shouldEnrage)
        {
            if (enrageType == 0)
                SetActionState(EnemyActionState.enrage);
            else
                SetActionState(EnemyActionState.enrage2);
        }

        if ((currentActionState == EnemyActionState.enrage || currentActionState == EnemyActionState.enrage2) && !shouldEnrage)
        {
            SetActionState(EnemyActionState.move);
        }
    }

    private void UpdateMovingSpeed()
    {
        if (enemyMover == null)
            return;

        float resultSpeedMultiplier = 1.0f;

        if (SpellEffects.FreezedOrParalysed)
            resultSpeedMultiplier = 0.0f;

        if (currentActionState != EnemyActionState.move)
            resultSpeedMultiplier = 0.0f;

        if (currentMovementType == EnemyMovementType.stop)
            resultSpeedMultiplier = 0.0f;

        resultSpeedMultiplier *= SpellEffects.GetSlowdownValue();
        resultSpeedMultiplier *= speedMultiplierByWaterHit;

        enemyMover.SetSpeedMultiplier(resultSpeedMultiplier);

        bool specSpeedEnabled = false;
        if (currentMovementType == EnemyMovementType.specMove || currentMovementType == EnemyMovementType.run)
            specSpeedEnabled = true;
        enemyMover.SetSpecSpeedEnabled(specSpeedEnabled);

        bool crawlSpeedEnabled = false;
        if (!specSpeedEnabled && currentMovementType == EnemyMovementType.crawl)
            crawlSpeedEnabled = true;
        enemyMover.SetCrawlSpeedEnabled(crawlSpeedEnabled);
    }

    private float lastTimeAttackAnimationEnabled = 0.0f;
    private int lastTriggetSet = -1;
    private Vector2 lastPositionDuringAnimatorUpdate1;
    private float lastPositionDuringAnimatorUpdateTime1;
    private Vector2 lastPositionDuringAnimatorUpdate2;
    private float lastPositionDuringAnimatorUpdateTime2;
    private void UpdateAnimator()
    {
        if (animator == null)
            return;

        float speed = 1.0f;
        AnimationPropertiesCach.AnimProperty newMoveType = AnimationPropertiesCach.instance.walkAnim;

        if (currentActionState == EnemyActionState.move)
        {
            if (currentMovementType == EnemyMovementType.stop || currentMovementType == EnemyMovementType.walk)
                newMoveType = AnimationPropertiesCach.instance.walkAnim;
            else if (currentMovementType == EnemyMovementType.specMove)
                newMoveType = AnimationPropertiesCach.instance.specialMoveAnim;
            else if (currentMovementType == EnemyMovementType.run)
                newMoveType = AnimationPropertiesCach.instance.runAnim;
            else if (currentMovementType == EnemyMovementType.crawl)
                newMoveType = AnimationPropertiesCach.instance.crawlAnim;
            else if (currentMovementType == EnemyMovementType.roll)
                newMoveType = AnimationPropertiesCach.instance.rollAnim;
        }
        else if (currentActionState == EnemyActionState.attack)
        {
            float attackAnimTime = Time.time - lastTimeAttackAnimationEnabled;
            float attackRate = Mathf.Max(attackSpeed, attackAnimLength);
            if (enemyType == EnemyType.ghoul_boss)
                attackRate += 1.5f;

            if (attackAnimTime <= attackAnimLength || attackAnimTime > attackRate)
            {
                newMoveType = AnimationPropertiesCach.instance.attackAnimation;
                speed = (1f + attackspeed_aura_modifier) * easyCoef;

                if (moveType != newMoveType)
                    lastTimeAttackAnimationEnabled = Time.time;
            }
        }
        else if (currentActionState == EnemyActionState.shoot)
        {
            newMoveType = AnimationPropertiesCach.instance.shootAnim;
        }
        else if (currentActionState == EnemyActionState.summon)
        {
            newMoveType = AnimationPropertiesCach.instance.summonAnim;
        }
        else if (currentActionState == EnemyActionState.gotHit)
        {
            newMoveType = AnimationPropertiesCach.instance.getHitAnim;
        }
        else if (currentActionState == EnemyActionState.jump)
        {
            if (cachedJumpDelta.x <= 0.0f)
                newMoveType = AnimationPropertiesCach.instance.jumpForwardAnimation;
            else
                newMoveType = AnimationPropertiesCach.instance.jumpBackwardAnimation;
        }
        else if (currentActionState == EnemyActionState.spawn)
        {
            newMoveType = AnimationPropertiesCach.instance.spawnAnim;
        }
        else if (currentActionState == EnemyActionState.enrage)
        {
            newMoveType = AnimationPropertiesCach.instance.enrageAnim;
        }
        else if (currentActionState == EnemyActionState.enrage2)
        {
            newMoveType = AnimationPropertiesCach.instance.enrageAnim2;
        }
        else if (currentActionState == EnemyActionState.dead || currentActionState == EnemyActionState.deadBeforeSpawn)
        {
            newMoveType = AnimationPropertiesCach.instance.deathAnim;
        }

        if (!animatorParametersCached.Contains(newMoveType))
            newMoveType = AnimationPropertiesCach.instance.walkAnim;

        if (newMoveType != moveType)
        {
            if (moveTypeInited)
            {
                animator.SetBool(moveType, false);
                animator.ResetTrigger(moveType);
            }
            else
            {
                moveTypeInited = true;
            }

            moveType = newMoveType;

            animator.SetBool(moveType, true);
        }

        bool shouldSetTrigger = true;
        string currentStateName;
        // TODO: Optimize. GetCurrentAnimatorClipInfo() > 1ms
        AnimationClip currentAnimationClip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        int currentAnimationClipHash = currentAnimationClip.GetHashCode();
        if (!animationClipNamesCached.ContainsKey(currentAnimationClipHash))
            animationClipNamesCached.Add(currentAnimationClipHash, currentAnimationClip.name);
        currentStateName = animationClipNamesCached[currentAnimationClipHash];

        // TODO: Refactor animatiors and remove this
        if (moveType == AnimationPropertiesCach.instance.walkAnim)
        {
            if (currentStateName.Contains("Walk") || currentStateName.Contains("walk"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.specialMoveAnim)
        {
            if (currentStateName.Contains("Spec") || currentStateName.Contains("spec"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.runAnim)
        {
            if (currentStateName.Contains("grunt"))
            {
                if (currentStateName.Contains("_run"))
                    shouldSetTrigger = false;
            }
            else
            {
                if (currentStateName.Contains("Run") || currentStateName.Contains("run"))
                    shouldSetTrigger = false;
            }
        }
        else if (moveType == AnimationPropertiesCach.instance.crawlAnim)
        {
            if (currentStateName.Contains("Crawl") || currentStateName.Contains("crawl"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.rollAnim)
        {
            if (currentStateName.Contains("Roll") || currentStateName.Contains("roll"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.attackAnimation)
        {
            if (currentStateName.Contains("Attack") || currentStateName.Contains("attack") ||
                currentStateName.Contains("Bite") || currentStateName.Contains("bite") ||
                currentStateName.Contains("blowup") || currentStateName.Contains("smash"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.shootAnim)
        {
            if (currentStateName.Contains("Shoot") || currentStateName.Contains("shoot") ||
                currentStateName.Contains("Throw") || currentStateName.Contains("throw"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.summonAnim)
        {
            if (currentStateName.Contains("Summer") || currentStateName.Contains("summer"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.getHitAnim)
        {
            if (currentStateName.Contains("Hit") || currentStateName.Contains("hit") ||
                currentStateName.Contains("Damage") || currentStateName.Contains("damage"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.jumpForwardAnimation || moveType == AnimationPropertiesCach.instance.jumpBackwardAnimation)
        {
            if (currentStateName.Contains("Jump") || currentStateName.Contains("jump"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.spawnAnim)
        {
            if (currentStateName.Contains("Spawn") || currentStateName.Contains("spawn"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.enrageAnim)
        {
            if (currentStateName.Contains("roar"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.enrageAnim2)
        {
            if (currentStateName.Contains("grabneat"))
                shouldSetTrigger = false;
        }
        else if (moveType == AnimationPropertiesCach.instance.deathAnim)
        {
            if (currentStateName.Contains("Death") || currentStateName.Contains("death") ||
                currentStateName.Contains("Die") || currentStateName.Contains("die"))
                shouldSetTrigger = false;
        }

        if (lastTriggetSet == moveType)
            shouldSetTrigger = false;

        if (!animator.IsInTransition(0))
            lastTriggetSet = -1;

        if (moveType == AnimationPropertiesCach.instance.getHitAnim)
        {
            if (gotHitAnimationTrigger)
            {
                shouldSetTrigger = true;
                gotHitAnimationTrigger = false;

                if (enemyType == EnemyType.skeleton_archer || enemyType == EnemyType.skeleton_archer_big)
                {
                    ArcherKnockBack();
                    StartCoroutine(SetMoveState(1));
                }
                StartCoroutine(SetMoveState(3));
            }
            else
            {
                shouldSetTrigger = false;
            }
        }

        if (shouldSetTrigger)
        {
            animator.SetTrigger(moveType);
            lastTriggetSet = moveType;
        }

        if (SpellEffects.FreezedOrParalysed)
            speed = 0.0f;
        speed *= SpellEffects.GetSlowdownValue();
        speed *= speedMultiplierByWaterHit;
        animator.speed = speed;

        float movementSpeed = 0.0f;
        Vector2 movementDelta = enemyMover.positionOnPlane - lastPositionDuringAnimatorUpdate2;
        movementDelta.y = movementDelta.y / 5.0f;
        float timeDelta = Time.time - lastPositionDuringAnimatorUpdateTime2;

        if (timeDelta > 0.0f)
            movementSpeed = movementDelta.magnitude / timeDelta;

        if (speed == 0.0f)
            movementSpeed = 1.0f;
        else
            movementSpeed /= speed;

        if (movementSpeed < 0.25f) // walk anim threshhold
            movementSpeed = 0.0f;

        animator.SetFloat("speed", movementSpeed);
        lastPositionDuringAnimatorUpdate2 = lastPositionDuringAnimatorUpdate1;
        lastPositionDuringAnimatorUpdate1 = enemyMover.positionOnPlane;
        lastPositionDuringAnimatorUpdateTime2 = lastPositionDuringAnimatorUpdateTime1;
        lastPositionDuringAnimatorUpdateTime1 = Time.time;
    }

    private IEnumerator SetMoveState(int delay)
    {
        yield return new WaitForSeconds(delay);
        if (currentActionState == EnemyActionState.gotHit)
        {
            currentActionState = EnemyActionState.move;
        }
    }

    private void FixedUpdate()
    {
#if LEVEL_EDITOR || UNITY_EDITOR
        if (IsLevelEditorScene)
            return;
#endif

        if (IsDead || IsDeadBeforeSpawn)
            return;

        HitpointsRegeneration();
        AutoChangeKingAuras();
    }

    public void SetupVulnerabilities(float vFire, float vAir, float vWater, float vEarth)
    {
        vulnerabilityFire = vFire / 100f;
        vulnerabilityAir = vAir / 100f;
        vulnerabilityWater = vWater / 100f;
        vulnerabilityEarth = vEarth / 100f;
    }

    public void SetupResistances(float rFire, float rAir, float rWater, float rEarth)
    {
        resistanceFire = rFire / 100f;
        resistanceAir = rAir / 100f;
        resistanceWater = rWater / 100f;
        resistanceEarth = rEarth / 100f;
    }

    private void forceHideHealthBar()
    {
        SpriteRenderer[] spriteRenderers = healthConatiner.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer _sp in spriteRenderers)
        {
            Color _color = _sp.color;
            _color.a = 0;
            _sp.color = _color;
        }
    }

    public void AnimateHealthBar()
    {
        SpriteRenderer[] spriteRenderers = healthConatiner.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (LeanTween.isTweening(spriteRenderer.gameObject))
            {
                LeanTween.cancel(spriteRenderer.gameObject);
            }
            Color _color = spriteRenderer.color;
            _color.a = 1;
            spriteRenderer.color = _color;
            LeanTween.alpha(spriteRenderer.gameObject, 0, 1).setDelay(0.5f);
        }
    }

    private void MakeAurasSmaller()
    {
        KingAura1.transform.localScale *= 0.5f;
        KingAura2.transform.localScale *= 0.5f;
    }

    private DamageView.DamageViewData GetResistantAndVulnerability(DamageType damageGot, float critInfo)
    {
        DamageView.DamageViewData to_return = new DamageView.DamageViewData();
        to_return.crit = critInfo;

        if (vulnerabilityFire != 0 && damageGot == DamageType.FIRE)
        {
            to_return.percent = vulnerabilityFire;
            to_return.vulnarable = DamageType.FIRE;
        }
        if (vulnerabilityAir != 0 && damageGot == DamageType.AIR)
        {
            to_return.percent = vulnerabilityAir;
            to_return.vulnarable = DamageType.AIR;
        }
        if (vulnerabilityEarth != 0 && damageGot == DamageType.EARTH)
        {
            to_return.percent = vulnerabilityEarth;
            to_return.vulnarable = DamageType.EARTH;
        }
        if (vulnerabilityWater != 0 && damageGot == DamageType.WATER)
        {
            to_return.percent = vulnerabilityWater;
            to_return.vulnarable = DamageType.WATER;
        }

        if (resistanceFire != 0 && damageGot == DamageType.FIRE)
        {
            to_return.percent = resistanceFire;
            to_return.resist = DamageType.FIRE;
        }
        if (resistanceAir != 0 && damageGot == DamageType.AIR)
        {
            to_return.percent = resistanceAir;
            to_return.resist = DamageType.AIR;
        }
        if (resistanceEarth != 0 && damageGot == DamageType.EARTH)
        {
            to_return.percent = resistanceEarth;
            to_return.resist = DamageType.EARTH;
        }
        if (resistanceWater != 0 && damageGot == DamageType.WATER)
        {
            to_return.percent = resistanceWater;
            to_return.resist = DamageType.WATER;
        }
        to_return.target = transform;
        to_return.incomingDmgType = damageGot;
        return to_return;
    }

    
}