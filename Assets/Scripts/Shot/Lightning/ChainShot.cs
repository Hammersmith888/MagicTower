using UnityEngine;
using System.Collections;

public class ChainShot : MonoBehaviour {

    public GameObject ChainLight; // Объект со скриптами эффекта молнии

    private int damage; // Урон цепной молнии в два раза меньше основного урона
    private int chance; // Случайное число от 0 до 100 для вычисления применения эффекта
    private int paralysisChance; // Вероятность эффекта
    private float paralysisTime; // Продолжительность эффекта
    private GameObject excludeEnemy; // Персонаж которого исключаем из цепной молнии, т.к. основной урон уже пришелся на него
	[HideInInspector]
	public int killCounter;
    private ChainLightningShot chainLightningShot;

    public void SetChainLightningParam(GameObject _enemy, int _damage, int _chance, float _time, ChainLightningShot _chainLightningShot)
    {     
        excludeEnemy = _enemy;
        damage = _damage;
        paralysisChance = _chance;
        paralysisTime = _time;
        chainLightningShot = _chainLightningShot;
    }

	void OnDestroy()
	{
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG) && coll.gameObject != excludeEnemy)
        {
            chainLightningShot.CountEnemiesCanKilled++;
            if (chainLightningShot.CountEnemiesCanKilled > chainLightningShot.CountEnemiesCanKill)
            {
                return;
            }
           // Debug.Log($"chain shot", gameObject);
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();

            if (enemyCharacter.CurrentHealth > 0)
            {
                // Эффекты на персонаже
                SpellEffects spellEffects = coll.GetComponent<SpellEffects>();
                // Наносим урон персонажу
                // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
                if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                    enemyCharacter.Hit(damage, false, DamageType.AIR);
                else
                    enemyCharacter.Hit(damage, true, DamageType.AIR);

				if (enemyCharacter.CurrentHealth <= (float)damage)
					killCounter++;

                chance = Random.Range(0, 100);
                if (chance < paralysisChance)
                    spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Paralysis, paralysisTime);
            }

            // Создаем дочернюю молнию
            GameObject child = Instantiate(ChainLight, transform.position, Quaternion.identity) as GameObject;
            child.transform.SetParent(transform);
            child.GetComponent<MagicalFX.FX_ElectroLine>().StartObject = transform;
            child.GetComponent<MagicalFX.FX_ElectroLine>().EndObject = coll.transform;
        }
    }
}