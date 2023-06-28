using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBase : MonoBehaviour
{
    public static bool IsAlreaddy(int _enemyID, List<EnemyCharacter> enemies)
    {
        int count = enemies.Count;
        for (int i = 0; i < count; i++)
        {
            if (enemies[i] != null && _enemyID == enemies[i].gameObject.GetInstanceID())
            {
                return true;
            }
        }
        return false;
    }

    public static void ApplyDamage(EnemyCharacter enemy, int damage, DamageType spellDamageType, float critOnlyInfo = 0, bool canInterruptAttack = false)
    {
        // Эффекты на персонаже
        var spellEffects = enemy.SpellEffects;
        // Наносим урон персонажу
        // Если на персонаже есть эффект заморозки или паралич, то наносим урон без анимации получения урона
        if (spellEffects != null)
        {
            bool freezedOrParalysed = spellEffects.FreezedOrParalysed;
            enemy.Hit(damage, !freezedOrParalysed, spellDamageType, canInterruptAttack, critOnlyInfo);
        }
    }


    protected List<EnemyCharacter> enemies; // Каждого персонажа необходимо атаковать только один раз, здесь список персонажей, которых уже атаковали

	protected bool AlreadyAdded(int _enemyID)
	{
        return IsAlreaddy(_enemyID, enemies);
	}
}
