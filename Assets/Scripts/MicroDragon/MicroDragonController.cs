using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroDragonController : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ShootPoint;
    public int damage;
    public float range;
    public Animation animation;

    private float time_stupm;
    private float cooldown;

    [SerializeField]
    private int upgradeItemsId;
    private LevelSettings levelSettings;
    public MyGSFU GoogleLoadedData;
    public Transform current_target;

    public AudioClip flySFX;
    public AudioClip attackSFX;

    private void Start()
    {
        levelSettings = LevelSettings.Current;
        GoogleLoadedData = MyGSFU.current;

        if (damage == 0)
        {
            damage = 50;
        }
        range = 1f;
        cooldown = 10f;
        var upgradeItem = levelSettings.upgradeItems[upgradeItemsId];
        if (!upgradeItem._active || !upgradeItem.unlock || upgradeItem.upgradeLevel == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Invoke("LoadParameters", 0.01f);
        }
        Invoke("GoIdle", 1.25f);
        animation.Play("swoop_down");

        SoundController sController = SoundController.Instanse;
        if (sController != null)
        {
            sController.Sounds.Add(gameObject.GetComponent<AudioSource>());
            sController.ReSetVolumes();
        }

        PlayWalkSFX();
    }

    public void LoadParameters()
    {
        int charUpgradeLevel = (int)levelSettings.upgradeItems[upgradeItemsId].upgradeLevel - 1;
        if (charUpgradeLevel >= 0)
        {
            damage = GoogleLoadedData.charUpgradesValues[upgradeItemsId].characterUpgradesValue[charUpgradeLevel];
            range = 1.75f * GoogleLoadedData.charUpgradesValues[upgradeItemsId].characterUpgradesRadius[charUpgradeLevel];
            cooldown = GoogleLoadedData.charUpgradesValues[upgradeItemsId].characterUpgradesSpeed[charUpgradeLevel];
        }
    }

    public void PlayWalkSFX()
    {
        if (flySFX == null)
        {
            return;
        }
        gameObject.GetComponent<AudioSource>().PlayOneShot(flySFX);
        this.CallActionAfterDelayWithCoroutine(5f, PlayWalkSFX);
    }

    public void GoIdle()
    {
        animation.Play("idle");
    }

    public void GoAttack()
    {
        animation.Play("bite");
        this.CallActionAfterDelayWithCoroutine(0.315f, ShootAt);
    }

    private void Attack()
    {
        current_target = ChooseEnemy();
        if (current_target != null)
        {
            time_stupm = Time.time;
            GoAttack();
        }
    }

    private void Update()
    {
        if ((time_stupm + cooldown) < Time.time)
        {
            Attack();
        }
    }

    public Transform ChooseEnemy()
    {
        Transform to_return;
        var total_enemies_in_range = new List<int>();

        var enemiesOnLevel = EnemiesGenerator.Instance.enemiesOnLevel;
        var enemiesOnLevelComponents = EnemiesGenerator.Instance.enemiesOnLevelComponents;
        var positionByX = transform.position.x;
        for (int i = 0; i < enemiesOnLevel.Count; i++)
        {
            if (enemiesOnLevel[i] == null || enemiesOnLevel[i].gameObject == null)
                continue;

            float dist = Mathf.Abs(positionByX - enemiesOnLevel[i].position.x);
            if (dist < range && enemiesOnLevelComponents[i].canBeAutoAttacked)
            {
                total_enemies_in_range.Add(i);
            }
        }
        if (total_enemies_in_range.Count > 0)
        {
            int index = Random.Range(0, total_enemies_in_range.Count);
            to_return = enemiesOnLevel[total_enemies_in_range[index]];
        }
        else
        {
            to_return = null;
        }
        return to_return;
    }

    private void ShootAt()
    {
        if (current_target != null)
        {
            var shootPointPosition = ShootPoint.position;
            GameObject strikeObject = Instantiate(Projectile, shootPointPosition, Quaternion.identity) as GameObject;

            var fireShot = strikeObject.GetComponent<FireShot>();
            if (fireShot != null)
            {
                fireShot.SetShotParamsAndActivate(current_target.position + new Vector3(0f, 0.5f, 0f), 10, damage);
            }
            else
            {
                var iceStrikeShot = strikeObject.GetComponent<IceStrikeShot>();
                if (iceStrikeShot != null)
                {
                    var speedValue = 50 / 10;
                    iceStrikeShot.SetIceShotParam(current_target.position - ShootPoint.position + new Vector3(0f, 0.5f, 0f), speedValue, damage);
                }
            }
            GoIdle();
        }
        else
        {
            time_stupm = 0f;
        }
    }
}
