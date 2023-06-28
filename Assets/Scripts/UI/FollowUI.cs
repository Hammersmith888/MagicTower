using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    public Transform target;
    public Canvas canvas;
    public Camera cam;
    RectTransform canvasRect;
    RectTransform rect;
    float maxX, maxY;
    void Start()
    {
        canvasRect = canvas.GetComponent<RectTransform>();
        rect = GetComponent<RectTransform>();
        maxY = Screen.height / 2;
        maxX = Screen.width / 2;

        // transform.position =  UIControl.Current.GetScreenPosition(target.position);
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, 0f);
        newPosition = Helpers.getMainCamera.WorldToScreenPoint(newPosition);

        UIControl.SpawnDamageView(newPosition, 100, new DamageView.DamageViewData());
    }

    // Update is called once per frame
    void Update()
    {
        //if (target == null)
        //    return;
        //Vector2 ViewportPosition = cam.WorldToViewportPoint(target.transform.position);
        //Vector2 WorldObject_ScreenPosition = new Vector2(
        //((ViewportPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
        //((ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
        //Vector2 vector = new Vector2(
        //         Mathf.Clamp(WorldObject_ScreenPosition.x, (-maxX ), (maxX)),
        //         Mathf.Clamp(WorldObject_ScreenPosition.y, (-maxY), (maxY)));
        //rect.anchoredPosition = vector;
    }
}
