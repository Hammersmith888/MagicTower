using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LocalizationDataUpdater : EditorWindow
{
    private const string LocalizationDataAssetPath = "Assets/Prefabs/UI/TextsLocalization.prefab";

    private bool currentlyUpdating;
    private static TextSheetLoader LocalizationData;

    [MenuItem("Tools/Update Localization Data")]
    static void Init()
    {
        LocalizationData = AssetDatabase.LoadAssetAtPath(LocalizationDataAssetPath, typeof(TextSheetLoader)) as TextSheetLoader;
        if (LocalizationData == null)
        {
            Debug.LogErrorFormat("Can't load localization data prefab at path {0}", LocalizationDataAssetPath);
            return;
        }
        LocalizationDataUpdater window = (LocalizationDataUpdater)EditorWindow.GetWindow(typeof(LocalizationDataUpdater));
        window.Show();
    }

    private void OnEnable()
    {
        if (!currentlyUpdating)
        {
            currentlyUpdating = true;
            RetrieveParameters();
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Don't close window while process running");
    }

    private bool isCallbackRegistered;
    public void RetrieveParameters()
    {
        Debug.Log("RetrieveParameters");
        if (!isCallbackRegistered)
        {
            isCallbackRegistered = true;
            CloudConnectorCore.processedResponseCallback.AddListener(SetOfflineBalanceVariables);
        }
        CloudConnectorCore.GetAllTables(true);
    }


    public void SetOfflineBalanceVariables(CloudConnectorCore.QueryType query, List<string> objTypeNames, List<string> jsonData)
    {
        Debug.Log("Data received, saving...");
        if (!LocalizationData)
        {
            Debug.LogError("LocalizationData is null");
        }
        else
        {
            LocalizationData.SetOfflineTextsEditor(query, objTypeNames, jsonData);
            EditorUtility.SetDirty(LocalizationData.gameObject);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            LocalizationData = null;
        }

        if (isCallbackRegistered)
        {
            isCallbackRegistered = false;
            CloudConnectorCore.processedResponseCallback.RemoveListener(SetOfflineBalanceVariables);
        }
        currentlyUpdating = false;
        Close();
        EditorUtility.DisplayDialog("Message", "Localization Data Updated.", "Ok");
    }
}
