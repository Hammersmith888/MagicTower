using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FireWallShot : BaseAOESpell
{
    public float spellTime; // Длительность эффекта
    public int minDamage, maxDamage; // min-max урон

    public int burnChance; // Вероятность эффекта возгорания
    public int burnDamage; // Урон от эффекта возгорания
    public float burnTime; // Длительность эффекта возгорания
    public GameObject burnEffect; // Эффект возгорания

    private bool useSetPermanentDamage = false;

    [SerializeField]
    private ParticleSystem[] particleSystems;

    protected override DamageType SpellDamageType
    {
        get
        {
            return DamageType.FIRE;
        }
    }

    public bool isPlayerWall;

    private void Start()
    {
        enemies = new List<EnemyCharacter>();
        enemiesTimers = new List<float>();
        //transform.position = new Vector3(transform.position.x, transform.position.y, -15f);
        if (!useSetPermanentDamage)
        {
            damage = (minDamage + maxDamage) / 2;
        }
        if (spellTime > 0.01)
        {
            if (particleSystems.Length > 0)
            {
                StartCoroutine(FadeToDestroy());
            }
            else
            {
                Destroy(gameObject, spellTime);
            }
        }
    }

    private void Update()
    {
        if (damageTimer == 0)
        {
            damageTimer = 1f;
        }

        if (isPlayerWall)
        {
            int enemiesCount = enemies.Count;
            for (int i = enemiesCount - 1; i >= 0; i--)
            {
                if (!enemies[i].isWallHitted)
                {
                    enemies.RemoveAt(i);
                    enemiesTimers.RemoveAt(i);
                }
            }

            if (EnemiesGenerator.Instance != null)
            {
                foreach (EnemyCharacter enemy in EnemiesGenerator.Instance.enemiesOnLevelComponents)
                {
                    if (!enemies.Contains(enemy) && enemy.isWallHitted)
                    {
                        enemies.Add(enemy);
                        enemiesTimers.Add(0.0f);
                    }
                }
            }
        }

        int count = enemies.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemiesTimers[i] + damageTimer <= Time.time)
            {
                if (enemies[i] != null)
                {
                    var enemyCharacter = enemies[i];
                    enemiesTimers[i] = Time.time;
                    bool canInterruptAttack = !isPlayerWall;
                    ApplyDamage(enemyCharacter, 0, canInterruptAttack);
                }
            }
        }
    }

    public void SetPermanentDamage()
    {
        //print ("enabling fire wall");
        LevelSettings levelSettings = GameObject.FindGameObjectWithTag("LevelSettings").GetComponent<LevelSettings>();
        if (levelSettings.upgradeItems[3].unlock && levelSettings.upgradeItems[3].upgradeLevel > 0)
        {
            MyGSFU balanceData = MyGSFU.current;
            damage = balanceData.charUpgradesValues[3].characterUpgradesValue[(int)levelSettings.upgradeItems[3].upgradeLevel - 1];
            damageTimer = balanceData.charUpgradesValues[3].characterUpgradesSpeed[(int)levelSettings.upgradeItems[3].upgradeLevel - 1];
            GetComponent<Collider2D>().enabled = true;
            gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(true);
            useSetPermanentDamage = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public override void Activation(Vector3 position)
    {
        base.Activation(position);
        transform.rotation = Quaternion.Euler(0f, 0f, -10); // Поворачиваем FireWall, чтобы сохранить эффект перспективы
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (!FireExplosion.ColliderValidation(coll))
        {
            return;
        }
        var enemyCharacter = coll.GetComponent<EnemyCharacter>();
        if (!FireExplosion.HpValidation(enemyCharacter.CurrentHealth))
        {
            return;
        }

        var enemyCharacterPosition = enemyCharacter.transform.position;
        if (enemyCharacter.enemyType == EnemyType.ghoul && enemyCharacterPosition.x > PlayerController.Position.x + 2.2f && spellTime != 0)
        {
            if (!enemies.Contains(enemyCharacter))
            {
                enemyCharacter.Jump(new Vector2(-2.2f, 0.0f));
            }
            return;
        }
        if (spellTime > 0.01f)
        {
            StartCoroutine(TakeDamage(enemyCharacter));
            if (FireExplosion.BurnValidation(enemyCharacter.CurrentHealth, burnChance))
                enemyCharacter.SpellEffects.AddEffect(SpellEffects.Effect.EffectTypes.FireBurn, burnTime, burnDamage);
        }
        else
        {
            if (!IsAlreadyAdded(enemyCharacter.gameObject.GetInstanceID()))
            {
                enemies.Add(enemyCharacter);
                enemiesTimers.Add(0f);
            }
        }
    }

    private IEnumerator TakeDamage(EnemyCharacter enemyCharacter) // Цель получает постоянный урон находясь в триггере
    {
        if (enemyCharacter.enemyType == EnemyType.skeleton_archer || enemyCharacter.enemyType == EnemyType.skeleton_archer_big)
        {
            ApplyDamage(enemyCharacter, 0, true);
        }
        else
        {
            for (int i = 0; i <= 3; i++)
            {
                if (enemyCharacter != null)
                {
                    ApplyDamage(enemyCharacter, 0, true);
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }

    private IEnumerator FadeToDestroy()
    {
        float fadePercent = 0.35f;
        float timeFade = spellTime * fadePercent;

        float currentFadeTime = 0;

        float[] lerpStart = new float[particleSystems.Length];
        for (int i = 0; i < particleSystems.Length; i++)
        {
            if (particleSystems[i] == null)
            {
                continue;
            }
            lerpStart[i] = particleSystems[i].maxParticles;
        }

        yield return new WaitForSeconds(spellTime - timeFade);

        float perc = 0;
        while (currentFadeTime < timeFade)
        {
            currentFadeTime += Time.deltaTime;
            if (currentFadeTime > timeFade)
            {
                currentFadeTime = timeFade;
            }

            perc = currentFadeTime / timeFade;
            for (int i = 0; i < particleSystems.Length; i++)
            {
                if (particleSystems[i] == null)
                {
                    continue;
                }
                particleSystems[i].maxParticles = (int)Mathf.Lerp(lerpStart[i], 0, perc);
            }

            yield return null;
        }

        Destroy(gameObject);
    }

    [ContextMenu("Cache Particle System")]
    private void CacheParticleSystem()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }
}