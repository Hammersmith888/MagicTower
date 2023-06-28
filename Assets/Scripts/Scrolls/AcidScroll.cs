using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AcidScroll : MonoBehaviour
{
    public int lifeTime; // Время работы заклинания
                         //public int minDamage, maxDamage; // min-max урон // Не используется
    public int paralizePercent;
    public int acidChance; // Вероятность эффекта отравления
    public int acidDamage; // Урон от эффекта отравления
    public float slowTime;
    //public float acidTime; // Длительность эффекта отравления

    //private int damage;
    private int chance;

    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>(); // Список персонажей, которые зашли в область отравления свитка
    private List<SpellEffects> poisonedEnemiesSpellEffects = new List<SpellEffects>();

    const float EFFECT_DESTROY_DELAY = 1f;

    void Start()
    {
        StartCoroutine(EffectLifeTimeCoroutine());
        PlayerPrefs.SetInt("SomeScrollUsed", 1);
        if (transform.parent.position.y + 0.6f > Location.instance.max)
        {
            float offset = transform.parent.position.y - ((transform.parent.position.y + 0.6f) - Location.instance.max);
            transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.parent.position.z);
        }
        if (transform.parent.position.y - 0.6f < Location.instance.min)
        {
            float offset = transform.parent.position.y - ((transform.parent.position.y - 0.6f) - Location.instance.min);
            transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.parent.position.z);
        }
    }

    private void Update()
    {
        foreach (SpellEffects poisonedEnemySpellEffects in poisonedEnemiesSpellEffects)
        {
            if (poisonedEnemySpellEffects == null)
                continue;

            poisonedEnemySpellEffects.AddEffect(SpellEffects.Effect.EffectTypes.PoisonBurn, 0.1f, acidDamage);
            poisonedEnemySpellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Slowdown, 0.1f, paralizePercent);
        }
    }

    private IEnumerator EffectLifeTimeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        StartCoroutine(DestroyEffectAfterDelay());
    }

    private IEnumerator DestroyEffectAfterDelay()
    {
        gameObject.ToggleComponent<Collider2D>(false);
        gameObject.DisableParticlesEmission();
        yield return new WaitForSeconds(EFFECT_DESTROY_DELAY);
        Destroy(transform.parent.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
            if (enemyCharacter.enemyType == EnemyType.ghoul && enemyCharacter.transform.position.x > PlayerController.Position.x + 2.8f && enemyCharacter.CurrentHealth > 0)
            {
                if (!enemies.Contains(coll.gameObject))
                {
                    enemyCharacter.Jump(new Vector2(-3.2f, 0.0f));
                }
                return;
            }
            enemies.Add(coll.gameObject);

            chance = Random.Range(0, 100);
            if (chance <= acidChance)
            {
                enemyCharacter.Hit(acidDamage, true, DamageType.EARTH);
                poisonedEnemiesSpellEffects.Add(coll.gameObject.GetComponent<SpellEffects>());
            }
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG))
        {
            enemies.Remove(coll.gameObject);

            SpellEffects enemySpellEffect = coll.gameObject.GetComponent<SpellEffects>();
            if (poisonedEnemiesSpellEffects.Contains(enemySpellEffect))
                poisonedEnemiesSpellEffects.Remove(enemySpellEffect);
        }
    }
}
