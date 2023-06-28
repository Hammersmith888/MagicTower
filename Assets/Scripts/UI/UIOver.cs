using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOver : MonoBehaviour
{
    private static List<GameObject> objs = new List<GameObject>();
    public static void Set(bool value, GameObject obj)
    {
        if (value)
        {
            var canvas = obj.AddComponent<Canvas>();
            canvas.overrideSorting = true;
            canvas.sortingOrder = 1;
            obj.AddComponent<GraphicRaycaster>();
            objs.Add(obj);
        }
        else
        {
            if(obj.GetComponent<GraphicRaycaster>() != null)
                Destroy(obj.GetComponent<GraphicRaycaster>());
            if (obj.GetComponent<Canvas>() != null)
                Destroy(obj.GetComponent<Canvas>());
            objs.Remove(obj);
        }
    }

    public static void ClearAll()
    {
        foreach (var  obj in objs)
        {
            if (obj != null)
            {
                if (obj.GetComponent<GraphicRaycaster>() != null)
                    Destroy(obj.GetComponent<GraphicRaycaster>());
                if (obj.GetComponent<Canvas>() != null)
                    Destroy(obj.GetComponent<Canvas>());
            }
        }
        objs.Clear();
    }
}
