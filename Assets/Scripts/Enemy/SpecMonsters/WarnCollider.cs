using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnCollider : MonoBehaviour
{
    public CircleCollider2D AttackCollider;
    public Transform parentBall;

    void Update()
    {
        if (parentBall != null)
        {
            transform.position = parentBall.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(GameConstants.ENEMY_TAG) && coll.transform.position.x > 0f && AttackCollider != null)
        {
            EnemyCharacter enemyCharacter = coll.GetComponent<EnemyCharacter>();
            if (enemyCharacter != null && enemyCharacter.enemyType == EnemyType.ghoul)
            {
                var enemyCharPosition = enemyCharacter.transform.position;
                float yPos = GameConstants.MaxTopBorder * 0.8f;
                if (Mathf.Abs(enemyCharPosition.y) > AttackCollider.radius * 2)
                {
                    yPos = -enemyCharPosition.y;
                }
                else if (enemyCharPosition.y > 0)
                {
                    yPos = GameConstants.MaxBottomBorder * 0.8f;
                }
                yPos = Mathf.Clamp(yPos, GameConstants.MaxBottomBorder * 0.8f, GameConstants.MaxTopBorder * 0.8f);
                enemyCharacter.Jump(new Vector2(0.0f, yPos - enemyCharPosition.y));
            }
        }
    }
}
