using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UICheckIfEnoughCoins : MonoBehaviour
{
    [SerializeField] Button[] _buttonsToCheck;
    [SerializeField] GameObject[] _popUpWindowToShow;
    [SerializeField] int _amountOfCoinsNeeded;
    void OnEnable()
    {
        EnableDisableButtonIfEnoughCoins();
    }

    async void EnableDisableButtonIfEnoughCoins()
    {
        foreach (var b in _buttonsToCheck)
        {
            if (CoinsManager.Instance.Coins >= _amountOfCoinsNeeded)
            {
                b.interactable = true;
                ShowBuyCoinsPopUp();
            }
            else
            {
                b.interactable = false;
                await Task.Delay(500);
                ShowBuyCoinsPopUp(true);
                gameObject.SetActive(false);
            }
        }
    }

    void ShowBuyCoinsPopUp(bool showHide = false)
    {
        foreach (var popUp in _popUpWindowToShow)
        {
           popUp.SetActive(showHide); 
        }
    }
}
