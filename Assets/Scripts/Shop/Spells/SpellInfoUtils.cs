
using UnityEngine;

public static class SpellInfoUtils
{ 
    public static Spell.SpellType GetSpellTypeBySpellDataIndex(int spellNumber)
    {
        switch (spellNumber)
        {
            case 0:
                return Spell.SpellType.FireBall;
            case 1:
                return Spell.SpellType.Lightning;
            case 2:
                return Spell.SpellType.IceStrike;
            case 3:
                return Spell.SpellType.EarthBall;
            case 4:
                return Spell.SpellType.FireWall;
            case 5:
                return Spell.SpellType.ChainLightning;
            case 6:
                return Spell.SpellType.IceBreath;
            case 7:
                return Spell.SpellType.Boulder;
            case 8:
                return Spell.SpellType.Meteor;
            case 9:
                return Spell.SpellType.ElecticPool;
            case 10:
                return Spell.SpellType.Blizzard;
            case 11:
                return Spell.SpellType.FireDragon;
            case 12:
                return Spell.SpellType.AcidSpray_Unused;
            default:
                return Spell.SpellType.FireBall;
        }
    }

    public static int GetSpellSpellDataIndexBySpellType(Spell.SpellType spellType)
    {
        switch (spellType)
        {
            case Spell.SpellType.FireBall:
                return 0;
            case Spell.SpellType.Lightning:
                return 1;
            case Spell.SpellType.IceStrike:
                return 2;
            case Spell.SpellType.EarthBall:
                return 3;
            case Spell.SpellType.FireWall:
                return 4;
            case Spell.SpellType.ChainLightning:
                return 5;
            case Spell.SpellType.IceBreath:
                return 6;
            case Spell.SpellType.Boulder:
                return 7;
            case Spell.SpellType.Meteor:
                return 8;
            case Spell.SpellType.ElecticPool:
                return 9;
            case Spell.SpellType.Blizzard:
                return 10;
            case Spell.SpellType.FireDragon:
                return 11;
            case Spell.SpellType.AcidSpray_Unused:
                return 12;
            default:
                return 0;
        }
    }

    public static string GetSpellPrefabPathFormat(Spell.SpellType spellType)
    {
        switch (spellType)
        {
            case Spell.SpellType.FireBall:
                return "SpellBalls/FireBall/FireBall_{0}";
            case Spell.SpellType.Lightning:
                return "SpellBalls/Lightning/Lightning_{0}";
            case Spell.SpellType.IceStrike:
                return "SpellBalls/IceStrike/IceStrike_{0}";
            case Spell.SpellType.Boulder:
                return "SpellBalls/RollingBowlder/RollingBowlder_{0}";
            case Spell.SpellType.FireWall:
                return "SpellBalls/FireWall/FireWall_{0}";
            case Spell.SpellType.ChainLightning:
                return "SpellBalls/ChainLightning/ChainLightning_{0}";
            case Spell.SpellType.IceBreath:
                return "SpellBalls/IceBreath/IceBreath_{0}";
            case Spell.SpellType.AcidSpray_Unused:
                return "SpellBalls/AcidSpray/AcidSpray_{0}";
            case Spell.SpellType.Meteor:
                return "SpellBalls/Meteor/MeteorSpell {0}";
            case Spell.SpellType.ElecticPool:
                return "SpellBalls/ElectricPool/ElectricPoolSpell {0}";
            case Spell.SpellType.Blizzard:
                return "SpellBalls/Blizzard/BlizzardSpell {0}";
            case Spell.SpellType.FireDragon:
                return "SpellBalls/FireDragon/FireDragonSpell {0}";
            case Spell.SpellType.EarthBall:
                return "SpellBalls/EarthBall/EarthBall {0}";
        }
        return null;
    }

}
