using UnityEngine;

public class AddPotion : BaseCollectableItem
{
    private const float WaitTime = 0.35f;// Время ожидания, после которого монета автоматически отправляется в "кошелек"

    [Space(20f)]
    public PotionManager.EPotionType spellType;
    public int NumberOfPots; // Величина добавляемого золота при сборе игроком / при автоматическом сборе

    public Vector3 arrive_point; // Координата, куда отправляется монета, если мы ее не собрали за время ожидания
    private LevelSettings levelSettings;
    private float waitTimer;

    private Animation animParent;
    private bool shadowShowing;

    [SerializeField]
    private GameObject shadow;
    private bool refencesCollected;

    private void Start()
    {
        if (arrive_point.x == 0f && arrive_point.y == 0f)
        {
            arrive_point = new Vector3(-8f, 3.5f, -15f);
        }
        CollectReferences();
        shadowShowing = false;
        RegisterForUpdate();
    }

    private void CollectReferences()
    {
        if (!refencesCollected)
        {
            refencesCollected = true;
            levelSettings = LevelSettings.Current;
            animParent = transform.parent.gameObject.GetComponent<Animation>();
        }
    }

    public override void UpdateObject()
    {
        // Перемещаем в "кошелек"
        if (collected)
        {
            shadowShowing = false;
            UpdateFlyAnimation();
            shadow.SetActive(false);
            return;
        }

        waitTimer += Time.deltaTime;
        // По времени
        if (waitTimer > WaitTime && !collected)
        {
            OnStartCollect();
        }

        if (!shadowShowing)
        {
            if (!animParent.isPlaying)
            {
                shadowShowing = true;
            }
        }

        shadow.SetActive(shadowShowing);
    }

    protected override void OnStartCollect()
    {
        CollectReferences();
        animParent.Stop();
        shadowShowing = false;
        base.OnStartCollect();
    }

    protected override void OnUIElementReached()
    {
        base.OnUIElementReached();
        UnregisterFromUpdate();
        PotionManager.AddPotion(spellType);
        Destroy(transform.parent.parent.gameObject);
        shadow.SetActive(shadowShowing);
    }
}
