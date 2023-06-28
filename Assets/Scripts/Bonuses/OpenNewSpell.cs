using System.Collections;
using UnityEngine;

public class OpenNewSpell : BaseUpdatableObject
{
    #region VARIABLES
    public Spell.SpellType spellType = Spell.SpellType.None;
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
    private GameObject new_dark_back;
    private byte newSlotId;

    private bool spellUnlocked;

    private Vector3 moveFrom;
    private float collectTimer;

    float disabledClickTime = 1.5f;

    private Transform transfToMove;
    private Transform getTransfToMove
    {
        get
        {
            if (transfToMove == null)
            {
                transfToMove = transform.parent.parent;
            }
            return transfToMove;
        }
    }
    #endregion

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        RegisterForUpdate();
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        Init();
        UnlockSpell();
    }

    private void Init()
    {
        levelSettings = LevelSettings.Current;

        for (int i = 0; i < 4; i++)
        {
            if (ShotController.Current.spells[i].spellType == Spell.SpellType.None)
            {
                positionOnSpellsPanel = ShotController.Current.GetSpellSlotWorldPosition(i);
                newSlotId = (byte)i;
                freeSlotOnSpellsPanelsWasFound = true;
                break;
            }
        }
        if (!freeSlotOnSpellsPanelsWasFound)
        {
            positionOnSpellsPanel = ShotController.Current.GetSpellSlotWorldPosition(0);
        }
    }

    private void Update()
    {
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -2.5f);
    }


    public void UnlockSpell()
    {

        if (spellUnlocked)
        {
            return;
        }
        spellUnlocked = true;
        var spellNumber = SpellInfoUtils.GetSpellSpellDataIndexBySpellType(spellType);
        var spellItems = PPSerialization.Load<Spell_Items>(EPrefsKeys.Spells.ToString());
        if (spellItems[spellNumber].active)
        {
            currentSpellDontFly = true;
            return;
        }
        spellItems[spellNumber].unlock = true; // Изменяем объект в массиве заклинаний и сохраняем
        ShopSpellItemSettings.SetSpellForHighlighting(spellType);
        if (freeSlotOnSpellsPanelsWasFound)
        {
            spellItems[spellNumber].active = true;
            spellItems[spellNumber].slot = newSlotId;
        }
        PPSerialization.Save(EPrefsKeys.Spells.ToString(), spellItems, true, true);
    }

    private void OnCollected()
    {
        var wears = FindObjectsOfType<OpenNewWear>();
        foreach (var o in wears)
            o.OnCollected();
        if (freeSlotOnSpellsPanelsWasFound && !currentSpellDontFly)
        {
            transform.parent.GetComponent<Animator>().StopAnimator();
            StartFly();
            _collider.enabled = false;
            collected = true;
            moveFrom = getTransfToMove.position;
        }
        else
        {
            _collider.enabled = false;
            collected = false;
            UnregisterFromUpdate();
            var alphaColorAnimations = transform.parent.GetComponent<Animations.AlphaColorAnimation>();
            alphaColorAnimations.Init();
            alphaColorAnimations.Animate(() =>
            {
                Destroy(getTransfToMove.gameObject, 1f);
            });
        }
    }

    private Vector3 pos;
    private bool reached;
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
            if (waittimer > waittime && !collected)
            {
                OnCollected();
            }
        }
        else
        {
            pos = getTransfToMove.position;
            Vector3 upped_pos = new Vector3(pos.x, start_pos.y + 2f, pos.z);
            pos = Vector3.MoveTowards(pos, start_pos, Time.deltaTime * 2f);
            getTransfToMove.position = pos;
            if (pos == start_pos)
            {
                _collider.enabled = true;
                upped = true;
                new_dark_back = Instantiate(dark_back, Vector3.forward, Quaternion.identity) as GameObject;
                transform.parent.transform.Find("shine_back").gameObject.SetActive(true);
            }
        }

        // Перемещаем в "кошелек"
        if (collected)
        {
            collectTimer += Time.deltaTime;
            getTransfToMove.position = Vector3.Lerp(moveFrom, positionOnSpellsPanel, collectTimer / moveTime);
            if (!reached && collectTimer / moveTime >= 1f)
            {
                reached = true;
                if (freeSlotOnSpellsPanelsWasFound)
                {
                    levelSettings.Refresh();
                }
                Destroy(getTransfToMove.gameObject, 1f);
                UnregisterFromUpdate();
            }
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
        transform.parent.gameObject.GetComponent<Animator>().StopAnimator();
    }
}
