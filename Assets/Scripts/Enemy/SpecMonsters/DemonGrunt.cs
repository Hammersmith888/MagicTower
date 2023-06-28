using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGrunt : MonoBehaviour
{
    private float enrageTimer = 2.5f, teleportTimer = 2f;

    // Use this for initialization
    private EnemyCharacter character;
    private float spawnPosX;
    [SerializeField]
    private SummonAnimationWithMaterial SpawnEffect;
    [SerializeField]
    private List<GameObject> visualObjs = new List<GameObject> ();
    [SerializeField]
    private List<Collider2D> colliders = new List<Collider2D> ();
    [SerializeField]
    private AudioClip runSFX;

    public event System.Action spawnEvent;

    IEnumerator Start()
    {
        character = GetComponent<EnemyCharacter>();
        character.canBeAutoAttacked = false;
        spawnPosX = UnityEngine.Random.Range(6f, 7.5f);
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < visualObjs.Count; i++)
        {
            visualObjs[i].SetActive(false);
        }
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }
        character.SetMovementCollisionsEnabled(false);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (transform.position.x > spawnPosX)
        {
            yield return new WaitForSeconds(0.2f);
        }
        if (character != null)
        {
            character.SetShouldPerformSpawn(true);
            if (spawnEvent != null)
            {
                spawnEvent();
            }
        }
        StartCoroutine(Enrage());
        yield return new WaitForSeconds(1.1f);
        for (int i = 0; i < visualObjs.Count; i++)
        {
           visualObjs[i].SetActive(true);
        }
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = true;
        }
        character.SetMovementCollisionsEnabled(true);
        SpawnEffect.dontUse = false;
        character.canBeAutoAttacked = true;
        SpawnEffect.StartEffect();
        StartCoroutine(Dissapear());
        yield break;
    }

    private IEnumerator Enrage()
    {
        yield return new WaitForSeconds(enrageTimer);
        if (character != null)
        {
            if (runSFX != null)
            {
                character.getEnemySoundController.walkSFX = runSFX;
            }
            character.SetShouldPerformSpawn(false);
            character.SetShouldEnrage(true);
        }
        yield break;
    }

    public void OnEnrageAnimationFinished()
    {
        character.SetShouldEnrage(false);
        character.SetMovementType(EnemyMovementType.run);
    }

    private IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(4f);
        SpawnEffect.StartHideEffect(OnDissapear);
        yield break;
    }

    private void OnDissapear()
    {
        for (int i = 0; i < visualObjs.Count; i++)
            visualObjs[i].SetActive(false);
        for (int i = 0; i < colliders.Count; i++)
            colliders[i].enabled = false;
        character.SetMovementCollisionsEnabled(false);

        StartCoroutine(DelayedReturn());
    }

    private IEnumerator DelayedReturn()
    {

        if (character != null)
        {
            character.canBeAutoAttacked = false;
            character.SetMovementType(EnemyMovementType.stop);

            yield return new WaitForSeconds(0.5f);

            Vector3 newPos = character.transform.position;
            newPos.x = UnityEngine.Random.Range(PlayerController.Instance.transform.position.x + 2f, newPos.x - 1.5f);
            newPos.y = UnityEngine.Random.Range(GameConstants.MaxBottomBorder, GameConstants.MaxTopBorder);
            character.SetPosition(newPos);

            for (int i = 0; i < visualObjs.Count; i++)
                visualObjs[i].SetActive(true);
            for (int i = 0; i < colliders.Count; i++)
                colliders[i].enabled = true;
            character.SetMovementCollisionsEnabled(true);
            SpawnEffect.StartEffect(OnTeleportEnd);
            character.SetMovementType(EnemyMovementType.run);
        }
        yield break;
    }

    private void OnTeleportEnd()
    {
        if (character != null)
        {
            character.canBeAutoAttacked = true;
            StartCoroutine(Enrage());
        }
    }
}
