using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBirdCollider : MonoBehaviour
{
    private const float ColliderDisablingBordersMultiplier = 1.2f;
    public BonusBird bonusBird;
    //[HideInInspector]
    public BirdLevelParams currentParams = new BirdLevelParams();

    private Transform transf;
    //[HideInInspector]
    public List<Vector3> wayPositions = new List<Vector3> ();
    private int currentPointId;
    private float startYrotation, useSpeed, onScreenTimer;
    private bool death, invulerableLevelReached = false;
    private Collider2D hitCollider;
    private int hitsLeft;
    private bool wasClicked = false;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private GameObject explosion, shadow;
    [SerializeField]
    private BonusBirdSounds birdSounds;

    private void Start()
    {
        _animator.SetTrigger(AnimationPropertiesCach.instance.walkAnim);
        transf = transform;
        startYrotation = transf.rotation.y;
        hitCollider = transf.GetComponent<Collider2D>();
        if (!currentParams.flyOnTop)
        {
            hitCollider.enabled = false;
        }

        if (currentParams.maxFreeTime < 5f)
        {
            currentParams.maxFreeTime = currentParams.spawnEachSeconds - 3f;
            if (currentParams.maxFreeTime < 12f)
            {
                currentParams.maxFreeTime = 12f;
            }
        }
        if (currentParams.maxFreeTime >= 30)
            currentParams.maxFreeTime = 30;

        currentPointId = 1;
        pointsPassed = currentParams.soarEveryPoint - 1;
        hitsLeft = currentParams.hitsNeed;
        useSpeed = currentParams.flySpeed * 1f;
        shadow.SetActive(false);
        //transf.position = wayPositions [0];
        Vector3 pos = Vector3.zero;
        try
        {
            if (currentPointId < wayPositions.Count)
            {
                pos = wayPositions[currentPointId];
            }
        }
        catch (System.Exception)
        {
        }
        if (pos != Vector3.zero)
        {
            StartCoroutine(FlyUpdate(wayPositions[currentPointId]));
        }
        if (birdSounds == null)
        {
            birdSounds = GetComponent<BonusBirdSounds>();
            if (birdSounds == null)
            {
                birdSounds = gameObject.AddComponent<BonusBirdSounds>();
            }
        }
    }

    private void OnMouseDown()
    {
        BirdClicked();
    }

    private int pointsPassed;

    public IEnumerator FlyUpdate(Vector3 flyPlace)
    {
        yield return new WaitForSeconds(0.3f);
        onScreenTimer += 0.3f;
        Vector3 currentFlyPos = transf.position;
        float angle = -Mathf.Atan2(flyPlace.y - currentFlyPos.y, flyPlace.x - currentFlyPos.x) * 180 / Mathf.PI + 90;
        float timeStep = 0.02f;
        var ways = wayPositions == null ? 0 : wayPositions.Count; 
        if (!currentParams.flyOnTop)
        {
            _animator.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        
        while (transf.position != flyPlace && !death && (onScreenTimer < currentParams.maxFreeTime || currentPointId >= (ways > 1 ? ways - 1 : 0) ))
        {
            currentFlyPos = Vector3.MoveTowards(transf.position, flyPlace, useSpeed * timeStep);
            transf.position = currentFlyPos;
            if (shadow.transform.position.y > GameConstants.MaxTopBorder * 1.2f || shadow.transform.position.y < GameConstants.MaxBottomBorder * 1.25f)
            {
                shadow.SetActive(false);
            }
            else
            {
                shadow.SetActive(true);
            }
            if (!currentParams.flyOnTop)
            {
                EnableHitCollider(currentFlyPos.y >= GameConstants.MaxBottomBorder * ColliderDisablingBordersMultiplier && currentFlyPos.y <= GameConstants.MaxTopBorder * ColliderDisablingBordersMultiplier);
            }
            yield return new WaitForSeconds(timeStep);
            onScreenTimer += timeStep;
        }
        useSpeed = currentParams.flySpeed;
        currentPointId++;
        pointsPassed++;
        if (pointsPassed == currentParams.soarEveryPoint && onScreenTimer < currentParams.maxFreeTime)
        {
            
            float soarTimer = currentParams.soarTime;
            while (soarTimer > 0f && !death)
            {
                yield return new WaitForSeconds(timeStep);
                onScreenTimer += timeStep;
                soarTimer -= timeStep;
            }
            pointsPassed = 0;
        }

        if (onScreenTimer > currentParams.maxFreeTime)
        {
            currentPointId = wayPositions.Count - 1;
        }
        if (death)
        {
            yield break;
        }
        if (currentPointId < wayPositions.Count || gameObject.transform.localPosition.y>2.4f|| gameObject.transform.localPosition.y<-2.4f)
        {
            StartCoroutine(FlyUpdate(wayPositions[currentPointId]));
        }
        else
        {
            Destroy(gameObject);
        }
        yield break;
    }

    private void EnableHitCollider(bool on)
    {
        if (invulerableLevelReached != !on)
        {
            invulerableLevelReached = !on;
            hitCollider.enabled = on;
        }
    }

    public bool IsCollididerEnabled()
    {
        if (hitCollider == null)
            return false;

        return hitCollider.enabled;
    }

    public int GetPassedPoints()
    {
        return pointsPassed;
    }

    public bool WasClicked()
    {
        return wasClicked;
    }

    public void OnDeath()
    {
        GameObject postEffect = Instantiate(explosion, transform.position - new Vector3(0, 0, 1f), Quaternion.identity) as GameObject;
        Destroy(postEffect, 0.6f);
        // Eugene unblock Tap when kill bird
        TapController.Current.SetEnebleTap();
    }

   

    public void BirdClicked()
    {
        if (invulerableLevelReached)
        {
            return;
        }


        float turnAngle = -180;
        if (transform.position.x > 6.5f)
        {
            turnAngle = 0f;
        }

        hitsLeft--;
        wasClicked = true;
        if (hitsLeft <= 0)
        {
            // Eugene block Tap when kill bird
            TapController.Current.IsCanShoot = false;
            List<CasketDrop> dropsVariants = EnemiesGenerator.Instance.enemyWaves[EnemiesGenerator.Instance.currentWave - 1].casket_drops;
            List<int> numbersVariants = new List<int>();
            for (int i = 0; i < dropsVariants.Count; i++)
            {
                if (dropsVariants[i].content_id >= 3)
                {
                    numbersVariants.Add(dropsVariants[i].content_id);
                    break;
                }
            }
            if (numbersVariants.Count > 0)
            {
                GameObject finalDrop = Instantiate(Casket.LoadDropPrefab(numbersVariants[UnityEngine.Random.Range(0, numbersVariants.Count)]).Item2, transf.position + Vector3.back, transf.position.x > 3f ? Quaternion.identity : Quaternion.Euler(new Vector3(0, -180f, 0))) as GameObject;
                if (finalDrop.transform.position.y > GameConstants.MaxTopBorder)
                {
                    finalDrop.transform.position = new Vector3(finalDrop.transform.position.x, GameConstants.MaxTopBorder * 0.95f, finalDrop.transform.position.z);
                }
                if (finalDrop.transform.position.y < GameConstants.MaxBottomBorder)
                {
                    finalDrop.transform.position = new Vector3(finalDrop.transform.position.x, GameConstants.MaxBottomBorder * 0.95f, finalDrop.transform.position.z);
                }
                EnemiesGenerator.Instance.dropsOnLevel.Add(finalDrop);
            }
            else
            {
                EnemiesGenerator.SpawnCoin(transf.position + Vector3.back, Quaternion.Euler(new Vector3(0, turnAngle, 0)), true);
            }
            death = true;
            birdSounds.PlayDeathSFX();
            OnDeath();
            Destroy(gameObject);
        }
        else
        {
            birdSounds.PlayDamageSFX();
            EnemiesGenerator.SpawnCoin(transf.position + Vector3.back, Quaternion.Euler(new Vector3(0, turnAngle, 0)), true);
            _animator.SetTrigger(AnimationPropertiesCach.instance.getHitAnim);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(new Vector3(-10f, GameConstants.MaxTopBorder, 0f), new Vector3(10f, GameConstants.MaxTopBorder, 0f));
        Gizmos.DrawLine(new Vector3(-10f, GameConstants.MaxBottomBorder, 0f), new Vector3(10f, GameConstants.MaxBottomBorder, 0f));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(-10f, GameConstants.MaxTopBorder * ColliderDisablingBordersMultiplier, 0f), new Vector3(10f, GameConstants.MaxTopBorder * ColliderDisablingBordersMultiplier, 0f));
        Gizmos.DrawLine(new Vector3(-10f, GameConstants.MaxBottomBorder * ColliderDisablingBordersMultiplier, 0f), new Vector3(10f, GameConstants.MaxBottomBorder * ColliderDisablingBordersMultiplier, 0f));
    }
#endif
}
