using MagicalFX;
using UnityEngine;

public class ChainLightningShot : SpellBase
{

    public float lifeTime; // Время жизни молнии
    public int minDamage, maxDamage; // min-max урон
    public int radius; // Радиус
    public int paralysisChance; // Вероятность эффекта
    public float paralysisTime; // Продолжительность эффекта
    public ChainShot chainRadius; // Объект который включает коллайдер - зона цепной молнии
    public int CountEnemiesCanKill = 4;
    [SerializeField]
    private FX_ElectroLine fXElectroLine; // Игровой объект со скриптами эффекта молнии

    private Transform fxStartPoint; // Точка начала молнии
    [HideInInspector]
    public int CountEnemiesCanKilled = 0;
    private int damage;
    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта
    private float crit;
    void Start()
    {
        LineRenderer lineRenderer = fXElectroLine.GetComponent<LineRenderer>();
        lineRenderer.sortingLayerName = "Elements";
        lineRenderer.sortingOrder = 1;

        crit = LevelSettings.Current.criticalModifier();
        damage = (int)((float)Random.Range(minDamage, maxDamage) * crit);
        Destroy(gameObject, lifeTime);
        Invoke("HideExplosion", lifeTime / 3);

    }

    // Активируется после нажатия
    public void Activation(Vector3 _targetDirection)
    {
        transform.position = new Vector3(_targetDirection.x, _targetDirection.y, -5f);
        Vector3 startPoint = new Vector3(_targetDirection.x, 5f, -5f); // 5 - координата за верхней частью экрана, для начала молнии

        fxStartPoint = transform.GetChild(1).gameObject.transform; // Transform объекта начала молнии
        fxStartPoint.position = startPoint; // Изменяем позицию по X объекта начала молнии
        CountEnemiesCanKilled = 0;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            CountEnemiesCanKilled++;
            if (CountEnemiesCanKilled > CountEnemiesCanKill)
            {
                return;
            }

            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();

            if (enemyCharacter.CurrentHealth > 0)
            {
                //Debug.Log("Health lishting", gameObject);
                // Эффекты на персонаже
                SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                // Наносим урон персонажу
                // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                {
                    enemyCharacter.Hit(damage, false, DamageType.AIR, true, crit);
                }
                else
                {
                    enemyCharacter.Hit(damage, true, DamageType.AIR, true, crit);
                }

                // Включаем эффект паралич на персонаже, если это еще необходимо
                chance = Random.Range(0, 100);
                if (chance < paralysisChance)
                {
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Paralysis, paralysisTime, isSpell:true);
                }

                if (enemyCharacter.CurrentHealth <= 0)
                {
                    chainRadius.killCounter++;
                }
                chainRadius.SetChainLightningParam(coll.gameObject, damage / 2, paralysisChance / 2, paralysisTime, this);
                chainRadius.gameObject.SetActive(true);
            }

        }
    }

    void HideExplosion()
    {
        Transform lightingTransform = transform.Find("Lightning");
        string fxName = fXElectroLine.FXEnd.name + "(Clone)";
        Transform fxTransform = lightingTransform.Find(fxName);
        fxTransform.gameObject.SetActive(false);
    }
}