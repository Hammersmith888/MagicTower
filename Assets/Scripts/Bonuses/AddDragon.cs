using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDragon : BaseCollectableItem
{
    #region VARIABLES
    public int waittime; // Время ожидания, после которого свиток автоматически улетает
    public float moveTime; // Время за которое свиток летит в сторону панели свитков
    public GameObject dark_back;

    private Vector3 start_pos;
    private bool collected;

    private Collider2D _collider;
    private float waittimer;
    private bool upped;
    private GameObject new_dark_back;

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

    private void Update()
    {
        transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -2.5f);
    }



    private void OnCollected()
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
            if (!reached && collectTimer / moveTime >= 1f)
            {
                reached = true;
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
