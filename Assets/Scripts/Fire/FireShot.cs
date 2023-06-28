using UnityEngine;

public class FireShot : SpellBase 
{
    public int minDamage, maxDamage; // min-max урон
    public float speed; // Скорость полета
    public int burnChance; // Вероятность эффекта возгорания
    public int burnDamage; // Урон от эффекта возгорания
    public float burnTime; // Длительность эффекта возгорания

    public GameObject explosion; // Взрыв

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение
    private int damage;

    private float speedValue;
    private float startXposition;
    private Transform transf;
    private Vector3 pos;
    [SerializeField]
    private GameObject warnCollider;
    [SerializeField]
    private SpriteRenderer shadowSpriteRenderer;

    const float SHADOW_FADEOUT_TIME = 0.8f;
    const float EXPLOSION_DISABLE_DELAY_TIME = 1.1f;
    const float Z_COORDINATE = -1.5f;
    Vector3 startPos;
    void Start()
    {
        startPos = transf.position;
    }

    public void SetShotParamsAndActivate(Vector3 _direction, float _speed, int _damage)
    {
        speed = _speed;
        minDamage = maxDamage = damage = _damage;
        Activation(_direction);
    }

    // Активируется после получения вектора направления движения
    public void Activation(Vector3 _targetDirection)
    {
        transf = transform;
        pos = transf.position;
        currentlyOnField = true;
        // Если начало вектора (координата x) направления движения находится в левой части от начальной точки движения
        if (_targetDirection.x < pos.x || _targetDirection.x - pos.x < 1f)
        {
            GetComponent<CircleCollider2D>().radius *= 2f;
            //_targetDirection = new Vector3(-_targetDirection.x, _targetDirection.y, _targetDirection.z);
        }

        _targetDirection.z = pos.z = 0;
        targetDirection = (_targetDirection - pos).normalized;

        pos.z = Z_COORDINATE;// Обнуляем координату Z
        transf.position = pos;
        active = true;

        startXposition = pos.x;
        speedValue = (GAME_FIELD_WIDTH_IN_UNITS / (speed / 10f)); // Вычисляем скорость в юнитах в секунду. Делим на 10 т.к. скорость в таблице задается как 10 (за 1 сек все поле), 20 (за 2 сек) и т.д.
        damage = (minDamage + maxDamage) / 2; // Теперь урон стабильный

        WarnGhouls();
        RegisterForUpdate();
    }

    override public void UpdateObject()
    {
        if (active)
        {
            pos = transf.position;
            pos += targetDirection * (speedValue * Time.deltaTime);
            transf.position = pos;
            if (currentlyOnField && pos.x - startXposition > DefaultMaxShotFlyDistance)
            {
                OnOutOfGameField();
            }

            Debug.DrawLine(startPos, transform.position, Color.white);
            //Debug.Log("Update: start pos: " + startPos + ", this: " + transform.position);

            var hit = Physics2D.Linecast(startPos, transf.position, LayerMask.GetMask("Characters"));
           // Debug.Log(hit.collider);
            if (hit.collider.CompareTag(GameConstants.ENEMY_TAG))
            {
                //Debug.Log("HIT FROM LINECAST");
                transform.position = hit.point;
                Hit(hit.collider);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
       Hit(coll);
    }

    void Hit(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            GetComponent<Collider2D>().enabled = false;
            active = false;
            UnregisterFromUpdate();
            StopEmission();
            DamageAOEHelper.Instance.mainTargetTransform = coll.transform;
            explosion.GetComponent<FireExplosion>().SetFireExplosionParam(damage, burnChance, burnDamage, burnTime);
            Destroy(gameObject, EXPLOSION_DISABLE_DELAY_TIME);
        }
    }

    private void WarnGhouls()
    {
        GameObject warnObj = Instantiate(warnCollider) as GameObject;
        WarnCollider warnComponent = warnObj.GetComponent<WarnCollider>();
        if (warnComponent != null)
        {
            warnComponent.AttackCollider = GetComponent<CircleCollider2D>();
            warnComponent.parentBall = transform;
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
        if (shadowSpriteRenderer != null)
        {
            this.PlayAlphaFadeout(new SpriteRendererColorHolder(shadowSpriteRenderer), SHADOW_FADEOUT_TIME);
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