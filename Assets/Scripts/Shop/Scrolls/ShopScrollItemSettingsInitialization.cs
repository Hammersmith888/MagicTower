
using System.Diagnostics;

public partial class ShopScrollItemSettings
{
    private void SetScrollCoinsForUnlock()
    {
        //scrollItems[0].unlockCoins = 5000;
        //scrollItems[1].unlockCoins = 7500;
        //scrollItems[2].unlockCoins = 10000;
        //scrollItems[3].unlockCoins = 15000;
        //scrollItems[4].unlockCoins = 20000;
        //scrollItems[5].unlockCoins = 20000;
    }

    private void SetScrollCoinsForUpgrade()
    {
        var scrollParameters = BalanceTables.Instance.ScrollParameters;

        int x = 0;
        int v = 0;
        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (x < scrollParameters.Length)
            {
                //UnityEngine.Debug.Log($"scrollItems: {scrollParameters.Length}, x: {x}");
                scrollItems[i].unlockCoins = scrollParameters[x].cost_open;
                scrollItems[i].cost = scrollParameters[x].cost_buy;
                //UnityEngine.Debug.Log($"scrollItems: {scrollItems[i].unlockCoins}, x: {x}");
            }
            for (int z = 0; z < scrollItems[i].upgradeCoins.Length; z++)
            {
                scrollItems[i].upgradeCoins[z] = scrollParameters[v].upg_cost;
                v++;
            }
            for (int z = 0; z < scrollParameters.Length / scrollItems.Length; z++)
                x++;
        }
    }

    private void SetScrollCoinsForBuy()
    {
        //scrollItems[0].cost = 150;
        //scrollItems[1].cost = 200;
        //scrollItems[2].cost = 250;
        //scrollItems[3].cost = 300;
        //scrollItems[4].cost = 300;
        //scrollItems[5].cost = 300;
    }
}
