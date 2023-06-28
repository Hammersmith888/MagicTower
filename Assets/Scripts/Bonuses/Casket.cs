using System.Collections;
using UnityEngine;

public class Casket : BaseUpdatableObject
{
    //[HideInInspector]
    public int casketContent;
    public int waitTime; // Время через которое сундук исчезает (только для выпадающих сундуков)
    [Tooltip("Time when casket will start blinking")]
    public int startBlinkTime; //(только для выпадающих сундуков)

    private GameObject content;
    private int contentCount = 1; // Количество появляющегося контента
    private bool dissapear; // Если true, то сундук исчезает через waitTime
    private float lifeTimeTimer;
    private bool clicked;
    int contentCascet;

    [SerializeField]
    private Animations.AlphaColorAnimation alphaColorAnim;
    [SerializeField]
    private Animations.Blinking blinkingAnimation;

    public delegate void SpawnEvent();
    public static event SpawnEvent OnCasketSpawned;
    public delegate void CollectEvent();
    public static event CollectEvent OnCasketCollected;

    private Collider2D colliderComponent;
    private bool isCoin;// temporary
    private bool isDestroyStarted;
    private bool isBlinking;

    public static int countCasketInScene { get; set; } = 0;

    private void Start()
    {
        countCasketInScene++;

        colliderComponent = GetComponentInChildren<Collider2D>();
        gameObject.GetComponentIfNull(ref alphaColorAnim);
        this.GetComponentIfNull(ref blinkingAnimation);
        RegisterForUpdate();
        isCoin = false;
        if (casketContent >= 0 && casketContent <= 2)
        {
            isCoin = true;
            contentCount = casketContent;
        }
        if (casketContent == 18 || casketContent == 19)
        {
            isCoin = true;
            contentCount = 3;
        }
        var obj = LoadDropPrefab(casketContent);
        content = obj.Item2;
        contentCascet = obj.Item1;
        //if (obj.Item2 == null)
        //    contentCount = obj.Item1;

        //Debug.Log($"CASKET ITEM: {obj.Item1}");
        if (OnCasketSpawned != null)
        {
            OnCasketSpawned();
        }
        if (gameObject.name == "casket_small(Clone)")
        {
            float y = transform.position.y;
            float x = transform.position.x;
            if (transform.position.y > 2.2f)
                y = 2.2f;
            if (transform.position.y < -2.2f)
                y = -2.2f;
            if (transform.position.x > 8.3f)
                x = 8.3f;
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    public static (int, GameObject) LoadDropPrefab(int casketContent)
    {
        GameObject to_return = null;
        switch (casketContent)
        {
            //case 0:
            //    isCoin = true;
            //    break;
            //case 1:
            //    contentCount = 2;
            //    isCoin = true;
            //    break;
            //case 2:
            //    contentCount = 3;
            //    isCoin = true;
            //    break;
            case 3:
                to_return = Resources.Load("Bonuses/AcidScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 4:
                to_return = Resources.Load("Bonuses/BarrierScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 5:
                to_return = Resources.Load("Bonuses/FrozenScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 6:
                to_return = Resources.Load("Bonuses/MinesScrollBonus", typeof(GameObject)) as GameObject;
                break;
            case 7:
                to_return = Resources.Load("Bonuses/LightningBonus", typeof(GameObject)) as GameObject;
                break;
            case 8:
                to_return = Resources.Load("Bonuses/StrikeBonus", typeof(GameObject)) as GameObject;
                break;
            case 9:
                to_return = Resources.Load("Bonuses/StoneBonus", typeof(GameObject)) as GameObject;
                break;
            case 10:
                to_return = Resources.Load("Bonuses/FireWallBonus", typeof(GameObject)) as GameObject;
                break;
            case 11:
                to_return = Resources.Load("Bonuses/ChainBonus", typeof(GameObject)) as GameObject;
                break;
            case 12:
                to_return = Resources.Load("Bonuses/BreathBonus", typeof(GameObject)) as GameObject;
                break;
            case 13:
                to_return = Resources.Load("Bonuses/AcidBonus", typeof(GameObject)) as GameObject;
                break;
            case 14:
                to_return = Resources.Load("Bonuses/PotionManaBonus", typeof(GameObject)) as GameObject;
                break;
            case 15:
                to_return = Resources.Load("Bonuses/PotionHealthBonus", typeof(GameObject)) as GameObject;
                break;
            case 16:
                to_return = Resources.Load("Bonuses/RessurPotionBonus", typeof(GameObject)) as GameObject;
                break;
            case 17:
                to_return = Resources.Load("Bonuses/PowerPotionBonus", typeof(GameObject)) as GameObject;
                break;
        }
        return (casketContent, to_return);
    }

    public void SetCasketContent(int _content)
    {
        casketContent = _content;
        dissapear = true;
        isBlinking = false;
    }

    public override void UpdateObject()
    {
        lifeTimeTimer += Time.deltaTime;

        if (dissapear)
        {
            if (!isBlinking)
            {
                if (lifeTimeTimer > startBlinkTime)
                {
                    isBlinking = true;
                    if (blinkingAnimation != null)
                    {
                        blinkingAnimation.StartBlinking();
                    }
                }
            }

            if (lifeTimeTimer > waitTime)
            {
                if (!isDestroyStarted)
                {
                    isDestroyStarted = true;
                    this.CallActionAfterDelayWithCoroutine(0.5f, StartDestroy);
                }
            }
        }
    }

    public void OnCliked()
    {
        if (clicked)
            return;

        TapController.Current.SetActiveShot(0.1f);

        clicked = true;
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
        isBlinking = true;
        if (colliderComponent != null)
        {
            StartCoroutine(FadeOutCollider());
        }
        if (EnemiesGenerator.Instance.levelSettings.wonFlag)
            Time.timeScale = 1.2f;
    }

    private IEnumerator FadeOutCollider()
    {
        yield return new WaitForSeconds(0.2f);
        colliderComponent.enabled = false;
    }

    public void OpenIt()
    {
        if (colliderComponent != null)
        {
            colliderComponent.enabled = false;
        }

        SpawnContent();

        if (OnCasketCollected != null)
        {
            OnCasketCollected();
        }

        if (!isDestroyStarted)
        {
            isDestroyStarted = true;
            this.CallActionAfterDelayWithCoroutine(0.5f, StartDestroy);
        }
        SoundController.Instanse.playOpenChestSFX();
    }

    private void SpawnContent()
    {
        if (content == null && !isCoin)
        {
            Debug.LogErrorFormat("Casket content is null! ContentID: {0}", casketContent);
            return;
        }

        if (contentCascet == 16)
            Debug.Log("--- === RESURECTION === ---");

        Vector3 position = transform.position;
        for (int i = 0; i < contentCount; i++)
        {
            if (transform.localScale.x > 0.9f)
            {
                position = new Vector3(position.x, position.y, position.z);
            }

            GameObject openToDrop = null;

            if (isCoin)
            {
                EnemiesGenerator.SpawnCoin(position, position.x > 3f ? Quaternion.identity : Quaternion.Euler(new Vector3(0, -180f, 0)));
            }
            else
            {
                openToDrop = Instantiate(content, position, position.x > 3f ? Quaternion.identity : Quaternion.Euler(new Vector3(0, -180f, 0)));
                EnemiesGenerator.Instance.dropsOnLevel.Add(openToDrop);
            }
        }
    }

    private void StartDestroy()
    {
        alphaColorAnim.Animate();
        this.CallActionAfterDelayWithCoroutine(1.2f, DestroyIt);
    }

    public void DestroyIt()
    {
        countCasketInScene--;
        EnemiesGenerator.Instance.RemoveDropFromList(gameObject);
        UnregisterFromUpdate();
        Destroy(gameObject);
    }
}
