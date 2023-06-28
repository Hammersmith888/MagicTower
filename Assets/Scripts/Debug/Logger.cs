#define DEBUG_MODE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    private  const string WARNING_COLOR_FORMAT = "<color=yellow>{0}</color>";
    private const string ERROR_COLOR_FORMAT = "<color=red>{0}</color>";

    #region VARIABLES
    [SerializeField]
    private Text    textComponentTemplate;
    [SerializeField]
    private  GameObject scrollView;
    [SerializeField]
    private  Button  toggleButton;
    [SerializeField]
    private Button clearButton;
    [SerializeField]
    private GameObject dontDestroyObject;

    [SerializeField]
    private bool logStackTrace;
    [SerializeField]
    private bool visibleOnInit;
    [SerializeField]
    private int maxSymbols = 10000;

    private Text    toggleBtnText;
    private Text currentlyActiveTextComponent;
    private List<Text> textComponentsPool;
    #endregion

    public static Logger m_Instance;

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        m_Instance = this;
        if (dontDestroyObject != null)
        {
            DontDestroyOnLoad(dontDestroyObject);
        }

        textComponentTemplate.gameObject.SetActive(false);
        textComponentsPool = new List<Text>() { textComponentTemplate };
        SetNewActiveTextComponent();

        clearButton.onClick.AddListener(Clear);
        toggleBtnText = toggleButton.GetComponentInChildren<Text>();
        toggleBtnText.text = scrollView.activeSelf ? "Hide Log" : "Show log";
        toggleButton.onClick.AddListener(ToggleLog);
        scrollView.SetActive(!visibleOnInit);
        ToggleLog();
        Application.logMessageReceived += HandleLog;
        
        
    }

    private void SetNewActiveTextComponent()
    {
        currentlyActiveTextComponent = null;
        for (int i = 0; i < textComponentsPool.Count; i++)
        {
            if (!textComponentsPool[i].gameObject.activeSelf)
            {
                currentlyActiveTextComponent = textComponentsPool[i];
                break;
            }
        }
        if (currentlyActiveTextComponent == null)
        {
            currentlyActiveTextComponent = GameObject.Instantiate(textComponentTemplate, textComponentTemplate.transform.parent);
            textComponentsPool.Add(currentlyActiveTextComponent);
        }
        currentlyActiveTextComponent.gameObject.SetActive(true);
        currentlyActiveTextComponent.text = string.Empty;
        currentlyActiveTextComponent.transform.SetAsLastSibling();
    }

    [System.Obsolete]
    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception)
        {
            logString = string.Format(ERROR_COLOR_FORMAT, logString);
        }
        else if (type == LogType.Warning)
        {
            logString = string.Format(WARNING_COLOR_FORMAT, logString);
        }

        if (logStackTrace)
        {
            Log(stackTrace + "\n" + logString);
        }
        else
        {
            Log(logString);
        }

    }


    private void Start()
    {}

    private void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    public void ToggleLog()
    {
        scrollView.SetActive(!scrollView.activeSelf);
        toggleBtnText.text = scrollView.activeSelf ? "Hide Log" : "Show log";
    }

    public void Clear()
    {
        for (int i = 0; i < textComponentsPool.Count; i++)
        {
            textComponentsPool[i].gameObject.SetActive(false);
        }
        textComponentsPool.Clear();
    }

    public static void Log(string text)
    {
        if (m_Instance == null)
        { 
            return;
        }
#if DEBUG_MODE
        if (text.Length + m_Instance.currentlyActiveTextComponent.text.Length > m_Instance.maxSymbols)
        {
            m_Instance.SetNewActiveTextComponent();
        }

        m_Instance.currentlyActiveTextComponent.text += text + "\n";
#endif
    }
}
