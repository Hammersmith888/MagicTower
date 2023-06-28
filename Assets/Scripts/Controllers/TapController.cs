using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using Tutorials;
using UnityEngine.UI;
using System;

public class TapController : MonoBehaviour
{
    public RectTransform tapRT;
    public EnemiesGenerator enemies;
    private Animation tapAnimation;

    // Управление мышью
    public bool simulateTouchWithMouse = true;
    private Vector2 lastMousePosition;

    public static bool touchUI { get; set; } = false;
    private bool noTouches;

    // Выстрелы
    private ShotController shotController;
    private float lastShotTime;
    private const float shotRateWhenPressing = 0.5f;

    // Нажатие на объекты в слое UI (монеты, сундуки, бонусы)
    private RaycastHit2D hit;
    private Camera mainCamera;
    private bool isCanShoot = true;

    [HideInInspector]
    public bool lastCantShoot;

    public bool iCanShot { get; private set; }
    [SerializeField] private Camera UICamera;

    private static TapController current;
    public static TapController Current
    {
        get
        {
            if (current == null)
            {
                current = FindObjectOfType<TapController>();
            }
            return current;
        }
    }

    public bool IsCanShoot
    {
        set { isCanShoot = value; }
    }

    private void Awake()
    {
        current = this;
        shotController = GetComponent<ShotController>();
        tapAnimation = tapRT.GetComponent<Animation>();

    }

    // Eugene unblock Tap when kill bird
    public void SetEnebleTap(float delay = 0.6f)
    {
        StartCoroutine(UnBlockInput(delay));
    }

    private IEnumerator UnBlockInput(float delay = 0.6f)
    {
        yield return new WaitForSeconds(delay);
        IsCanShoot = true;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        iCanShot = true;
        Debug.unityLogger.logEnabled = true;
    }

    private void Update()
    {
        // Taч
        noTouches = true;
#if !UNITY_EDITOR
        Touch[] touches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            noTouches = false;
            UpdateTouch(touches[i].fingerId, touches[i].phase, touches[i].position);
        }
#elif UNITY_EDITOR || UNITY_STANDALONE
        // Мышь
        if (simulateTouchWithMouse)
        {
            Vector2 mousePosition = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                UpdateTouch(0, TouchPhase.Ended, mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                noTouches = false;
                UpdateTouch(0, Input.GetMouseButtonDown(0) ? TouchPhase.Began : (mousePosition.Equals(lastMousePosition) ? TouchPhase.Stationary : TouchPhase.Moved), mousePosition);
            }
            lastMousePosition = mousePosition;
        }
#endif

    }

    private void LateUpdate()
    {
        touchUI = false;
    }

    public void DiactiveShot()
    {
        iCanShot = false;
    }

    public void SetActiveShot(float time)
    {
        iCanShot = false;
        StartCoroutine(_SetActiveShot(time));
    }

    private IEnumerator _SetActiveShot(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        iCanShot = true;
    }

    public static bool tutorial5IsStart = false;
    public static bool tutorial3IsStart = false;

    float timeTouch = 3f;
    float timeDelay = 0f;

    private void TutorialCheck(TouchPhase phase)
    {
        if (phase == TouchPhase.Ended)
        {
            Tutorial_1.Current.ResetHandStreamTutorial();
            timeDelay = 0;
            return;
        }
        Tutorial_1.Current.OnShotClick(17);

        timeDelay += Time.unscaledDeltaTime;
        if (timeDelay > timeTouch)
        {
            timeDelay = 0;
            Tutorial_1.Current.OnStreamTutorialComplete();
        }
    }

    private void UpdateTouch(int num, TouchPhase phase, Vector2 position)
    {
        // Eugene block Tap when kill bird
        if (!UIBlackPatch.Current.isOuted || !isCanShoot)
            return;

        // При нажатии на элемент интерфейса, тачи выстрела не обрабатываются
        bool overUI = false;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
		overUI = EventSystem.current.IsPointerOverGameObject(num);
#else
        overUI = EventSystem.current.IsPointerOverGameObject(num);
#endif

        if (overUI || lastCantShoot || LevelSettings.Current.wonFlag || Tutorials.TutorialsManager.IsTutorialActive(Tutorials.ETutorialType.USE_ACID_SCROLL))
        {
            touchUI = true;
            StartCoroutine(AllowShot());
        }

        // При нажатии на монеты/сундуки/бонусы, тачи выстрела не обрабатываются
        hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(position), Vector2.zero, Mathf.Infinity, 1 << 5);
        var uiHit = Physics2D.Raycast(UICamera.ScreenToWorldPoint(position), Vector2.zero, Mathf.Infinity, 1 << 5);

        if (hit.collider != null)
        {
            var casket = hit.collider.gameObject.GetComponent<Casket>();
            var coin = hit.collider.gameObject.GetComponent<AddCoin>();

            if (casket != null)
                casket.OnCliked();
            else if (coin != null)
                coin.TakeCoin();

            return;
        }
        if (!touchUI && iCanShot && uiHit.collider == null)
        {
            if (tutorial5IsStart) 
                TutorialCheck(phase);

            if (phase == TouchPhase.Began || Time.time - lastShotTime > shotRateWhenPressing)
            {
                lastShotTime = Time.time;
                shotController.Shot(position);
                tapRT.position = position;
            }
        }
    }
    private static IEnumerator AllowShot() // Разрешаем каст
    {
        yield return new WaitForSeconds(0.1f);
        touchUI = false;
    }
}