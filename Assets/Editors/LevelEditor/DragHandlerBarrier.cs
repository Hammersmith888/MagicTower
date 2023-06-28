using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandlerBarrier : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject barrierPrefab;

    public static GameObject itemBeingDragged;
    public EditorPlayerHelpers editorPlayerHelpers;
    Vector3 startPosition;

    public void OnBeginDrag(PointerEventData _eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;

       
        Vector3 spawnPosition = new Vector3(Helpers.getMainCamera.ScreenToWorldPoint(_eventData.position).x, Helpers.getMainCamera.ScreenToWorldPoint(_eventData.position).y, -1);
        GameObject barrier = Instantiate(barrierPrefab, spawnPosition, barrierPrefab.transform.rotation) as GameObject;

        EditorBarrier editorBarrier = barrier.GetComponent<EditorBarrier>();
        editorBarrier.editorPlayerHelpers = editorPlayerHelpers;

        editorPlayerHelpers.AddBarrier(barrier.transform);
    }

}
