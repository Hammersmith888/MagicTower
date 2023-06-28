using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragonSpell : SpellBase
{
    public GameObject burnEffect; // Эффект возгорания
    public int minDamage, maxDamage; // min-max урон
    public float speed; // Скорость полета
    public int burnDamage; // Урон от эффекта возгорания
    public float burnTime; // Длительность эффекта возгорания

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение
    private int damage;

    private float speedValue;
    private float startXposition;
    private Transform transf;
    private Vector3 pos;
    private Collider2D _collider;
    const float EXPLOSION_DISABLE_DELAY_TIME = 1.1f;
    const float Z_COORDINATE = -1.5f;
    //const float MAX_PARTICLE_LIFE_TIME = 0.5f;
    private List<EnemyCharacter> enemies = new List<EnemyCharacter>(); // Каждого персонажа необходимо атаковать только один раз, здесь список персонажей, которых уже атаковали
    private float crit;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        startXposition = transform.position.x;
        speedValue = (GAME_FIELD_WIDTH_IN_UNITS / (speed / 10f)); // Вычисляем скорость в юнитах в секунду. Делим на 10 т.к. скорость в таблице задается как 10 (за 1 сек все поле), 20 (за 2 сек) и т.д.
        crit = LevelSettings.Current.criticalModifier();
        damage = (int)((float)Random.Range(minDamage, maxDamage) * crit); // Вычисляем величину случайного урона
        print("blizzard damage = " + damage);
    }

    // Активируется после получения вектора направления движения
    public void Activation(Vector3 spawnPos)
    {
        transf = transform;
        transf.position = spawnPos;
        pos = transf.position;
        currentlyOnField = true;
        // Если начало вектора (координата x) направления движения находится в левой части от начальной точки движения
        Vector3 _targetDirection = new Vector3(pos.x + 15f, 0, 0);

        _targetDirection.z = pos.z = 0;
        targetDirection = (_targetDirection - pos).normalized;

        pos.z = Z_COORDINATE;// Обнуляем координату Z
        transf.position = pos;
        Invoke("EnableCollider", 1.6f);
        Invoke("HandDestroy", 1.8f);
        //active = true;
        //RegisterForUpdate();
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
    }

    private bool AlreadyAdded(int _enemyID)
    {
        int count = enemies.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemies[i] != null && _enemyID == enemies[i].gameObject.GetInstanceID())
                return true;
        }
        return false;
    }

    private void HandDestroy()
    {
        OnOutOfGameField();
    }

    override public void UpdateObject()
    {
        if (active)
        {
            pos = transf.position;
            pos += targetDirection * (Time.deltaTime * speedValue);
            transf.position = pos;
            if (currentlyOnField && pos.x - startXposition > DefaultMaxShotFlyDistance)
            {
                OnOutOfGameField();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();

            if (!AlreadyAdded(enemyCharacter.gameObject.GetInstanceID()) && enemyCharacter.CurrentHealth > 0)
            {
                enemies.Add(enemyCharacter);
                // Эффекты на персонаже
                PushEnemy(enemyCharacter);
            }
        }
    }

    private void PushEnemy(EnemyCharacter enemy)
    {
        float timer = 0.3f;
        enemy.enemyMover.PushItTo(enemy.transform.position.x + 1.25f, timer);
        SpellEffects spellEffects = enemy.GetComponent<SpellEffects>();
        // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
        if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
        {
            StartCoroutine(enemy.DeferredHit(damage, false, DamageType.FIRE, true, timer, crit));
        }
        else
        {
            StartCoroutine(enemy.DeferredHit(damage, true, DamageType.FIRE, true, timer, crit));
        }
    }

    private void StopEmission()
    {
        // Останавливаем излучение у всех систем частиц эффекта
        if (transf.childCount != 0)
        {
            ParticleSystem particles;
            ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

            for (int i = 0; i < particleSystems.Length; i++)
            {
                particles = particleSystems[i];
                ParticleSystem.EmissionModule emission = particles.emission;
                emission.enabled = false;
            }
        }
    }

#if UNITY_EDITOR
    [SerializeField]
    [Space(10f)]
    private bool stopEmission_Editor;
    private void OnDrawGizmosSelected()
    {
        if (stopEmission_Editor)
        {
            stopEmission_Editor = false;
            transf = transform;
            StopEmission();
        }
    }
#endif
}