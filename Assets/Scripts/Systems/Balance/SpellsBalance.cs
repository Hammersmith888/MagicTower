
using System.Collections.Generic;
using UnityEngine;

public partial class MyGSFU
{ 
    public static readonly Dictionary<Spell.SpellType, SpellParameters> SpellTypeToSpellsParamsMap = new Dictionary<Spell.SpellType, SpellParameters>()
    {
        { Spell.SpellType.FireBall, new SpellParameters() { spellTableIndex = 0} },
        { Spell.SpellType.Lightning, new SpellParameters() { spellTableIndex = 8} },
        { Spell.SpellType.IceStrike, new SpellParameters() { spellTableIndex = 16} },
            { Spell.SpellType.EarthBall, new SpellParameters() { spellTableIndex = 24} },
             { Spell.SpellType.FireWall, new SpellParameters() { spellTableIndex = 32} },
              { Spell.SpellType.ChainLightning, new SpellParameters() { spellTableIndex = 40} },
               { Spell.SpellType.IceBreath, new SpellParameters() { spellTableIndex = 48} },
        { Spell.SpellType.Boulder, new SpellParameters() { spellTableIndex = 56} },
        { Spell.SpellType.Meteor, new SpellParameters() { spellTableIndex = 64} },
         { Spell.SpellType.ElecticPool, new SpellParameters() { spellTableIndex = 72} },
        { Spell.SpellType.Blizzard, new SpellParameters() { spellTableIndex = 80} },
        { Spell.SpellType.FireDragon, new SpellParameters() { spellTableIndex = 88} },
    
        { Spell.SpellType.AcidSpray_Unused, new SpellParameters() { spellTableIndex = 56} },
    };

    public void SetSpellParameters(Spell.SpellType spellType, SpellBase spellPrefab, int spellLvl)
    {
        if (spellParams == null || spellParams.IsNullOrEmpty())
        {
            return;
        }
        //Debug.Log( spellType + " " + spellLvl );
        spellLvl -= 1;
        switch (spellType)
        {
            case Spell.SpellType.FireBall:
                SetFireBallParameters((FireShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.Lightning:
                SetLightingParameters((LightningShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.IceStrike:
                SetIceStrikeParameters((IceStrikeShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.Boulder:
                SetRollingBowlderParameters((BowlderShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.FireWall:
                SetFireWallParameters((FireWallShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.ChainLightning:
                SetChainLightingParameters((ChainLightningShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.IceBreath:
                SetIceBreathParameters((IceBreathShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.AcidSpray_Unused:
                SetAcidSprayParameters((AcidSprayShot)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.Meteor:
                SetMeteorParameters((MeteorSpell)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.ElecticPool:
                SetElectricPoolParameters((ElectricPoolSpell)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.Blizzard:
                SetBlizzardParameters((BlizzardSpell)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.FireDragon:
                SetFireDragonParameters((FireDragonSpell)spellPrefab, spellLvl);
                break;
            case Spell.SpellType.EarthBall:
                SetEarthBallParameters((EarthShot)spellPrefab, spellLvl);
                break;
        }
    }

    private void SetFireBallParameters(FireShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.FireBall].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.transform.GetChild(0).GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
        projectilePrefab.burnChance = 50;//0(int)spellParams[index].abilityChance;
        projectilePrefab.burnDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.burnTime = spellParams[index].abilityTime;
    }

    private void SetEarthBallParameters(EarthShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.EarthBall].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.transform.GetChild(0).GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
        projectilePrefab.burnChance = (int)spellParams[index].abilityChance;
        projectilePrefab.burnDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.burnTime = spellParams[index].abilityTime; 
        projectilePrefab.abilityEffect = spellParams[index].abilityEffect;
        projectilePrefab.timeOfSecondEffect = spellParams[index].timeOfSecondEffect;
        projectilePrefab.chanceAbility = spellParams[index].chanceAbility2;
    }

    private void SetLightingParameters(LightningShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.Lightning].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.paralysisChance = (int)spellParams[index].abilityChance;
        projectilePrefab.paralysisTime = spellParams[index].abilityTime;
    }

    private void SetIceStrikeParameters(IceStrikeShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.IceStrike].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.transform.GetChild(0).GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
        projectilePrefab.freezingChance = (int)spellParams[index].abilityChance;
        projectilePrefab.slowdownTime = spellParams[index].spellTime;
        projectilePrefab.freezingTime = spellParams[index].abilityTime;
    }

    private void SetRollingBowlderParameters(BowlderShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.Boulder].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
    }

    private void SetFireWallParameters(FireWallShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.FireWall].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        // Устанавливаем высоту триггера стены (ширина постоянная). Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит.
        float ySize = spellParams[index].spellHeight / 10;
        //projectilePrefab.GetComponent<BoxCollider2D>().size = new Vector2(1f, ySize);
        projectilePrefab.spellTime = spellParams[index].spellTime;
        projectilePrefab.burnChance = (int)spellParams[index].abilityChance;
        projectilePrefab.burnDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.burnTime = spellParams[index].abilityTime;
    }

    private void SetChainLightingParameters(ChainLightningShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.ChainLightning].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.transform.GetChild(2).GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.paralysisChance = (int)spellParams[index].abilityChance;
        projectilePrefab.paralysisTime = spellParams[index].abilityTime;
        projectilePrefab.CountEnemiesCanKill = (int)spellParams[index].spellHeight;
    }

    private void SetIceBreathParameters(IceBreathShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.IceBreath].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10;
        projectilePrefab.freezingChance = (int)spellParams[index].abilityChance;
        projectilePrefab.size = spellParams[index].spellHeight;
        projectilePrefab.damageFreeze = spellParams[index].abilityEffect;
        //shot.freezingTime = spellParams[index].abilityTime;
        projectilePrefab.freezingTime = spellParams[index].spellTime;
        projectilePrefab.timeOfSecondEffect = spellParams[index].timeOfSecondEffect;
    }

    private void SetAcidSprayParameters(AcidSprayShot projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.AcidSpray_Unused].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.countAcidStrikes = (int)spellParams[index].parts;
        projectilePrefab.angle = (int)spellParams[index].spellAngle;
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.strike.GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера заряда. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
        projectilePrefab.acidChance = (int)spellParams[index].abilityChance;
        projectilePrefab.acidDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.acidTime = spellParams[index].abilityTime;
    }

    private void SetMeteorParameters(MeteorSpell projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.Meteor].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.damage = (int)spellParams[index].minDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.lifeTime = spellParams[index].spellTime;
        projectilePrefab.burnChance = (int)spellParams[index].abilityChance;
        projectilePrefab.burnDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.burnTime = spellParams[index].abilityTime;
        projectilePrefab.radius = spellParams[index].radius;
    }

    private void SetElectricPoolParameters(ElectricPoolSpell projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.ElecticPool].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        // Устанавливаем высоту триггера стены (ширина постоянная). Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит.
        float ySize = spellParams[index].spellHeight / 10;
        // Устанавливаем размер дочерних объектов - эффектов
        projectilePrefab.lifeTime = spellParams[index].spellTime;
        projectilePrefab.paralysisChance = (int)spellParams[index].abilityChance;
        projectilePrefab.paralysisTime = spellParams[index].abilityTime;
    }

    private void SetBlizzardParameters(BlizzardSpell projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.Blizzard].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.lifeTime = (int)spellParams[index].spellTime;
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.freezingTime = spellParams[index].abilityTime;
    }

    private void SetFireDragonParameters(FireDragonSpell projectilePrefab, int spellLvl)
    {
        int index = SpellTypeToSpellsParamsMap[Spell.SpellType.FireDragon].spellTableIndex + spellLvl; // Номер объекта заклинания в таблице баланса
        projectilePrefab.minDamage = (int)spellParams[index].minDamage;
        projectilePrefab.maxDamage = (int)spellParams[index].maxDamage;
        projectilePrefab.rechargeTime = spellParams[index].reload / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        projectilePrefab.manaValue = (int)spellParams[index].manacost;
        //projectilePrefab.transform.GetChild(0).GetComponent<CircleCollider2D>().radius = spellParams[index].radius / 10f; // Устанавливаем радиус триггера взрыва. Делим на 10 т.к. размер в таблице задается как 10 это 1 юнит
        projectilePrefab.speed = spellParams[index].speed;
        projectilePrefab.burnDamage = (int)spellParams[index].abilityEffect;
        projectilePrefab.burnTime = spellParams[index].abilityTime;
    }
}