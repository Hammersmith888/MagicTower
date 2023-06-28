using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MyGSFU
{
    public static readonly int[] ScrollsBalanceIdsMap = new int[]
    { 
        0,
        8,
        16,
        24,
        84,
        32,
    };

    public static readonly Dictionary<Scroll.ScrollType, SpellParameters> ScrollTypeToSpellParamsMap = new Dictionary<Scroll.ScrollType, SpellParameters>()
    {
        { Scroll.ScrollType.Acid, new SpellParameters() { spellTableIndex = 0} },
        { Scroll.ScrollType.Barrier, new SpellParameters() { spellTableIndex = 8} },
        { Scroll.ScrollType.FrostyAura, new SpellParameters() { spellTableIndex = 16} },
        { Scroll.ScrollType.Minefield, new SpellParameters() { spellTableIndex = 24} },
        { Scroll.ScrollType.Haste, new SpellParameters() { spellTableIndex = 32} },
    };

    public void SetScrollParameters(Scroll.ScrollType scrollType, GameObject scrollPrefab, int spellLvl)
    {
        if (scrollParams == null || scrollParams.IsNullOrEmpty())
        {
            return;
        }

        switch (scrollType)
        {
            case Scroll.ScrollType.Acid:
                SetAcidScrollParameters(scrollPrefab, spellLvl);
                break;
            case Scroll.ScrollType.Barrier:
                SetBarrierScrollParameters(scrollPrefab, spellLvl);
                break;
            case Scroll.ScrollType.FrostyAura:
                SetFreezScrollParameters(scrollPrefab, spellLvl);
                break;
            case Scroll.ScrollType.Minefield:
                SetMinesScrollParameters(scrollPrefab, spellLvl);
                break;
            case Scroll.ScrollType.Zombie:
                SetZombieScrollParameters(scrollPrefab, spellLvl);
                break;
            case Scroll.ScrollType.Haste:
                SetHasteScrollParameters(scrollPrefab, spellLvl);
                break;
        }
    }
    // Устанавливаем параметры свитков -----
    private void SetAcidScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        int index = ScrollTypeToSpellParamsMap[Scroll.ScrollType.Acid].spellTableIndex + spellLvl; // Номер объекта свитка в таблица баланса
        AcidScroll scroll = scrollPrefab.transform.GetChild(0).GetComponent<AcidScroll>();
        scroll.lifeTime = (int)scrollParams[index].spellTime / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        scroll.paralizePercent = (int)scrollParams[index].abilityEffect;
        scroll.acidChance = (int)scrollParams[index].abilityChance;
        scroll.acidDamage = (int)scrollParams[index].maxDamage;
        scroll.slowTime = scrollParams[index].abilityTime;
        scrollPrefab.transform.localScale = new Vector3(scrollParams[index].radius / 10f, scrollParams[index].radius / 10f, 1f); // Масштаб родительского объекта области действия свитка
    }

    private void SetBarrierScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        int index = ScrollTypeToSpellParamsMap[Scroll.ScrollType.Barrier].spellTableIndex + spellLvl; // Номер объекта свитка в таблица баланса
        scrollPrefab.GetComponent<BarrierScroll>().health = scrollParams[index].minDamage; // Здоровье барьера, используется minDamage (заглушка)
        //MagicalFX.FX_SpawnDirectionBarrier /*fxSpawnDirection*/ = scrollPrefab.GetComponent<MagicalFX.FX_SpawnDirectionBarrier>();
        //fxSpawnDirection.LifeTime = scrollParams[index].spellTime / 10f;
        scrollPrefab.GetComponent<BarrierScroll>().currentLevel = (byte)scrollParams[index].level;
        //fxSpawnDirection.Number = (int)scrollParams[index].parts; // Количество частей барьера, от этого зависит высота и смещение коллайдера барьера, задается далее
        //if (fxSpawnDirection.Number != 1) // Если состоит из одной части, то все настроено по умолчанию
        //{
        //    BoxCollider2D newBoxCollider2D = scrollPrefab.GetComponent<BoxCollider2D>();
        //    Vector2 colliderSize = newBoxCollider2D.size;
        //    colliderSize = new Vector2(colliderSize.x, 0.6f * fxSpawnDirection.Number); // Для двух частей высота 0.6, для трех 1.2 и т.д.
        //    Vector2 colliderOffset = newBoxCollider2D.offset;
        //    colliderOffset = new Vector2(colliderOffset.x, 0.3f * (fxSpawnDirection.Number - 1)); // Для двух частей смещаем на 0.3, для трех на 0.6 и т.д.
        //    newBoxCollider2D.size = colliderSize;
        //    newBoxCollider2D.offset = colliderOffset;
        //}
    }

    private void SetFreezScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        int index = ScrollTypeToSpellParamsMap[Scroll.ScrollType.FrostyAura].spellTableIndex + spellLvl; // Номер объекта свитка в таблица баланса
        FreezScroll scroll = scrollPrefab.transform.GetChild(0).GetComponent<FreezScroll>();
        scroll.lifeTime = (int)scrollParams[index].spellTime / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        scroll.freezChance = (int)scrollParams[index].abilityChance;
        scroll.freezTime = scrollParams[index].abilityTime / 10f;
        scroll.maxDamage = scrollParams[index].maxDamage;
        scroll.minDamage = scrollParams[index].minDamage;
        scrollPrefab.transform.localScale = new Vector3(scrollParams[index].radius / 10f, scrollParams[index].radius / 10f, 1f); // Масштаб родительского объекта области действия свитка
    }

    private void SetMinesScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        int index = ScrollTypeToSpellParamsMap[Scroll.ScrollType.Minefield].spellTableIndex + spellLvl; // Номер объекта свитка в таблица баланса
        MinesScroll scroll = scrollPrefab.GetComponent<MinesScroll>();
        scroll.lifeTime = (int)scrollParams[index].spellTime / 10; // Делим на 10 т.к. время в таблице задается как 10 это 1 секунда
        scroll.minDamage = (int)scrollParams[index].minDamage;
        scroll.maxDamage = (int)scrollParams[index].maxDamage;
        scroll.radius = scrollParams[index].radius / 10;
        scroll.parts = (int)scrollParams[index].parts;
    }

    private void SetZombieScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        ZombieScroll scroll = scrollPrefab.GetComponentInChildren<ZombieScroll>();
        scroll.upgradeLevel = spellLvl;
    }

    private void SetHasteScrollParameters(GameObject scrollPrefab, int spellLvl)
    {
        int index = ScrollTypeToSpellParamsMap[Scroll.ScrollType.Haste].spellTableIndex + spellLvl; // Номер объекта свитка в таблица баланса
        HasteScroll scroll = scrollPrefab.GetComponent<HasteScroll>();
        scroll.addSpeed = scrollParams[index].abilityEffect;
        scroll.workTime = (int)scrollParams[index].spellTime;
        scroll.healthRegen = scrollParams[index].minDamage;
    }
}
