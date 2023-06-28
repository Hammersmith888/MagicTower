using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

[System.Serializable]
public struct EnemyParameters
{
    public string Name;
    public float health;
    public float regeneration;
    public float armor;
    public float dpStrike;
    public float dpSpecialStrike;
    public float attackSpeed;
    public float radius;
    public float speed;
    public float specialSpeed;
    public float rangeDistanceMin;
    public float rangeDistanceMax;
    public string ability;
    public float metamorph;
    public string metamorphName;

    public float resistanceFire;
    public float resistanceAir;
    public float resistanceWater;
    public float resistanceEarth;

    public float vulnerabilityFire;
    public float vulnerabilityAir;
    public float vulnerabilityWater;
    public float vulnerabilityEarth;

    public float gold;
    public float indexFreeze; 
}

[System.Serializable]
public class Enemy_Parameters : ArrayInClassWrapper<EnemyParameters>
{
    public Enemy_Parameters()
    {
    }

    public Enemy_Parameters(int capacity) : base(capacity)
    {
    }
}

[System.Serializable]
public struct SpellParameters
{
    public int spellTableIndex;
    public string name;
    public string element;
    public float level;
    public float rank;
    public float minDamage;
    public float maxDamage;
    public float reload;
    public float manacost;
    public float radius;
    public float damageLength;
    public float speed;
    public float parts;
    public float spellAngle;
    public float spellHeight;
    public float spellTime;
    public float abilityChance;
    public float abilityEffect;
    public float abilityTime;
    public float timeOfSecondEffect;
    public float chanceAbility2;
    public float abilityDamage;
    public float abilityRadius;
    public int upg_cost;
    public int cost_open;
    public int cost_buy;
}

[System.Serializable]
public class Spell_Parameters : ArrayInClassWrapper<SpellParameters>
{
    public Spell_Parameters()
    {
    }

    public Spell_Parameters(int capacity) : base(capacity)
    {
    }
}

[System.Serializable]
public struct CharacterUpgradesValues
{
    public int[] characterUpgradesValue;
    public float[] characterUpgradesSpeed;
    public float[] characterUpgradesRadius;
}

[System.Serializable]
public struct CharacterUpgradeParameters
{
    public string Name;
    public string Effect;
    public float Value;
    public float Radius;
    public float Speed;
    public int cost_open;
    public int upg_cost;
}

[System.Serializable]
public class Character_UpgradeParameters : ArrayInClassWrapper<CharacterUpgradeParameters>
{
    public Character_UpgradeParameters()
    {
    }

    public Character_UpgradeParameters(int capacity) : base(capacity)
    {
    }
}

[System.Serializable]
public class EnemyParametersSettings
{
    public int enemyParamIndex;
    public bool hasSpecMove;
    public bool hasSpecDamage;
    public bool hasMetamorph;
}

[System.Serializable]
public struct PotionsParameters
{
    public string name;
    public float add_value;
    public int upg_cost;
    public int cost;

}

[System.Serializable]
public class Potions_Parameters : ArrayInClassWrapper<PotionsParameters>
{
    public Potions_Parameters()
    {
    }

    public Potions_Parameters(int capacity) : base(capacity)
    {
    }
}


[System.Serializable]
public struct BottlesWinParameters
{
    public int level;
    public int acid;
    public int barrier;
    public int frozen;
    public int mine;
    public int hipno;
    public int haste;
    public int mana;
    public int health;
    public int power;
    public int ressurection;

    public class Type
    {
        public string name;
        public int count;
    }

    public List<Type> GetItems()
    {
        List<Type> x = new List<Type>();

        if (acid > 0)
            x.Add(new Type { name= "acid", count=acid });
        if (barrier > 0)
            x.Add(new Type { name = "barrier", count = barrier });
        if (frozen > 0)
            x.Add(new Type { name = "frozen", count = frozen });
        if (mine > 0)
            x.Add(new Type { name = "mine", count = mine });
        if (hipno > 0)
            x.Add(new Type { name = "hipno", count = hipno });
        if (haste > 0)
            x.Add(new Type { name = "haste", count = haste });
        if (mana > 0)
            x.Add(new Type { name = "mana", count = mana });
        if (health > 0)
            x.Add(new Type { name = "health", count = health });
        if (power > 0)
            x.Add(new Type { name = "power", count = power });
        if (ressurection > 0)
            x.Add(new Type { name = "ressurection", count = ressurection });

        List<Type> f = new List<Type>();
        int c = 0;
        for (int i = 0; i < x.Count; i++)
        {
            if(c < 3)
            {
                f.Add(x[i]);
                c++;
            }
        }

        return f;
    }
}

[System.Serializable]
public class BottlesWin_Parameters : ArrayInClassWrapper<BottlesWinParameters>
{
    public BottlesWin_Parameters()
    {
    }

    public BottlesWin_Parameters(int capacity) : base(capacity)
    {
    }
}

[System.Serializable]
public struct OtherParameters
{
    public string name;
    public string value1;
    public float value2;
}

[System.Serializable]
public class Other_Parameters : ArrayInClassWrapper<OtherParameters>
{
    public Other_Parameters()
    {
    }

    public Other_Parameters(int capacity) : base(capacity)
    {
    }
}

[System.Serializable]
public struct GemSellCostParameters
{
    public int value;
}

[System.Serializable]
public class GemSellCost_Parameters : ArrayInClassWrapper<GemSellCostParameters>
{
    public GemSellCost_Parameters()
    {
    }

    public GemSellCost_Parameters(int capacity) : base(capacity)
    {
    }
}
