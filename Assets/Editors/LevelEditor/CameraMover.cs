using UnityEngine;

public class CameraMover : MonoBehaviour {

    [SerializeField] private RectTransform targetTransf;
    [SerializeField] private float speed = 20;
    [SerializeField] private float defaultOffset;
    [SerializeField] private float offset;
    public static bool iCanMove = true;
    private Vector3 currentPosition;
    RectTransform position;
    [SerializeField] private GameObject canvas;
    public static GameObject scrollCanvas;

    private void Awake()
    {
        scrollCanvas = canvas;
        currentPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        position = gameObject.GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        currentPosition.x = (defaultOffset - targetTransf.anchoredPosition.x) / speed;

        if (scrollCanvas.activeSelf)
        {
            position.anchoredPosition = new Vector3(currentPosition.x, 0, -10);
            gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, 0, 55), 0, -10);
            targetTransf.anchoredPosition = new Vector2(Mathf.Clamp(targetTransf.anchoredPosition.x, offset, 0), targetTransf.anchoredPosition.y);
        }
    }
}