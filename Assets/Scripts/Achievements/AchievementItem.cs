using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Achievement
{
    public class AchievementItem : MonoBehaviour
    {
        [SerializeField]
        Text textName, textDes, textAward, textToMade;
        [SerializeField]
        Image image, imageProgress;
        [SerializeField]
        GameObject lockObj;
        [SerializeField]
        GameObject[] stars;
        [SerializeField]
        Button btnTake;
        public AchievementController.Data data;
        [SerializeField]
        Transform coinsEffectStart;
        Transform startParent;

        public void Set(AchievementController.Data data)
        {
            this.data = data;
            textName.text = TextSheetLoader.Instance.GetString(data.keyName);
            textDes.text = TextSheetLoader.Instance.GetString(data.keyDescription);
            image.sprite = AchievementController.GetSprite(data.achievement);
            textAward.text = data.award.ToString();
            textToMade.text = (data.save.countMade > data.countToFinish ? data.countToFinish : data.save.countMade) + " / " + data.countToFinish;
            imageProgress.fillAmount = (float)(data.save.countMade / (float)data.countToFinish);
            lockObj.SetActive(!data.isSuccess);
            btnTake.interactable = data.isSuccess;
            btnTake.gameObject.SetActive(!data.save.took);
            for (int i = 0; i < stars.Length; i++)
                stars[i].SetActive(false);
            if (data.save.countMade >= data.countToFinish / 3f)
                stars[0].SetActive(true);
            if (data.save.countMade >= data.countToFinish / 2f)
                stars[1].SetActive(true);
            if (data.save.countMade >= data.countToFinish / 1f)
                stars[2].SetActive(true);

            
            if (Achievement.AchievementController.Achievement.FirstWin == data.achievement &&
                !SaveManager.GameProgress.Current.tutorialGetAch &&
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Splash" &&
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Menu")
            {
                if (SaveManager.GameProgress.Current.CompletedLevelsNumber > 1)
                {
                    SaveManager.GameProgress.Current.tutorialGetAch = true;
                    SaveManager.GameProgress.Current.Save();
                    return;
                }
                StartCoroutine(_Tut());
            }
        }

        IEnumerator _Tut()
        {
            Tutorial_2.Instance.closeBtn.interactable = false;

            yield return new WaitForEndOfFrame();
            Debug.Log($"!!!!!!   gameProgress: { SaveManager.GameProgress.Current.tutorialGetAch}");
            Tutorial.Close();
            Tutorial.Open(target: btnTake.gameObject, focus: new Transform[] { gameObject.transform, GameObject.FindObjectOfType<AchievementUIController>().transform.GetChild(1).transform }, mirror: true, rotation: new Vector3(0, 0, -30f), offset: new Vector2(50, 50), waiting: 0f);

        }

        public void Take()
        {
            if (!SaveManager.GameProgress.Current.tutorialGetAch && Tutorial_2.Instance.closeBtn != null)
            {
                Tutorial_2.Instance.closeBtn.interactable = true;
                SaveManager.GameProgress.Current.tutorialGetAch = true;
                SaveManager.GameProgress.Current.Save();
            }

            data.save.took = true;
            CoinsManager.AddCoinsST(data.award);
            AchievementController.Save();
            lockObj.SetActive(true);
            btnTake.interactable = false;
            AnalyticsController.Instance.LogMyEvent("Achievement Claim", new Dictionary<string, string>() {
                { "name", data.achievement.ToString() }
            });
            Tutorial.Close();
            StartCoroutine(_Take());
        }

        IEnumerator _Take()
        {
            if (UIShop.Instance != null)
            {
                startParent = UIShop.Instance.coinsIndecatorIconTransf.transform.parent.parent.parent;
                UIShop.Instance.coinsFlyAnimation.PlayEffect(coinsEffectStart.position, UIShop.Instance.coinsIndecatorIconTransf.position);
            }
            if (UIMap.Current != null)
            {
                startParent = UIMap.Current.coinTargetEffect.parent.parent;
                UIMap.Current.flyCoins.PlayEffect(coinsEffectStart.position, UIMap.Current.coinTargetEffect.position);
            }
            yield return new WaitForSeconds(1.1f);
            AchievementUIController.instance.UpdateData();
            if (UIShop.Instance != null)
                UIShop.Instance.coinsIndecatorIconTransf.transform.parent.parent.SetParent(startParent);
            if (UIMap.Current != null)
                UIMap.Current.coinTargetEffect.parent.SetParent(startParent);
        }
    }

}