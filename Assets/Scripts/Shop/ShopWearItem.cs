using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopWearItem : MonoBehaviour
{

    public Wear wear = new Wear();
    [SerializeField]
    public Image[] buffSlots, gemSlots;
    public int idInBase;
    public Text unlockCoinsText;
    public GameObject UnlockButton, activeSlot, unlockText, slots, BuyButton, halo;
    [SerializeField]
    private ShopWearItemSettings shopWearItemSettings;
    private ShopGemShadowObj[] addLinks;
    public Text wearName;
   
    public List<BuffShowObject> buffShowObjects = new List<BuffShowObject>();

    private void SetAddons()
    {
        addLinks = new ShopGemShadowObj[gemSlots.Length];
        for (int i = 0; i < gemSlots.Length; i++)
        {
            addLinks[i] = gemSlots[i].GetComponent<ShopGemShadowObj>();
        }
    }

    public void OperateSlot(int slotId)
    {
        Debug.Log($" ============= OperateSlot: {slotId}, idInBase: {idInBase}");

        ShopGemItemSettings.instance.OpenInsert();

        Debug.Log($" wear.gemsInSlots[slotId].type: {wear.gemsInSlots.Length}");
        if (wear.gemsInSlots[slotId].type == GemType.None)
        {
            shopWearItemSettings.ShowGemsForWear(wear, gemSlots[slotId].transform, idInBase, slotId);
        }
        else
        {
            shopWearItemSettings.CallActiveGemPopup(this, idInBase, slotId, wear.gemsInSlots[slotId], gemSlots[slotId].transform.position);
        }
    }


    public void AnimateGemSlot(int slotId)
    {
        Debug.Log($"AnimateGemSlot: {slotId}");
        gemSlots[slotId].GetComponent<Animation>().Play();
        SoundController.Instanse.gemInsert.Play();
        //gemSlots[slotId].enabled = false;

       // uiAchivement.OpenTutorial();

    }

    public void PlaceGems()
    {
        shopWearItemSettings.ResetBuffs(idInBase);
        if (addLinks == null || addLinks.Length == 0)
        {
            SetAddons();
        }

        for (int i = 0; i < wear.gemsInSlots.Length; i++)
        {
            if (wear.gemsInSlots[i].type != GemType.None)
            {
                InsertGem(wear.gemsInSlots[i], i);
            }
            else
            {
                GameObject valueObj = gemSlots[i].transform.parent.Find("value").gameObject;
                valueObj.SetActive(false);
                gemSlots[i].color = Color.clear;
                addLinks[i].shadowObj.SetActive(false);
                addLinks[i].plusObj.SetActive(true);
            }
        }
        for (int i = wear.gemsInSlots.Length; i < gemSlots.Length; i++)
        {
            gemSlots[i].transform.parent.gameObject.SetActive(false);
        }
    }

    private void InsertGem(Gem gem, int slot)
    {
        wear.gemsInSlots[slot] = gem;
        gemSlots[slot].sprite = Resources.Load<Sprite>(shopWearItemSettings.shopGemItemSettings.gemsLoaderConfig.GetGem(gem));
        gemSlots[slot].color = Color.white;
        GameObject valueObj = gemSlots[slot].transform.parent.Find("value").gameObject;
        valueObj.SetActive(true);
        addLinks[slot].shadowObj.SetActive(true);
        addLinks[slot].plusObj.SetActive(false);

        List<Gem> gems = new List<Gem>();
        foreach (var item in wear.gemsInSlots)
            gems.Add(item);

        var gemsRed = gems.FindAll(x => x.type == GemType.Red);
        var gemsBlue = gems.FindAll(x => x.type == GemType.Blue);
        var gemsWhite = gems.FindAll(x => x.type == GemType.White);
        var gemsYellow = gems.FindAll(x => x.type == GemType.Yellow);

        bool dublicate = false;

        if (gemsRed.Count > 1)
        {
            SetDublicateBuff(gemsRed);
            dublicate = true;
        }
        if (gemsBlue.Count > 1)
        { 
            SetDublicateBuff(gemsBlue);
            dublicate = true;
        }
        if (gemsWhite.Count > 1)
        {
            SetDublicateBuff(gemsWhite);
            dublicate = true;
        }
        if (gemsYellow.Count > 1)
        {
            SetDublicateBuff(gemsYellow);
            dublicate = true;
        }

        if(!dublicate)
        {
            Buff workingBuff1 = shopWearItemSettings.shopGemItemSettings.buffsLoaderConfig.GetGemBuffInWear(gem, wear.wearType);
            shopWearItemSettings.UpdateBuffs(idInBase, workingBuff1);
        }

        var txt = valueObj.GetComponent<Text>();
        if (txt != null)
        {
            txt.color = Color.white;
            var s = ShopWearItemSettings.instance.infoWear.GetValueGem(idInBase, slot);
            txt.text = s;
        }
        else
            Debug.Log($"insert gem is null");
    }

    private void SetDublicateBuff(List<Gem> gems)
    {
        float value = 0f;
        Buff workingBuff = shopWearItemSettings.shopGemItemSettings.buffsLoaderConfig.GetGemBuffInWear(gems[0], wear.wearType);
        for (int i = 1; i < gems.Count; i++)
        {
            Buff tempBuff = shopWearItemSettings.shopGemItemSettings.buffsLoaderConfig.GetGemBuffInWear(gems[i], wear.wearType);
            value += tempBuff.buffValue;
        }
        shopWearItemSettings.UpdateBuffs(idInBase, workingBuff, value);
    }

    public void ExtractGem(int slotId)
    {
        Debug.Log($" +++++++++++++ ExtractGem");
        shopWearItemSettings.shopGemItemSettings.gemImgTransform = gemSlots[slotId].transform;
        shopWearItemSettings.ExtractGemFromWear(idInBase, slotId, () => {
        });
        shopWearItemSettings.UpdateData();
    }

    public void ReplaceGem(int slotId)
    {
        Debug.Log($" +++++++++++++ ReplaceGem");
        shopWearItemSettings.shopGemItemSettings.gemImgTransform = gemSlots[slotId].transform;
        //shopWearItemSettings.ReplaceGemInWear(idInBase, slotId);
        shopWearItemSettings.UpdateData();
    }

    public void UseWear(int slot)
    {
        shopWearItemSettings.UseWear(wear.wearType, slot);
    }
}
