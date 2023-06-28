using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMessageWindow : MonoBehaviour
{
    [SerializeField]
    private Button closeButton, linkButton;
    public static bool openRate = true;

    void Start()
    {
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(OnCloseClicked);
        }

        if (linkButton != null)
        {
            linkButton.onClick.AddListener(OnLinkClicked);
        }
    }

    private void OnCloseClicked()
    {
        if(openRate)
            CallRateLink.OpenLate(2);
        PlayerPrefs.SetInt(GameConstants.SaveIds.ShowLikeButtonOnMainMenu, 2);
        //UIBlackPatch.Current.Appear("Menu");
        Destroy(gameObject);
    }

    private void OnLinkClicked()
    {
        //Application.OpenURL(GameConstants.LinksIds.GameVisitPage);
    }

}
