using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mana : MonoBehaviour
{
    public static float DEFAULT_MAX_MANA = 100f;
    #region VARIABLES
    [SerializeField]
	//private float maxValue;
	private ObfuscatedFloat maxValue; // Максимальное значение объема маны, единиц
    private float manaUIRectWidth;
    public float recoverySpeed; // Скорость восстановления маны, единиц в секунду
    public GameObject manaBar; // Бар маны
    public GameObject manaDigits; // Объект отображающий объем маны в цифрах

    private float currentValue; // Текущее значение в значении высоты бара маны (px)
    private float manaRatio; // Соотношение, сколько единиц размера бара в одной единице маны

    public GameObject tip; // Наконечник бара маны, включается только тогда, когда мана наполняется
    public LevelSettings levelSettings;
    public MyGSFU GoogleLoadedData;

    private RectTransform manaBarRectTransf;
    private Text manaDigitsLabel;
    private float highLevelCoef = 1f;
    public float valueHaste;
    public float valueHasteTime;
    [SerializeField]
    private Color hasteColor, defaultColor;

    [SerializeField] Animator _animEffect;


    public bool isFull
    {
        get
        {
            return currentValue >= maxValue;
        }
    }

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            currentValue = (currentValue > maxValue) ? (float)maxValue : currentValue;

        }
    }
    #endregion

    private static Mana current;
    public static Mana Current
    {
        get
        {
            if (current == null)
            {
                current = FindObjectOfType<Mana>();
            }
            return current;
        }
    }

    private void Start()
    {
        current = this;
        manaDigitsLabel = manaDigits.GetComponent<Text>();

        recoverySpeed /= levelSettings.easyCoef;
        if (BuffsLoader.Instance != null)
        {
            recoverySpeed += recoverySpeed * BuffsLoader.Instance.GetBuffValue(BuffType.manaRegeneration) / 100f;
        }

        try
        {
            recoverySpeed *= GoogleLoadedData.charUpgradesValues[0].characterUpgradesSpeed[(int)levelSettings.upgradeItems[0].upgradeLevel];
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogWarning(e.Message);
        }

        if (levelSettings.VIPenabled)
        {
            recoverySpeed *= 1.2f;
        }
        recoverySpeed *= 1.25f;
        if (maxValue == null)
        {
            maxValue = 0f;
        }
        if (maxValue < DEFAULT_MAX_MANA)
        {
            CurrentValue = maxValue = DEFAULT_MAX_MANA;
        }

        CalculateManaRatio();
       // tip = manaBar.transform.GetChild(0).gameObject;
    }

    public void LoadManaUpgrade()
    {
        float baseMana = DEFAULT_MAX_MANA;
        if (levelSettings.upgradeItems[0].unlock == true && levelSettings.upgradeItems[0].upgradeLevel - 1 > 0)
        {
            //for (int i = 0; i < GoogleLoadedData.charUpgradesValues[0].characterUpgradesValue.Length; i++)
            //{
            //    Debug.Log($"i: {i}, value: { GoogleLoadedData.charUpgradesValues[0].characterUpgradesValue[i]}");
            //}
            //Debug.Log($"level: {levelSettings.upgradeItems[0].upgradeLevel}");
            baseMana = new ObfuscatedFloat(DEFAULT_MAX_MANA + GoogleLoadedData.charUpgradesValues[0].characterUpgradesValue[(int)levelSettings.upgradeItems[0].upgradeLevel - 1]);
        }
        if (BuffsLoader.Instance != null)
        {
            baseMana += baseMana * BuffsLoader.Instance.GetBuffValue(BuffType.manaLimit) / 100f;
        }
        maxValue = new ObfuscatedFloat(baseMana);
        manaUIRectWidth = maxValue;
        CurrentValue = maxValue;
        CalculateManaRatio();
    }

    private void Update()
    {
        valueHasteTime -= Time.deltaTime;
        if (valueHasteTime < 0)
            valueHaste = 1;
        if (CurrentValue <= maxValue)
        {
            CurrentValue += (recoverySpeed) * Time.deltaTime * highLevelCoef * valueHaste;
            manaBarRectTransf.sizeDelta = new Vector2(currentValue * manaRatio, manaBarRectTransf.sizeDelta.y);
            manaDigitsLabel.text = ((int)currentValue).ToString();

            tip.SetActive((CurrentValue == maxValue) ? false : true); // Выключаем накочник бара маны, когда мана 100%
        }
    }

    public void RestoreToFull()
    {
        CurrentValue = maxValue;
    }

    // Уменьшить значение маны на определенное значение
    public void SpendMana(float _manaValue)
    {
        CurrentValue -= _manaValue;
    }

    // Увеличить значение маны на определенное значение
    public void AddMana(int _manaValue)
    {
        CurrentValue += _manaValue;
    }

    // Увеличить скорость восстановления маны (временно? постоянно?)
    // Увеличить максимальное значение объема маны на определенное значение
    // Высчитываем соотношение
    private void CalculateManaRatio()
    {
        if (manaBarRectTransf == null)
        {
            manaBarRectTransf = manaBar.GetComponent<RectTransform>();
        }
        if (manaUIRectWidth == 0)
        {
            manaUIRectWidth = DEFAULT_MAX_MANA;
        }
        manaRatio = manaBarRectTransf.sizeDelta.x / manaUIRectWidth;
    }

    public void SetManaHasteView(bool on)
    {
        // manaBar.GetComponent<Image>().color = on ? hasteColor : defaultColor;
        if (on)
        {
            _animEffect.enabled = true;
            _animEffect.Play(0);
        }
        else
        {
            _animEffect.enabled = false;
            _animEffect.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }
}