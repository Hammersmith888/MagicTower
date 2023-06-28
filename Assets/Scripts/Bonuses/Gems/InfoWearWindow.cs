using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoWearWindow : MonoBehaviour
{
    [SerializeField]
    private List<BuffShowObject> buffShowObjects = new List<BuffShowObject>(), CustomBuffShowObjects = new List<BuffShowObject>();
    [SerializeField]
    private LocalTextLoc wearName, shortDescription;
    [SerializeField]
    private Image wearIcon;

    [SerializeField]
    private List<GameObject> toOnObjects = new List<GameObject>();

    [SerializeField]
    private ShopWearItemSettings shopWearItemSettings;

    public event System.Action hideWindowEvent;


    [SerializeField]
    private UIShop uiShop;
    [SerializeField]
    private BuffMiniInfo buffInfo;

    [SerializeField] private GameObject infoCanvas;

    private static int slotNumber;
    Wear_Items wearItems = new Wear_Items(11);

    float valueBuff;

    private void Awake()
    {
        
    }

    private void Start()
    {
        //wearItems = PPSerialization.Load<Wear_Items>("Wears");
        valueBuff = 0;
    }

    public void ShowWearInfo(int savedId)
    {
        //Eugene refresh info canvas
        SetStateInfoCanvas(false);
        SetStateInfoCanvas(true);

        slotNumber = savedId;
        Debug.Log($"savedId: {savedId}, slotNumber: {slotNumber}");

        for (int i = 0; i < toOnObjects.Count; i++)
            toOnObjects[i].SetActive(true);

        wearItems = PPSerialization.Load<Wear_Items>("Wears");
        wearIcon.sprite = shopWearItemSettings.spellIcons[savedId];
        wearName.SetLocaleId(shopWearItemSettings.wearNamesIds[savedId]);
        shortDescription.SetLocaleId(shopWearItemSettings.wearNamesIds[savedId]);
        int gemSlotsCount = 0;
        //показываем дефолтные баффы на шмотке, независимо от камней
        for (int i = 0; i < wearItems[savedId].wearParams.buffs.Count; i++)
        {
            Sprite showSprite = Resources.Load<Sprite>(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetBuff(wearItems[savedId].wearParams.buffs[i].buffType));
            buffShowObjects[i].icon.sprite = showSprite;
            string tempDescription = TextSheetLoader.Instance.GetString(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetStringId(wearItems[savedId].wearParams.buffs[i].buffType));
            float buffValue = wearItems[savedId].wearParams.buffs[i].buffValue;
            string textValue = buffValue.ToString();
            if (buffValue < 1f)
            {
                buffValue *= 100f;
                textValue = buffValue.ToString();
            }
            if (AddPersentSymbol(tempDescription))
            {
                textValue += "%";
            }

           


            buffShowObjects[i].value.text = textValue;
            buffShowObjects[i].value.color = Color.white;
            buffShowObjects[i].gameObject.SetActive(true);

            if (wearItems[savedId].wearParams.buffs[i].buffType == BuffType.gemSlot)
            {
                gemSlotsCount = (int)wearItems[savedId].wearParams.buffs[i].buffValue;
            }

            if (buffShowObjects[i].tapButton == null)
            {
                buffShowObjects[i].tapButton = buffShowObjects[i].gameObject.AddComponent<Button>();
            }
            buffShowObjects[i].tapButton.onClick.RemoveAllListeners();
            textValue = tempDescription.Replace("#", buffValue.ToString());
            var t = buffShowObjects[i].icon.transform;
            buffShowObjects[i].tapButton.onClick.AddListener(delegate { ShowBuffMiniInfo(t, showSprite, textValue); });
        }
        for (int i = wearItems[savedId].wearParams.buffs.Count; i < buffShowObjects.Count; i++)
        {
            buffShowObjects[i].gameObject.SetActive(false);
        }
        //Распределяем камни по слотам.
        List<Buff> gemBuffs = new List<Buff>();
        List<Gem> gems = new List<Gem>();

        for (int i = 0; i < gemSlotsCount; i++)
        {
            //if (wearItems [savedId].wearParams.gemsInSlots [i].type != GemType.none)
            gemBuffs.Add(shopWearItemSettings.shopGemItemSettings.buffsLoaderConfig.GetGemBuffInWear(wearItems[savedId].wearParams.gemsInSlots[i], wearItems[savedId].wearParams.wearType));
            gems.Add(wearItems[savedId].wearParams.gemsInSlots[i]);
            if (SaveManager.GameProgress.Current.gemsAnimationSlot != null)
            {
                if (SaveManager.GameProgress.Current.gemsAnimationSlot[savedId] && SaveManager.GameProgress.Current.gemsAnimationGemSlot[i])
                {
                    CustomBuffShowObjects[i].plus.transform.Find("gem").gameObject.GetComponent<Animation>().Play();
                    SaveManager.GameProgress.Current.gemsAnimationSlot[savedId] = false;
                    SaveManager.GameProgress.Current.gemsAnimationGemSlot[i] = false;
                    SaveManager.GameProgress.Current.Save();
                }
            }
            else
            {
                SaveManager.GameProgress.Current.InitWearGemsSave();
            }
        }

        for (int i = 0; i < gemBuffs.Count; i++)
        {
            CustomBuffShowObjects[i].icon.sprite = Resources.Load<Sprite>(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetBuff(gemBuffs[i].buffType));
            string stringId = shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetStringId(gemBuffs[i].buffType);
            CustomBuffShowObjects[i].plus.GetComponent<Button>().onClick.RemoveAllListeners();
            if (stringId != "t_0368")
            {
                if (CustomBuffShowObjects[i].tapButton != null)
                {
                    CustomBuffShowObjects[i].tapButton.enabled = false;
                }
                string tempDescription = TextSheetLoader.Instance.GetString(stringId);
                float buffValue = gemBuffs[i].buffValue;
                string textValue = tempDescription.Replace("#", buffValue.ToString());
                var t = "+" + textValue;
                string[] split = t.Split(null);
                var tf = "<color=#F1F268>" + split[0].ToString() + "</color>" + t.Replace(split[0].ToString(), "");
                CustomBuffShowObjects[i].value.text = tf;
                //CustomBuffShowObjects[i].value.color = Color.white;
                CustomBuffShowObjects[i].value.gameObject.SetActive(true);
                CustomBuffShowObjects[i].value.transform.parent.gameObject.SetActive(true);
                CustomBuffShowObjects[i].emptyValue.gameObject.SetActive(false);
                var gem = CustomBuffShowObjects[i].plus.GetComponentInChildren<ShopGemShadowObj>();
                gem.shadowObj.SetActive(true);
                gem.plusObj.SetActive(false);
                gem.gameObject.GetComponent<Image>().color = Color.white;
                gem.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetGem(gems[i]));
                var g = gems[i];
                CustomBuffShowObjects[i].plus.GetComponent<Button>().onClick.AddListener(delegate {
                    //Debug.Log($"shopWearItemSettings.shopWearItems[i]: {shopWearItemSettings.shopWearItems[savedId]}, {savedId}, shopWearItemSettings.shopWearItems: {shopWearItemSettings.shopWearItems.Length}");
                    shopWearItemSettings.CallActiveGemPopup(shopWearItemSettings.shopWearItems[savedId], savedId, i - 1, g, gem.transform.position);
                    GameObject.FindGameObjectWithTag("WearActive").transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                });
            }
            else
            {
                CustomBuffShowObjects[i].value.gameObject.SetActive(false);
                CustomBuffShowObjects[i].emptyValue.gameObject.SetActive(true);
                CustomBuffShowObjects[i].value.transform.parent.gameObject.SetActive(false);
                
                var gem = CustomBuffShowObjects[i].plus.GetComponentInChildren<ShopGemShadowObj>();
                gem.shadowObj.SetActive(false);
                gem.plusObj.SetActive(true);
                gem.gameObject.GetComponent<Image>().color = Color.clear;
                if (CustomBuffShowObjects[i].tapButton != null)
                {
                    if (wearItems[savedId].unlock)
                    {
                        //CustomBuffShowObjects[i].tapButton.enabled = true;
                        //CustomBuffShowObjects[i].tapButton.onClick.RemoveAllListeners();
                        int gemSlotId = i;
                        //CustomBuffShowObjects[i].tapButton.onClick.AddListener(delegate { shopWearItemSettings.ShowGemsForWear(wearItems[savedId].wearParams, CustomBuffShowObjects[i].tapButton.transform, savedId, gemSlotId); HideWearInfo(); });
                        CustomBuffShowObjects[i].plus.GetComponent<Button>().onClick.RemoveAllListeners();
                        CustomBuffShowObjects[i].plus.GetComponent<Button>().onClick.AddListener(delegate {
                            shopWearItemSettings.ShowGemsForWear(wearItems[savedId].wearParams, CustomBuffShowObjects[i].tapButton.transform, savedId, gemSlotId);
                            HideWearInfo();
                        });
                    }
                    else
                    {
                        CustomBuffShowObjects[i].tapButton.enabled = false;
                    }
                }
            }
            CustomBuffShowObjects[i].gameObject.SetActive(true);
        }
        for (int i = gemBuffs.Count; i < CustomBuffShowObjects.Count; i++)
        {
            CustomBuffShowObjects[i].gameObject.SetActive(false);
        }

        string[] d = new string[] {
            "basic_stafff",
            "pyromaniac_stuff",
            "freezing_stuff",
            "stuff_of_geomency",
            "electrophoresis_stuff",
            "basic_robe",
            "pyromaniac_robe",
            "freezing_robe",
            "robe_of_geomency",
            "electrophoresis_robe",
            "robe_of_luck",
        };

        AnalyticsController.Instance.LogMyEvent("info_press_" + d[savedId]);

    }

    public string GetValueGem(int index, int slot)
    {
        //Распределяем камни по слотам.
        Buff gemBuffs = new Buff();
       // if(wearItems[index].wearParams == null)
            wearItems = PPSerialization.Load<Wear_Items>("Wears");
        
        gemBuffs = shopWearItemSettings.shopGemItemSettings.buffsLoaderConfig.GetGemBuffInWear(wearItems[index].wearParams.gemsInSlots[slot], wearItems[index].wearParams.wearType);

        string stringId = shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetStringId(gemBuffs.buffType);
        string tempDescription = TextSheetLoader.Instance.GetString(stringId);
        float buffValue = gemBuffs.buffValue;
        //string textValue = tempDescription.Replace("#", buffValue.ToString());
        return buffValue.ToString() + "%";
    }
    public void ResetBuffValue()
    {
        valueBuff = 0;
    }

    public void SetDataBuffs(BuffShowObject obj, int savedId, int z, Buff buff, float value = 0)
    {
        Wear_Items wearItems = new Wear_Items(11);
        wearItems = PPSerialization.Load<Wear_Items>("Wears");
        Sprite showSprite = Resources.Load<Sprite>(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetBuff(wearItems[savedId].wearParams.buffs[z].buffType));
        obj.icon.sprite = showSprite;
        string tempDescription = TextSheetLoader.Instance.GetString(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetStringId(wearItems[savedId].wearParams.buffs[z].buffType));
        float buffValue = wearItems[savedId].wearParams.buffs[z].buffValue;
        string textValue = buffValue.ToString();
        valueBuff = value;
        var items = shopWearItemSettings.shopWearItems[savedId];

        var isIt = false;
        if (buff != null)
        {
            if (buff.buffType == wearItems[savedId].wearParams.buffs[z].buffType)
                isIt = true;
            else
                return;
        }

        if (buffValue < 1f)
        {
            buffValue *= 100f;
            textValue = buffValue.ToString();
        }

        if (buff != null && isIt)
        {
            valueBuff += buff.buffValue;
            buffValue += valueBuff;
            textValue = buffValue.ToString();
        }

        if (AddPersentSymbol(tempDescription))
        {
            textValue += "%";
        }
        
        obj.value.text = textValue;
        obj.value.color = buff != null && isIt ? Color.green : Color.white;
        obj.gameObject.SetActive(true);

        if (obj.tapButton == null)
        {
            obj.tapButton = obj.icon.gameObject.AddComponent<Button>();
        }
        obj.tapButton.onClick.RemoveAllListeners();
        textValue = tempDescription.Replace("#", buffValue.ToString());
        obj.tapButton.onClick.AddListener(delegate { ShowBuffMiniInfo(obj.icon.transform, showSprite, textValue); });
        ResetBuffValue();
    }

    private bool AddPersentSymbol(string str)
    {
        if (str == null)
        {
            return false;
        }
        return str.IndexOf('%') >= 0;
    }

    public void HideWearInfo()
    {
        Debug.Log($"HideWearInfo: {slotNumber}");

        ShopWearItemSettings.instance.AnimGemInSlot(slotNumber);


        for (int i = 0; i < toOnObjects.Count; i++)
        {
            toOnObjects[i].SetActive(false);
        }
        if (hideWindowEvent != null)
        {
            hideWindowEvent();
        }


    }

   

    private void ShowBuffMiniInfo(Transform buttonPos, Sprite iconSprite, string descriptionText)
    {
        if (buffInfo != null)
        {
            buffInfo.OpenIt(buttonPos, iconSprite, descriptionText);
        }
    }

    //Eugene refresh info canvas
    private void SetStateInfoCanvas(bool state)
    {
        if (infoCanvas != null)
        {
            infoCanvas.SetActive(state);
        }
    }
}
