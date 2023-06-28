using UnityEngine;

public class IceStrikeShot : SpellBase
{
    public int minDamage, maxDamage; // min-max урон
    //public int radius; // Радиус
    public float speed; // Скорость полета
    public int slowdownValue; // Эффект замедления (на сколько замедляем в %)
    public float slowdownTime; // Время действия эффекта замедления
    public int freezingChance; // Вероятность эффекта заморозки
    public float freezingTime; // Время действия эффекта заморозки

    public GameObject explosion; // Взрыв

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение
    private int damage;

    private float speedValue;

	private float startXposition;

	private Vector3 pos;

	[SerializeField]
	private GameObject warnCollider;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        startXposition = transform.position.x;
        speedValue = GAME_FIELD_WIDTH_IN_UNITS / (speed / 10); // Вычисляем скорость в юнитах в секунду. Делим на 10 т.к. скорость в таблице задается как 10 (за 1 сек все поле), 20 (за 2 сек) и т.д.
        damage = Random.Range(minDamage, maxDamage); // Вычисляем величину случайного урона
		RegisterForUpdate();
		WarnGhouls ();

    }

	public void SetIceShotParam(Vector3 _direction, float _speed, int _damage)
	{
		targetDirection = _direction.normalized;
		targetDirection.z = 0;
		speed = _speed;
		damage = _damage;
//		freezingChance = _freezingChance;
//		freezingTime = _freezingTime;
		currentlyOnField = true;
		startXposition = transform.position.x;
		RegisterForUpdate();
		active = true;
	}

    // Активируется после получения вектора направления движения
    public void Activation(Vector3 _targetDirection)
    {
		currentlyOnField = true;
        // Если начало вектора (координата x) направления движения находится в левой части от начальной точки движения
        if (_targetDirection.x < pos.x || _targetDirection.x - pos.x < 1f)
        {
            GetComponent<CircleCollider2D>().radius *= 2f;
            //_targetDirection = new Vector3(-_targetDirection.x, _targetDirection.y, _targetDirection.z);
        }

        pos = transform.position;
		_targetDirection.z = pos.z = 0;// Обнуляем координату Z
		targetDirection = ( _targetDirection - pos ).normalized;
        active = true;
    }

	override public void UpdateObject()
	{
		if( active )
		{
			pos = transform.position;
			pos += (targetDirection * speedValue) * Time.deltaTime;
			transform.position = pos;
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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
            Hit(coll);
    }

    void Hit(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            active = false;
            GetComponent<Collider2D>().enabled = false;
            UnregisterFromUpdate();
            StopEmission();
            DamageAOEHelper.Instance.mainTargetTransform = coll.transform;

            explosion.GetComponent<IceStrikeExplosion>().SetIceExplosionParam(damage, slowdownValue, slowdownTime, freezingChance, freezingTime);
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            Destroy(gameObject, 1.3f);
        }
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

    private void StopEmission()
    {
        // Останавливаем излучение у всех систем частиц эффекта
        // Дети
        if (gameObject.transform.childCount != 0)
        {
            for (int i = 1; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<ParticleSystem>() && gameObject.transform.GetChild(i).name != "Explosion")
                {
                    ParticleSystem.EmissionModule emission = gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
                    emission.enabled = false;
                }
            }
        }
    }
}