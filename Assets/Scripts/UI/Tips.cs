using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    public static Tips instance;
    void Awake()
    {
        instance = this;
    }


    [System.Serializable]
    public class Tip
    {
        public string key;
        public Sprite sprite;
    }

    [SerializeField]
    List<Tip> tips = new List<Tip>();

    [SerializeField]
    Text _text;
    [SerializeField]
    Image img;

    private static int countLose = 0;

    /// <summary>
    /// 0 - mana, health
    /// 1 - easy mod
    /// 2 - fire wall
    /// 3 - scrolls
    /// </summary>
    public bool Show()
    {
        int current = -1;
        var items = PPSerialization.Load<Potion_Items>(EPrefsKeys.Potions);
        if (items[0].count <= 0 || items[1].count <= 0)
            current = 0;
        if((PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUseManaSave) == 0 || PlayerPrefs.GetInt(GameConstants.SaveIds.AutoUseSpellSave) == 0) && current == -1)
            current = 1;
        if (current == -1 && mainscript.CurrentLvl >= 14)
            current = Random.Range(2, 5);
        else if (current == -1)
            current = Random.Range(3, 4);

        countLose++;
        var ii = countLose >= 0;
        if (countLose >= 0 && current != -1)
        {
            _text.text = TextSheetLoader.Instance.GetString(tips[current].key);
            img.sprite = tips[current].sprite;
            img.transform.parent.gameObject.SetActive(tips[current].sprite != null);
            _text.transform.parent.gameObject.SetActive(true);
            if (tips[current].sprite != null)
            {
                var btn = img.gameObject.GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => { 
                    if(current == 0)
                    {
                        PlayerPrefs.SetInt(UIShop.LastActiveShopPagePrefsKey, 2);
                        UIControl.Current.ToShopFromFirstLevel();
                    }
                    if (current == 1)
                    {
                        // PlayerPrefs.SetInt(UIShop.LastActiveShopPagePrefsKey, 0);
                        UIAutoHelperButton.instance.Click();
                    }
                    if (current == 2)
                    {
                        PlayerPrefs.SetInt(UIShop.LastActiveShopPagePrefsKey, 0);
                        UIControl.Current.ToShopFromFirstLevel();
                    }
                    if (current == 3)
                    {
                        PlayerPrefs.SetInt(UIShop.LastActiveShopPagePrefsKey, 1);
                        UIControl.Current.ToShopFromFirstLevel();
                    }
                    if (current == 4)
                    {
                        PlayerPrefs.SetInt(UIShop.LastActiveShopPagePrefsKey, 1);
                        UIControl.Current.ToShopFromFirstLevel();
                    }
                });
            }
            StartCoroutine(_Show());
            countLose = 0;
        }
        return ii;
    }
   
    IEnumerator _Show()
    {
        yield return new WaitForEndOfFrame();
        _text.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().CalculateLayoutInputHorizontal();
        _text.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
        _text.transform.parent.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = 25f;
        _text.transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, _text.transform.parent.gameObject.GetComponent<RectTransform>().anchoredPosition.y);
    }
}
