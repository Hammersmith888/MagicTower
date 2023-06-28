using ADs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private static GameObject prefab;
    
    [SerializeField]
    GameObject[] hands;
    [SerializeField]
    Transform hand;
    [SerializeField]
    RectTransform targetObj;

    public static GameObject getTarget;
    
    public GameObject mainPanel;
    public RectTransform panelWithCircle;
    public static List<GameObject> objs = new List<GameObject>();
    private static List<Transform> startParent = new List<Transform>();
    private static List<Transform> targetParent = new List<Transform>();
    private static List<int> index = new List<int>();
    public int layerID = 300;
    [HideInInspector]
    public bool disableAnimation = false;
    [HideInInspector]
    public bool dublicateObj = true;
    [HideInInspector]
    public bool circlePanel = false;
    [HideInInspector]
    public Vector2 circlePosition;

    public GameObject panelText;
    [SerializeField]
    UnityEngine.UI.Text text;

    public static List<GameObject> duplicates = new List<GameObject>();

    public float timerC = -1;
    public UnityAction _action;
    public static Action OnObjectsNeededToDisableAfterTutorial;

    #region METHODS

    public static Tutorial Open(GameObject target, Vector2 offset = default(Vector2),  Transform[] focus = null, float waiting = 0, Vector3 rotation = default(Vector3), bool mirror = false, string keyText = "")
    {
        getTarget = target;
        if (prefab == null)
            prefab = Resources.Load("UI/Tutorial") as GameObject;

        Debug.Log("tut open");
        var obj = Instantiate(prefab) as GameObject;
        obj.GetComponent<Tutorial>().StartOpen(target, offset, waiting, rotation, mirror, focus, keyText);
        objs.Add(obj);
        return obj.GetComponent<Tutorial>();
    }
    public static Tutorial Open(GameObject target, Transform[] focus, float waiting = 0, bool mirror = false)
    {
        return Open(target,waiting:waiting,mirror:mirror, focus: focus);
    }

    public static Tutorial Open(GameObject target, Vector2 offset, Transform[] focus, float waiting = 0, bool mirror = false)
    {
        return Open(target, offset, waiting: waiting, mirror:mirror, focus: focus);
    }


    public static void OpenBlock(UnityAction _event = null, float timer = -1)
    {
        if (prefab == null)
            prefab = Resources.Load("UI/Tutorial") as GameObject;

        Debug.Log("OpenBlock");
        var obj = Instantiate(prefab) as GameObject;
        objs.Add(obj);
        var t = obj.GetComponent<Tutorial>();
        t.mainPanel.GetComponent<Animator>().enabled = false;
        t.mainPanel.GetComponent<CanvasGroup>().alpha = 0;
        t.mainPanel.GetComponent<CanvasGroup>().enabled = true;
        t._action = _event;
        t.timerC = timer;
        obj.name = "TutorialBlock";
    }

    public static bool isActive()
    {
        return objs.Count > 0;
    }

    public static void Close()
    {
        foreach (var item in duplicates)
            Destroy(item);
        duplicates.Clear();
        if (targetParent != null)
        {
            for (int i = 0; i < targetParent.Count; i++)
            {
                if (targetParent[i] != null)
                {
                    if (startParent[i] != null)
                    {
                        targetParent[i].transform.SetParent(startParent[i]);
                      
                    }
                    targetParent[i].transform.SetSiblingIndex(index[i]);

                    var info = targetParent[i].transform.Find("Info");
                    if (info != null)
                        info.GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
            }
        }

        foreach (var o in objs)
            Destroy(o);

        objs.Clear();
        targetParent.Clear();
        startParent.Clear();
        index.Clear();
        OnObjectsNeededToDisableAfterTutorial?.Invoke();
    }

    #endregion

    protected void StartOpen(GameObject target, Vector2 offset, float waiting, Vector3 rotation, bool mirror, Transform[] focus, string keyText)
    {
        mainPanel.SetActive(false);
        StartCoroutine(_StartOpen(target, offset, waiting, rotation, mirror, focus, keyText));
    }

    public void ChangePoint(GameObject target, Vector2 offset)
    {
        
    }
    IEnumerator _StartOpen(GameObject target, Vector2 offset, float waiting, Vector3 rotation, bool mirror, Transform[] focus, string keyText)
    {
        hand.gameObject.SetActive(false);
        if(waiting != -1)
            yield return new WaitForEndOfFrame();
        var c = GetComponent<Canvas>();
    
        var map = GameObject.FindGameObjectWithTag("CameraMap");
        if(map != null)
            c.worldCamera = map.GetComponent<Camera>();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Shop")
            c.worldCamera = Camera.main;
        var game = GameObject.FindGameObjectWithTag("GameCamera");
        if (game != null)
            c.worldCamera = game.GetComponent<Camera>();
        if (waiting < 0)
            waiting = 0;

        mainPanel.GetComponent<Animator>().enabled = !disableAnimation;

        if (waiting != -1)
            yield return new WaitForSecondsRealtime(waiting);
        else
            mainPanel.GetComponent<Animator>().enabled = false;
        c.sortingOrder = layerID;

        mainPanel.SetActive(true);
        var x = GetComponent<RectTransform>().localScale.x;
        if (focus != null)
        {
            //startParent = new Transform[focus.Length];
            //targetParent = new Transform[focus.Length];
            //index = new int[focus.Length];
            for (int i = 0; i < focus.Length; i++)
            {
                startParent.Add(focus[i].parent);
                targetParent.Add(focus[i]);
                if(dublicateObj)
                {
                    var xo = Instantiate(focus[i].gameObject, focus[i].parent) as GameObject;
                    //var _a = xo.GetComponentsInChildren<Animator>();
                    //foreach (var aa in _a)
                    //{
                    //    Debug.Log($"anim: {aa.name}", aa.gameObject);
                    //    Destroy(aa);
                    //}
                    var childs = xo.GetComponentsInChildren<Transform>();
                    foreach (var o in childs)
                    {
                        if(o != xo.transform)
                            Destroy(o.gameObject);
                    }
                    duplicates.Add(xo);
                }
                index.Add(focus[i].GetSiblingIndex());
                focus[i].SetParent(mainPanel.transform);
                if (dublicateObj && duplicates[i]!=null)
                    duplicates[i].transform.position = focus[i].position;
                focus[i].SetSiblingIndex(0);
                if (dublicateObj)
                    duplicates[i].transform.SetSiblingIndex(index[i]);

                var info = focus[i].transform.Find("Info");
                if (info != null)
                    info.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
        }
        else
            mainPanel.GetComponent<UnityEngine.UI.Image>().enabled = false;
        if (circlePanel)
        {
            panelWithCircle.gameObject.SetActive(true);
            panelWithCircle.anchoredPosition = circlePosition;
        }
        if (target != null)
        {
            targetObj.SetParent(target.transform);
            targetObj.anchoredPosition = Vector2.zero;
            targetObj.SetParent(mainPanel.transform);
            if (waiting != -1)
                yield return new WaitForEndOfFrame();
            hand.GetComponent<RectTransform>().anchoredPosition = targetObj.anchoredPosition + offset;
        }
        hand.rotation = Quaternion.Euler(rotation);
        if (mirror)
            hand.localScale = new Vector3(-1, 1, 1);
        hand.gameObject.SetActive(true);
        if(keyText != "")
        {
            panelText.SetActive(true);
            text.text = TextSheetLoader.Instance.GetString(keyText);
        }
        StartCoroutine(_LoopHandPoint());
    }

    private IEnumerator _LoopHandPoint()
    {
        var click = false;
        while (true)
        {
            hands[0].gameObject.SetActive(click);
            hands[1].gameObject.SetActive(!click);
            yield return new WaitForSecondsRealtime(click ? 0.1f : 0.35f);
            click = !click;
        }
    }

    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(timerC);
        if (timerC != -1)
        {
            Destroy(gameObject);
            if (_action != null)
                _action();
        }
    }

}
