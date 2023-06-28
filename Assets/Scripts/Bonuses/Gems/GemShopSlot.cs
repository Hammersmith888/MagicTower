using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemShopSlot : MonoBehaviour
{
    public int gemLevel;
    public GemType gemType;
    public GameObject activeFrame;
    [HideInInspector]
    public Image activeFrameImage;
    [SerializeField]
    private Image gemImage;
    [SerializeField]
    private Text gemsCount, levelNumber;
    [SerializeField]
    private ShopGemItemSettings shopGem;
    private Button activeFrameButton = null;

    public Button ActiveFrameButton
    {
        get
        {
            return activeFrameButton;
        }
    }

    private void Awake()
    {
        if (levelNumber != null)
        {
            levelNumber.text = TextSheetLoader.Instance.GetString("t_0407").Replace("#", (gemLevel + 1).ToString());
        }
        if (activeFrame != null)
        {
            activeFrameImage = activeFrame.GetComponent<Image>();
            activeFrameButton = activeFrame.GetComponent<Button>();
        }
    }

    public void SetType(GemType gemType)
    {
        Gem newGem = new Gem();
        newGem.gemLevel = gemLevel;
        newGem.type = gemType;
        Sprite newSprite = Resources.Load<Sprite>(shopGem.gemsLoaderConfig.GetGem(newGem));
        if (newSprite != null)
        {
            gemImage.sprite = newSprite;
        }
    }

    public void SetCount(int number, bool useColor = true)
    {
        if (number <= 0)
        {
            if (gemsCount != null)
            {
                gemsCount.gameObject.SetActive(false);
            }
            if(useColor)
                gemImage.color = Color.clear;
        }
        else
        {
            if (gemsCount != null)
            {
                gemsCount.gameObject.SetActive(true);
                gemsCount.text = number.ToString();
            }
            if(useColor)
                gemImage.color = Color.white;
        }
    }

    public void OnClick()
    {
        shopGem.ChooseGem(gemLevel);
    }
}
