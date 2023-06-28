using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFatty : MonoBehaviour
{
    private EnemyCharacter character;
    private float specPosX;
    private bool specMoveUsed = false;
    private bool vibrated;

    void Start()
    {
        character = GetComponent<EnemyCharacter>();
        StartCoroutine(SetNewSpecPosX());
    }

    void Update()
    {
        if (!specMoveUsed && transform.position.x < specPosX)
        {
            character.SetMovementType(EnemyMovementType.specMove);
            specMoveUsed = true;
        }

        if (character.IsSpecMove && character.IsAttacking)
        {
            character.SetMovementType(EnemyMovementType.walk);
        }

        if (!vibrated && character.attackedObject != null && character.attackedObject.CompareTag(GameConstants.WALL_TAG))
        {
            vibrated = true;
            CameraAnimations cameraAnim = Helpers.getMainCamera.GetComponent<CameraAnimations>();
            if (cameraAnim != null)
            {
                cameraAnim.CameraGeater();
                cameraAnim.VibrateIt();
            }
        }

    }

    IEnumerator SetNewSpecPosX()
    {
        if (character == null)
            yield break;

        while (character.minActionX == 0.0f && character.maxActionX == 0.0f)
            yield return null;

        specPosX = Random.Range(character.minActionX, character.maxActionX);
    }
}
