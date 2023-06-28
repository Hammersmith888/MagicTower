using UnityEngine;

public class AddScroll : BaseCollectableItem
{
    public enum ScrollType
    {
        acid, barrier, frozen, mines, zombie, haste
    }

    private const float WaiTtime = 0.35f; // Время ожидания, после которого свиток автоматически улетает

    [Space(20f)]
    public ScrollType scrollType = ScrollType.acid;
  
    private Vector3 scrollPanel;
    private LevelSettings levelSettings;
    private ScrollController scrollController;
    //private CircleCollider2D collider;
    private float waittimer;

    private Animation animParent;

    private bool shadowShowing;

    [SerializeField]
    private GameObject shadow;

    [SerializeField]
    Animator _animStay;
    bool onStay = false;

    void Start()
    {
        _animStay.enabled = false;
           scrollController = GameObject.FindGameObjectWithTag("ScrollController").GetComponent<ScrollController>();
        //collider = GetComponent<CircleCollider2D>();
        levelSettings = GameObject.FindObjectOfType<LevelSettings>();

        // Позиция, куда полетит свиток, когда его собрали
        scrollPanel = scrollController.GetPanelPos((int)scrollType);
        if(scrollPanel == Vector3.zero)
            onStay = true;
        animParent = transform.parent.gameObject.GetComponent<Animation>();

        shadowShowing = false;
        //startColliderRadius = collider.radius;
        RegisterForUpdate();
    }

    override public void UpdateObject()
    {
        waittimer += Time.deltaTime;
        // По времени
        if (waittimer > WaiTtime && !collected)
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

        if (waittimer > 5f)
            Destroy(transform.parent.parent.gameObject);

        // Перемещаем в "кошелек"
        if (collected)
        {
            shadowShowing = false;
            if (!onStay)
                UpdateFlyAnimation();
            else
                _animStay.enabled = true;
        }

        shadow.SetActive(shadowShowing);
    }

    protected override void OnStartCollect()
    {
        animParent.Stop();
        shadowShowing = false;
        //collider.enabled = false;
        SoundController.Instanse.PlayScrollFlySFX();
        base.OnStartCollect();
    }

    protected override void OnUIElementReached()
    {
        base.OnUIElementReached();
        scrollController.AddScrolls((int)scrollType, 1);
        UnregisterFromUpdate();
        Destroy(transform.parent.parent.gameObject);
    }
}
