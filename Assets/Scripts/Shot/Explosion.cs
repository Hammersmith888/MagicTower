using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    /*public enum SpellEffectType { burn, paralysis, poisoning, frosting }
    public SpellEffectType spellEffectType = SpellEffectType.burn;

    public float explosionTime; // Время которое происходит взрыв (зависит от системы частиц)

    public int minDamage, maxDamage; // min-max урон
    public int spellChance; // Вероятность того, что случится дополнительный эффект после взрыва

    private int damage;
    private Collider2D collider;

	void Start () {
        damage = Random.Range(minDamage, maxDamage);
        Invoke("StopEmission", explosionTime);
        collider = GetComponent<Collider2D>();
	}

    private void StopEmission()
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
            for (int i=0; i<gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).GetComponent<ParticleSystem>())
                {
                    ParticleSystem.EmissionModule emission = gameObject.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
                    emission.enabled = false;
                }
            }
        }
        // Уничтожаем объект
        Destroy(gameObject, 1);
    }
	
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            bool chance = (Random.Range(0, 100) < spellChance) ? true : false;

            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
            SpellEffects spellEffect = coll.GetComponent<SpellEffects>();
                
            if (enemyCharacter.CurrentHealth > 0)
            {
                if (damage != 0)
                    enemyCharacter.Hit(damage);

                if (chance && enemyCharacter.CurrentHealth > 0)
                {
                    switch (spellEffectType) {
                        case SpellEffectType.burn:
                            spellEffect.Burning();
                            break;
                        case SpellEffectType.paralysis:
                            spellEffect.Paralysis();
                            break;
                        case SpellEffectType.poisoning:
                            spellEffect.StartPoisoning();
                            break;
                        case SpellEffectType.frosting:
                            spellEffect.Frosting();
                            Invoke("DisableCollider", 0.5f);
                            break;
                        default:
                            break;
                    }
                }
                    
            }   
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
            SpellEffects spellEffect = coll.GetComponent<SpellEffects>();

            if (spellEffectType == SpellEffectType.poisoning)
            {
                spellEffect.StopPoisoning();
            }
        }
    }

    private void DisableCollider()
    {
        collider.enabled = false;
    }*/
}
