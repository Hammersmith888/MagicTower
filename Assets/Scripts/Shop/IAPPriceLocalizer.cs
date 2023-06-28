using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPPriceLocalizer : MonoBehaviour
{
    [SerializeField] GameObject errorText;
    [SerializeField]
    private UnityEngine.UI.Text priceLbl;
    [SerializeField]
    private string overridePriceFormat;
    [SerializeField]
    private float multiplyPriceBy;

    [SerializeField] Image buyButtonImage;

    public string productId;

    const string DEAULT_LOCALIZED_PRICE_FORMAT = "{0} {1}";//0 is price, 1 is currency code
    const string JPY_LOCALIZED_PRICE_FORMAT = "{1}{0}";//0 is price, 1 is currency code

    private Button button;

    [SerializeField]
    string testCost = "";

    public bool doubleLines = false;

    void Awake()
    {
        button = GetComponentInParent<Button>();
        buyButtonImage = button.gameObject.GetComponent<Image>();

        if (priceLbl == null)
        {
            priceLbl = GetComponentInChildren<UnityEngine.UI.Text>();
        }
        Purchaser.Instance.AddPriceLocalizer(this);
    }

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            buyButtonImage.color = Color.white;
            button.interactable = true;

            var st = Purchaser.Instance.GetPriceString(productId);
            var cur = (float)st.object1;
            string curPriceStr = string.Empty;

            var curLang = TextSheetLoader.Instance.langId;
            curPriceStr = cur.ToString(curLang == "KO" || curLang == "JP" ? "F0" : "F2");

            priceLbl.text = curPriceStr + " " + st.object2;

            if (multiplyPriceBy == 0)
                return;

            var multPriceStr = (cur * multiplyPriceBy).ToString(curLang == "KO" || curLang == "JP" ? "F0" : "F2");

            priceLbl.text = multPriceStr + " " + st.object2;
        }
        else
        {
            button.interactable = false;
            buyButtonImage.color = Color.gray;
            if (errorText != null)
            {
                errorText.SetActive(true);
                errorText.GetComponent<Text>().text = TextSheetLoader.Instance.GetString("t_0683");
                gameObject.SetActive(false);
            }
            else
                priceLbl.text = TextSheetLoader.Instance.GetString("t_0683");
        }
    }


    private void OnDestroy()
    {
        Purchaser.Instance.RemovePriceLocalizer(this);
    }
}
