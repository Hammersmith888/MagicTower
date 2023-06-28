using UnityEngine;
using System.Collections;

public class EarthShot : SpellBase
{
    public int minDamage, maxDamage; // min-max урон
    public float speed; // Скорость полета
    public int burnChance; // Вероятность эффекта возгорания
    public int burnDamage; // Урон от эффекта возгорания
    public float burnTime; // Длительность эффекта возгорания
    public float abilityEffect; // Длительность эффекта возгорания
    //public float timeOfSecondEffect; // Длительность эффекта линии земли
    public float chanceAbility; // Шанс появления грязевого пути

    
    public GameObject explosion, mainObj; // Взрыв

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение
    private int damage;

    private float speedValue;
	private float startXposition;
	private Transform transf;
	private Vector3 pos;
	[SerializeField]
	private GameObject warnCollider;

	const float EXPLOSION_DISABLE_DELAY_TIME = 1.1f;
	const float Z_COORDINATE = -1.5f;
    //const float MAX_PARTICLE_LIFE_TIME = 0.5f;
    Vector3 startPos;

    private bool trailActive;
    private Vector2 startTrailPositionOnPlane;
    private Vector2 endTrailPositionOnPlane;
    private const float TRAIL_RADIUS = 0.5f;
    public ParticleSystem[] effectGround;
    float destroyTimer;

    private Vector2 PositionOnPlane
    {
        get
        {
            return new Vector2(transform.position.x, (transform.position.y - 0.4f) / EnemyMover.WORLD_PLANE_SIN);
        }
    }

    void Start()
    {
        startPos = transform.position;
        startXposition = transform.position.x;
        speedValue = ( GAME_FIELD_WIDTH_IN_UNITS / ( speed / 10f ) ); // Вычисляем скорость в юнитах в секунду. Делим на 10 т.к. скорость в таблице задается как 10 (за 1 сек все поле), 20 (за 2 сек) и т.д.
        damage = Random.Range(minDamage, maxDamage); // Вычисляем величину случайного урона
		WarnGhouls();
        for (int i = 0; i < effectGround.Length; i++)
        {
            var m = effectGround[i].main;
            m.startLifetimeMultiplier = timeOfSecondEffect;
        }
        destroyTimer = timeOfSecondEffect;

        float chance = Random.Range(0, 100);

        if (chance > chanceAbility)
        {
            foreach (var o in effectGround)
            {
                Destroy(o);
            }
            trailActive = false;
        }
        else
        {
            trailActive = true;
        }

        if (trailActive)
        {
            startTrailPositionOnPlane = PositionOnPlane;
            endTrailPositionOnPlane = PositionOnPlane;
        }

        Destroy(gameObject, destroyTimer);
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
		targetDirection = ( _targetDirection - pos ).normalized;

		pos.z = Z_COORDINATE;// Обнуляем координату Z
		transf.position = pos;
		active = true;
		RegisterForUpdate();
	}

    private void Update()
    {
        if (trailActive)
        {
            if (active)
                endTrailPositionOnPlane = PositionOnPlane;

            float sqrTrailRadius = TRAIL_RADIUS * TRAIL_RADIUS;
            if (EnemiesGenerator.Instance != null)
            {
                int enemiesCount = EnemiesGenerator.Instance.enemiesOnLevelComponents.Count;
                for (int i = enemiesCount - 1; i >= 0; i--)
                {
                    EnemyCharacter enemy = EnemiesGenerator.Instance.enemiesOnLevelComponents[i];
                    if (enemy.enemyMover == null)
                        continue;

                    if (SqrDistanceFromPointToSegment(enemy.enemyMover.positionOnPlane, startTrailPositionOnPlane, endTrailPositionOnPlane) < sqrTrailRadius)
                    {
                        SpellEffects spellEffects = enemy.GetComponent<SpellEffects>();
                        if (spellEffects != null)
                            spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.EarthSlowdown, burnTime, 25.0f);
                    }
                }
            }
        }
    }
    private bool dissStarted;

    override public void UpdateObject ()
	{
		if( active )
		{
			pos = transf.position;
			pos += (targetDirection * speedValue) * Time.deltaTime;
			transf.position = pos;
			if ((pos.y > GameConstants.MaxTopBorder || pos.y < GameConstants.MaxBottomBorder) && !dissStarted)
			{
				dissStarted = true;
				StartCoroutine(SingleDissappear());
			}
			if( currentlyOnField && pos.x - startXposition > DefaultMaxShotFlyDistance)
			{
				OnOutOfGameField();
			}

            Debug.DrawLine(startPos, transform.position, Color.white);
            //Debug.Log("Update: start pos: " + startPos + ", this: " + transform.position);

            var hit = Physics2D.Linecast(startPos, transform.position, LayerMask.GetMask("Characters"));
            if (hit.collider.CompareTag(GameConstants.ENEMY_TAG))
            {
                // Debug.Log("HIT FROM LINECAST");
                transform.position = hit.point;
                Hit(hit.collider);
            }
        }
    }
    private IEnumerator SingleDissappear()
    {
	    IColorHolder[] colorHolders = GetComponentsInChildren<Renderer>().GetColorHolders();
	    if (colorHolders.Length > 0)
	    {
		    var startAlphaValues = new float[colorHolders.Length];
		    int i;
		    for (i = 0; i < colorHolders.Length; i++)
		    {
			    startAlphaValues[i] = colorHolders[i].alpha;
		    }
		    var _collider = GetComponentInChildren<Collider>();
		    if (_collider != null)
		    {
			    _collider.enabled = false;
		    }

	    }
	    UnregisterFromUpdate();
        explosion.GetComponent<EarthExplosion>().SetEarthExplosionParam(0, 0, 0, 0);
        mainObj.SetActive(false);
	    yield return null;
    }
    void Hit(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            //#if UNITY_EDITOR
            //			print ("collide with " + coll.transform.name);
            //#endif
            GetComponent<Collider2D>().enabled = false;
            active = false;
            UnregisterFromUpdate();
            StartCoroutine(StopEmission());
            DamageAOEHelper.Instance.mainTargetTransform = coll.transform;

            explosion.GetComponent<EarthExplosion>().SetEarthExplosionParam(damage, burnChance, burnDamage, burnTime);
            mainObj.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Hit(coll);
    }

	private void WarnGhouls()
	{
		GameObject warnObj =  Instantiate (warnCollider) as GameObject;
		WarnCollider warnComponent = warnObj.GetComponent<WarnCollider> ();
		if (warnComponent != null){
			warnComponent.AttackCollider = GetComponent<CircleCollider2D> ();
			warnComponent.parentBall = transform;
		}
	}

	private IEnumerator StopEmission()
    {
   //     // Останавливаем излучение у всех систем частиц эффекта
   //     if ( transf.childCount != 0)
   //     {
			//ParticleSystem particles;
			//ParticleSystem[ ] particleSystems = GetComponentsInChildren<ParticleSystem>();

			//for (int i = 0; i < particleSystems.Length; i++)
   //         {
			//	particles = particleSystems[ i ];
   //             ParticleSystem.EmissionModule emission = particles.emission;
   //             emission.enabled = false;
   //         }

			//yield return new WaitForSecondsRealtime (0.3f);
			//for (int i = 0; i < particleSystems.Length; i++) {
   //             for (int z = 0; z < effectGround.Length; z++)
   //             {
   //                 //if (particleSystems[i] != effectGround[z])
   //                 //    particleSystems[i].gameObject.SetActive(false);
   //             }
			//}
   //     }
		yield break;
    }

    // TODO: Optimize
    private float SqrDistanceFromPointToSegment(Vector2 p, Vector2 s1, Vector2 s2)
    {
        float minDistance = 10000.0f;
        for (float t = 0.0f; t <= 1.0f; t += 0.05f)
        {
            Vector2 midPoint = s1 + (s2 - s1) * t;
            float dx = p.x - midPoint.x;
            float dy = p.y - midPoint.y;
            minDistance = Mathf.Min(minDistance, dx * dx + dy * dy);
        }

        return minDistance;
    }


#if UNITY_EDITOR
	[SerializeField]
	[Space(10f)]
	private bool stopEmission_Editor;
	private void OnDrawGizmosSelected( )
	{
        if (trailActive)
        {
            Vector3 startTrailPoint = new Vector3(startTrailPositionOnPlane.x, startTrailPositionOnPlane.y * EnemyMover.WORLD_PLANE_SIN,
                startTrailPositionOnPlane.y * EnemyMover.WORLD_PLANE_COS - 6.0f);
            Vector3 endTrailPoint = new Vector3(endTrailPositionOnPlane.x, endTrailPositionOnPlane.y * EnemyMover.WORLD_PLANE_SIN,
                endTrailPositionOnPlane.y * EnemyMover.WORLD_PLANE_COS - 6.0f);
            Gizmos.DrawLine(startTrailPoint, endTrailPoint);
        }

        if ( stopEmission_Editor )
		{
			stopEmission_Editor = false;
			transf = transform;
			StopEmission();
		}
	}
#endif
}