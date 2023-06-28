
using UnityEngine;
using System.Collections;

public class CasketWithNewItem : MonoBehaviour
{
    #region VARIABLES
    //for testing
    public bool unlockedContent;

    public delegate void SpawnEvent();
    public static event SpawnEvent CasketSpawned;
    public delegate void CollectEvent();
    public static event CollectEvent CasketCollected;

    //[HideInInspector]
    public int casketContent;

    [SerializeField]
    private GameObject _casket;
    [SerializeField]
    private GameObject _shadow_fall_casket;

    private GameObject content;
    private int contentCount = 1; // Количество появляющегося контента
    private bool dissapear; // Если true, то сундук исчезает через waitTime
    private float dissapearTimer;
    private bool clicked;

    private Animator _animCasket;
    private Animator _animShadow;
    private bool shadowOn;
    private bool isCoin;// temporary
    #endregion

    private void Start()
    {
        var barrier = GameObject.FindGameObjectsWithTag("Barrier");
        if (barrier != null)
        {
            foreach (var item in barrier)
            {
                item.GetComponent<BarrierScroll>().DestroyBarrier();
            }
        }

        _animCasket = _casket.GetComponent<Animator>();
        _animShadow = _shadow_fall_casket.GetComponent<Animator>();

        _animCasket.speed = 1.4f;
        shadowOn = true;

        SetupContent();
        transform.position = new Vector3(0, 0, -2.5f);

        EnemiesGenerator.Instance.isVictory = true;

        EnemiesGenerator.Instance.HideAllEffects();
        var coinsOnLevel = GameObject.FindObjectsOfType<AddCoin>();
        foreach (AddCoin item in coinsOnLevel)
        {
            item.TakeCoin();
        }
        this.CallActionAfterDelayWithCoroutine(3f, OnMouseUp);
    }

    private void Update()
    {
        if (shadowOn && _animCasket.GetCurrentAnimatorStateInfo(0).IsName("casket_fall_pulse"))
        {
            TurntOnShadow();
        }
    }

    private void SetupContent()
    {
        isCoin = false;
        switch (casketContent)
        {
            case 0:
                isCoin = true;
                break;
            case 1:
                contentCount = 2;
                isCoin = true;
                break;
            case 2:
                contentCount = 3;
                isCoin = true;
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                SetupScrolls(casketContent);
                break;
            case 7:
                content = Resources.Load("Bonuses/Spells/LightningBonus", typeof(GameObject)) as GameObject;
                break;
            case 8:
                content = Resources.Load("Bonuses/Spells/IceStrikeBonus", typeof(GameObject)) as GameObject;
                break;
            case 9:
               content = Resources.Load("Bonuses/Spells/BoulderBonus", typeof(GameObject)) as GameObject;
                break;
            case 10:
                content = Resources.Load("Bonuses/Spells/FireWallBonus", typeof(GameObject)) as GameObject;
                break;
            case 11:
                content = Resources.Load("Bonuses/Spells/ChainLightningBonus", typeof(GameObject)) as GameObject;
                break;
            case 12:
                content = Resources.Load("Bonuses/Spells/IceBreathBonus", typeof(GameObject)) as GameObject;
                break;
            case 13:
                content = Resources.Load("Bonuses/Spells/BoulderBonus", typeof(GameObject)) as GameObject;
                break;
            case 14:
                content = Resources.Load("Bonuses/PotionManaBonus", typeof(GameObject)) as GameObject;
                break;
            case 15:
                content = Resources.Load("Bonuses/PotionHealthBonus", typeof(GameObject)) as GameObject;
                break;
            case 16:
                content = Resources.Load("Bonuses/RessurPotionBonus", typeof(GameObject)) as GameObject;
                break;
            case 17:
                content = Resources.Load("Bonuses/PowerPotionBonus", typeof(GameObject)) as GameObject;
                break;
            case 18:
            case 19:
                SetupScrolls(casketContent - 11);
                break;
            case 20:
                content = Resources.Load("Bonuses/Spells/MeteorBonus", typeof(GameObject)) as GameObject;
                break;
            case 21:
                content = Resources.Load("Bonuses/Spells/ElectricPoolBonus", typeof(GameObject)) as GameObject;
                break;
            case 22:
                content = Resources.Load("Bonuses/Spells/BlizzardBonus", typeof(GameObject)) as GameObject;
                break;
            case 23:
                content = Resources.Load("Bonuses/Spells/FireDragonBonus", typeof(GameObject)) as GameObject;
                break;
            case 24:
                content = Resources.Load("Bonuses/Spells/EarthBallBonus", typeof(GameObject)) as GameObject;
                break;
            case 25:
                content = Resources.Load("Bonuses/Dragons/FireWallDragonBonus", typeof(GameObject)) as GameObject;
                break;
            case 26:
                content = Resources.Load("Bonuses/Spells/FrostWallDragonBonus", typeof(GameObject)) as GameObject;
                break;
                
            default:
                isCoin = true;
                break;
        }
    }

    private void SetupScrolls(int casketContent)
    {
        Debug.Log($"SetupScrolls: {casketContent}");
        casketContent -= 3;
        string path = "Bonuses/";
        if (!GameObject.FindGameObjectWithTag("ScrollController").GetComponent<ScrollController>().IsScrollUnlock(casketContent))
        {
            path += "ScrollsFirstAppearing/";
        }
        switch (casketContent)
        {
            case 0:
                content = Resources.Load(path + "AcidScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 1:
                content = Resources.Load(path + "BarrierScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 2:
                content = Resources.Load(path + "FrozenScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 3:
                content = Resources.Load(path + "MinesScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 4:
                content = Resources.Load(path + "ZombieScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 5:
                content = Resources.Load(path + "HasteScrollBonus", typeof(GameObject)) as GameObject;
                break;
        }
        AddScroll newScroll = content.transform.GetChild(0).GetChild(0).GetComponent<AddScroll>();
        if (newScroll != null)
        {
            var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
            int id = (int)newScroll.scrollType;
            if (scrollItems[id].unlock)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetItSpawned()
    {
        if (CasketSpawned != null)
        {
            CasketSpawned();
        }
    }

    private void TurntOnShadow(bool yes = false)
    {
        _shadow_fall_casket.gameObject.SetActive(yes);
        shadowOn = yes;
    }

    public void OnMouseUp()
    {
        if (clicked)
        {
            return;
        }

        clicked = true;
        _animCasket.SetTrigger(AnimationPropertiesCach.instance.openCasketAnim);
        this.CallActionAfterDelayWithCoroutine(0.5f, OpenIt);
        //TODO: Check if this needed
        //if (Tutorials.Tutorial_1.Current != null)
        //    Tutorials.Tutorial_1.Current.ContinueGame(3);

        var infoAnim = GameObject.FindObjectOfType<UIInfoAnimation>();
        if (infoAnim != null)
        {
            infoAnim.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    //for testing
    public void RestAnim()
    {
        _animCasket.SetTrigger(AnimationPropertiesCach.instance.restartAnim);
        _animShadow.SetTrigger(AnimationPropertiesCach.instance.restartAnim);
        TurntOnShadow(true);
    }

    public void OpenIt()
    {
        Vector3 position = transform.position;

        for (int i = 0; i < contentCount; i++)
        {
            if (transform.localScale.x > 0.9f)
            {
                position = new Vector3(position.x, position.y, position.z);
            }

            if (isCoin)
            {
                EnemiesGenerator.SpawnCoin(position, Quaternion.identity);
            }
            else
            {
                //  SetupLayerOfContent();
                Instantiate(content, position, Quaternion.identity);
                StartCoroutine(TrySpawnStartWear());
            }
        }

        Invoke("Disappearing", 0.1f);
        if (CasketCollected != null)
        {
            CasketCollected();
        }

        SoundController.Instanse.playOpenChestSFX();
        SoundController.Instanse.playDrobScrollSFX();
        SoundController.Instanse.playScrollUnlockSFX();
    }

    public void Disappearing()
    {
        _animCasket.SetTrigger(AnimationPropertiesCach.instance.disappearingAnim);
        this.CallActionAfterDelayWithCoroutine(0.8f, DestroyIt);
    }

    public void DestroyIt()
    {
        StopAllCoroutines();
        EnemiesGenerator.Instance.RemoveDropFromList(gameObject);
        Destroy(gameObject);
    }

    private IEnumerator TrySpawnStartWear()
    {
        if (LevelSettings.Current.currentLevel != 1)
        {
            yield break;
        }
        CancelInvoke();
        Instantiate(WearAppearBonusesLoaderConfig.Instance.GetWearBonusPrefab(0), transform.position, Quaternion.identity);
        Instantiate(WearAppearBonusesLoaderConfig.Instance.GetWearBonusPrefab(5), transform.position, Quaternion.identity);
        Invoke("Disappearing", 0.1f);

        yield break;
    }
}
