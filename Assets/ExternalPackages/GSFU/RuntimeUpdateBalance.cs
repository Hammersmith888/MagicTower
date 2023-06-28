using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CloudConnectorCore;

public class RuntimeUpdateBalance : MonoBehaviour
{
    public static bool waiting = false;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    IEnumerator Start()
    {
        Debug.Log("Start runtime updating table balance");
        Dictionary<string, string> form = new Dictionary<string, string>();
        form.Add("action", QueryType.getAllTables.ToString());

        CloudConnector.Instance.CreateRequest(form);
        CloudConnectorCore.processedResponseCallback.AddListener(SetOfflineBalanceVariables);
        yield return new WaitForEndOfFrame();
    }
    public void SetOfflineBalanceVariables(CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
    {
        Debug.Log("Data received, saving...");
        Spell_Parameters spellParams_save = Spell_Parameters.Create<Spell_Parameters>(GSFUJsonHelper.JsonArray<SpellParameters>(jsonData[0]));
        Spell_Parameters scrollParams_save = Spell_Parameters.Create<Spell_Parameters>(GSFUJsonHelper.JsonArray<SpellParameters>(jsonData[1]));
        //Debug.Log(jsonData[0]);
        //Debug.Log(jsonData[7]);
        Potions_Parameters potionsParams_save = Potions_Parameters.Create<Potions_Parameters>(GSFUJsonHelper.JsonArray<PotionsParameters>(jsonData[5]));

        //GemsConfig.GemsParameters gems = GemsConfig.GemsParameters.Create<GemsConfig.GemsParameters>(GSFUJsonHelper.JsonArray<GemsConfig.Parameters>(jsonData[4]));
        var dt = LitJson.JsonMapper.ToObject<List<GemsConfig.Parameters>>(jsonData[4]);
        GemsConfig.SetParams(dt);

        Enemy_Parameters enemyParams_save = Enemy_Parameters.Create<Enemy_Parameters>(GSFUJsonHelper.JsonArray<EnemyParameters>(jsonData[2]));
        Character_UpgradeParameters characterUpgrades_save = Character_UpgradeParameters.Create<Character_UpgradeParameters>(GSFUJsonHelper.JsonArray<CharacterUpgradeParameters>(jsonData[3]));
        BottlesWin_Parameters bottlesWinParams_save = BottlesWin_Parameters.Create<BottlesWin_Parameters>(GSFUJsonHelper.JsonArray<BottlesWinParameters>(jsonData[6]));
        Other_Parameters otherParams_save = Other_Parameters.Create<Other_Parameters>(GSFUJsonHelper.JsonArray<OtherParameters>(jsonData[7]));
        
        
        if (spellParams_save.Length == 0)
        {
            return;
        }

        BalanceTables.Instance.SetBalanceData(
            spellParams_save.getInnerArray,
            scrollParams_save.getInnerArray,
            enemyParams_save.getInnerArray,
            characterUpgrades_save.getInnerArray,
            potionsParams_save.getInnerArray,
            bottlesWinParams_save.getInnerArray,
            otherParams_save.getInnerArray
            );
        CloudConnectorCore.processedResponseCallback.RemoveListener(SetOfflineBalanceVariables);
    }
}
