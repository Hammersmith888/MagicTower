using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UI;
using Tutorials;


public class BossProgress : MonoBehaviour
{
	[System.Serializable]
	private class BossOnMap
	{
		public Sprite picture;
		public int level;
        public EnemyType enemyType;
        public List<GameObject> infos = new List<GameObject>();
	}
	[SerializeField]
	private List<BossOnMap> Bosses = new List<BossOnMap>();

	private BossOnMap activeBoss;

	[SerializeField]
	private Image percentBar, bossImage;
	[SerializeField]
	private Text percentText;


    [SerializeField]
    float speedEffect = 1;
    [SerializeField]
    bool isEditorTest = false;

    bool isPlay = false;

    float startFillAmount, needFillAmount;
    int openLevel;
    int needLevel;

    public Canvas canvas;

    public Animator _anim;
    public AudioSource _audio;

    public static BossProgress instance;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator Start( )
	{
        canvas = GetComponent<Canvas>();
        var lvl = 0;
        openLevel = lvl = SaveManager.GameProgress.Current.finishCount.Count( i => i > 0 ) + 1;
        if(SaveManager.GameProgress.Current.tutorialBossMapClik15 || SaveManager.GameProgress.Current.tutorialBossMapClik30 || SaveManager.GameProgress.Current.tutorialBossMapClik45)
        {
            Debug.Log($"destroy 1");
            Destroy(GetComponent<GraphicRaycaster>());
            Destroy(GetComponent<Canvas>());
        }
        
        if((lvl != 3) && lvl != 31 && lvl != 46)
        {
            Debug.Log($"destroy 2");
            Destroy(GetComponent<GraphicRaycaster>());
            Destroy(GetComponent<Canvas>());
        }

        percentText.text = PlayerPrefs.GetString("b_prog_text") + "%";

        for ( int i = 0; i < Bosses.Count; i++ )
		{
			if( Bosses[ i ].level >= openLevel )
			{
				activeBoss = Bosses[ i ];
				break;
			}
		}
		if( activeBoss == null )
		{
			gameObject.SetActive( false );
			yield break;
		}

        needLevel = activeBoss.level;
		for( int i = Bosses.Count - 2; i >= 0; i-- )
		{
			if( Bosses[ i ].level < openLevel )
			{
				needLevel -= Bosses[ i ].level;
				openLevel -= Bosses[ i ].level;
				break;
			}
		}

        openLevel -= 1;

        if(lvl == 16)
        {
            
        }
        else
            bossImage.sprite = activeBoss.picture;


        yield return new WaitForSecondsRealtime(1.5f);
        if (lvl != 3 && lvl != 31 && lvl != 46)
        {
            //canvas.sortingOrder = 1;
            Destroy(GetComponent<GraphicRaycaster>());
            Destroy(GetComponent<Canvas>());
        }

        PlayProgress();
    }

    public void IconRemoveCanvas()
    {
        Destroy(GetComponent<GraphicRaycaster>());
        Destroy(GetComponent<Canvas>());
    }

    public void _Start(bool isNewLevel)
    {
        StartCoroutine(_Str(isNewLevel));
    }

    public void OpenAnim()
    {
        var lvl = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) ;
        if (lvl == 15)
            StartCoroutine(_OpenA());
    }

    IEnumerator _OpenA()
    {
        _anim.enabled = true;
        _audio.Play(22050);
        yield return new WaitForSecondsRealtime(0.15f);
        bossImage.sprite = activeBoss.picture;
    }


    IEnumerator _Str(bool isNewLevel)
    {
       
        if (openLevel > 1)
            startFillAmount = ((float)openLevel - 1) / ((float)needLevel);
        needFillAmount = ((float)openLevel) / ((float)needLevel);
        percentBar.fillAmount = isNewLevel ? startFillAmount : needFillAmount;
        percentText.text = ((int)(startFillAmount * 100f)).ToString() + "%";

        PlayerPrefs.SetString("b_prog_text", ((int)(startFillAmount * 100f)).ToString());

        yield return new WaitForSecondsRealtime(2f);
    }

    public void Upd()
    {
        needFillAmount = ((float)openLevel) / ((float)needLevel);
        if (openLevel > 0 && SaveManager.GameProgress.Current.tutorial[(int)ETutorialType.DAILY_SPIN])
        {
            startFillAmount = ((float)openLevel - 1) / ((float)needLevel);
            //needFillAmount = ((float)openLevel) / ((float)needLevel);
            percentBar.fillAmount = needFillAmount;
            percentText.text = ((int)(needFillAmount * 100f)).ToString() + "%";
        }
        else
        {
            percentBar.fillAmount = 0f;
            percentText.text = "0%";
        }
       
    }

    public void BossPressed( )
	{

        Debug.Log("BossPressed");
        for ( int i = 0; i < activeBoss.infos.Count; i++ )
		{
			if( activeBoss.infos[ i ] != null )
				activeBoss.infos[ i ].SetActive( true ); 
		}
       
        if(canvas != null)
            canvas.sortingOrder = 1;
        if (ReplicasConditionsCheckerMap.Current != null && ReplicasConditionsCheckerMap.Current.ShowReplica)
        {
            return;
        }
        if (Tutorial_13_BossIsComing_Map.Current != null && Tutorial_13_BossIsComing_Map.Current.StartTutorial)
        {
            return;
        }
        InfoCallScript.Current.ShowEnemyScreen((int)activeBoss.enemyType, false);
       
    }

    public void PlayProgress()
    {
        if (activeBoss == null)
            return;
        isPlay = true;
    }

    void Update()
    {
        if (isEditorTest)
        {
            PlayProgress();

            isEditorTest = false;
        }

        if (isPlay)
        {
            percentBar.fillAmount = startFillAmount;
            percentText.text = ((int)(startFillAmount * 100f)).ToString() + "%";
            if (startFillAmount < needFillAmount)
                startFillAmount += Time.unscaledDeltaTime * speedEffect;
        }
    }
    
    public void OpenBoss()
    {
        PanelInfoDescription.instance.ShowEnemyScreen(activeBoss.enemyType, false);
    }
}