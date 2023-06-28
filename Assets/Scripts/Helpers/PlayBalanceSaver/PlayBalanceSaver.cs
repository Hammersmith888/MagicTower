
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_STANDALONE
public class PlayBalanceSaver : MonoBehaviour
{
    public class SaveContainer
    {
        public Spell_Parameters spellParamsSave;
        public Spell_Parameters scrollParamsSave;
        public Enemy_Parameters enemyParamsSave;
        public Character_UpgradeParameters characterUpgradesSave;

        public bool IsValid
        {
            get
            {
                return (spellParamsSave != null && !spellParamsSave.getInnerArray.IsNullOrEmpty()) &&
                        (scrollParamsSave != null && !scrollParamsSave.getInnerArray.IsNullOrEmpty()) &&
                        (enemyParamsSave != null && !enemyParamsSave.getInnerArray.IsNullOrEmpty()) &&
                        (characterUpgradesSave != null && !characterUpgradesSave.getInnerArray.IsNullOrEmpty());
            }
        }
    }

    private static SaveContainer m_CurrentSaveContainer;
    public static SaveContainer CurrentSaveContainer
    {
        get
        {
            if (m_CurrentSaveContainer == null)
            {
                m_CurrentSaveContainer = JsonUtility.FromJson<PlayBalanceSaver.SaveContainer>(System.IO.File.ReadAllText(GameConstants.BalanceJsonPath));
            }
            return m_CurrentSaveContainer;
        }
    }

    private UnityEngine.UI.Text stateTextLable;

    private bool currentlyUpdating;

    public void TryUpdate(UnityEngine.UI.Text labelText)
    {
        stateTextLable = labelText;
        if (!currentlyUpdating)
        {
            currentlyUpdating = true;
            RetrieveParameters();
        }
    }

    private bool isCallbackRegistered;
    private void RetrieveParameters()
    {
        stateTextLable.text = "Retrieving Parameters";
        stateTextLable.transform.parent.gameObject.SetActive(true);
        Debug.Log("RetrieveParameters");
        if (!isCallbackRegistered)
        {
            isCallbackRegistered = true;
            CloudConnectorCore.processedResponseCallback.AddListener(SetOfflineBalanceVariables);
        }
        CloudConnectorCore.GetAllTables(true);
    }

    private void SetOfflineBalanceVariables(CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
    {
        StartCoroutine(TextLabelDisabling());
        Debug.Log("Data received, saving...");
        stateTextLable.text = "Data received, saving...";
        SaveContainer saveContainer = new SaveContainer();
        saveContainer.spellParamsSave = Spell_Parameters.Create<Spell_Parameters>(GSFUJsonHelper.JsonArray<SpellParameters>(jsonData[0]));
        saveContainer.scrollParamsSave = Spell_Parameters.Create<Spell_Parameters>(GSFUJsonHelper.JsonArray<SpellParameters>(jsonData[1]));
        saveContainer.enemyParamsSave = Enemy_Parameters.Create<Enemy_Parameters>(GSFUJsonHelper.JsonArray<EnemyParameters>(jsonData[2]));
        saveContainer.characterUpgradesSave = Character_UpgradeParameters.Create<Character_UpgradeParameters>(GSFUJsonHelper.JsonArray<CharacterUpgradeParameters>(jsonData[3]));
        if (!saveContainer.IsValid)
        {
            Debug.LogError("SetOfflineBalanceVariables: loaded data is not valid");
            return;
        }
        m_CurrentSaveContainer = saveContainer;
        File.WriteAllText(GameConstants.BalanceJsonPath, JsonUtility.ToJson(saveContainer));
        BalanceTables.Instance.ApplyBalanceFromSaveContainer();

        if (isCallbackRegistered)
        {
            isCallbackRegistered = false;
            CloudConnectorCore.processedResponseCallback.RemoveListener(SetOfflineBalanceVariables);
        }
        stateTextLable.text = "New balance saved";
        currentlyUpdating = false;
    }

    private IEnumerator TextLabelDisabling()
    {
        yield return new WaitForSecondsRealtime(3f);
        stateTextLable.transform.parent.gameObject.SetActive(false);
        yield break;
    }
}
#else
public class PlayBalanceSaver : MonoBehaviour
{ 
    public void TryUpdate(UnityEngine.UI.Text labelText)
    {
        Debug.Log("PlayBalanceSaver not implemented on this platform");
    }
}
#endif
