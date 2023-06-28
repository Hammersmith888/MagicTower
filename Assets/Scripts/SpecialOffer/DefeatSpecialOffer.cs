using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatSpecialOffer : MonoBehaviour
{

    [SerializeField] private Text text;
    private List<PoisonsManager> poisons = new List<PoisonsManager>();

    [SerializeField] private GameObject manaContent;
    [SerializeField] private GameObject healthContent;
    [SerializeField] private GameObject powerContent;
    [SerializeField] private GameObject ressurectionContent;

    [SerializeField] private Button poisonButton;
    [SerializeField] private Button ressurectionButton;

    [SerializeField] UIAction action;

    private int currentTypeIndex;
    private UIConsFlyAnimation animation;
 
    void Start()
    {
        poisons.Add(PoisonsManager.Get(PotionManager.EPotionType.Health));
        poisons.Add(PoisonsManager.Get(PotionManager.EPotionType.Mana));
        poisons.Add(PoisonsManager.Get(PotionManager.EPotionType.Power));

        PoisonsManager lowerPoison = poisons[0];

        foreach (var poison in poisons)
        {
            if (lowerPoison.CurrentPotion > poison.CurrentPotion)
                lowerPoison = poison;
        }
        SwitchPoison(lowerPoison);
    }

    private void SwitchPoison(PoisonsManager poisons)
    {
        var type = poisons.currentType;
        switch (type)
        {
            case PotionManager.EPotionType.Mana:
                SetActiveContent(manaContent);
                currentTypeIndex = 0;
                text.text = TextSheetLoader.Instance.GetString("t_0092");
                break;
            case PotionManager.EPotionType.Health:
                SetActiveContent(healthContent);
                currentTypeIndex = 1;
                text.text = TextSheetLoader.Instance.GetString("t_0095");
                break;
            case PotionManager.EPotionType.Power:
                SetActiveContent(powerContent);
                currentTypeIndex = 2;
                text.text = TextSheetLoader.Instance.GetString("t_0099");
                break;
        }
    }

    private void SetActiveContent(GameObject poisonObject)
    {
        animation = poisonObject.transform.GetComponentInChildren<UIConsFlyAnimation>();
        poisonObject.SetActive(true);
    }

    public void BuyButton(bool isPower)
    {
        if (isPower)
        {
            ressurectionButton.interactable = false;
            if (ADs.AdsManager.Instance.isAnyVideAdAvailable)
            {
                try
                {
                    ADs.AdsManager.ShowVideoAd((bool result) =>
                    {
                        if (result)
                        {
                            PlayerPrefs.SetInt("LoseStreak", 0);
                            action.BuyForRes(3);
                            animation = ressurectionContent.transform.GetComponentInChildren<UIConsFlyAnimation>();
                            gameObject.SetActive(false);
                        }
                    });
                }
                catch (Exception)
                {
                    gameObject.GetComponent<Animator>().SetTrigger("Hide");
                }
            }
            else
                gameObject.GetComponent<Animator>().SetTrigger("Hide");

        }
        else
        {
            poisonButton.interactable = false;
            if (Application.internetReachability == NetworkReachability.NotReachable)
                gameObject.GetComponent<Animator>().SetTrigger("Hide");
            else
                gameObject.GetComponent<Animator>().SetTrigger("Flip");

            var check = CoinsManager.Instance.BuySomething(550);
            if (check)
            {
                animation.PlayEffect();
                action.BuyForPoison(currentTypeIndex, 6);
            }
        }
    }

    public void DestroyOffer()
    {
        Destroy(gameObject);
    }

}
