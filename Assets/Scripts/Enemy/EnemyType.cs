public enum EnemyType
{
    zombie_walk,
    zombie_big,
    zombie_fire,
    zombie_boss,
    zombie_fatty,
    zombie_murderer,
    zombie_snapper,
    skeleton_grunt,
    skeleton_archer,
    skeleton_king,
    skeleton_mage,
    skeleton_swordsman,
    casket,
    skeleton_mage2,
    skeleton_strong_mage,
    skeleton_strong_mage2,
    ghoul_scavenger,
    demon_imp,
    demon_bomb,
    demon_boss,
    demon_fatty,
    demon_grunt,
    ghoul,
    ghoul_boss,
    ghoul_festering,
    ghoul_grotesque,
    burned_king,
    skeleton_tom,
    zombie_brain,
    zombie_snapper_big,
    skeleton_archer_big,
    skeleton_swordsman_big,
    aura_properties1,
    aura_properties2,
    aura_properties3,
    None
}

public static class EnemyTypeExtensions
{
    public static bool IsJumpingGhoul(this EnemyType enemyType)
    {
        return enemyType == EnemyType.ghoul || enemyType == EnemyType.ghoul_festering || enemyType == EnemyType.ghoul_scavenger;
    }
}
