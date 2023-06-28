using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;

public class GemCollectable : BaseCollectableItem
{
    private const float CHECK_DISTANCE = 2.5f * 2.5f;
    static readonly int[] BOSS_TO_EXCLUDE_FROM_GEM_SPAWN = {94,95};

    [SerializeField]
    private SpriteRenderer gemIcon;
    public int waittime; // Время ожидания, после которого монета автоматически отправляется в "кошелек"
                         //public float speed; // Скорость с которой монета летит в сторону "кошелька"
    public Vector3 arrive_point; // Координата, куда отправляется монета, если мы ее не собрали за время ожидания
    private LevelSettings levelSettings;
    private CircleCollider2D _collider;
    private float waittimer;

    private bool shadowShowing;
    public bool isBoss;

    [SerializeField]
    private GameObject shadow;
    private int rareCounter;
    public bool timerCollect = true;
    private float startColliderRadius;
    private List<GameObject> otherNearObjs = new List<GameObject> ();
    private Gem gem;
    public Animator[] _anims;
    public bool unscaledAnim = false;

    [HideInInspector] public static GameObject gemCollectableInstance;
    
    public UnityEngine.Events.UnityAction _action;

    public Gem Gem
    {
        get
        {
            return gem;
        }
    }

    public CircleCollider2D Collider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<CircleCollider2D>();
            }
            return _collider;
        }
    }

    public static void Spawn(Gem gemToSpawn, Vector3 position, bool isBoss = false)
    {
        Casket.countCasketInScene++;

        foreach (var level in BOSS_TO_EXCLUDE_FROM_GEM_SPAWN)
        {
            if (isBoss && LevelSettings.Current.currentLevel == level)
            {
                break;
            }
            GemsDropOnLevelData.GemDropped(gemToSpawn.type, gemToSpawn.gemLevel + 1);
            GameObject gemCollectablePrefab = Resources.Load("Bonuses/Gems/GemCollectable", typeof(GameObject)) as GameObject;
            Vector3 gemPosition = position + new Vector3(0, 1.15f, 0);
            gemPosition.z = -0.5f;
            GameObject gemInstance = Instantiate(gemCollectablePrefab, gemPosition, gemPosition.x > 3f ? Quaternion.identity : Quaternion.Euler(new Vector3(0, -180f, 0)));
            GemCollectable gemCollectable = gemInstance.GetComponentInChildren<GemCollectable>();
            gemCollectable.Init(gemToSpawn);
            gemCollectable.isBoss = isBoss;
            gemCollectableInstance = gemCollectable.gameObject;
            EnemiesGenerator.Instance.dropsOnLevel.Add(gemInstance);
            Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.GEM_SPAWN, gemCollectable);
            break;
        }
    }

    private void Init(Gem gemToSpawn)
    {
        gem = gemToSpawn;
        gemIcon.sprite = Resources.Load<Sprite>(GemsLoaderConfig.Instance.GetGem(gemToSpawn));
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            otherNearObjs.Add(transform.parent.GetChild(i).gameObject);
        }
        if (arrive_point.x == 0f && arrive_point.y == 0f)
        {
            arrive_point = new Vector3(-8f, 3.5f, -15f);
        }
        levelSettings = GameObject.FindObjectOfType<LevelSettings>();
        if (_collider == null)
        {
            _collider = GetComponent<CircleCollider2D>();
        }
        //animParent = transform.parent.gameObject.GetComponent<Animation>();
        shadowShowing = false;
        startColliderRadius = _collider.radius;
        OtherObjsActive(shadowShowing);
        otherNearObjs[1].SetActive(true);
        RegisterForUpdate();
        if (unscaledAnim)
        {
            foreach (var a in _anims)
                a.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        if (isBoss)
            waittime += 4;
        StartCoroutine(_Init());
    }

    IEnumerator _Init()
    {
        yield return new WaitForSeconds(.7f);
        shadowShowing = true;
        if (unscaledAnim)
        {
            foreach (var a in _anims)
                a.updateMode = AnimatorUpdateMode.Normal;
        }
        yield return new WaitForEndOfFrame();
        OtherObjsActive(shadowShowing);
        if (unscaledAnim)
        {
            foreach (var a in _anims)
                a.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    public override void UpdateObject()
    {
        waittimer += Time.deltaTime;
        // По времени
        if (waittimer > waittime && !collected && timerCollect)
        {
            _collider.enabled = false;
            foreach (var a in _anims)
                a.enabled = false;
            OnStartCollect();
            StartReplica();
        }

       // Перемещаем в "кошелек"
        if (collected)
        {
            shadowShowing = false;
            UpdateFlyAnimation();
        }
        OtherObjsActive(shadowShowing);
        if (rareCounter >= 20)
        {
            rareCounter = 0;
            CheckEnemiesAround();
        }
        else
        {
            rareCounter++;
        }
    }

    private void OtherObjsActive(bool on)
    {
        for (int i = 0; i < otherNearObjs.Count; i++)
        {
            if (otherNearObjs[i] != gameObject)
            {
                otherNearObjs[i].SetActive(on);
            }
        }
    }

    protected override void OnUIElementReached()
    {
        Casket.countCasketInScene--;
        base.OnUIElementReached();
        levelSettings.gemsValue.text = (int.Parse(levelSettings.gemsValue.text.ToString()) + 1).ToString();
        UnregisterFromUpdate();
        IncrementGem();
        Destroy(transform.parent.parent.gameObject);
        OtherObjsActive(shadowShowing);
    }

    private void CheckEnemiesAround()
    {
        if (levelSettings == null || levelSettings.enemies == null)
        {
            return;
        }
        bool isEnemyNear = false;
        int count = levelSettings.enemies.enemiesOnLevel.Count;
        Vector3 transPos = transform.position;
        for (int i = 0; i < count; i++)
        {
            float distance = Vector3.SqrMagnitude(transPos - levelSettings.enemies.enemiesOnLevel[i].position);
            if (distance < CHECK_DISTANCE)
            {
                isEnemyNear = true;
                break;
            }
        }
        if (!isEnemyNear)
        {
            _collider.radius = startColliderRadius * 2f;
        }
        else
        {
            _collider.radius = startColliderRadius;
        }
    }

    public void OnMouseUp()
    {
        shadowShowing = false;
        //_collider.enabled = false;
        foreach (var a in _anims)
            a.enabled = false;
        if (_collider.enabled)
        {
            StartCoroutine(_Col());
            _collider.enabled = false;
        }

        StartReplica();
    }
    IEnumerator _Col()
    {
        if(isBoss)
            yield return new WaitForSeconds(0.25f);
        OnStartCollect();
    }

    void StartReplica()
    {
        //Вторая реплика игрока - до какого уровня босс
        if (isBoss)
        {
            if (mainscript.CurrentLvl == 2 || mainscript.CurrentLvl == 15)
            {
                Tutorial_1.tutorialFirstCrystal.CollectCrystal();
                UI.ReplicasConditionsChecker.Current.ShowMageReplica(UI.EReplicaID.Level2_Mage2_FirstCrystal2);
            }
            _action?.Invoke();
        }
    }


    public void IncrementGem()
    {
        var gemLooted = false;
        var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
        for (int i = 0; i < gemItems.Length; i++)
        {
            if (gemItems[i].gem.type == gem.type && gemItems[i].gem.gemLevel == gem.gemLevel)
            {
                gemLooted = true;
                gemItems[i].count++;
                PPSerialization.Save(EPrefsKeys.Gems, gemItems, false);
                break;
            }
        }
    }

}
