
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameObjectContextDebugOptions
{
    [MenuItem("GameObject/Debug/Draw Rect Center", false, 0)]
    static void MakeUIButton()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                var rectTransform = selection[i].GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    DebugTools.DrawCross(rectTransform.GetRectCenter(), 20f, Color.white, 10f);
                }
            }
        }
    }
}
