using UnityEngine;
using UnityEngine.UI;

public class BuffMiniInfo : MonoBehaviour {

    private OverUIPopup uIPopup;

    public Image iconImage;
    public Text descriptionText;

    public void OpenIt(Vector3 setPos, Sprite iconSprite, string description)
    {
        iconImage.sprite = iconSprite;
        descriptionText.text = description;

        if (uIPopup == null)
        {
            uIPopup = GetComponent<OverUIPopup>();
        }

        uIPopup.OpenIt(setPos);
    }

    public void OpenIt(Transform setPos, Sprite iconSprite, string description)
    {
        iconImage.sprite = iconSprite;
        descriptionText.text = description;

        if (uIPopup == null)
        {
            uIPopup = GetComponent<OverUIPopup>();
        }
        uIPopup.OpenIt(setPos.transform.position);
    }
}
