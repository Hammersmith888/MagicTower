using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayerHelpersLoader : MonoBehaviour {

    public static LevelPlayerHelpersLoader Current;

    [HideInInspector]
    public bool manaUse, healthUse,  powerUse, spellUse;
    [HideInInspector]
    public bool[] usedSlot = new bool[4];

    [System.Serializable]
    public class AutoSpellSlotsUsing
    {
        public bool[] usedSlot = new bool[4];
    }

    private void Awake()
    {
        Current = this;
    }

    void Start ()
    {
        StartCoroutine(DelayedHelpersCreating());
        _Update();
     
        //LevelSettings.Current.usedGameSpeed = PlayerPrefs.GetInt(GameConstants.SaveIds.UseDoubleSpeedSave, 0) == 1 ? LevelSettings.Current.increasedUsedSpeed : LevelSettings.defaultUsedSpeed;
        //Time.timeScale = LevelSettings.Current.usedGameSpeed;

    }

    public void _Update()
    {
        LoadSpellSlotsUsing();
        manaUse = PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUseManaSave, 0) == 1;
        healthUse = PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUseHealthSave, 0) == 1;
        powerUse = PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUsePowerSave, 0) == 1;
        spellUse = PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUseSpellSave, 0) == 1;
    }

    private IEnumerator DelayedHelpersCreating()
    {
        yield return new WaitForEndOfFrame();

        CreatHelpersOnScene();

        yield break;
    }

    public void CreatHelpersOnScene()
    {
        //Wave Info Object
        if (LevelWaveInfoText.Current == null)
        {
            Transform waveInfoParent = EnemiesGenerator.Instance.progressBar.transform.parent;
            Instantiate(LevelPlayerHelpersLoaderConfig.Instance.WaveDataObject, waveInfoParent);

            EnemiesGenerator.Instance.UpdateWaveInfoHelper();
        }

        //Double Speed Button

        Transform helpersButtonsParent = LevelSettings.Current.gemsValue.transform.parent.parent;

        Instantiate(LevelPlayerHelpersLoaderConfig.Instance.DoubleSpeedButtonObject, helpersButtonsParent);

        //Double Popup Button
        GameObject popupCallButton = Instantiate(LevelPlayerHelpersLoaderConfig.Instance.DoublePopupButtonObject, helpersButtonsParent) as GameObject;
        popupCallButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CallHelpersWindow);
        popupCallButton.transform.GetChild(0).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(CallHelpersWindow);

    }

    private void CallHelpersWindow()
    {
        if (EnemiesGenerator.Instance.isVictory)
            return;
        Debug.Log($"CallHelpersWindow: {UIAutoHelperButton.instance.CantUseHelpers}");
        if (UIAutoHelperButton.instance.CantUseHelpers)
            return;
        UIPauseController.Instance.pauseCalled = true;
        Time.timeScale = 0f;
        var o = Instantiate(LevelPlayerHelpersLoaderConfig.Instance.DoublePopupWindowObject, LevelSettings.Current.pauseObj.transform.parent);
        Debug.Log($"UI Auto HElper: {o.name}");
    }

    private void LoadSpellSlotsUsing()
    {
        AutoSpellSlotsUsing autoSpellSlotsUsing = PPSerialization.Load<AutoSpellSlotsUsing>(GameConstants.SaveIds.AutoSpellSlotsUsing);
        if (autoSpellSlotsUsing == null)
        {
            autoSpellSlotsUsing = new AutoSpellSlotsUsing();
            for (int i = 0; i < autoSpellSlotsUsing.usedSlot.Length; i++)
            {
                autoSpellSlotsUsing.usedSlot[i] = true;
            }
            PPSerialization.Save(GameConstants.SaveIds.AutoSpellSlotsUsing, autoSpellSlotsUsing);
        }

        usedSlot = autoSpellSlotsUsing.usedSlot;
    }

    public void SaveSpellSlotsUsing()
    {
        AutoSpellSlotsUsing autoSpellSlotsUsing = new AutoSpellSlotsUsing();
        autoSpellSlotsUsing.usedSlot = usedSlot;
        PPSerialization.Save(GameConstants.SaveIds.AutoSpellSlotsUsing, autoSpellSlotsUsing);
    }
}
