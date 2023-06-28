using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PromoBonusController : MonoBehaviour
{
    public InputField inputField;

    public GameObject[] panels;

    public Text coins, badLabel;
    int currentAward;
    public UIConsFlyAnimation fly;
    public Transform targetFly;

    public Button btnClaim, btnReedem;
    string word;

    class Word
    {
        public string word;
        public float coins;
    }

    private void Awake()
    {
        //inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return SetToUpper(addedChar); };
    }

    public char SetToUpper(char c)
    {
        string str = c.ToString().ToUpper();
        char[] chars = str.ToCharArray();
        return chars[0];
    }

    public void OnEnable()
    {
        panels[0].SetActive(SaveManager.GameProgress.Current.typePromoCode == 0);
        panels[1].SetActive(SaveManager.GameProgress.Current.typePromoCode == 1);
        panels[2].SetActive(false);
        inputField.text = "";
        btnReedem.interactable = false;
       
        inputField.ActivateInputField();
        inputField.Select();
        AnalyticsController.Instance.LogMyEvent("Press_PromoCode");
        coins.text = PlayerPrefs.GetInt("PromoCoins").ToString();
        ////inputField.OnPointerClick(new UnityEngine.EventSystems.PointerEventData());
        //EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        //inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    public void Reedem()
    {
        if (inputField.text.ToLower() == "reset" && DebugButtons.Instance != null)
        {
            DebugButtons.Instance.ClearPrefsAndQuit();
            return;
        }

        foreach (var o in panels)
            o.SetActive(false);

        var p = BalanceTables.Instance.OtherParameters;
        List<Word> w = new List<Word>();

        foreach (var o in p)
        {
            if(o.name == "bonus_word")
            {
                w.Add(new Word { word= o.value1, coins = o.value2 });
            }
        }
        // t_0671 , t_0666
        int x = 0;
        int z = 0;

        string input = inputField.text.ToUpper();

        foreach (var o in w)
        {
            if (input == o.word)
            {
                int a = 0;
                foreach (var v in SaveManager.GameProgress.Current.GetStringList("words_promo"))
                {
                    if (v == o.word)
                    {
                        a++;
                        z++;
                    }
                }
                if (a == 0)
                {
                    currentAward = (int)o.coins;
                    panels[1].SetActive(true);
                    coins.text = currentAward.ToString();
                    PlayerPrefs.SetInt("PromoCoins", currentAward);
                    SaveManager.GameProgress.Current.SetString("words_promo", o.word);
                    SaveManager.GameProgress.Current.typePromoCode = 1;
                    SaveManager.GameProgress.Current.Save();
                    btnClaim.interactable = true;
                    word = o.word;
                    x++;
                    break;
                }
            }
        }

        if(x == 0)
        {
            panels[2].SetActive(true);
            badLabel.text = TextSheetLoader.Instance.GetString((z > 0 ? "t_0671" : "t_0666"));
        }
        inputField.text = "";
        btnReedem.interactable = false;
    }

    public void CangeText()
    {
        //inputField.text = inputField.text
        btnReedem.interactable = inputField.text.Length > 0;
    }

    public void Ok()
    {
        foreach (var o in panels)
            o.SetActive(false);
        panels[0].SetActive(true);
        inputField.text = "";
        btnReedem.interactable = false;
    }

    public void Claim()
    {
        StartCoroutine(_Claim());
        btnClaim.interactable = false;
        fly.PlayEffect(targetFly.position);
    }

    IEnumerator _Claim()
    {
        SaveManager.GameProgress.Current.typePromoCode = 0;
        SaveManager.GameProgress.Current.Save();
        CoinsManager.AddCoinsST(currentAward);
        for (int i = 0; i < 5; i++)
        {
            SoundController.Instanse.playAddCoinSFX();
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return new WaitForSecondsRealtime(1.5f);
        
        foreach (var o in panels)
            o.SetActive(false);
        panels[0].SetActive(true);
       
        inputField.text = "";
        btnReedem.interactable = false;
        AnalyticsController.Instance.LogMyEvent("Get_PromoCode_" + word);
        panels[0].transform.parent.parent.gameObject.SetActive(false);
    }
}
