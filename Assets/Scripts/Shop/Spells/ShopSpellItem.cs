using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopSpellItem : ShopItem
{
    [Space(10f)]
    public Spell.SpellType spellType;
    public Button unlockButton;
    public Sprite spellIcon;

    [HideInInspector] public ShopSpellItemSettings shopSpellItemSettings;
    [HideInInspector] public int shopSpellIndex;

    public void Init(ShopSpellItemSettings shopSpellItemSettings)
    {
        shopSpellIndex = this.transform.GetSiblingIndex();
        this.shopSpellItemSettings = shopSpellItemSettings;
        upgradeBtn.onClick.AddListener(OnUpgradeClicked);
        if (unlockButton != null)
        {
            unlockButton.onClick.AddListener(OnUnlockClicked);
        }
        if (useButton != null)
        {
            useButton.GetComponent<Button>().onClick.AddListener(OnActivateClicked);
        }
        if (spellLock != null)
        {
            spellLock.Init(shopSpellItemSettings.IsUnlock(shopSpellIndex));
        }
    }

    private void OnUpgradeClicked()
    {
        shopSpellItemSettings.UpgradeSpell(shopSpellIndex);
    }

    private void OnUnlockClicked()
    {
        if (shopSpellItemSettings.IsUnlock(shopSpellIndex))
            return;
        if (shopSpellItemSettings.IsCan(shopSpellIndex))
            UnlockSpell();
        else
            shopSpellItemSettings.uiShop.OpenBuyCoins();
    }

    private void UnlockSpell()
    {
        AnalyticsController.Instance.LogMyEvent("ShopBuySpell: " + spellType);

        gameObject.GetComponent<Animator>().enabled = true;

        shopSpellItemSettings.UnlockSpell(shopSpellIndex);

        shopSpellItemSettings.UnlockSpellObj(shopSpellIndex, false);

        if (spellLock != null)
            StartCoroutine(spellLock.UnlockText());

        StartCoroutine(Tutorial_2.Instance.SpellTutorial4SlotAreFull.StartChangeSpell());
    }

    private void OnActivateClicked()
    {
        shopSpellItemSettings.OpenSpellSlotSelector(shopSpellIndex);
    }
}