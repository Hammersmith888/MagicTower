
using System.Collections;
using UnityEngine;

public class UINewLevelsComingButton : MonoBehaviour
{
	[SerializeField]
    private GameObject text;
    [SerializeField]
    Transform _parent;

    void Start()
    {
        text.SetActive(false);
    }

    public void ShowTextAnim()
    {
        if (SaveManager.GameProgress.Current.CompletedLevelsNumber < 95)
        {
            text.SetActive(true);
            StartCoroutine(_Text());
            return;
        }
        EndGameMessageWindow.openRate = false;
        var  o =  Instantiate(Resources.Load("UI/EndGameLinkWindow"), _parent) as GameObject;
    }
    IEnumerator _Text()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        text.SetActive(false);
    }

}
