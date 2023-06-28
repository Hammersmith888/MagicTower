using UnityEngine;

public class DemonFattyBullet : SpellBase
{
    public float speed; // Скорость полета

    public DemonFattyFireExplosion explosion; // Взрыв

    private Vector3 targetDirection; // Направление в котором летит шар
    private bool active; // Когда true - начинается движение
    public int damage = 30;

    private float speedValue;
    private const float widthInUnits = 13f; // Ширина игрового поля в юнитах
    private float startXposition;
    private Transform transf;
    private Vector3 pos;

    const float EXPLOSION_DISABLE_DELAY_TIME = 1.1f;

    void Start()
    {
        startXposition = transform.position.x;
        speedValue = widthInUnits;
        Activation();
        if (explosion != null)
            explosion.damage = damage;
    }

    private void Activation()
    {
        transf = transform;
        pos = transform.position;

        targetDirection = GameObject.FindGameObjectWithTag("Wall").transform.position;
        targetDirection.x -= 0.1f;
        active = true;
        RegisterForUpdate();
    }

    override public void UpdateObject()
    {
        if (active)
        {
            pos = transf.position;
            targetDirection.y = pos.y;
            targetDirection.z = pos.z;
            transf.position = Vector3.MoveTowards(pos, targetDirection, Time.deltaTime * speedValue);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Wall"))
        {
            GetComponent<Collider2D>().enabled = false;
            active = false;
            UnregisterFromUpdate();
            StopEmission();
            explosion.gameObject.SetActive(true);
            Destroy(gameObject, EXPLOSION_DISABLE_DELAY_TIME);
        }
    }

    private void StopEmission()
    {
        // Останавливаем излучение у всех систем частиц эффекта
        // Дети
        if (transf.childCount != 0)
        {
            ParticleSystem particles;

            for (int i = 1; i < transf.childCount; i++)
            {
                particles = transf.GetChild(i).GetComponent<ParticleSystem>();

                if (particles != null && particles.name != "Explosion")
                {
                    ParticleSystem.EmissionModule emission = particles.emission;
                    emission.enabled = false;
                }
            }
        }
    }
}