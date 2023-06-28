
using UnityEngine;

public partial class SaveManager
{
    public class SavesDataValidator
    {
        public void ValidateAll(bool profile = true)
        {
            // Сохранение прогресса игрока по умолчанию
            GameProgress.Validate();
            if(profile)
                ProfileSettings.Validate();
            Energy.Validate();

            // Сохранение по умолчанию значений: заклинаний, свитков, зелий, бонусов, улучшений (если их до этого не было)
            ValidateSpellSaves();
            ValidateScrollSaves();
            ValidatePotionSaves();
            ValidateUpgradeSaves();
            ValidateGemSaves();
            ValidateWearSaves();
            ValidateAchievementsViews();
            ValidateBonusSaves();
            ValidateAchievementConditionsSaves();
        }

        private void ValidateSpellSaves()
        {
            if (PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells) == null)
            {
                var spellItems = new Spell_Items();
                spellItems[0].unlock = true;
                spellItems[0].active = true;
                spellItems[0].slot = 0;
                spellItems[0].upgradeLevel = 0;
                PPSerialization.Save(EPrefsKeys.Spells, spellItems);
            }
        }

        private void ValidateScrollSaves()
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            if (scrollItems == null)
            {
                PPSerialization.Save(EPrefsKeys.Scrolls, new Scroll_Items());
            }
        }

        private void ValidatePotionSaves()
        {
            if (PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions) == null)
            {
                Potion_Items potionItems = new Potion_Items();
                for (int i = 0; i < potionItems.Length; i++)
                {
                    potionItems[i] = new PotionItem();
                    potionItems[i].count = 1;
                }
                potionItems[3].count = 3;

                PPSerialization.Save(EPrefsKeys.Potions, potionItems);
            }
        }

        private void ValidateGemSaves()
        {
            int totalGems = 40;
            Gem_Items gemItems = new Gem_Items(totalGems);
            if (PPSerialization.Load<Gem_Items>(EPrefsKeys.Gems) == null)
            {
                int k = 0;
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        gemItems[k] = new GemItem();
                        switch (j)
                        {
                            case 0:
                                gemItems[k].gem.type = GemType.Red;
                                break;
                            case 1:
                                gemItems[k].gem.type = GemType.Blue;
                                break;
                            case 2:
                                gemItems[k].gem.type = GemType.White;
                                break;
                            case 3:
                                gemItems[k].gem.type = GemType.Yellow;
                                break;
                        }
                        gemItems[k].gem.gemLevel = i;
                        k++;
                    }
                }

                PPSerialization.Save(EPrefsKeys.Gems, gemItems);
            }
        }

        private void ValidateWearSaves()
        {
            int totalWears = 11;
            Wear_Items wearItems = new Wear_Items(totalWears);
            if (PPSerialization.Load<Wear_Items>("Wears") == null)
            {
                for (int i = 0; i < wearItems.Length; i++)
                {
                    wearItems[i] = new WearItem();
                    //wearItems [i].unlockCoins = new ObfuscatedInt ();
                }
                for (int i = 0; i < 5; i++)
                {
                    wearItems[i].wearParams = SaveManager.Instance.wearloaderConfig.GetWear(WearType.staff, i + 1);
                }
                for (int i = 5; i < 11; i++)
                {
                    wearItems[i].wearParams = SaveManager.Instance.wearloaderConfig.GetWear(WearType.cape, i - 4);
                }

                for (int i = 0; i < wearItems.Length; i++)
                {
                    for (int j = 0; j < wearItems[i].wearParams.buffs.Count; j++)
                    {
                        if (wearItems[i].wearParams.buffs[j].buffType == BuffType.gemSlot)
                        {
                            wearItems[i].wearParams.gemsInSlots = new Gem[(int)wearItems[i].wearParams.buffs[j].buffValue];
                            for (int k = 0; k < wearItems[i].wearParams.gemsInSlots.Length; k++)
                            {
                                wearItems[i].wearParams.gemsInSlots[k] = new Gem() { type = GemType.None };
                            }
                        }
                    }
                }

                var bonusItems = PPSerialization.Load<Bonus_Items>(EPrefsKeys.Bonuses);
                if (bonusItems != null)
                {
                    if (bonusItems[0].bought)
                    {
                        wearItems[10].unlock = true;
                        wearItems[10].active = bonusItems[0].active;
                    }
                    if (bonusItems[1].bought)
                    {
                        wearItems[6].unlock = true;
                        wearItems[6].active = bonusItems[1].active;
                    }
                }
                wearItems[0].unlock = true;
                wearItems[5].unlock = true;

                PPSerialization.Save("Wears", wearItems, true, true);
            }
        }

        private void ValidateAchievementsViews()
        {
            var viwsData = PPSerialization.Load<AchieveViewed>(EPrefsKeys.AchieveViewed.ToString());
            if (viwsData == null || viwsData.viewed.IsNullOrEmpty())
            {
                AchieveViewed viewed = new AchieveViewed();
                viewed.viewed = new bool[50];
                PPSerialization.Save(EPrefsKeys.AchieveViewed.ToString(), viewed, true, true);
            }
        }

        private void ValidateUpgradeSaves()
        {
            if (PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades) == null)
            {
                PPSerialization.Save(EPrefsKeys.Upgrades, new Upgrade_Items(5));
            }
        }

        private void ValidateBonusSaves()
        {
            if (PPSerialization.Load<Bonus_Items>(EPrefsKeys.Bonuses) == null)
            {
                PPSerialization.Save(EPrefsKeys.Bonuses, new Bonus_Items());
            }
        }

        private void ValidateAchievementConditionsSaves()
        {
            IntArrayWrapper achivementConditions = PPSerialization.Load<IntArrayWrapper>(EPrefsKeys.AchievemtConditions);
            if (achivementConditions == null || achivementConditions.getInnerArray.IsNullOrEmpty())
            {
                PPSerialization.Save(EPrefsKeys.AchievemtConditions, new IntArrayWrapper(50));
            }
        }
    }
}
