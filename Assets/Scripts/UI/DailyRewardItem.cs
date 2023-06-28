using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardItem : MonoBehaviour
{
    [SerializeField] GameObject glow, bottomGlow, active;
    [SerializeField] GameObject[] toogle;
    [SerializeField] CanvasGroup group;
    [SerializeField] Material mat;
    public GameObject[] awards;
    [SerializeField] bool isWeek = false;
    public int date;
    public bool getRobe = false;
    [SerializeField]
    List<Image> images = new List<Image>();
    [SerializeField]
    GameObject parentImg;
    [SerializeField]
    Image[] imgGray;
    [SerializeField]
    Animator _anim;
    DailyReward reward;

    int day, week;
    string id => isWeek ? date.ToString() : date.ToString() + week.ToString();

    public bool isReady = false;

    GameObject prefabToCopy;

    // state
    // 0 - soon
    // 1 - acive
    // 2 - took
    // 3 - dont took

    public void Set(int day, int week, DailyReward reward)
    {
        this.reward = reward;
        this.day = day;
        this.week = week;
        int state = 0;
        var d = day;
        if(!isWeek)
            d = day - (week * 7);
        if (d == date && !isTook())
            state = 1;
        else if (date > d)
            state = 0;
        else
        {
            //Debug.Log($"isTook(): {isTook()}, id: {id}");
            if (isTook())
                state = 2;
            else
                state = 3;
        }

        isReady = state == 1;

        glow.SetActive(state == 1);
        bottomGlow.SetActive(state == 0);
        if (date <= 5)
            bottomGlow.SetActive(false);
        
        toogle[0].SetActive(state == 2);
        toogle[1].SetActive(state == 3);
        _anim.enabled = state == 1;

        if(isWeek)
        {
            if(date == 27)
            {
                Wear_Items wearItems = new Wear_Items(WearItem.ItemsNumber);
                for (int i = 0; i < wearItems.Length; i++)
                    wearItems[i] = new WearItem();

                wearItems = PPSerialization.Load<Wear_Items>("Wears");
                awards[0].SetActive(wearItems[10].unlock);
                awards[1].SetActive(!wearItems[10].unlock);
            }
        }
        else
        {
            if (week == 0 || week == 2)
            {
                awards[0].SetActive(true);
                if(awards.Length > 1)
                    awards[1].SetActive(false);
            }
            else
            {
                awards[0].SetActive(true);
                if (awards.Length > 1)
                {
                    awards[0].SetActive(false);
                    awards[1].SetActive(true);
                }
            }
        }

        group.alpha = state >= 2 ? 0.7f : 1f;

        if (state == 3 || state == 2)
        {
            Material m = Instantiate(mat) as Material;
            m.SetFloat("_GrayscaleAmount", 0.8f);
            foreach (var o in imgGray)
                o.material = m;
        }
        else
        {
            foreach (var o in imgGray)
                o.material = null;
        }
    }

    public void _Update(bool value)
    {
        active.SetActive(isReady || (day + 1 == (!isWeek ? ((date + (week * 7))): (date)) && !value));
    }

    bool isTook()
    {
        //Debug.Log($"isTook: contain: {DailyReward.saveData._items.ContainsKey("_dailyRewards_" + id)}");
        if (!DailyReward.saveData._items.ContainsKey("_dailyRewards_" + id))
            DailyReward.saveData.SetItem("_dailyRewards_" + id, false);
        Debug.Log($"isTook: id: {id}, {DailyReward.saveData._items["_dailyRewards_" + id]}");
        return DailyReward.saveData._items["_dailyRewards_" + id];
    }

    public void ResetSaves()
    {
        DailyReward.saveData.SetItem("_dailyRewards_" + id, false);
    }
    public GameObject Take()
    {
        if (isWeek)
        {
            if (date == 27)
            {
                Wear_Items wearItems = new Wear_Items(WearItem.ItemsNumber);
                for (int i = 0; i < wearItems.Length; i++)
                    wearItems[i] = new WearItem();

                wearItems = PPSerialization.Load<Wear_Items>("Wears");
                
                if (!wearItems[10].unlock)
                {
                    wearItems[10].unlock = true;
                    Debug.Log("Unlock wear");
                    getRobe = true;
                    PPSerialization.Save("Wears", wearItems, true, true);
                }
                else
                {
                    CoinsManager.AddCoinsST(30000);
                    AnalyticsController.Instance.CurrencyAccrual(30000, DevToDev.AccrualType.Earned);
                }
            }
            if(date == 6)
            {
                CoinsManager.AddCoinsST(10000);
                AnalyticsController.Instance.CurrencyAccrual(10000, DevToDev.AccrualType.Earned);
            }
            if(date == 13)
            {
                var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
                int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Yellow, 4);
                gemItems[gem1Id].count++;
                PPSerialization.Save(EPrefsKeys.Gems, gemItems);
                CoinsManager.AddCoinsST(12000);
                AnalyticsController.Instance.CurrencyAccrual(12000, DevToDev.AccrualType.Earned);
            }
            if(date == 20)
            {
                var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
                int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Red, 6);
                gemItems[gem1Id].count++;
                PPSerialization.Save(EPrefsKeys.Gems, gemItems);
                CoinsManager.AddCoinsST(12000);
                AnalyticsController.Instance.CurrencyAccrual(12000, DevToDev.AccrualType.Earned);
            }
        }
        else
        {
            if (week == 0 || week == 2)
            {
                if(date == 0)
                {
                    CoinsManager.AddCoinsST(1500);
                    reward.effectCoins = true;
                    AnalyticsController.Instance.CurrencyAccrual(1500, DevToDev.AccrualType.Earned);
                }
                if (date == 1)
                {
                    var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                    potionItems[0].count += 5;
                    potionItems[1].count += 5;
                    potionItems[2].count += 5;
                    //case RewardType.PotionResurrection:
                    //    potionItems[3].count += rewards[i].number;
                    PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                }
                if (date == 2)
                {
                    var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
                    int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Blue, 5);
                    gemItems[gem1Id].count++;
                    PPSerialization.Save(EPrefsKeys.Gems, gemItems);
                    CoinsManager.AddCoinsST(1500);
                    reward.effectCoins = true;
                    AnalyticsController.Instance.CurrencyAccrual(1500, DevToDev.AccrualType.Earned);
                }
                if (date == 3)
                {
                    CoinsManager.AddCoinsST(3000);
                    reward.effectCoins = true;
                    AnalyticsController.Instance.CurrencyAccrual(3000, DevToDev.AccrualType.Earned);
                }
                if (date == 4)
                {
                    CoinsManager.AddCoinsST(4000);
                    reward.effectCoins = true;
                    AnalyticsController.Instance.CurrencyAccrual(4000, DevToDev.AccrualType.Earned);
                }
                if (date == 5)
                {
                    var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                    potionItems[2].count += 5;
                    PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                    CoinsManager.AddCoinsST(3000);
                    reward.effectCoins = true;
                    AnalyticsController.Instance.CurrencyAccrual(3000, DevToDev.AccrualType.Earned);
                }
            }
            else
            {
                if (date == 0)
                {
                    CoinsManager.AddCoinsST(2000);
                    AnalyticsController.Instance.CurrencyAccrual(2000, DevToDev.AccrualType.Earned);
                }
                if (date == 1)
                {
                    var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                    potionItems[0].count += 5;
                    potionItems[1].count += 5;
                    potionItems[2].count += 5;
                    PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                }
                if (date == 2)
                {
                    var gemItems = PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems);
                    int gem1Id = ShopGemItemSettings.GetGemIdWithItems(gemItems, GemType.Red, 2);
                    gemItems[gem1Id].count++;
                    PPSerialization.Save(EPrefsKeys.Gems, gemItems);
                    CoinsManager.AddCoinsST(1500);
                    AnalyticsController.Instance.CurrencyAccrual(1500, DevToDev.AccrualType.Earned);
                }
                if (date == 3)
                {
                    var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                    potionItems[2].count += 3;
                    PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                    CoinsManager.AddCoinsST(3000);
                    AnalyticsController.Instance.CurrencyAccrual(3000, DevToDev.AccrualType.Earned);
                }
                if (date == 4)
                {
                    CoinsManager.AddCoinsST(3500);
                    AnalyticsController.Instance.CurrencyAccrual(3500, DevToDev.AccrualType.Earned);
                }
                if (date == 5)
                {
                    var potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
                    potionItems[3].count += 2;
                    PPSerialization.Save(EPrefsKeys.Potions, potionItems);
                    CoinsManager.AddCoinsST(3500);
                    AnalyticsController.Instance.CurrencyAccrual(3500, DevToDev.AccrualType.Earned);
                }
            }
        }
        DailyReward.saveData.SetItem("_dailyRewards_" + id, true);
        Set(day, week, reward);
        prefabToCopy = Instantiate(parentImg.transform.parent.gameObject) as GameObject;
        //PPSerialization.Save<DailyReward.SaveData>("DailyReward", DailyReward.saveData);
        foreach (var o in prefabToCopy.GetComponentsInChildren<Image>())
            o.material = null;

        return prefabToCopy;
    }


    public void Info()
    {
        var wearItems = PPSerialization.Load<Wear_Items>("Wears");
        float buffValue = wearItems[10].wearParams.buffs[0].buffValue;
        MessageWindow.Show(MessageWindow.EMessageWindowType.FREE_INFO, TextSheetLoader.Instance.GetString("t_0343").Replace("#%",buffValue + "%" ));
    }

}
