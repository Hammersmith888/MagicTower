using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewScroll : BaseUpdatableObject
{
    public Scroll.ScrollType scrollType = Scroll.ScrollType.Acid;
    public float waittime; // Время ожидания, после которого свиток автоматически улетает
    public float speed; // Скорость с которой свиток летит в сторону панели свитков
    public GameObject dark_back;

    private Vector3 scrollPanel;
    private bool collect;
    private ScrollController scrollController;

    private float waittimer;


    private Vector3 start_pos;
    private bool have_refresh;
    private bool upped;
    private GameObject new_dark_back;
    private byte new_slot_id;
    private float blockTime = 1f;
    float disabledClickTime = 1.5f;

    private float timeHide = 0.5f;
    private float curentHide = 0;
    private float startScale = 0;

    private Collider2D m_collider;
    private Collider2D GetCollider
    {
        get
        {
            if (m_collider == null)
            {
                m_collider = GetComponent<Collider2D>();
            }
            return m_collider;
        }
    }

    IEnumerator Start()
    {
        blockTime += Time.time;
        yield return new WaitForEndOfFrame(); Init();
    }

    void Init()
    {
        scrollController = GameObject.FindGameObjectWithTag("ScrollController").GetComponent<ScrollController>();
        // Позиция, куда полетит свиток, когда его собрали
        scrollPanel = scrollController.GetPanelPos((int)scrollType);
    }

    void Awake()
    {
        RegisterForUpdate();
    }

    private void Update()
    {
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -2.5f);
    }

    override public void UpdateObject()
    {
        disabledClickTime -= Time.unscaledDeltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        if (upped)
        {
            waittimer += Time.deltaTime;
            // По времени
            if (waittimer > waittime && !collect)
            {
                StartFly();
                GetCollider.enabled = false;
                collect = true;
                startScale = transform.parent.localScale.x;
            }
        }
        else
        {
            transform.parent.parent.position = Vector3.MoveTowards(transform.parent.parent.position, start_pos, Time.deltaTime * 2f);
            GetCollider.enabled = true;
            upped = true;
            new_dark_back = Instantiate(dark_back, Vector3.forward, Quaternion.identity) as GameObject;
            Transform shine_back = transform.parent.transform.Find("shine_back");
            if (shine_back != null)
            {
                shine_back.gameObject.SetActive(true);
            }
        }

        // Перемещаем в "кошелек"
        if (collect)
        {
            if (scrollController.IsSlotFree())
            {
                transform.position = Vector3.MoveTowards(transform.position, scrollPanel, Time.deltaTime * speed);

                if (transform.position == scrollPanel)
                {
                    scrollController.AddScrolls((int)scrollType, 3);
                    Destroy(transform.parent.parent.gameObject);
                    UnregisterFromUpdate();
                    ShopScrollItemSettings.SetScrollForHighlighting(scrollType);
                }
                ScrollController.Instance.UnlockScrollSlots();
            }
            else
            {
                curentHide += Time.deltaTime;
                float progress = curentHide / timeHide;
                float scale = Mathf.Lerp(startScale, 0, progress);
                transform.parent.localScale = new Vector3(scale, scale, transform.parent.localScale.z);
                if (progress >= 1f)
                {
                    scrollController.AddScrolls((int)scrollType, 3);
                    Destroy(transform.parent.parent.gameObject);
                    UnregisterFromUpdate();
                    ShopScrollItemSettings.SetScrollForHighlighting(scrollType);
                }
            }
        }
    }


    public void OnMouseUp()
    {
        if (disabledClickTime > 0)
            return;
        if (blockTime > Time.time)
            return;

        transform.parent.gameObject.GetComponent<Animator>().StopAnimator();

        StartFly();
        GetCollider.enabled = false;
        collect = true;
        startScale = transform.parent.localScale.x;
    }

    void StartFly()
    {
        transform.parent.transform.Find("shine_back").gameObject.SetActive(false);
        transform.parent.transform.Find("unlocked").gameObject.SetActive(false);
        Destroy(new_dark_back);
        transform.parent.gameObject.GetComponent<Animator>().StopAnimator();
    }

}
