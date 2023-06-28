using UnityEngine;
using UnityEngine.EventSystems;

public class UIInfoPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        rectTransform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
    }

    public void OnPointerUp(PointerEventData _eventData)
    {
        rectTransform.localScale = Vector3.one;
    }
}
