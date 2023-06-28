using UnityEngine;
using UnityEngine.UI;

public class UIPotionToggle : MonoBehaviour {

    public enum PotionType { mana, health }
    public PotionType potionType = PotionType.mana;
    public GameObject manaPotion, healthPotion, manaBtnImg, healthBtnImg;

    public void ChangePotion()
    {
        switch (potionType)
        {
            case PotionType.mana:
                manaPotion.SetActive(false);
                manaBtnImg.SetActive(true);
                healthPotion.SetActive(true);
                healthBtnImg.SetActive(false);
                potionType = PotionType.health;
                break;
            case PotionType.health:
                healthPotion.SetActive(false);
                healthBtnImg.SetActive(true);
                manaPotion.SetActive(true);
                manaBtnImg.SetActive(false);
                potionType = PotionType.mana;
                break;
        }
    }
}
