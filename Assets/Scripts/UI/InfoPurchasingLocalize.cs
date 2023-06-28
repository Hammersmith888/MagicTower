using UnityEngine;
using UnityEngine.UI;

public class InfoPurchasingLocalize : MonoBehaviour
{
    [SerializeField] private Text _amountGold;

    private void OnEnable()
    {
        if (_amountGold == null)
            _amountGold = GetComponent<Text>();

        var curLang = TextSheetLoader.Instance.langId;
        if (curLang == "JP")
        {
            _amountGold.text = _amountGold.text.Replace(".", ",");
        }
    }
}