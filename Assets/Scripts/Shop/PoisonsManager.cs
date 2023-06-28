using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//TODO: Refactor this or remove completely
public class PoisonsManager : MonoBehaviour
{
    //[SerializeField]
    public PotionManager.EPotionType currentType;
    [SerializeField]
    private Text Current_Poison;

    private Potion_Items potionItems = new Potion_Items(PotionItem.PotionsNumber);
    private void LoadData()
    {
        for (int i = 0; i < potionItems.Length; i++)
            potionItems[i] = new PotionItem();

        potionItems = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
    }

    public int CurrentPotion
    {
        get
        {
            LoadData();
            if (Current_Poison)
                if (potionItems != null)
                    Current_Poison.text = potionItems[(int)currentType].count.ToString();
                else
                    Current_Poison.text = "0";
            return potionItems[(int)currentType].count;
        }
    }
    
    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if (Current_Poison != null)
            Current_Poison.text = CurrentPotion.ToString();
    }

    public void UpdateCount()
    {
        if (Current_Poison != null)
            Current_Poison.text = CurrentPotion.ToString();
    }

    private void OnFacebookLoginListener()
    {
        Start();
    }

    private void OnEnable()
    {
        Social.FacebookManager.OnFacebookLogin += OnFacebookLoginListener;
    }

    private void OnDestroy()
    {
        Social.FacebookManager.OnFacebookLogin -= OnFacebookLoginListener;
    }
    public void TimeStop(bool value)
    {
        if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
        }
    }

    public void Save(PotionManager.EPotionType currentType, int value)
    {

        potionItems[(int)currentType].count = value;
        Debug.LogError(potionItems[(int)currentType].count);

        if (potionItems[(int)currentType].count < 0)
            potionItems[(int)currentType].count = 0;

        PPSerialization.Save(EPrefsKeys.Potions, potionItems);

        if (Current_Poison)
            Current_Poison.text = potionItems[(int)currentType].count.ToString();
    }

    public static PoisonsManager Get(PotionManager.EPotionType currentType)
    {
        var find = FindObjectsOfType<PoisonsManager>();
        for (int i = 0; i < find.Length; i++)
        {
            if (find[i].currentType == currentType)
                return find[i];
        }
        return null;
    }
}
