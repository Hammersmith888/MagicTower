using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorBarrier : MonoBehaviour {

    public EditorPlayerHelpers editorPlayerHelpers;
    public void OnMouseDrag()
    {
        print("OnMouseDrag" + name);
        Vector3 spawPosition = new Vector3(Helpers.getMainCamera.ScreenToWorldPoint(Input.mousePosition).x, Helpers.getMainCamera.ScreenToWorldPoint(Input.mousePosition).y, -1);
        transform.position = spawPosition;
    }

    public void OnMouseUp()
    {
        if (Input.mousePosition.y < 100)
        {
            editorPlayerHelpers.RemoveBarrier(transform);

            Destroy(gameObject);
        }
        else
        {
            editorPlayerHelpers.AddBarrier(transform);
        }
    }

}
