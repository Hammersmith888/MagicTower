using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;

public class UpdateWindowController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public static bool isShow = false;
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (!TutorialsManager.IsAnyTutorialActive && isShow)
            _panel.SetActive(true);
    }

    public void CloseClick()
    {
        AnalyticsController.Instance.LogMyEvent("UpdateWindow", new Dictionary<string, string>()
        {
            { "Click", "Close" }
        });
        _panel.SetActive(false);
    }

    public void UpdateClick()
    {
        AnalyticsController.Instance.LogMyEvent("UpdateWindow", new Dictionary<string, string>()
        {
            { "Click", "Accept" }
        });

        Application.OpenURL("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege");
        _panel.SetActive(false);
    }
}
