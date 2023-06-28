using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSpell4SlotAreFull
{
    private const int FIRE_WALL_INDEX = 4;
    private const int MAX_SLOTS = 4;
    private const int MIN_LEVEL_INDEX_TO_SHOW = 12;

    private Tutorial_2 tutor;
    private Button activeBtn;
    private Button slot;
    private Transform slotBackground;

    private Spell_Items items;
    Transform tipLabel;

    public TutorialSpell4SlotAreFull(Tutorial_2 tutor)
    {
        this.tutor = tutor;
    }

    public void Run()
    {
        int idTutor = (int)ETutorialType.SPELL_4_SLOT;

        items = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells);

        if (ValidationRun())
        {
            Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
            tutor.gameObject.SetActive(true);
            //MonoBehaviour.print("progress.tutorial[(int)ETutorialType.FIRST_CRYSTAL_SHOP] = " + tutor.Progress.tutorial[idTutor].ToString());
            if (!SaveManager.GameProgress.Current.tutorial[idTutor])
                tutor.StartCoroutine(WaitForStaffActiveMessageFirstCrystal());
        }
        tutor.StartCoroutine(WaitForStaffActiveMessageFirstCrystal());
    }

    private bool ValidationRun()
    {
        return !IsComplete() && IsCorrectLevel() && SlotsAreFullAndActive();
    }

    private bool IsCorrectLevel()
    {
        return SaveManager.GameProgress.Current.CompletedLevelsNumber > MIN_LEVEL_INDEX_TO_SHOW;
    }

    private bool IsComplete()
    {
        int idTutor = (int)ETutorialType.SPELL_4_SLOT;
        return SaveManager.GameProgress.Current.tutorial[idTutor];
    }

    private bool SlotsAreFullAndActive()
    {
        int countSpellActive = 0;
        var spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells.ToString());

        //if (spellItems[FIRE_WALL_INDEX].active)
        //{
        //    return false;
        //}

        for (int i = 0; i < spellItems.Length; i++)
        {
            if (spellItems[i].active)
            {
                countSpellActive++;
            }
        }
        if (countSpellActive >= MAX_SLOTS) // slots are full
        {
            return true;
        }

        return false;
    }

    private IEnumerator WaitForStaffActiveMessageFirstCrystal()
    {
        yield return new WaitForEndOfFrame();
       
        SpellPanelActiveMessage();
    }

    //Step 1
    private void SpellPanelActiveMessage()
    {
        if (tutor.ButtonInFocus != null)
        {
            Debug.LogFormat("UpgradeButton is busy by {0}", tutor.ButtonInFocus.transform.name);
            Extensions.CallActionAfterDelayWithCoroutine(tutor, 0f, SpellPanelActiveMessage, true);
            return;
        }

        if (UIShop.Instance.IsActiveSpellItems())
        {
            ChangeSpellSlot();
        }
        else
        {
            tutor.MessagaForSepllPanelButton();
            ChangeSpellSlot();
        }
    }

    public IEnumerator StartChangeSpell()
    {
        yield return new WaitForEndOfFrame();
        ChangeSpellSlot(true);
    }

    public void ChangeSpellSlot(bool isBuy = false)
    {
        if (!TutorialsManager.IsAnyTutorialActive)
        {
            ChangeSpellSetMessage(isBuy);
        }
    }

    int level = 0;
    //Step 2
    private void ChangeSpellSetMessage(bool isBuy = false)
    {
        items = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells);

        if (((items[4].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 13) && !SaveManager.GameProgress.Current.tutorialSlot13)
        {
            level = 13;
            OpenTutorial(items[4], tutor.fireWallSpell.transform);
        }
        else if (((items[5].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 16) && !SaveManager.GameProgress.Current.tutorialSlot17)
        {
            level = 16;
            OpenTutorial(items[5], tutor.lightning.transform);
        }
        else if (((items[6].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 21) && !SaveManager.GameProgress.Current.tutorialSlot21)
        {
            level = 21;
            OpenTutorial(items[6], tutor.wind.transform);
        }
        else if (((items[7].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 26) && !SaveManager.GameProgress.Current.tutorialSlot26)
        {
            level = 26;
            OpenTutorial(items[7], tutor.rollingRtone.transform);
        }
        else if (((items[8].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 59) && !SaveManager.GameProgress.Current.tutorialSlot59)
        {
            level = 59;
            OpenTutorial(items[8], tutor.meteor.transform);
        }
        else if (((items[9].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 67) && !SaveManager.GameProgress.Current.tutorialSlot67)
        {
            level = 67;
            OpenTutorial(items[9], tutor.electricPuddle.transform);
        }
        else if (((items[10].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 75) && !SaveManager.GameProgress.Current.tutorialSlot75)
        {
            level = 75;
            OpenTutorial(items[10], tutor.iceRain.transform); 
        }
        else if (((items[11].effectUnlock && isBuy) || SaveManager.GameProgress.Current.CompletedLevelsNumber == 80) && !SaveManager.GameProgress.Current.tutorialSlot80)
        {
            level = 80;
            OpenTutorial(items[11], tutor.gorgula.transform);
        }
    }

    private void OpenTutorial(SpellItem spell, Transform transform)
    {
        if (!SlotsAreFullAndActive())
        {
            SaveProgress();
            return;
        }

        tutor.gameObject.SetActive(true);

        Tutorial.OpenBlock(timer: 1f);

        UIShop.Instance.ActiveSpellItems();
        UIShop.Instance.FocusItem(transform);

        Transform target = transform.Find("PosTutor");
        Transform activeObj = transform.Find("UseBtn_1");

        activeBtn = activeObj.GetComponent<Button>();
        activeBtn.onClick.AddListener(OnActiveSpellItemClicked);

        var o = Tutorial.Open(target: activeObj.gameObject, focus: new Transform[] { transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(45, 60), waiting: 0.2f, keyText: "t_0521");

        SaveProgress();
    }

    private void OnActiveSpellItemClicked()
    {
        activeBtn.onClick.RemoveListener(OnActiveSpellItemClicked);
        tutor.gameObject.SetActive(false);

        Tutorial.Close();
        ChangeSlotSetMessage();
    }

    //Step 3
    private void ChangeSlotSetMessage()
    {
        tutor.spellSlots.SetActive(true);
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);

        tipLabel = tutor.spellSlots.transform.Find("TipLabel");
        tipLabel.gameObject.SetActive(false);

        slotBackground = tutor.spellSlots.transform.Find("DarkBackground");
        slotBackground.GetComponent<Button>().enabled = false;

        for (int i = 0; i < 4; i++)
            tutor.spellSlots.transform.Find("Slots").Find(i + "_slot").gameObject.GetComponent<Button>().enabled = false;
        var s = "";
        if (level == 0 || level == 13)
            s = "3_slot";
        if (level == 16 || level == 75 || level == 67)
            s = "1_slot";
        if (level == 21 || level == 26)
            s = "2_slot";
        if (level == 59 || level == 80)
            s = "0_slot";

        Transform slotObj = tutor.spellSlots.transform.Find("Slots").Find(s);
        slot = slotObj.GetComponent<Button>();
        slot.enabled = true;

        slot.onClick.AddListener(OnSetSlotForNewSpell);

        var o = Tutorial.Open(target: slot.gameObject, focus: null, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(75, 90), waiting: 0f, keyText: "t_0503");

        o.disableAnimation = true;
        o.dublicateObj = false;
        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void OnSetSlotForNewSpell()
    {
        slot.onClick.RemoveListener(OnSetSlotForNewSpell);

        Time.timeScale = LevelSettings.defaultUsedSpeed;
        slotBackground.gameObject.SetActive(true);

        tutor.gameObject.SetActive(false);

        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        Tutorial.Close();

        UIShop.Instance.StartCoroutine(_Tip());

        for (int i = 0; i < 4; i++)
            tutor.spellSlots.transform.Find("Slots").Find(i + "_slot").gameObject.GetComponent<Button>().enabled = true;

        slotBackground.GetComponent<Button>().enabled = true;
    }

    IEnumerator _Tip()
    {
        yield return new WaitForSeconds(2f);
        tipLabel.gameObject.SetActive(true);
    }


    private void SaveProgress()
    {
        SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.SPELL_4_SLOT] = true;
        if (level == 13)
            SaveManager.GameProgress.Current.tutorialSlot13 = true;
        if (level == 16)
            SaveManager.GameProgress.Current.tutorialSlot17 = true;
        if (level == 21)
            SaveManager.GameProgress.Current.tutorialSlot21 = true;
        if (level == 26)
            SaveManager.GameProgress.Current.tutorialSlot26 = true;
        if (level == 59)
            SaveManager.GameProgress.Current.tutorialSlot59 = true;
        if (level == 67)
            SaveManager.GameProgress.Current.tutorialSlot67 = true;
        if (level == 75)
            SaveManager.GameProgress.Current.tutorialSlot75 = true;
        if (level == 80)
            SaveManager.GameProgress.Current.tutorialSlot80 = true;

        SaveManager.GameProgress.Current.Save();
    }
}