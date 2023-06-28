using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScroll4SlotAreFull
{
    private const int ZOMBIE_INDEX = 4;
    private const int MAX_SLOTS = 4;
    private const int MIN_LEVEL_INDEX_TO_SHOW = 54;

    private Tutorial_2 tutor;
    private Button activeBtn;
    private Button slot;

    Transform tipLabel;

    public TutorialScroll4SlotAreFull(Tutorial_2 tutor)
    {
        this.tutor = tutor;
    }

    public void Run()
    {
        int idTutor = (int)ETutorialType.SCROLL_4_SLOT;
        if (ValidationRun())
        {
            Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);
            tutor.gameObject.SetActive(true);
            //MonoBehaviour.print("progress.tutorial[(int)ETutorialType.FIRST_CRYSTAL_SHOP] = " + tutor.Progress.tutorial[idTutor].ToString());
            if (!SaveManager.GameProgress.Current.tutorial[idTutor])
            {
                tutor.StartCoroutine(WaitForStaffActiveMessageFirstCrystal());
            }
        }
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
        int idTutor = (int)ETutorialType.SCROLL_4_SLOT;
        return SaveManager.GameProgress.Current.tutorial[idTutor];
    }

    private bool SlotsAreFullAndActive()
    {
        int countScrollActive = 0;
        var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls.ToString());

        if (scrollItems[ZOMBIE_INDEX].active)
        {
            return false;
        }

        for (int i = 0; i < scrollItems.Length; i++)
        {
            if (scrollItems[i].active)
            {
                countScrollActive++;
            }
        }
        if (countScrollActive >= MAX_SLOTS) // slots are full
        {
            return true;
        }

        return false;
    }

    private IEnumerator WaitForStaffActiveMessageFirstCrystal()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        SpellPanelActiveMessage();
    }

    //Step 1
    private void SpellPanelActiveMessage()
    {
        Debug.Log(" -----------!!!!!!------- SpellPanelActiveMessage");
        if (tutor.ButtonInFocus != null)
        {
            Debug.LogFormat("UpgradeButton is busy by {0}", tutor.ButtonInFocus.transform.name);
            Extensions.CallActionAfterDelayWithCoroutine(tutor, 0.03f, SpellPanelActiveMessage, true);
            return;
        }
        ShopScrollItemSettings.Current.countOpen = -1;
        if (UIShop.Instance.IsActiveScrollItems())
        {
            OnScrollActive();
        }
        else
        {
            OnScrollActive();
            //Tutorial.Open(target: tutor.scrollPanel.gameObject, focus: new Transform[] { tutor.scrollPanel.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(85, 60), waiting: 0.5f, keyText: "t_0525");
            ////tutor.MessagaForScrollPanelButton();
            //tutor.scrollPanel.onClick.AddListener(OnScrollActive);
        }
    }

    private void OnScrollActive()
    {
        Tutorial.Close();
        tutor.scrollPanel.onClick.RemoveListener(OnScrollActive);
        //tutor.ContinueGame();
        ContinueZombieTutor();
    }

    public void ContinueZombieTutor()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        if (!SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.SCROLL_4_SLOT])
        {
            tutor.gameObject.SetActive(true);
            
            UIShop.Instance.ActiveScrollItems();
            Extensions.CallActionAfterDelayWithCoroutine(tutor, 0.03f, ZombieSetMessage, true);
        }
    }

    //Step 2
    private void ZombieSetMessage()
    {
        
        UIShop.Instance.FocusItem(tutor.zobieScroll.transform);
        //TutorialUtils.AddCanvasOverrideWithoutRaycaster(tutor.zobieScroll.gameObject);
        Transform activeObj = tutor.zobieScroll.transform.Find("UseBtn_1");
        activeBtn = activeObj.GetComponent<Button>();
        activeBtn.onClick.AddListener(OnActiveScrollItemClicked);
        Tutorial.OpenBlock(timer: 3.2f);
        //tutor.FocusUIButtonTutorial((int)(ETutorialType.SCROLL_4_SLOT), activeBtn.gameObject, "t_0525", 0.5f);
        Tutorial.Open(target: activeBtn.gameObject, focus: new Transform[] { activeBtn.gameObject.transform.parent }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(45, 60), waiting: 3f, keyText: "");
    }

    private void OnActiveScrollItemClicked()
    {
        Tutorial.Close();
        //tutor.gameObject.SetActive(false);
        activeBtn.onClick.RemoveListener(OnActiveScrollItemClicked);
        //TutorialUtils.ClearAllCanvasOverrides();
        ChangeSlotSetMessage();
    }

    //Step 3
    private void ChangeSlotSetMessage()
    {
        //tutor.scrollSlots.SetActive(true);
       
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(false);
        Transform slotObj = tutor.scrollSlots.transform.Find("Slots").Find("0_slot");
        slot = slotObj.GetComponent<Button>();
        tipLabel = tutor.scrollSlots.transform.Find("TipLabel");
        tipLabel.gameObject.SetActive(false);
        slot.onClick.AddListener(OnSetSlotForNewSpell);
        var o = Tutorial.Open(target: slot.gameObject, focus: new Transform[] { slot.gameObject.transform }, mirror: false, rotation: new Vector3(0, 0, 0), offset: new Vector2(45, 60), waiting: 0f, keyText: "t_0524");
        //tutor.FocusUIButtonTutorial((int)(ETutorialType.SCROLL_4_SLOT), slot.gameObject, "t_0524", 0.5f);
        o.disableAnimation = true;
        o.dublicateObj = false;
        o.mainPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private void OnSetSlotForNewSpell()
    {
        Tutorial.Close();
        Time.timeScale = LevelSettings.defaultUsedSpeed;
       
        UIShop.Instance.StartCoroutine(_Tip());
        //tutor.gameObject.SetActive(false);
        slot.onClick.RemoveListener(OnSetSlotForNewSpell);
        //TutorialUtils.ClearAllCanvasOverrides();
        UI.UIBackbtnClickDispatcher.ToggleBackButtonDispatcher(true);
        SaveProgress();
    }
    IEnumerator _Tip()
    {
        yield return new WaitForSeconds(2f);
        tipLabel.gameObject.SetActive(true);
    }

    private void SaveProgress()
    {
        SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.SCROLL_4_SLOT] = true;
        SaveManager.GameProgress.Current.Save();
    }
}