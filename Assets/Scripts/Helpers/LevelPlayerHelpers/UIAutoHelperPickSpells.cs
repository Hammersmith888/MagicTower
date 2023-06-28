using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAutoHelperPickSpells : MonoBehaviour {


    [SerializeField]
    private Button backButton;
    [SerializeField]
    private List<Button> slotButtons = new List<Button>();
    [SerializeField]
    private List<Image> slotIcons = new List<Image>();
    UIAutoHelpersWindow uiParent;

    private void Start()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(ClickBackground);
        }

        for (int i = 0; i < slotButtons.Count; i++)
        {
            if (slotButtons[i] != null)
            {
                int slotNumber = i;
                slotButtons[i].onClick.AddListener(delegate { ClickSpellSlot(slotNumber); });
            }

            if (slotIcons[i] != null && ShotController.Current.spells.Length - 1 >= i && ShotController.Current.spells[i].spellIcon != null)
            {
                slotIcons[i].sprite = ShotController.Current.spells[i].spellIcon.sprite;
            }
        }
    }

    private void ClickSpellSlot(int slotNumber)
    {
        LevelPlayerHelpersLoader.Current.usedSlot[slotNumber] = !LevelPlayerHelpersLoader.Current.usedSlot[slotNumber];
        LevelPlayerHelpersLoader.Current.SaveSpellSlotsUsing();

        UpdateSpellSlotUsing(slotNumber);
    }

    private void ClickBackground()
    {
        gameObject.SetActive(false);
        uiParent.CloseSpeels();
    }

    public void ShowSpellSlots(UIAutoHelpersWindow ui)
    {
        gameObject.SetActive(true);

        for (int i = 0; i < slotIcons.Count; i++)
        {
            UpdateSpellSlotUsing(i);
        }
        uiParent = ui;

    }

    private void UpdateSpellSlotUsing(int slotNumber)
    {
        Color setColor = LevelPlayerHelpersLoader.Current.usedSlot[slotNumber] ? Color.white : Color.gray;
        setColor.a = LevelPlayerHelpersLoader.Current.usedSlot[slotNumber] ? 1f : 0.4f;
        slotIcons[slotNumber].color = setColor;
    }
}
