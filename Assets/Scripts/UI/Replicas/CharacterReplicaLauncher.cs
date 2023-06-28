
using UnityEngine;
using UI;
using System.Collections;

public class CharacterReplicaLauncher : MonoBehaviour
{
    [SerializeField]
    public Vector3 pointToCheckOffset;
    [SerializeField]
    private GameObject[] characterRenderers;

    private Vector3 posisiton;
    private EnemyType enemyType;

    [HideInInspector]
    public bool showReplicaManually;

    private void Start()
    {
        enemyType = EnemyType.casket;//Casket because there is no None options :/
        var enemyCharacter = GetComponentInParent<EnemyCharacter>();
        if (enemyCharacter != null)
        {
            enemyType = enemyCharacter.enemyType;
        }
    }

    private void LateUpdate()
    {
        if (showReplicaManually)
        {
            return;
        }
        posisiton = transform.position + pointToCheckOffset;
        if (Helpers.getMainCamera.WorldToViewportPoint(posisiton).x < 1f)
        {
            if (enemyType != EnemyType.demon_grunt)
            {
                enabled = false;
                //Debug.Log($"repl: ssd", gameObject);
                //var objs = new GameObject[characterRenderers.Length + PlayerController.Instance.m_mageRendererObjects.Length];
                //for (int i = 0; i < characterRenderers.Length; i++)
                //{
                //    objs[i] = characterRenderers[i];
                //}
                //for (int i = 0; i < PlayerController.Instance.m_mageRendererObjects.Length; i++)
                //{
                //    objs[i + characterRenderers.Length] = PlayerController.Instance.m_mageRendererObjects[i];
                //}
                if ( enemyType == EnemyType.zombie_fatty)
                {
                    if (transform.parent.position.y < 0f)
                        StartCoroutine(FattyReplicaDelay());
                }
                else
                    ReplicasConditionsChecker.Current.ShowEnemyCharacterReplica(transform, enemyType, characterRenderers);
            }
            else if (transform.parent.position.y < -1f)
            {
                enabled = false;
                ReplicasConditionsChecker.Current.ShowEnemyCharacterReplica(transform, enemyType, characterRenderers);
            }
            
        }
    }

    private IEnumerator FattyReplicaDelay()
    {
        yield return new WaitForSeconds(1.5f);
        ReplicasConditionsChecker.Current.ShowEnemyCharacterReplica(transform, enemyType, characterRenderers);
    }

    public void ShowReplicaManual()
    {
        GameObject[] obj = new GameObject[characterRenderers.Length + PlayerController.Instance.m_mageRendererObjects.Length];
        for (int i = 0; i < characterRenderers.Length; i++)
        {
            obj[i] = characterRenderers[i];
        }
        for (int i = 0; i < PlayerController.Instance.m_mageRendererObjects.Length; i++)
        {
            obj[i + characterRenderers.Length] = PlayerController.Instance.m_mageRendererObjects[i];
        }
        ReplicasConditionsChecker.Current.ShowEnemyCharacterReplica(transform, enemyType, obj);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + pointToCheckOffset);
        Gizmos.DrawSphere(transform.position + pointToCheckOffset, 0.2f);
    }
#endif
}
