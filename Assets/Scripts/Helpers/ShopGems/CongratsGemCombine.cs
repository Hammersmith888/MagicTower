using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CongratsGemCombine : MonoBehaviour
{
    [SerializeField]
    private Image gemImage;
    [SerializeField]
    private Text gemDescription, gemLevel;
    [SerializeField]
    private Animation splashAnimationLeft;
    [SerializeField]
    private Animation splashAnimationRight;
    [SerializeField]
    private GemsLoaderConfig gemsLoaderConfig;
    [SerializeField]
    private BuffsLoaderConfig buffsLoaderConfig;
    [SerializeField]
    private ShopGemItemSettings shopGemItemSettings;

    public void StartWithGem(Gem gem, WearType wearType)
    {
        Sprite setSprite = Resources.Load<Sprite>(gemsLoaderConfig.GetGem(gem));
        if (setSprite != null)
        {
            gemImage.sprite = setSprite;
        }
        Buff gotBuffCape = buffsLoaderConfig.GetGemBuffInWear(gem, WearType.cape);
        Buff gotBuffStaff = buffsLoaderConfig.GetGemBuffInWear(gem, WearType.staff);
        string buffStringCape = TextSheetLoader.Instance.GetString(gemsLoaderConfig.GetStringId(gotBuffCape.buffType)).Replace("#", gotBuffCape.buffValue.ToString());
        string buffStringStaff = TextSheetLoader.Instance.GetString(gemsLoaderConfig.GetStringId(gotBuffStaff.buffType)).Replace("#", gotBuffStaff.buffValue.ToString());
        switch (wearType)
        {
            case WearType.cape:
                gemDescription.text = buffStringCape;
                break;
            case WearType.staff:
                gemDescription.text = buffStringStaff;
                break;
            case WearType.none:
                gemDescription.text = buffStringCape + " / " + buffStringStaff;
                break;
        }
        gemLevel.text = TextSheetLoader.Instance.GetString("t_0364").Replace("#", (gem.gemLevel + 1).ToString());
        gameObject.SetActive(true);
        splashAnimationLeft.Play();
        splashAnimationRight.Play();
        GetComponent<AudioSource>().Play();
    }

    public void CloseIt()
    {
        splashAnimationLeft.Stop();
        splashAnimationRight.Stop();
        gameObject.SetActive(false);
    }
}
