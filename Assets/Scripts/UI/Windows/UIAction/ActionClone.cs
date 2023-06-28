using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionClone : MonoBehaviour
{
    [SerializeField]
    Text textCoins, textButtles, textTimer;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    IAPPriceLocalizer[] pricesId;

    public void Show(string coins, string buttles,  bool value , string idPrice)
    {
        panel.SetActive(value);
        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, value ? 500 : 0);
        textCoins.text = coins;
        textButtles.text = buttles;

        foreach (var o in pricesId)
        {
            o.productId = idPrice;
        }
    }

    public void Open(bool value)
    {
       
        panel.SetActive(value);
        transform.parent.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, value ? 500 : 0);
    }

    public void SetTimer(string timer, TimeSpan delta)
    {
        textTimer.text = timer;
        textTimer.color = delta.TotalSeconds > 10 ? Color.white : Color.red;
    }
}
