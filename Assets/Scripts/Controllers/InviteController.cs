using Social;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class InviteController : MonoBehaviour
{
    public static InviteController instance;

    private void Awake()
    {
        instance = this;
    }
    public GameObject invitePanel;
    public GameObject fbBtn, btnInvite;

    void Start()
    {
        if(!FacebookManager.Instance.isLoggedIn && SaveManager.GameProgress.Current.CompletedLevelsNumber >= 61 && SaveManager.GameProgress.Current.CompletedLevelsNumber <= 65)
        {
            btnInvite.SetActive(false);
            fbBtn.SetActive(true);
            if(PlayerPrefs.GetInt("pop_facebook") == 0)
                FacebookUIController.current.ShowLoginWindowIfWasNotLoggedIn();
            PlayerPrefs.SetInt("pop_facebook", 1);
        }
        else
            fbBtn.SetActive(false);
    }

    public void OpenInvite()
    {
        invitePanel.SetActive(true);
    }

    public void UpdateFB()
    {
        btnInvite.SetActive(true);
        fbBtn.SetActive(false);
    }
}
