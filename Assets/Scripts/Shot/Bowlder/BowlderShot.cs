using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BowlderShot : SpellBase
{
    private const float FADEOUT_TIME = 0.5f;
    #region VARIABLES
    public int minDamage, maxDamage; // min-max урон
                                     //public int radius; // Радиус
    public float speed; // Скорость полета

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение

    private int damage;
    private float speedValue;
    private const float widthInUnits = 13f; // Ширина игрового поля в юнитах

    private List<GameObject> enemies; // Каждого персонажа необходимо атаковать только один раз, здесь список персонажей, которых уже атаковали

    private float startXposition;
    [SerializeField]
    private List<ParticleSystem> particles = new List<ParticleSystem> ();
    [SerializeField]
    private SpriteRenderer shadow;
    private List<float> startAlpha = new List<float>();

    private Vector3 pos;

    #endregion
    [SerializeField]
    private GameObject warnCollider;
    Vector3 startPos;

    private const float RADIUS = 1f;

    void Start()
    {
        startPos = transform.position;
        startXposition = transform.position.x;
        speedValue = widthInUnits / (speed / 10f); // Вычисляем скорость в юнитах в секунду. Делим на 10 т.к. скорость в таблице задается как 10 (за 1 сек все поле), 20 (за 2 сек) и т.д.
        damage = Random.Range(minDamage, maxDamage); // Вычисляем величину случайного урона
        enemies = new List<GameObject>();
        for (int i = 0; i < particles.Count; i++)
        {
            startAlpha.Add(particles[i].main.startColor.color.a);
        }
        startAlpha.Add(shadow.color.a);
        WarnGhouls();
    }

    // Активируется после получения вектора направления движения
    public void Activation(Vector3 targetPosition)
    {
        currentlyOnField = true;
        pos = transform.position;
        // Если начало вектора (координата x) направления движения находится в левой части от начальной точки движения
        if (targetPosition.x < pos.x || targetPosition.x - pos.x < 1f)
        {
            GetComponent<CircleCollider2D>().radius *= 2f;
            //_targetDirection = new Vector3(-_targetDirection.x, _targetDirection.y, _targetDirection.z);
        }
         
        pos.z = targetPosition.z = 0; // Обнуляем координату Z 
        targetDirection = (targetPosition - pos).normalized;
        active = true;
        RegisterForUpdate();
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

    override public void UpdateObject()
    {
        if (active)
        {
            pos = transform.position;
            pos += targetDirection * (Time.deltaTime * speedValue);
            transform.position = pos;
            if ((pos.y > GameConstants.MaxTopBorder || pos.y < GameConstants.MaxBottomBorder) && !dissStarted)
            {
                dissStarted = true;
                StartCoroutine(SingleDissappear());
            }
            if (currentlyOnField && !dissStarted && pos.x - startXposition > DefaultMaxShotFlyDistance)
            {
                OnOutOfGameField();
            }

            if (EnemiesGenerator.Instance != null && !dissStarted)
            {
                Vector2 bowlerPositionOnPlane = new Vector2(transform.position.x, transform.position.y / EnemyMover.WORLD_PLANE_SIN);

                int enemiesCount = EnemiesGenerator.Instance.enemiesOnLevelComponents.Count;
                for (int i = enemiesCount - 1; i >= 0; i--)
                {
                    EnemyCharacter enemy = EnemiesGenerator.Instance.enemiesOnLevelComponents[i];
                    if (!AlreadyDamaged(enemy.gameObject))
                    {
                        if (enemy.enemyMover == null)
                            continue;

                        float dx = enemy.enemyMover.positionOnPlane.x - bowlerPositionOnPlane.x;
                        float dy = enemy.enemyMover.positionOnPlane.y - bowlerPositionOnPlane.y;
                        float r = RADIUS + enemy.enemyMover.movementRadius;
                        if (dx * dx + dy * dy < r * r)
                            Hit(enemy);
                    }
                }
            }
        }
    }

    private bool dissStarted;
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

            float timePassed = 0;
            float alphaMultiplier;
            float startSpeedValue = speedValue;
            while (timePassed < FADEOUT_TIME)
            {
                timePassed += Time.deltaTime;
                alphaMultiplier = 1f - (timePassed / FADEOUT_TIME);
                speedValue = startSpeedValue * alphaMultiplier;
                for (i = 0; i < colorHolders.Length; i++)
                {
                    colorHolders[i].alpha = alphaMultiplier * startAlphaValues[i];
                }

                yield return null;
            }
        }
        UnregisterFromUpdate();
        Destroy(gameObject);
    }

    void Hit(EnemyCharacter hittedCharacter)
    {
        hittedCharacter.Hit(damage, true, DamageType.EARTH);

        // По Y случайное смещение вверх или вниз
        float offsetY = (Random.Range(0, 2) == 0 ? 0.1f : -0.1f);

        // Смещение персонажа
        hittedCharacter.SetPosition(hittedCharacter.transform.position + new Vector3(0.2f, offsetY, 0.0f));

        // Добавляем персонажа в список
        enemies.Add(hittedCharacter.gameObject);
    }

    // Персонаж уже был атакован?
    private bool AlreadyDamaged(GameObject _enemy)
    {
        if (enemies == null)
            return false;

        foreach (GameObject go in enemies)
        {
            if (go.GetInstanceID() == _enemy.GetInstanceID())
            {
                return true;
            }
        }
        return false;
    }
}