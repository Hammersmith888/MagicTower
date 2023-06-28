
using UnityEngine;
using UnityEngine.UI;

public class ShopBalanceValues : MonoBehaviour
{
    [SerializeField]
    public Text currentValueText, additionalValueText;

    public void SetupLabel(string baseValue, string additionValue)
    {
        currentValueText.text = baseValue;
        additionalValueText.text = additionValue;
    }
}
