using UnityEngine;
using System.Collections;
using UI;
using Tutorials;
using UnityEngine.SceneManagement;

public class UILowMana : MonoBehaviour
{
    [SerializeField]
    private GameObject textInChiledren, adsForManaWindow;
    private int lowManaTimesCounter;
    private bool adsUsed;

    void Start()
    {
        textInChiledren.SetActive(false);
    }

    public void ShowLowMana()
    {
        textInChiledren.SetActive(true);
        textInChiledren.GetComponent<Animator>().SetTrigger(AnimationPropertiesCach.instance.restartAnim);
        SoundController.Instanse.playLowManaSFX();
        if (SceneManager.GetActiveScene().name != "Shop")
            CountLowManaShown();
    }

    private IEnumerator WaitForMoreLowManaShows()
    {
        yield return new WaitForSecondsRealtime(2f);
        lowManaTimesCounter = 0;
        //textInChiledren.SetActive(false);
        yield break;
    }

    private void OnDisable()
    {
        textInChiledren.SetActive(false);
    }

    private void CountLowManaShown()
    {
        if (adsUsed || PlayerController.Instance.CurrentHealth == 0 || GameObject.FindObjectOfType<ReplicaUI>())
        {
            return;
        }

        lowManaTimesCounter++;
        StopAllCoroutines();

        if (lowManaTimesCounter >= 4 && PotionManager.GetPotionsNumber(PotionManager.EPotionType.Mana) <= 0  && Time.timeScale > 0)
        {
            if (adsForManaWindow != null && ADs.AdsManager.Instance.isAnyVideAdAvailable)
            {
                if (!TutorialsManager.IsAnyTutorialActive)
                {
                    adsUsed = true;
                    if (!SaveManager.GameProgress.Current.mapLowMana)
                    {   
                        Time.timeScale = 0f;
                        UIPauseController.Instance.pauseCalled = true;
                        var o = Instantiate(adsForManaWindow, UIControl.Current.transform) as GameObject;
                        o.GetComponent<UIAdsToManaWindow>().type = UIAdsToManaWindow.TypePotions.Mana;
                    }
                }
            }
        }
        else
        {
            StartCoroutine(WaitForMoreLowManaShows());
        }

    }
}
