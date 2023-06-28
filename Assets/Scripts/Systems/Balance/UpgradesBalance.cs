
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public partial class MyGSFU
{
   public static readonly int[] UpgradesBalanceIdsMap = new int[]
    {
        0,
        8,
        24,
        16,
        32
    };

    private int UpgaradeLevelsNumber
    {
        get { return UpgradeItem.MaxUpgradeLevelIndex + 1; }
    }

    // Устанавливаем параметры улучшений персонажа: стены, маны, отдачи от стены и т.д.
    private void SetManaUpgradeParameters()
    {
        int index = UpgradesBalanceIdsMap[0];
        charUpgradesValues[0].characterUpgradesValue = new int[UpgaradeLevelsNumber];
        charUpgradesValues[0].characterUpgradesSpeed = new float[UpgaradeLevelsNumber];
        int prev_value = 0;

        for (int i = 0; i < UpgaradeLevelsNumber; i++)
        {
            prev_value += (int)characterUpgrades[index].Value;
            charUpgradesValues[0].characterUpgradesValue[i] = prev_value;
            charUpgradesValues[0].characterUpgradesSpeed[i] = characterUpgrades[index].Speed;
            index++;
        }
        Mana.Current.LoadManaUpgrade();
    }

    private void SetHealthUpgradeParameters()
    {
        int index = UpgradesBalanceIdsMap[1];
        charUpgradesValues[1].characterUpgradesValue = new int[UpgaradeLevelsNumber];
        int prev_value = 0;

        for (int i = 0; i < UpgaradeLevelsNumber; i++)
        {
            prev_value += (int)characterUpgrades[index].Value;
            charUpgradesValues[1].characterUpgradesValue[i] = prev_value;
            index++;
        }
        PlayerController.Instance.LoadHealthUpgrade();
    }

    private void SetFireWallUpgradeParameters()
    {
        int index = UpgradesBalanceIdsMap[3];
        charUpgradesValues[3].characterUpgradesValue = new int[UpgaradeLevelsNumber];
        charUpgradesValues[3].characterUpgradesSpeed = new float[UpgaradeLevelsNumber];

        for (int i = 0; i < UpgaradeLevelsNumber; i++)
        {
            charUpgradesValues[3].characterUpgradesValue[i] = (int)characterUpgrades[index].Value;
            charUpgradesValues[3].characterUpgradesSpeed[i] = characterUpgrades[index].Speed;
            index++;
        }

        GameObject wall = GameObject.FindGameObjectWithTag("Wall").transform.Find("FireWallBig").gameObject;
        FireWallTower fireWallTower = wall.GetComponent<FireWallTower>();
        FireWallShot wallShot = fireWallTower.SetFireWall();

        if (wallShot != null)
        {
            if (!SaveManager.GameProgress.Current.firstFireWallEnable)
            {
                StartCoroutine(_OpenWall(fireWallTower.gameObject));
                SaveManager.GameProgress.Current.firstFireWallEnable = true;
                SaveManager.GameProgress.Current.Save();
            }
            else
            {
                var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
                fireWallTower.gameObject.SetActive(upgradeItems[3]._active);
            }
            wallShot.SetPermanentDamage();
        }
    }
    IEnumerator _OpenWall(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        var upgradeItems = PPSerialization.Load<Upgrade_Items>(EPrefsKeys.Upgrades);
        obj.SetActive(upgradeItems[3]._active); 
    }

    private void SetDragonUpgradeParameters()
    {
        int index = UpgradesBalanceIdsMap[2];
        charUpgradesValues[2].characterUpgradesValue = new int[UpgaradeLevelsNumber];
        charUpgradesValues[2].characterUpgradesSpeed = new float[UpgaradeLevelsNumber];
        charUpgradesValues[2].characterUpgradesRadius = new float[UpgaradeLevelsNumber];

        for (int i = 0; i < UpgaradeLevelsNumber; i++)
        {
            charUpgradesValues[2].characterUpgradesValue[i] = (int)characterUpgrades[index].Value;
            charUpgradesValues[2].characterUpgradesSpeed[i] = characterUpgrades[index].Speed;
            charUpgradesValues[2].characterUpgradesRadius[i] = characterUpgrades[index].Radius;
            index++;
        }
    }

    private void SetDragonFrostUpgradeParameters()
    {
        int index = UpgradesBalanceIdsMap[4];
        charUpgradesValues[4].characterUpgradesValue = new int[UpgaradeLevelsNumber];
        charUpgradesValues[4].characterUpgradesSpeed = new float[UpgaradeLevelsNumber];
        charUpgradesValues[4].characterUpgradesRadius = new float[UpgaradeLevelsNumber];

        for (int i = 0; i < UpgaradeLevelsNumber; i++)
        {
            charUpgradesValues[4].characterUpgradesValue[i] = (int)characterUpgrades[index].Value;
            charUpgradesValues[4].characterUpgradesSpeed[i] = characterUpgrades[index].Speed;
            charUpgradesValues[4].characterUpgradesRadius[i] = characterUpgrades[index].Radius;
            index++;
        }
    }
}
