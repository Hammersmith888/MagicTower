using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNewWear : BaseUpdatableObject
{
    #region VARIABLES
    public WearType wearType = WearType.none;
    public int wearNumber;
    public int waittime; // Время ожидания, после которого свиток автоматически улетает
    public float moveTime; // Время за которое свиток летит в сторону панели свитков
    public GameObject dark_back;

    private Vector3 positionOnSpellsPanel;
    private Vector3 start_pos;
    private bool collected;

    private LevelSettings levelSettings;
    private Collider2D _collider;
    private float waittimer;
    private bool freeSlotOnSpellsPanelsWasFound;
    private bool currentSpellDontFly;
    private bool upped;
    private bool wasSomethingDressed;
    private GameObject new_dark_back;
    private byte newSlotId;

    private bool wearUnlocked;

    private Vector3 moveFrom;
    private float collectTimer;

    float disabledClickTime = 1.5f;

    private Transform transfToMove;

    SpriteRenderer sprite;

    private Transform getTransfToMove
    {
        get
        {
            if (transfToMove == null)
            {
                transfToMove = transform.parent;
            }
            return transfToMove;
        }
    }

    private GameObject mainObject;
    [SerializeField]
    private ItemDropAnimation itemDropAnimation;
    #endregion

    public void Init()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (mainObject == null)
        {
            mainObject = transform.parent.parent.gameObject;
        }
        if (itemDropAnimation == null)
        {
            itemDropAnimation = transform.parent.GetComponent<ItemDropAnimation>();
        }
        itemDropAnimation.Init();

        levelSettings = LevelSettings.Current;
        positionOnSpellsPanel = PlayerController.Instance.mageSkins.transform.position;
        itemDropAnimation.Init();
        itemDropAnimation.Play();
    }

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        RegisterForUpdate();
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        Init();
        UnlockWear();
    }

    public void UnlockWear()
    {
        if (wearUnlocked)
        {
            return;
        }
        wearUnlocked = true;
        var wearItems = PPSerialization.Load<Wear_Items>(EPrefsKeys.Wears.ToString());

        //for (int i = 0; i < wearItems.Length; i++)
        //{
        //    if (wearItems[i].active && wearItems[i].wearParams.wearType == wearType)
        //    {
        //        wasSomethingDressed = true;
        //    }
        //}
        Debug.Log($"Unlock wear: {wearItems[wearNumber].active}, xx: {wearNumber}, ssss: {wearItems[wearNumber].wearParams.wearType}, wasSomethingDressed: {wasSomethingDressed}");
        if (wasSomethingDressed)
        {
            currentSpellDontFly = true;
            return;
        }
        wearItems[wearNumber].unlock = true;
        wearItems[wearNumber].active = true;
       
        PPSerialization.Save(EPrefsKeys.Wears.ToString(), wearItems, true, true);
    }

    public void OnCollected()
    {
        itemDropAnimation.Stop();
        StartFly();
        _collider.enabled = false;
        collected = true;
        moveFrom = getTransfToMove.position;
    }

    private Vector3 pos;
    private bool reached;
    float distance = 0;
    override public void UpdateObject()
    {

        disabledClickTime -= Time.unscaledDeltaTime;
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        // Перемещаем в "кошелек"
        if (collected)
        {
            collectTimer += Time.deltaTime * 2f;
            print(getTransfToMove.name + " move from " + moveFrom + " to " + positionOnSpellsPanel);
            distance = Vector3.Distance(moveFrom, positionOnSpellsPanel);
            getTransfToMove.position = Vector3.Lerp(moveFrom, positionOnSpellsPanel, collectTimer / moveTime);
            if (!reached && collectTimer / moveTime >= 1f)
            {
                reached = true;
                Destroy(getTransfToMove.gameObject);
                Destroy(getTransfToMove.parent.gameObject, 1f);
                UnregisterFromUpdate();
                PlayerController.Instance.LoadMageView();
                PlayerController.Instance.PlayEffectChangeTexture();
            }
        }
    }

    void Update()
    {
        if (collected)
        {
            var d = Vector3.Distance(transform.position, positionOnSpellsPanel);
            sprite.color = new Color(1, 1, 1, (d / distance));
        }
    }

    public void OnMouseUp()
    {
        if (disabledClickTime > 0)
            return;
        OnCollected();
    }

    void StartFly()
    {
        transform.parent.transform.Find("shine_back").gameObject.SetActive(false);
        transform.parent.transform.Find("unlocked").gameObject.SetActive(false);
        Destroy(new_dark_back);
    }
}
