using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemInsertToItemChoose : MonoBehaviour
{
    [SerializeField]
    private GameObject cape, staff;
    [HideInInspector]
    public WearType chosenWear = WearType.none;
    [SerializeField]
    private ShopGemItemSettings shopGemItemSettings;
    [SerializeField]
    private bool isPromo;
    private Button[] buttons;
    public int t;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    public void ActivateItem(string item)
    {
        cape.SetActive(false);
        staff.SetActive(false);
        switch (item)
        {
            case "cape":
                chosenWear = WearType.cape;
                cape.SetActive(true);
                break;
            case "staff":
                chosenWear = WearType.staff;
                staff.SetActive(true);
                break;
            default:
                chosenWear = WearType.none;
                break;
        }
        Debug.Log($"ActivateItem: {item}, chosenWear: {chosenWear}");
        shopGemItemSettings.SetActualDescriptions(t);
        StartCoroutine(_Set(t));
        shopGemItemSettings.SetItemChoose(item, t);
    }

    IEnumerator _Set(int t)
    {
        yield return new WaitForEndOfFrame();
        shopGemItemSettings.SetActualDescriptions(t);
    }

    public void ActivateItemObj(string item)
    {
        cape.SetActive(false);
        staff.SetActive(false);
        switch (item)
        {
            case "cape":
                chosenWear = WearType.cape;
                cape.SetActive(true);
                break;
            case "staff":
                chosenWear = WearType.staff;
                staff.SetActive(true);
                break;
            default:
                chosenWear = WearType.none;
                break;
        }
    }

    public void ButtonsInterectable(bool enable)
    {
        if (buttons == null)
        {
            return;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == null)
            {
                continue;
            }
            buttons[i].interactable = enable;
        }
    }
}
