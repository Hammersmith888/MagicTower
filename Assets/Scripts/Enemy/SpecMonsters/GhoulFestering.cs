using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulFestering : MonoBehaviour
{
    private EnemyCharacter character;

    [SerializeField]
    private GameObject onDeathExplosion, explosionPos;
    private float jumpDelay = 5.5f;
    private float minDistance;
    [HideInInspector]
    public bool canJump = true;
    private float jumpTimer = 0.0f;

    private bool isSummonedByGhoulBoss = false;
    private Transform socketTransform;
    private bool thrown = false;
    private float thrownTime;
    private Vector2 startPosition;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        jumpDelay = UnityEngine.Random.Range(jumpDelay / 2f, jumpDelay * 1.5f);
        minDistance = PlayerController.Position.x + 1.8f;
    }

    public void InitAsGhoulBossSummoned(Transform newSocketTransform)
    {
        isSummonedByGhoulBoss = true;
        socketTransform = newSocketTransform;
        canJump = false;
        GetComponent<EnemyCharacter>().disableDrop = true;
        GetComponent<Collider2D>().enabled = false;
    }

    public void Throw()
    {
        thrown = true;
        thrownTime = Time.time;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (isSummonedByGhoulBoss)
        {
            if (!thrown)
            {
                if (socketTransform != null)
                    character.SetPosition(socketTransform.position);
            }
            else
            {
                float animProgress = (Time.time - thrownTime) / 0.4f;
                if (animProgress >= 1.0f)
                {
                    character.SetPosition(startPosition - new Vector2(2.5f, 1.0f));
                    character.SetMovementType(EnemyMovementType.walk);
                    canJump = true;
                    GetComponent<Collider2D>().enabled = true;
                    isSummonedByGhoulBoss = false;

                    if (transform.position.x > PlayerController.Position.x + 1.8f)
                        character.Jump(new Vector2(-1.5f, 0.0f));
                }
                else
                {
                    character.SetPosition(Vector3.Lerp(startPosition, startPosition - new Vector2(2.5f, 1.0f), animProgress));
                    character.SetMovementType(EnemyMovementType.roll);
                }
            }
        }
        else
        {
            if (transform.position.x > minDistance)
            {
                jumpTimer += Time.deltaTime;
                if (jumpTimer > jumpDelay)
                {
                    jumpTimer = 0.0f;
                    if (canJump && !character.SpellEffects.FreezedOrParalysed)
                    {
                        character.Jump(new Vector2(-1.5f, 0.0f));
                    }
                }
            }
        }
    }

    public void OnDeath()
    {
        GameObject explosion = Instantiate(onDeathExplosion, explosionPos.transform.position - new Vector3(0, 0, 1f), Quaternion.identity) as GameObject;
        Destroy(explosion, 0.6f);
    }
}
