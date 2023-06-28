using Facebook;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfferItem : MonoBehaviour
{
    [SerializeField]
    Text labelText, coinsText, countItemText, timerText;
    [SerializeField]
    Transform parentImg;
    [SerializeField]
    List<Image> imgGrayscale = new List<Image>();
    [SerializeField]
    Image[] glow;
    [SerializeField]
    GameObject[] disabledObjs, enabledObjs;
    [SerializeField]
    Button btnBuy;
    GameObject imgItem;
    [SerializeField]
    Material matGrayscale;
    bool isActive = true;
    bool animActive = false;
    float tempActive;
    [SerializeField]
    float effectSpeed = 1;
    public bool disable;

    [SerializeField]
    bool editorGrayscale = false;
    SpecialOffer.Item item;
    [SerializeField]
    Animator _animTimer;
    SpecialOffer offer;
    [SerializeField]
    GameObject newEffect;

    float ticks;

    int amountItem;

    Transform targetFly;

    public void Open(SpecialOffer.Item item, SpecialOffer offer)
    {
        this.offer = offer;

        targetFly = item.targetFly;

        var m = Instantiate(matGrayscale) as Material;
        foreach (var i in imgGrayscale)
            i.material = m;

        m = Instantiate(matGrayscale) as Material;
        imgGrayscale[0].material = m;

        gameObject.SetActive(item.enable && !disable);
        
        if (!item.enable || disable)
            return;
        if (item.enable)
            gameObject.SetActive(item.typeBuy != "2");
        this.item = item;
      
        var timeSpan = item.time - UnbiasedTime.Instance.Now();
        SetActive(timeSpan.Ticks <= 0, true);
        if(imgItem == null)
            imgItem = Instantiate(item.prefab, parentImg) as GameObject;
        if (imgItem != null)
        {
            var childs = imgItem.GetComponentsInChildren<Image>();
            foreach (var c in childs)
                imgGrayscale.Add(c);
        }

        coinsText.text = (item.typeBuy == "0" || item.typeBuy == "1" ? (item.cost * 2) : item.cost).ToString();
        amountItem = (item.typeBuy == "0" || item.typeBuy == "1" ? (item.amount * 2) : item.amount);
        countItemText.text = amountItem.ToString();
        if (TextSheetLoader.Instance != null)
            labelText.text = TextSheetLoader.Instance.GetString(item.keyLocalization);
        if (!SpecialOffer.saveData._items.ContainsKey("new_" + item.idTimer))
            SpecialOffer.saveData.SetItem("new_" + item.idTimer, "");
        if (SpecialOffer.saveData._items["new_" + item.idTimer] == "")
        {
            newEffect.SetActive(true);
            SpecialOffer.saveData.SetItem("new_" + item.idTimer, "1");
        } 
    }

    void Update()
    {
        if (editorGrayscale)
        {
            SetActive(!isActive, false);
            editorGrayscale = false;
        }
        if (animActive)
        {
            if (isActive)
                tempActive -= Time.deltaTime * effectSpeed;
            else
                tempActive += Time.deltaTime * effectSpeed;

            for (int i = 0; i < imgGrayscale.Count; i++)
            {
                if (i > 0)
                    imgGrayscale[i].material.SetFloat("_GrayscaleAmount", Mathf.Clamp(tempActive, 0, 0.7f));
                else
                    imgGrayscale[i].material.SetFloat("_GrayscaleAmount", tempActive);
            }

            foreach (var g in glow)
                g.color = new Color(g.color.r, g.color.g, g.color.b, 1 - tempActive);
            if (tempActive < 0)
            {
                animActive = false;
                foreach (var i in imgGrayscale)
                    i.material.SetFloat("_GrayscaleAmount", 0);
                foreach (var g in glow)
                    g.color = new Color(g.color.r, g.color.g, g.color.b, 1);

            }
            if (tempActive > 1)
            {
                animActive = false;
                foreach (var i in imgGrayscale)
                    i.material.SetFloat("_GrayscaleAmount", 0.7f);

                imgGrayscale[0].material.SetFloat("_GrayscaleAmount", 1);
                foreach (var g in glow)
                    g.color = new Color(g.color.r, g.color.g, g.color.b, 0);
            }
        }
    }

    public void Buy()
    {
        if (!item.enable)
            return;
        if (CoinsManager.Instance.BuySomething(int.Parse(coinsText.text)))
        {
            SetActive(false, false);
            var t = "";
            if (item.typeBuy == "1")
                t = "2";

            item.AddItem(amountItem);
            if (item.typeBuy == "")
            {
                t = "0";
                coinsText.text = (item.cost * 2).ToString();
                countItemText.text = (item.amount * 2).ToString();
                amountItem *= 2;
            }
            item.SetCountBuy(t);
            item.SetTimer();


            var fly = imgItem.GetComponentInChildren<UIConsFlyAnimation>();
            fly.PlayEffect(targetFly.position);

            btnBuy.interactable = false;
            SoundController.Instanse.PlayShopBuySFX();
            if (item.typeBuy == "2")
                GetComponent<Animator>().Play("closeItemOffer");

            ShopPotionItemSettings.instance.Open();
        }
        else
            UIShop.Instance.OpenBuyCoins();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        offer.CloseItem();
    }

    void SetActive(bool value, bool isFast = true)
    {
        isActive = value;
        if (!isFast)
        {
            tempActive = value ? 1 : 0;
            animActive = true;
            return;
        }
        foreach (var g in glow)
            g.color = new Color(g.color.r, g.color.g, g.color.b, value ? 1 : 0);
        foreach (var i in imgGrayscale)
            i.material.SetFloat("_GrayscaleAmount", value ? 0 : 0.7f);
        imgGrayscale[0].material.SetFloat("_GrayscaleAmount", value ? 0 : 1);
        btnBuy.interactable = value;
    }

    public void CountDownTimer()
    {
        if (item == null)
            return;
        if (!item.enable)
            return;
        var timeSpan = item.time - UnbiasedTime.Instance.Now();
        ticks = timeSpan.Ticks;
        if (timeSpan.Ticks > 0 && item.typeBuy != "2")
        {
            foreach (var o in enabledObjs)
                o.SetActive(true);
        }

        if (timeSpan.Ticks <= 0 && item.typeBuy == "0")
        {
            item.SetCountBuy("1");
            SetActive(true, false);
            _animTimer.Play("reverse");
            btnBuy.interactable = true;
            foreach (var o in enabledObjs)
                o.SetActive(false);
            return;
        }
        btnBuy.interactable = timeSpan.Ticks <= 0;

        int hours = (int)timeSpan.TotalHours;
        int mins = timeSpan.Minutes;
        int seconds = timeSpan.Seconds;
        timerText.text = (mins.ToString("D2") + ":" + seconds.ToString("D2"));
    }
}
