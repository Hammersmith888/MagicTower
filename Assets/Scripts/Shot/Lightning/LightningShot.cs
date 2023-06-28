using UnityEngine;

public class LightningShot : SpellBase {

    public float lifeTime; // Время жизни молнии
    public int minDamage, maxDamage; // min-max урон
    public int paralysisChance; // Вероятность эффекта паралича
    public float paralysisTime; // Время паралича

    private GameObject fxEffect; // Игровой объект со скриптами эффекта молнии
    private Transform fxStartPoint; // Точка начала молнии

    private int damage;
    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта
	private int killCounter;
    private float crit;

    void Start()
    {
        if (fxEffect == null)
        {
            fxEffect = transform.GetChild(0).gameObject;
        }
        LineRenderer lineRenderer = fxEffect.GetComponent<LineRenderer>();
        lineRenderer.sortingLayerName = "Elements";
        lineRenderer.sortingOrder = 1;

        crit = LevelSettings.Current.criticalModifier();
        damage = Random.Range(minDamage, maxDamage);
        Destroy(gameObject, lifeTime);
		if (BuffsLoader.Instance != null)
			paralysisTime += paralysisTime * BuffsLoader.Instance.GetBuffValue (BuffType.electrizedTime);
		
    }

    // Активируется после нажатия
    public void Activation(Vector3 _targetDirection)
    {
        transform.position = new Vector3(_targetDirection.x, _targetDirection.y, 0f);
        Vector3 startPoint = new Vector3(_targetDirection.x, 10f, 0f); // 10 - координата за верхней частью экрана, для начала молнии

        fxEffect = transform.GetChild(0).gameObject; // Объект со скриптами эффекта молнии
        fxStartPoint = transform.GetChild(1).gameObject.transform; // Transform объекта начала молнии
        fxStartPoint.position = startPoint; // Изменяем позицию по X объекта начала молнии
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag( GameConstants.ENEMY_TAG ) )
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();


            //Debug.Log($"lighting shot", gameObject);
            if (enemyCharacter.CurrentHealth > 0)
            {
                // Эффекты на персонаже
                SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                // Наносим урон персонажу
                // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                    enemyCharacter.Hit(damage, false, DamageType.AIR, true, crit);
                else
                    enemyCharacter.Hit(damage, true, DamageType.AIR, true, crit);

                // Включаем эффект паралич на персонаже, если это еще необходимо
				if (enemyCharacter.CurrentHealth <= 0)
                {
                    killCounter++;
                }
                chance = Random.Range(0, 100);
                if (chance < paralysisChance)
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Paralysis, paralysisTime, isSpell: true);   
            }
        }
    }

	void OnDestroy()
	{
	}

	private void DisableEffect( )
	{

	}

    // Объявление переменных
    // private const float explosionTime = 0.2f; // Время которое длится система частиц дыма
    // Для вызова в Start
    // Invoke("StopEmission", explosionTime);

    // Заготовка для плавной остановки частиц
    /*private void StopEmission()
    {
        // Останавливаем излучение у всех систем частиц эффекта
        // Основной объект
        if (gameObject.GetComponent<ParticleSystem>())
        {
            ParticleSystem.EmissionModule emission = gameObject.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        // Дети
        if (gameObject.transform.childCount != 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<ParticleSystem>())
                {
                    ParticleSystem.EmissionModule emission = gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
                    emission.enabled = false;
                }
            }
        }
        // Уничтожаем объект
        Destroy(gameObject, explosionTime);
    }*/
}