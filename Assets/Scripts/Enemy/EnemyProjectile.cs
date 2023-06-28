using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyCharacter eChar;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float animDeltaX;

    [SerializeField]
    private Transform origTransform;
    [SerializeField]
    private Transform boneTransform;
    public Transform cloneTransform;
    [SerializeField]
    private GameObject collisionEffect;

    private bool isMoving = true;
    private Vector3 startPos, moveTo, newPos;
    private Quaternion startRotation;
    private bool attackStarted;

    float xOffsetByYPositionOnField;
    private float currentXRotation;
    private Vector3 startRotationEular;

    private Color projectileColor;

    private void Start()
    {
        isMoving = true;
        newPos = startPos;
    }

    private void LateUpdate()
    {
        if (!isMoving)
        {
            if (!attackStarted)
            {
                attackStarted = true;
                startPos = boneTransform.position;
                startRotation = boneTransform.rotation;
                startRotationEular = startRotation.eulerAngles;
                currentXRotation = startRotationEular.x;
                xOffsetByYPositionOnField = Mathf.Lerp(-0.25f, 1f, Mathf.InverseLerp(GameConstants.MaxTopBorder, GameConstants.MaxBottomBorder, transform.position.y));
            }

            newPos = cloneTransform.position;
            moveTo.y = newPos.y;
            moveTo.z = newPos.z;
            var position = Vector3.MoveTowards(newPos, moveTo, Time.deltaTime * -speed);
            currentXRotation += Time.deltaTime * rotationSpeed;
            cloneTransform.SetPositionAndRotation(position, Quaternion.Euler(currentXRotation, startRotationEular.y, startRotationEular.z));
            if (newPos.x + animDeltaX + xOffsetByYPositionOnField < moveTo.x)
            {
                eChar.Damage();
                attackStarted = false;
                enabled = false;
                if (collisionEffect != null)
                {
                    GameObject afterEffect = Instantiate(collisionEffect, cloneTransform.position + Vector3.back, Quaternion.identity) as GameObject;
                    Destroy(afterEffect, 0.7f);
                }
                this.CallActionAfterDelayWithCoroutine(0.5f, HidePrjective);
            }
            return;
        }

        newPos = boneTransform.position;
        cloneTransform.SetPositionAndRotation(newPos, boneTransform.rotation);
    }

    public void OnAttackAnimationStarted()
    {
        enabled = true;

        if (eChar.attackedObject != null)
        {
            MeshRenderer meshRenderer = cloneTransform.GetComponent<MeshRenderer>();
            if (eChar.attackedObject.CompareTag(GameConstants.BARRIER_TAG))
            {
                if (projectileColor == Color.clear)
                {
                    projectileColor = meshRenderer.material.color;
                }
                meshRenderer.material.color = Color.clear;
            }
            else
            {
                meshRenderer.material.color = Color.white;
                meshRenderer.enabled = true;
            }

            ResetProjectiveState();
            moveTo = new Vector3(5.0f, 0.0f, 0.0f);
        }

        isMoving = true;
    }

    public void OnProjectileTime()
    {
        isMoving = false;
    }

    public void HidePrjective()
    {
        cloneTransform.GetComponent<MeshRenderer>().enabled = false;
        cloneTransform.GetComponent<MeshRenderer>().material.color = Color.clear;
    }

    private void ResetProjectiveState()
    {
        cloneTransform.position = startPos;
        cloneTransform.rotation = startRotation;
        cloneTransform.gameObject.SetActive(true);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, moveTo);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, moveTo + Vector3.left * animDeltaX);
    }
#endif
}
