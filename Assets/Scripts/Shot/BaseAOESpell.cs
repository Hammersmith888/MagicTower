using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAOESpell : SpellBase
{
    [SerializeField]
    protected Vector2 effectAreaSize;

    protected List<EnemyCharacter> enemies; // Каждого персонажа необходимо атаковать только один раз, здесь список персонажей, которых уже атаковали
    protected List <float> enemiesTimers;
    public float damageTimer;
    protected int damage;

    abstract protected DamageType SpellDamageType { get; }

    // Активируется после получения вектора направления движения
    public virtual void Activation(Vector3 position)
    {
        var offset = (position.y + effectAreaSize.y / 2f) - GameConstants.MaxTopBorder;
        if (offset > 0)
        {
            position.y -= offset;
        }
        else
        {
            offset = (position.y - effectAreaSize.y / 2f) - GameConstants.MaxBottomBorder;
            if (offset < 0)
            {
                position.y -= offset;
            }
        }
        transform.position = new Vector3(position.x, position.y, 0);
    }

    protected bool IsAlreadyAdded(int enemyID)
    {
        return ExplosionBase.IsAlreaddy(enemyID, enemies);
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        int objID = coll.gameObject.GetInstanceID();
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null && enemies[i].gameObject.GetInstanceID() == objID)
            {
                enemiesTimers.RemoveAt(i);
                enemies.RemoveAt(i);
                break;
            }
        }
    }

    private void Update()
    {
        if (damageTimer == 0)
        {
            damageTimer = 3f;
        }

        int count = enemies.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemiesTimers[i] + damageTimer <= Time.time)
            {
                if (enemies[i] != null)
                {
                    var enemyCharacter = enemies[i];
                    enemiesTimers[i] = Time.time;
                    ApplyDamage(enemyCharacter);
                }
            }
        }
    }

    protected void ApplyDamage(EnemyCharacter enemy, float critOnlyInfo = 0, bool canInterruptAttack = false)
    {
        ExplosionBase.ApplyDamage(enemy, damage, SpellDamageType, critOnlyInfo, canInterruptAttack);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(effectAreaSize.x, effectAreaSize.y, 0f));
    }
#endif
}
