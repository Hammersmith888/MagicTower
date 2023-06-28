using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementUI : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Image img;
    [SerializeField]
    Text textName;
    [SerializeField]
    GameObject[] stars;


    public static void Open(Achievement.AchievementController.Data item)
    {
        GameObject o = Instantiate(Resources.Load("UI/CanvasAchivementSide")) as GameObject;
        o.GetComponent<AchivementUI>().Set(item);
    }

    public void Set(Achievement.AchievementController.Data item)
    {
        textName.text = TextSheetLoader.Instance.GetString(item.keyName);
        if (item.save.countMade >= item.countToFinish / 3f)
            stars[0].SetActive(true);
        if (item.save.countMade >= item.countToFinish / 2f)
            stars[1].SetActive(true);
        if (item.save.countMade >= item.countToFinish / 1f)
            stars[2].SetActive(true);
        img.sprite = Achievement.AchievementController.GetSprite(item.achievement);
    }

    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(4f);
        Close();
    }

    public void Close()
    {
        StartCoroutine(_Close());
    }

    IEnumerator _Close()
    {
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("hide");
        yield return new WaitForSecondsRealtime(1f);
        Destroy(gameObject);
    }
}
