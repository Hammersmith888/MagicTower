
using System.Collections.Generic;

public static class EnemyInfoIdsUnlockOrder
{
    public static readonly EnemyType[] EnemyIdsOrder =
    {
        EnemyType.zombie_walk,
        EnemyType.zombie_big,
        EnemyType.skeleton_mage,
        EnemyType.zombie_fire,
        EnemyType.zombie_snapper,
         
        EnemyType.zombie_murderer,
        EnemyType.zombie_fatty,
        
        EnemyType.zombie_boss,
        EnemyType.skeleton_swordsman,
        EnemyType.skeleton_archer,
        EnemyType.skeleton_grunt,
        EnemyType.zombie_snapper_big,
        EnemyType.skeleton_strong_mage,
        EnemyType.skeleton_archer_big,
        EnemyType.skeleton_king,
        EnemyType.skeleton_swordsman_big,
        EnemyType.burned_king,
        EnemyType.ghoul,
        EnemyType.ghoul_scavenger,
        EnemyType.ghoul_grotesque,
        EnemyType.ghoul_festering,
        EnemyType.ghoul_boss,
        EnemyType.demon_imp,
        EnemyType.demon_bomb,
        EnemyType.demon_fatty,
        EnemyType.demon_grunt,
        EnemyType.demon_boss,
        EnemyType.aura_properties1,
        EnemyType.aura_properties2,
        EnemyType.aura_properties3,
    };


    public static int GetInfoUnlockOrderIndex(this EnemyType enemyType)
    {
        return GetInfoUnlockIndexForEnemyType(enemyType);
    }

    public static int GetInfoUnlockIndexForEnemyType(EnemyType enemyType)
    {
        for (int i = 0; i < EnemyIdsOrder.Length; i++)
        {
            if (EnemyIdsOrder[i] == enemyType)
            {
                return i;
            }
        }
        return 0;
    }


    public static EnemyType GetEnemyTypeByInfoUnlockIndex(int index)
    {
        return EnemyIdsOrder[index];
    }

    public static int SortingByInfoUnlockIndex(EnemyType a, EnemyType b)
    {
        var aInfoIndex = a.GetInfoUnlockOrderIndex();
        var bInfoIndex = b.GetInfoUnlockOrderIndex();
        if (aInfoIndex > bInfoIndex)
        {
            return 1;
        }
        else if(aInfoIndex < bInfoIndex)
        {
            return -1;
        }
        return 0;
    }

    //public static EnemyType BySortLevel(int value)
    //{
    //    var l = r.OrderBy(key => key.Key);
    //    return InfoLoaderConfig.Instance.GetEnemyTypesOnLevel(mainscript.CurrentLvl, true)[value];
    //}

}
