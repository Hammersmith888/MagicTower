using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    [SerializeField]
    private EnemyCharacter character;
    [HideInInspector]
    public float lastJumpTimer;

    void Start()
    {
        StartCoroutine(EnrageChecker());
    }

    private IEnumerator EnrageChecker()
    {
        while (transform.position.x > 0f)
        {
            yield return new WaitForSeconds(0.3f);
        }
        character.SetMovementType(EnemyMovementType.specMove);
        yield break;
    }
}
