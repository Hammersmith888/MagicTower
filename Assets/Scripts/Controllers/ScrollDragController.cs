using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Tutorials;

public class ScrollDragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    // Тип свитка
    public Scroll.ScrollType scrollType = Scroll.ScrollType.Acid;
    public GameObject scrollIcon; // Визуальное отображение свитка который перетаскиваем

    private ScrollController scrollController;
    private Vector3 startIconPos;
    public Tutorials.Tutorial_1 HideScrollTutor;
    [SerializeField]
    private bool useWithoutDrag;

    private LevelSettings levelSettings;
    Vector3 lastPos;
    float timer;
    bool isUse;

    public static ScrollDragController Current;

    void Start()
    {
        Current = this;
        scrollController = transform.parent.GetComponent<ScrollController>();
        startIconPos = scrollIcon.transform.position;
        levelSettings = LevelSettings.Current;
    }

    void Update()
    {
        if(!scrollController) return;
        
        if (isUse)
        {
            if (lastPos == transform.position)
            {
                timer += Time.deltaTime;
                if (timer > 5)
                {
                    scrollController.Activation((int)scrollType, lastPos);
                    DefaultScrollState();
                    isUse = false;
                    timer = -50;
                }
            }
            if (lastPos != transform.position)
            {
                lastPos = transform.position;
            }
        }
    }

    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        if (useWithoutDrag)
        {
            scrollController.Activation((int)scrollType, PlayerController.Instance.transform.position);
            DefaultScrollState();
            return;
        }
        if (!TutorialsManager.IsAnyTutorialActive)
            TapController.Current.DiactiveShot();
    }

    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        if (levelSettings != null && levelSettings.wonFlag || useWithoutDrag)
            return;

        Vector3 pos = pointerEventData.pressEventCamera.ScreenToWorldPoint(pointerEventData.position);
        pos.z = startIconPos.z;
        if (scrollIcon)
        {
            scrollIcon.transform.position = pos;
            scrollIcon.SetActive(true);
            isUse = true;
        }
    }
    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        bool overUI = false;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
		overUI = EventSystem.current.IsPointerOverGameObject(Input.GetTouch (0).fingerId);
#else
        overUI = EventSystem.current.IsPointerOverGameObject();
#endif

        float topBorder = Screen.height - pointerEventData.position.y;
        float downBorder = pointerEventData.position.y - Screen.height;

        //Debug.LogWarning($"s: {topBorder}, Screen.height: {Screen.height}, y: {pointerEventData.position.y}" + " | " + Screen.height * 0.2f);

        if (overUI || (levelSettings != null && levelSettings.wonFlag))
        {
            if ((topBorder < (Screen.height * 0.3f)) || (topBorder > (Screen.height - (Screen.height * 0.2f))))
            {
                StartCoroutine(Returning());
                isUse = false;
                TapController.Current.SetActiveShot(0.1f);
                return;
            }
        }
        if (HideScrollTutor != null && Tutorials.TutorialsManager.IsTutorialActive(Tutorials.ETutorialType.USE_ACID_SCROLL))
        {
            HideScrollTutor.ContinueGame(5);
        }
        scrollController.Activation((int)scrollType, pointerEventData.position);
        DefaultScrollState();
        isUse = false;
        timer = 0;

        TapController.Current.SetActiveShot(0.1f);
    }

    // Восстанавливаем начальное состояние отображения свитка
    private void DefaultScrollState()
    {
        if(!scrollIcon) return;
        
        scrollIcon.SetActive(false);
        scrollIcon.transform.position = startIconPos;
    }

    private IEnumerator Returning()
    {
        float speed = 1000f;
        float flyTime = Vector3.SqrMagnitude(startIconPos - scrollIcon.transform.position) / (speed * speed);
        float timer = 0;

        Vector3 startFlyPos = scrollIcon.transform.position;
        flyTime = 0.3f;
        while (timer < flyTime)
        {
            timer += Time.unscaledDeltaTime;
            scrollIcon.transform.position = Vector3.Lerp(startFlyPos, startIconPos, timer / flyTime);
            yield return null;
        }
        DefaultScrollState();
        yield break;
    }
}