
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Spell
{
    public enum SpellType
    {
        FireBall,
        Lightning,
        IceStrike,
        Boulder,
        FireWall,
        IceBreath,
        ChainLightning,
        AcidSpray_Unused,
        None,
        Blizzard,
        Meteor,
        ElecticPool,
        FireDragon,
        EarthBall
    }

    public SpellType spellType;

    public Image spellIcon; // Здесь устанавливаем иконку загруженного заклинания
    public Text manaText; // Компонент для хранения значения стоимости заклинания
    public Image progressBar; // Прогресс бар данного заклинания
    public GameObject blockSpell, blockCost; // Блокировка заклинания и изображения его стоимости, если недостаточно маны
    public Vector3 glowPos; // Позиция подсветки активного заклинания

    // Все данные о заклинании хранятся в одном месте - в скрипте префаба заклинания
    //[HideInInspector]
    public GameObject spellObject;
    [HideInInspector]
    public float rechargeTime;
    //[HideInInspector]
    public int manaValue;

    public float timeOfSecondEffect;

    // Поля и свойства необходимы для рассчета времени перезарядки
    [HideInInspector]
    public bool MayShot;

    private float speedBar;
    public float SpeedBar
    {
        get
        {
            return speedBar;
        }
        set
        {
            speedBar = value;
        }
    }

    private float rechargeTimer;
    public float RechargeTimer
    {
        get
        {
            return rechargeTimer;
        }
        set
        {
            rechargeTimer = value;
        }
    }


    // Делаем стоимость заклинаний активной-неактивной
    public void SetSpellCostActive()
    {
        blockCost.SetActive(false);
    }
    public void SetSpellCostInActive()
    {
        blockCost.SetActive(true);
    }
    // Затемняем заклинание, если недостаточно маны
    public void SetSpellActive()
    {
        blockSpell.SetActive(false);
    }
    public void SetSpellInActive()
    {
        blockSpell.SetActive(true);
    }
}