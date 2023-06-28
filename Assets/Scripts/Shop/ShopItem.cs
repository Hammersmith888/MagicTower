
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Button       upgradeBtn;
    public Text         priceLabel;
    public Text         upgradeTextObj;
    public GameObject   maxUpgradeLabel, useButton;
    public ShopBalanceValues damageValuesUnit, rangeValuesUnit;
    public Image imgBuyBtn;

    public int unlockCoins;

    public RectTransform paretnLife, valueLife;
    public Text textLife;

    public GameObject effectUnlock;
    public float grayscale = 1;
    public bool isGrayscale = true;
    Image img;
    public SpellLockText spellLock;

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        UpdateIcon();
    }

    public void UpdateButtonsUnlock()
    {
        if(imgBuyBtn != null)
        {
            imgBuyBtn.sprite = CoinsManager.Instance.Coins > unlockCoins ? UIShop.Instance.spriteBtnBuy[0] : UIShop.Instance.spriteBtnBuy[1];
            var v = imgBuyBtn.transform.Find("Unlock");
            v.gameObject.GetComponent<Text>().color = CoinsManager.Instance.Coins > unlockCoins ? Color.white : Color.red;
        }
    }

    public void UpdateIcon()
    {
        if (transform.childCount == 0)
            return;
        var _lock = transform.GetChild(1);
       // Debug.Log($"lock icon: {_lock}, active: {_lock.gameObject.activeSelf}");
        var m = Instantiate(Resources.Load("BlackWhiteUI")) as Material;
        if (_lock != null)
        {
            img = transform.GetChild(0).GetComponent<Image>();
            //Debug.Log($"Img: {img.name}");
            try
            {
                img.material = _lock.gameObject.activeSelf ? m : null;
            }
            catch { }
        }
        if (paretnLife != null)
        {
            paretnLife.transform.parent.gameObject.SetActive(!_lock.gameObject.activeSelf);
        }
        if (!isGrayscale)
            img.material = null;
    }

    private void Update()
    {
        if (img != null)
        {
            if (img.material != null)
            {
                img.material.SetFloat("_GrayscaleAmount", grayscale);
            }
        }
    }

    private void OnDisable()
    {
        if (effectUnlock != null)
        {
            effectUnlock.SetActive(false);
        }
    }

    public void DisableAnimator()
    {
        gameObject.GetComponent<Animator>().enabled = false;
    }
}