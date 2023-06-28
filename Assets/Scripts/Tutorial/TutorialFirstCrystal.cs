using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFirstCrystal
{
    private bool breakMessage17;
    private MonoBehaviour monoBehaviour;
    private Camera uiCamera;
    private GameObject[] messages;
    private UIPauseController pause;
    private Action<Vector3, bool> PlaceHandPointer;
    private Action<RectTransform, Vector3> CenterBlackOnObject;
    private GemCollectable gemCollectable;
    private Vector3 handPivotPoint;
    private Vector3 handPivotPoint2;
    private Image backgroundImage;
    public Tutorial_1 tutor;

    public TutorialFirstCrystal(MonoBehaviour monoBehaviour,
                                Camera uiCamera,
                                GameObject[] messages,
                                UIPauseController pause,
                                SaveManager.GameProgress progress,
                                Action<Vector3, bool> PlaceHandPointer,
                                Action<RectTransform, Vector3> CenterBlackOnObject)
    {
        this.monoBehaviour = monoBehaviour;
        this.uiCamera = uiCamera;
        this.messages = messages;
        this.pause = pause;
        this.PlaceHandPointer = PlaceHandPointer;
        this.CenterBlackOnObject = CenterBlackOnObject;

    }
    public void ShowMessage(Core.BaseEventParams eventParams)
    {
        GemCollectable currentGem = eventParams.GetParameterUnSafe<GemCollectable>();
        if (mainscript.CurrentLvl == 2)
        {
            if (currentGem.Gem.type == GemType.Blue)
            {
                Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.GEM_SPAWN, ShowMessage);

                gemCollectable = currentGem;
                gemCollectable.Collider.enabled = false; //Disable click
                gemCollectable.timerCollect = false; //timer collect
                gemCollectable.unscaledAnim = true;

                Extensions.CallActionAfterDelayWithCoroutine(monoBehaviour, 1f, ShowTutorialForCrystalPickup, true);
            }
        }

        Debug.Log($"currentGem.Gem.gemLevel: {currentGem.Gem.gemLevel}");
        if (currentGem.Gem.type == GemType.Red && currentGem.Gem.gemLevel == 3 && mainscript.CurrentLvl == 15)
        {
            gemCollectable = currentGem;
            gemCollectable.Collider.enabled = false; //Disable click
            gemCollectable.timerCollect = false; //timer collect
            gemCollectable.unscaledAnim = true;
            Extensions.CallActionAfterDelayWithCoroutine(monoBehaviour, 5f, Show, true);
        }
    }

    void Show()
    {
        Transform coin = gemCollectable.transform;
        messages[11].SetActive(true);
        Time.timeScale = 0f;
        pause.pauseCalled = true;
        // Вычисляю позицию кристалла и стрелки через экранные координаты, т.к. один объект на сцене, а другой UI
        GameObject arrow = messages[11].transform.GetChild(2).gameObject;
        RectTransform arrowRT = arrow.GetComponent<RectTransform>();
        Vector3 offsetHand = new Vector3(-0.5f, 0f, 0);
        Vector3 offsetHand2 = new Vector3(-0.1f, -0.6f, 0);
        var coinPosition = coin.transform.position;
        handPivotPoint = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(coinPosition + offsetHand));
        handPivotPoint2 = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(coinPosition + offsetHand2));
        Transform background = messages[11].transform.GetChild(0);
        RectTransform backgroundRectTransform = background.GetComponent<RectTransform>();
        backgroundImage = background.GetComponent<Image>();
        CenterBlackOnObject(backgroundRectTransform, coinPosition);
        messages[11].transform.GetChild(1).gameObject.SetActive(false);
        backgroundImage.raycastTarget = false;
        PlaceHandPointer(handPivotPoint, true);
        if (mainscript.CurrentLvl == 15)
        {
            PlaceHandPointer(handPivotPoint2, true);
            CenterBlackOnObject(backgroundRectTransform, coinPosition+offsetHand2);
            PlayerPrefs.SetInt("CanGrabCrystal", 1);
        }


        Extensions.CallActionAfterDelayWithCoroutine(monoBehaviour, 0.5f, _End, true);
    }

    private void EnableClick(EReplicaID replicaID)
    {
        ReplicaUI.OnReplicaComplete -= EnableClickCrystal;
        Extensions.CallActionAfterDelayWithCoroutine(monoBehaviour, 1f, _End, true);
    }

    void _End()
    {
        Time.timeScale = LevelSettings.defaultUsedSpeed;
        pause.pauseCalled = false;
        backgroundImage.raycastTarget = true;
        gemCollectable.Collider.enabled = true;
        gemCollectable._action = _Clickcc;
    }

    void _Clickcc()
    {
        messages[11].SetActive(false);
        tutor.HideHandPointer();
    }

    private void ShowTutorialForCrystalPickup()
    {
        if (breakMessage17)
        {
            Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.GEM_SPAWN, ShowMessage);
            return;
        }
        Core.GlobalGameEvents.Instance.LaunchEvent(Core.EGlobalGameEvent.TUTORIAL_START);

        Transform coin = gemCollectable.transform;
        breakMessage17 = true;
       
        messages[11].SetActive(true);
        //Time.timeScale = 0f;
        //pause.pauseCalled = true;
        // Вычисляю позицию кристалла и стрелки через экранные координаты, т.к. один объект на сцене, а другой UI
        GameObject arrow = messages[11].transform.GetChild(2).gameObject;
        RectTransform arrowRT = arrow.GetComponent<RectTransform>();
        Vector3 offsetHand = new Vector3(-0.5f, 0, 0);
        var coinPosition = coin.transform.position;
        handPivotPoint = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(coinPosition + offsetHand));
        Transform background = messages[11].transform.GetChild(0);
        RectTransform backgroundRectTransform = background.GetComponent<RectTransform>();
        backgroundImage = background.GetComponent<Image>();
        CenterBlackOnObject(backgroundRectTransform, new Vector3(coinPosition.x, coinPosition.y - 0.1f));
        messages[11].transform.GetChild(1).gameObject.SetActive(false);
        backgroundImage.raycastTarget = false;

        ReplicaUIDarkBackground.CanvasDisable();

        EnableClickCrystal(EReplicaID.Level2_Mage2_FirstCrystal1);

        //ReplicaUI.OnReplicaComplete -= EnableClickCrystal;
        //ReplicaUI.OnReplicaComplete += EnableClickCrystal;
    }

    private void EnableClickCrystal(EReplicaID replicaID)
    {
        //ReplicaUI.OnReplicaComplete -= EnableClickCrystal;

        backgroundImage.raycastTarget = true;
        PlaceHandPointer(handPivotPoint, true);
        gemCollectable.Collider.enabled = true;
        messages[11].transform.GetChild(1).gameObject.SetActive(true);
        PlayerPrefs.SetInt("CanGrabCrystal",1);

    }

    public void CollectCrystal()
    {
        try
        {
            gemCollectable.timerCollect = true;
            gemCollectable.waittime = 0;
            gemCollectable.UpdateObject();
        }
        catch (Exception) { }
    }

    public void OnItemPickedByPlayerGems(Core.BaseEventParams eventParams)
    {
       
        if (mainscript.CurrentLvl != 2)
            return;
        UI.UIBattleElementPositionHolder.EUIElementType elementType = eventParams.GetParameterUnSafe<UI.UIBattleElementPositionHolder.EUIElementType>();
        if (elementType == UI.UIBattleElementPositionHolder.EUIElementType.GEMS)
        {
            tutor.ContinueGame(11);

            Core.BattleEventsMono.BattleEvents.RemoveListenerFromEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, OnItemPickedByPlayerGems);
            //ReplicasConditionsChecker.Current.ShowLevelMageReplica();
            breakMessage17 = true;
            SaveManager.GameProgress.Current.tutorial[(int)(ETutorialType.FIRST_CRYSTAL_INGAME)] = true;
            SaveManager.GameProgress.Current.Save();
        }
    }
}