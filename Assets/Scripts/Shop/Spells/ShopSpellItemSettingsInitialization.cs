
public partial class ShopSpellItemSettings
{
    public void SetSpellCoinsForUnlock()
    {
        //// spellItems[0] - открыто всегда
        //spellItems[1].unlockCoins = 5000;
        //spellItems[2].unlockCoins = 5000;
        //spellItems[3].unlockCoins = 5000;
        //spellItems[4].unlockCoins = 15000;
        //spellItems[5].unlockCoins = 15000;
        //spellItems[6].unlockCoins = 30000;
        //spellItems[7].unlockCoins = 30000;
        //spellItems[8].unlockCoins = 45000;
        //spellItems[9].unlockCoins = 30000;
        //spellItems[10].unlockCoins = 30000;
        //spellItems[11].unlockCoins = 45000;
    }

    public void SetSpellCoinsForUpgrade()
    {
        var scrollParameters = BalanceTables.Instance.SpellParameters;
        //UnityEngine.Debug.Log($"------- SetSpellCoinsForUpgrade: { scrollParameters.Length}");
       

        int x = 0;
        int v = 0;
        for (int i = 0; i < spellItems.Length; i++)
        {
            if (x < scrollParameters.Length)
            {
                //UnityEngine.Debug.Log($"name: { scrollParameters[x].name}, x: {x}, sost: {scrollParameters[x].cost_open}");
                spellItems[i].unlockCoins = scrollParameters[x].cost_open;
                //UnityEngine.Debug.Log($"name array: { spellItems[i].upgradeLevel}");
            }
            for (int z = 0; z < spellItems[i].upgradeCoins.Length; z++)
            {
                spellItems[i].upgradeCoins[z] = scrollParameters[v].upg_cost;
                //UnityEngine.Debug.Log($"z: {z}, name: { scrollParameters[v].name}, count: {scrollParameters[v].upg_cost}");
                v++;
            }
            for (int z = 0; z < scrollParameters.Length / spellItems.Length; z++)
                x++;
        }


        //spellItems[0].upgradeCoins[0] = 500;
        //spellItems[0].upgradeCoins[1] = 1000;
        //spellItems[0].upgradeCoins[2] = 2000;
        //spellItems[0].upgradeCoins[3] = 4000;
        //spellItems[0].upgradeCoins[4] = 4000;
        //spellItems[0].upgradeCoins[5] = 4000;
        //spellItems[0].upgradeCoins[6] = 4000;

        //spellItems[1].upgradeCoins[0] = 700;
        //spellItems[1].upgradeCoins[1] = 1400;
        //spellItems[1].upgradeCoins[2] = 2800;
        //spellItems[1].upgradeCoins[3] = 5600;
        //spellItems[1].upgradeCoins[4] = 5600;
        //spellItems[1].upgradeCoins[5] = 5600;
        //spellItems[1].upgradeCoins[6] = 5600;

        //spellItems[2].upgradeCoins[0] = 1000;
        //spellItems[2].upgradeCoins[1] = 2000;
        //spellItems[2].upgradeCoins[2] = 4000;
        //spellItems[2].upgradeCoins[3] = 8000;
        //spellItems[2].upgradeCoins[4] = 8000;
        //spellItems[2].upgradeCoins[5] = 8000;
        //spellItems[2].upgradeCoins[6] = 8000;

        //spellItems[3].upgradeCoins[0] = 1250;
        //spellItems[3].upgradeCoins[1] = 2500;
        //spellItems[3].upgradeCoins[2] = 5000;
        //spellItems[3].upgradeCoins[3] = 10000;
        //spellItems[3].upgradeCoins[4] = 10000;
        //spellItems[3].upgradeCoins[5] = 10000;
        //spellItems[3].upgradeCoins[6] = 10000;

        //spellItems[4].upgradeCoins[0] = 1500;
        //spellItems[4].upgradeCoins[1] = 3000;
        //spellItems[4].upgradeCoins[2] = 6000;
        //spellItems[4].upgradeCoins[3] = 12000;
        //spellItems[4].upgradeCoins[4] = 12000;
        //spellItems[4].upgradeCoins[5] = 12000;
        //spellItems[4].upgradeCoins[6] = 12000;

        //spellItems[5].upgradeCoins[0] = 1750;
        //spellItems[5].upgradeCoins[1] = 3500;
        //spellItems[5].upgradeCoins[2] = 7000;
        //spellItems[5].upgradeCoins[3] = 14000;
        //spellItems[5].upgradeCoins[4] = 14000;
        //spellItems[5].upgradeCoins[5] = 14000;
        //spellItems[5].upgradeCoins[6] = 14000;

        //spellItems[6].upgradeCoins[0] = 2000;
        //spellItems[6].upgradeCoins[1] = 4000;
        //spellItems[6].upgradeCoins[2] = 8000;
        //spellItems[6].upgradeCoins[3] = 16000;
        //spellItems[6].upgradeCoins[4] = 16000;
        //spellItems[6].upgradeCoins[5] = 16000;
        //spellItems[6].upgradeCoins[6] = 16000;

        //spellItems[7].upgradeCoins[0] = 2250;
        //spellItems[7].upgradeCoins[1] = 4500;
        //spellItems[7].upgradeCoins[2] = 9000;
        //spellItems[7].upgradeCoins[3] = 18000;
        //spellItems[7].upgradeCoins[4] = 18000;
        //spellItems[7].upgradeCoins[5] = 18000;
        //spellItems[7].upgradeCoins[6] = 18000;

        //spellItems[8].upgradeCoins[0] = 1500;
        //spellItems[8].upgradeCoins[1] = 3000;
        //spellItems[8].upgradeCoins[2] = 6000;
        //spellItems[8].upgradeCoins[3] = 12000;
        //spellItems[8].upgradeCoins[4] = 12000;
        //spellItems[8].upgradeCoins[5] = 12000;
        //spellItems[8].upgradeCoins[6] = 12000;

        //spellItems[9].upgradeCoins[0] = 1750;
        //spellItems[9].upgradeCoins[1] = 3500;
        //spellItems[9].upgradeCoins[2] = 7000;
        //spellItems[9].upgradeCoins[3] = 14000;
        //spellItems[9].upgradeCoins[4] = 14000;
        //spellItems[9].upgradeCoins[5] = 14000;
        //spellItems[9].upgradeCoins[6] = 14000;

        //spellItems[10].upgradeCoins[0] = 2000;
        //spellItems[10].upgradeCoins[1] = 4000;
        //spellItems[10].upgradeCoins[2] = 8000;
        //spellItems[10].upgradeCoins[3] = 16000;
        //spellItems[10].upgradeCoins[4] = 16000;
        //spellItems[10].upgradeCoins[5] = 16000;
        //spellItems[10].upgradeCoins[6] = 16000;

        //spellItems[11].upgradeCoins[0] = 2250;
        //spellItems[11].upgradeCoins[1] = 4500;
        //spellItems[11].upgradeCoins[2] = 9000;
        //spellItems[11].upgradeCoins[3] = 18000;
        //spellItems[11].upgradeCoins[4] = 18000;
        //spellItems[11].upgradeCoins[5] = 18000;
        //spellItems[11].upgradeCoins[6] = 18000;

        //spellItems[12].upgradeCoins[0] = 2250;
        //spellItems[12].upgradeCoins[1] = 4500;
        //spellItems[12].upgradeCoins[2] = 9000;
        //spellItems[12].upgradeCoins[3] = 18000;
        //spellItems[12].upgradeCoins[4] = 18000;
        //spellItems[12].upgradeCoins[5] = 18000;
        //spellItems[12].upgradeCoins[6] = 18000;
    }
}
