using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseStreak : MonoBehaviour
{
    [SerializeField] GameObject vipButton;
    [SerializeField] Image coinImage;
    [SerializeField] GameObject Offer;

    private bool vipStatus;

    private void OnEnable()
    {
        vipStatus = SaveManager.GameProgress.Current.VIP;

        coinImage.enabled = vipStatus;

        if (!vipStatus)
        {
            vipButton.SetActive(true);

            if (PlayerPrefs.HasKey("LoseStreak"))
            {
                var streak = PlayerPrefs.GetInt("LoseStreak");

                AnalyticsController.Instance.LogMyEvent("Louse Streak", new Dictionary<string, string>()
                { { "CurrentLevel", mainscript.CurrentLvl.ToString() },
                  { "Streak", streak.ToString() }
                });

                streak++;
                PlayerPrefs.SetInt("LoseStreak", streak);

                if (streak >= 3)
                {
                    if (CoinsManager.Instance.Coins >= 550)
                    {
                        Offer.SetActive(true);
                    }
                }
            }
            else
            {
                PlayerPrefs.SetInt("LoseStreak", 0);
            }
        }
    }

   
}