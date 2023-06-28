
using UnityEngine;
using UnityEngine.UI;

public class UILoadingTextAnimation : MonoBehaviour
{
    [SerializeField]
    private Text label;
    [SerializeField]
    private string constantText;
    [SerializeField]
    private string animatedSymbolsStr;
    [SerializeField]
    private float showSymbolDelay;

    private int currentSymbolIndex;
    private float showNextSymbolTime;

    private Text Label
    {
        get
        {
            if (label == null)
            {
                label = GetComponentInChildren<Text>();
            }
            return label;
        }
    }

    private void Awake()
    {
        var textLocalization = label.GetComponent<LocalTextLoc>();
        if (textLocalization != null)
        {
            textLocalization.enabled = false;
            textLocalization.SetTextWithoutParameters();
            constantText = textLocalization.CurrentText;

            var rectSize = textLocalization.RectTransform.sizeDelta;
            rectSize.x = label.preferredWidth + 70f;
            textLocalization.RectTransform.sizeDelta = rectSize;
        }
    }

    private void OnEnable()
    {
        label.resizeTextForBestFit = false;
        label.text = constantText;
        currentSymbolIndex = -1;
        showNextSymbolTime = Time.unscaledTime + showSymbolDelay;
    }

    private void Update()
    {
        if (Time.unscaledTime > showNextSymbolTime)
        {
            currentSymbolIndex++;
            showNextSymbolTime = Time.unscaledTime + showSymbolDelay;
            if (currentSymbolIndex >= animatedSymbolsStr.Length)
            {
                currentSymbolIndex = -1;
                label.text = constantText;
            }
            else
            {
                label.text += animatedSymbolsStr[currentSymbolIndex];
            }

        }
    }
}
