using UnityEngine;
using System.Collections;

public class MinesScroll : MonoBehaviour {

    public GameObject mineExp; // Эффект взрыва мины
    private int damage; // Урон от мины
	public int lifeTime; // Время существования мины
	public int minDamage, maxDamage; // Минимальный и максимальный урон от мины
	public float radius; // Радиус коллайдера мины
	public int parts; // Количество мин

    EnemiesGenerator enemiesGenerator;

    public void SetMineParam(int _damage, float _scale)
    {
		PlayerPrefs.SetInt ("SomeScrollUsed", 1);
		damage = minDamage;
        //damage = _damage;
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    private void Start()
    {
        if (transform.position.x <= -4 && transform.position.y > 0.5f)
            transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (enemiesGenerator == null)
            enemiesGenerator = EnemiesGenerator.Instance;

        if (enemiesGenerator != null)
        {
            Vector2 scrollPositionOnPlane = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);

            int enemiesCount = enemiesGenerator.enemiesOnLevelComponents.Count;
            for (int i = enemiesCount - 1; i >= 0; i--)
            {
                EnemyCharacter enemy = enemiesGenerator.enemiesOnLevelComponents[i];
                if (enemy != null)
                {
                    try
                    {
                        if ((enemy.enemyMover.positionOnPlane - scrollPositionOnPlane).sqrMagnitude < (radius + enemy.enemyMover.movementRadius) * (radius + enemy.enemyMover.movementRadius))
                            OnEnemyEnter(enemy);
                    }
                    catch { }
                }
            }
        }
    }

    private void OnEnemyEnter(EnemyCharacter enemy)
    {
        if (enemy.CurrentHealth > 0)
        {
            // Эффекты на персонаже
            SpellEffects spellEffects = enemy.GetComponent<SpellEffects>();
            // Наносим урон персонажу
            // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
            if (spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Freezing) || spellEffects.IsEffectApplyed(SpellEffects.Effect.EffectTypes.Paralysis))
                enemy.Hit(damage, false, DamageType.NONE);
            else
                enemy.Hit(damage, true, DamageType.NONE);
        }
        SoundController.Instanse.playActivateMineFieldSFX();

        Instantiate(mineExp, transform.position, Quaternion.identity);

        CameraAnimations cameraAnim = Helpers.getMainCamera.GetComponent<CameraAnimations>();
        if (cameraAnim != null)
        {
            cameraAnim.CameraGeater();
            cameraAnim.VibrateIt();
        }
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);
        for (int a = 0; a < 360; a++)
        {
            float a1 = a;
            float a2 = (a + 1) % 360;

            Vector2 circlePointPlane1 = circleCenter + radius * new Vector2(Mathf.Cos(a1 * Mathf.Deg2Rad), Mathf.Sin(a1 * Mathf.Deg2Rad));
            Vector2 circlePointPlane2 = circleCenter + radius * new Vector2(Mathf.Cos(a2 * Mathf.Deg2Rad), Mathf.Sin(a2 * Mathf.Deg2Rad));

            Vector3 circlePoint1 = new Vector3(circlePointPlane1.x, circlePointPlane1.y * EnemyMover.WORLD_PLANE_SIN,
                circlePointPlane1.y * EnemyMover.WORLD_PLANE_COS - 6.0f);
            Vector3 circlePoint2 = new Vector3(circlePointPlane2.x, circlePointPlane2.y * EnemyMover.WORLD_PLANE_SIN,
                circlePointPlane2.y * EnemyMover.WORLD_PLANE_COS - 6.0f);

            Gizmos.DrawLine(circlePoint1, circlePoint2);
        }
    }
#endif
}
