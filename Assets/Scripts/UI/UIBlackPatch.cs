using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ADs;

public class UIBlackPatch : MonoBehaviour
{
    [SerializeField]
    private Image image, circle;
    [SerializeField]
    private GameObject loadingLabel;

    [SerializeField]
    private GameObject currentLevelObjects;
    [SerializeField]
    [ResourceFile(resourcesFolderPath = "Scenes")]
    private string currentLevelObjectsInResources;

    private bool haveToStart;
    private bool haveToOut;
    private bool haveToOutById;
    private bool hateToOutByCallback;

    public bool isOuted;

    public float processTime;
    private string nextScene;
    private int nextSceneId;
    private System.Action callback;

    private bool sceneLoadPending;
    private bool canLoadPendingScene;

    private static float sceneStartLoadTime;

    public bool IsPlaying => haveToStart || haveToOut || haveToOutById || sceneLoadPending;

    private static UIBlackPatch _instance;
    public static UIBlackPatch Current
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIBlackPatch>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        haveToStart = true;
        image = transform.GetChild(0).GetComponent<Image>();

        //Resources.UnloadUnusedAssets();
        if (!string.IsNullOrEmpty(currentLevelObjectsInResources))
        {
            currentLevelObjects = Instantiate(Resources.Load<GameObject>(currentLevelObjectsInResources));
            currentLevelObjects.SetActive(false);
        }
        PendingOperationsManager.CheckPendingOperations(() =>
        {
            if (currentLevelObjects != null)
            {
                currentLevelObjects.SetActive(true);
            }
            StartCoroutine(DissapearRoutine());
        });
    }

    public void LoadPendingScene()
    {
        if (sceneLoadPending)
        {
            sceneLoadPending = false;
            sceneStartLoadTime = Time.unscaledTime;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            canLoadPendingScene = true;
        }
    }

    public void StartDissapear()
    {
        StartCoroutine(DissapearRoutine());
    }

    private IEnumerator FadeInColorAnimation(bool loadSceneAutomatically = true)
    {
        while (image.color.a < 1)
        {
            image.color = new Color(1f, 1f, 1f, image.color.a + (1 / processTime) * Time.unscaledDeltaTime);
            circle.color = new Color(1f, 1f, 1f, circle.color.a + (1 / processTime) * Time.unscaledDeltaTime);
            yield return null;
        }
        if (loadSceneAutomatically || canLoadPendingScene)
        {
            sceneStartLoadTime = Time.unscaledTime;
            Debug.Log("SceneManager.LoadScene(nextScene)");
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("sceneLoadPending");
            sceneLoadPending = true;
            LoadPendingScene();
        }
    }

    public void SetBlackOnAds()
    {
        image.gameObject.SetActive(true);
        image.color = new Color(1f, 1f, 1f, 1);
    }
    public void OffBlackOnAds()
    {
        image.color = new Color(1f, 1f, 1f, 0);
        image.gameObject.SetActive(false);
    }
    public IEnumerator FadeInColorAnimation(System.Action callBack)
    {
        image.gameObject.SetActive(true);
        while (image.color.a < 1)
        {
            image.color = new Color(1f, 1f, 1f, image.color.a + (1 / processTime) * Time.unscaledDeltaTime);
            circle.color = new Color(1f, 1f, 1f, circle.color.a + (1 / processTime) * Time.unscaledDeltaTime);
            yield return null;
        }
        if (callBack != null)
        {
            callBack.InvokeSafely();
        }
    }

    public IEnumerator FadeOutColorAnimation(System.Action callBack)
    {
        while (image.color.a > 0)
        {
            image.color = new Color(1f, 1f, 1f, image.color.a - (1 / processTime) * Time.unscaledDeltaTime);
            circle.color = new Color(1f, 1f, 1f, (circle.color.a - (2f / processTime) * Time.unscaledDeltaTime - 0.3f));
            yield return null;
        }
        callBack.InvokeSafely();
        image.gameObject.SetActive(false);
    }

    private IEnumerator DissapearRoutine()
    {
        if (loadingLabel != null)
        {
            loadingLabel.SetActive(false);
        }

        Debug.LogFormat("(2) Scene <b>{0}</b> loaded. Load time <b>{1}</b>", SceneManager.GetActiveScene().name, (Time.unscaledTime - sceneStartLoadTime));
        float maxTimeDelta = processTime / 25f;
        float timer = processTime;

        if (SaveManager.GameProgress.Current.CompletedLevelsNumber <= 0 && SaveManager.GameProgress.Current.firstStart == 1)
        {
            Debug.Log($"------------------- load game");
            var mainMenuUIComponent = FindObjectOfType<UIMenu>();
            while (mainMenuUIComponent == null)
            {
                yield return null;
            }
            mainMenuUIComponent.ToMap();
            SaveManager.GameProgress.Current.firstStart = 3;
            SaveManager.GameProgress.Current.Save();
            yield break;
        }

        if (SaveManager.GameProgress.Current.firstStart == 0)
        {
            SaveManager.GameProgress.Current.firstStart = 1;
            SaveManager.GameProgress.Current.Save();
        }

        while (timer > 0)
        {
            timer -= Mathf.Min(Time.unscaledDeltaTime, maxTimeDelta);
            image.color = new Color(1f, 1f, 1f, timer / processTime);
            circle.color = new Color(1f, 1f, 1f, (timer / processTime) - 0.3f);
            yield return null;
        }
        haveToStart = false;

        DisableIt();
    }

    private void DisableIt()
    {
        isOuted = true;
        image.gameObject.SetActive(false);
        UIPauseController pause = GameObject.FindObjectOfType<UIPauseController>();
        if (pause != null)
        {
            pause.pauseCalled = false;
        }
    }

    public void Appear(System.Action callback, bool showLoadingLabel = false)
    {
        this.callback = callback;
        image.gameObject.SetActive(true);
        hateToOutByCallback = true;
        gameObject.SetActive(true);
        StartCoroutine(FadeInColorAnimation(() =>
        {
            if (showLoadingLabel && loadingLabel != null)
            {
                loadingLabel.SetActive(true);
            }
            hateToOutByCallback = false;
            callback.InvokeSafely();
        }));
    }

    public void Appear(string sceneName, bool loadSceneAutomatically = true)
    {
        SharedMaterialsStorage.Clear();
        if (nextScene == null)
        {
            nextScene = sceneName;
            image.gameObject.SetActive(true);
            haveToOut = true;
            SoundController.Instanse.FadeOutCurrentMusic();
            sceneLoadPending = canLoadPendingScene = false;
        }
        StartCoroutine(FadeInColorAnimation(loadSceneAutomatically));
    }

    public void AppearInt(int sceneId)
    {
        SharedMaterialsStorage.Clear();
        if (nextSceneId == 0)
        {
            nextSceneId = sceneId;
            image.gameObject.SetActive(true);
            haveToOutById = true;
        }
        StartCoroutine(FadeInColorAnimation(() =>
          {
              haveToOutById = false;
              sceneStartLoadTime = Time.unscaledTime;
              SceneManager.LoadScene(nextSceneId);
          }));
    }
}