using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreezScroll : MonoBehaviour {

    public int lifeTime; // Время работы заклинания

    public int freezChance; // Вероятность эффекта заморозки
    public float freezTime; // Длительность эффекта заморозки

    private int chance;
	private bool destroyCoroutineCurrentlyActive;

    public float minDamage, maxDamage;

	const float EFFECT_DESTROY_DELAY = 0.8f;
    const float RADIUS = 2.4f;

    private List<EnemyCharacter> enemiesAlreadyEntered = new List<EnemyCharacter>();

    IEnumerator Start()
    {
		PlayerPrefs.SetInt ("SomeScrollUsed", 1);
		StartCoroutine( EffectLifeTimeCoroutine ( lifeTime ) );
        if (transform.parent.position.y + 1f > Location.instance.max)
        {
            float offset = transform.parent.position.y - ((transform.parent.position.y + 1f) - Location.instance.max);
            transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.parent.position.z);
        }
        if (transform.parent.position.y - 1f < Location.instance.min)
        {
            float offset = transform.parent.position.y - ((transform.parent.position.y - 1f) - Location.instance.min);
            transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.parent.position.z);
        }
        yield return new WaitForSeconds(0.2f);
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    private void Update()
    {
        if (GetComponent<PolygonCollider2D>().enabled && EnemiesGenerator.Instance != null)
        {
            Vector2 scrollPositionOnPlane = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);

            foreach (EnemyCharacter enemy in EnemiesGenerator.Instance.enemiesOnLevelComponents)
            {
                if (!enemiesAlreadyEntered.Contains(enemy) && (enemy.enemyMover.positionOnPlane - scrollPositionOnPlane).sqrMagnitude < RADIUS * RADIUS)
                {
                    enemiesAlreadyEntered.Add(enemy);
                    OnEnemyEnter(enemy);
                }
            }
        }
    }

    // Отключаем коллайдер, чтобы эффект заморозки не действовал на новых персонажей, попавших в область действия свитка
    private void DisableCollider()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
    }

	private IEnumerator EffectLifeTimeCoroutine( float _lifeTime )
	{
		yield return new WaitForSeconds( _lifeTime );
		if( !destroyCoroutineCurrentlyActive )
		{
			StartCoroutine( DestroyEffectAfterDelay() );
		}
	}

	private IEnumerator DestroyEffectAfterDelay()
	{
		DisableCollider();
		gameObject.DisableParticlesEmission();
		yield return new WaitForSeconds( EFFECT_DESTROY_DELAY );
		Destroy( transform.parent.gameObject );
	}

    private void OnEnemyEnter(EnemyCharacter enemy)
    {
        chance = Random.Range(0, 100);
        //chance = 100;
        if (chance <= freezChance)
        {
            var freezeDamage = Random.Range(minDamage, minDamage);
            // Эффекты на персонаже
            SpellEffects spellEffects = enemy.GetComponent<SpellEffects>();
            spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.Freezing, freezTime, 1.0f, true);
            spellEffects.AddEffect(SpellEffects.Effect.EffectTypes.IceBurn, freezTime, freezeDamage);

            if (!destroyCoroutineCurrentlyActive)
            {
                StopAllCoroutines();
                StartCoroutine(EffectLifeTimeCoroutine(1f));
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);
        for (int a = 0; a < 360; a++)
        {
            float a1 = a;
            float a2 = (a + 1) % 360;

            Vector2 circlePointPlane1 = circleCenter + RADIUS * new Vector2(Mathf.Cos(a1 * Mathf.Deg2Rad), Mathf.Sin(a1 * Mathf.Deg2Rad));
            Vector2 circlePointPlane2 = circleCenter + RADIUS * new Vector2(Mathf.Cos(a2 * Mathf.Deg2Rad), Mathf.Sin(a2 * Mathf.Deg2Rad));

            Vector3 circlePoint1 = new Vector3(circlePointPlane1.x, circlePointPlane1.y * EnemyMover.WORLD_PLANE_SIN,
                circlePointPlane1.y * EnemyMover.WORLD_PLANE_COS - 6.0f);
            Vector3 circlePoint2 = new Vector3(circlePointPlane2.x, circlePointPlane2.y * EnemyMover.WORLD_PLANE_SIN,
                circlePointPlane2.y * EnemyMover.WORLD_PLANE_COS - 6.0f);

            Gizmos.DrawLine(circlePoint1, circlePoint2);
        }
    }
#endif
}
