using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class EditorHelpers
{
    [MenuItem("GameObject/Toggle Unused On Renderers", false, 11)]
    static void Init()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                Renderer[] renderers = selection[i].GetComponentsInChildren<Renderer>();
                for (int j = 0; j < renderers.Length; j++)
                {
                    renderers[j].motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
                    renderers[j].receiveShadows = false;
                    renderers[j].shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    renderers[j].lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
                    renderers[j].reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
                }
            }
        }
    }

    [MenuItem("GameObject/UI_MoveButtonImageToChild_CenterChild", false, 11)]
    static void MakeUIButton()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            Undo.RegisterCompleteObjectUndo(selection, "MakeUIButton Undo");
            for (int i = 0; i < selection.Length; i++)
            {
                Button button = selection[i].GetComponent<Button>();
                Image image = selection[i].GetComponent<Image>();
                if (button != null && image != null)
                {
                    GameObject buttonImgObj = new GameObject("ButtonImage");
                    buttonImgObj.transform.parent = selection[i];
                    //buttonImgObj.transform.SetAsFirstSibling();
                    Image img = buttonImgObj.AddComponent<Image>();
                    img.sprite = image.sprite;
                    img.preserveAspect = image.preserveAspect;
                    img.raycastTarget = false;
                    img.type = image.type;

                    GameObject.DestroyImmediate(image);
                    button.targetGraphic = selection[i].gameObject.AddComponent<UI.NonRenderedGraphic>();
                    //button.transition = Selectable.Transition.None;
                    button.targetGraphic = img;

                    RectTransform newChildRect = buttonImgObj.GetComponent<RectTransform>();
                    RectTransform sourceRect = selection[i].GetComponent<RectTransform>();
                    newChildRect.localScale = sourceRect.localScale;
                    //rectTransf.pivot = sourceRect.pivot;
                    newChildRect.sizeDelta = sourceRect.sizeDelta;
                    newChildRect.localEulerAngles = sourceRect.localEulerAngles;
                    newChildRect.anchoredPosition3D = Vector3.zero;

                    sourceRect.localScale = Vector3.one;
                    sourceRect.sizeDelta = new Vector2(125f, 125f);

                }
            }
        }
    }

    [MenuItem("GameObject/UI_MoveButtonImageToChild_KeepChildAnchor", false, 12)]
    static void MakeUIButtonKeepAnchor()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            Undo.RegisterCompleteObjectUndo(selection, "MakeUIButton Undo");
            for (int i = 0; i < selection.Length; i++)
            {
                Button button = selection[i].GetComponent<Button>();
                Image image = selection[i].GetComponent<Image>();
                if (button != null && image != null)
                {
                    GameObject buttonImgObj = new GameObject("ButtonImage");
                    buttonImgObj.transform.parent = selection[i];
                    //buttonImgObj.transform.SetAsFirstSibling();
                    Image img = buttonImgObj.AddComponent<Image>();
                    img.sprite = image.sprite;
                    img.preserveAspect = image.preserveAspect;
                    img.raycastTarget = false;
                    img.type = image.type;

                    GameObject.DestroyImmediate(image);
                    button.targetGraphic = selection[i].gameObject.AddComponent<UI.NonRenderedGraphic>();
                    //button.transition = Selectable.Transition.None;
                    button.targetGraphic = img;

                    RectTransform newChildRect = buttonImgObj.GetComponent<RectTransform>();
                    RectTransform sourceRect = selection[i].GetComponent<RectTransform>();
                    newChildRect.localScale = sourceRect.localScale;
                    //rectTransf.pivot = sourceRect.pivot;
                    newChildRect.sizeDelta = sourceRect.sizeDelta;
                    newChildRect.localEulerAngles = sourceRect.localEulerAngles;
                    newChildRect.pivot = sourceRect.pivot;
                    newChildRect.anchorMax = sourceRect.anchorMax;
                    newChildRect.anchorMin = sourceRect.anchorMin;
                    newChildRect.anchoredPosition3D = Vector3.zero;

                    sourceRect.localScale = Vector3.one;
                    sourceRect.sizeDelta = new Vector2(125f, 125f);

                }
            }
        }
    }

    [MenuItem("GameObject/UI_ValidateButtonTargetGraphickForAllInChild", false, 13)]
    static void ValidateButtonTargetGraphickForAllInChild()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                Debug.LogFormat("Processing <b>{0}</b>", selection[i].gameObject.name);
                ValidateButtonTargetGraphickRecursive(selection[i]);
            }
        }
    }

    [MenuItem("GameObject/UI_ValidateAndFixButtonTargetGraphickForAllInChild", false, 13)]
    static void ValidateAndFixButtonTargetGraphickForAllInChild()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                Debug.LogFormat("Processing <b>{0}</b>", selection[i].gameObject.name);
                ValidateButtonTargetGraphickRecursive(selection[i], true);
            }
        }
    }

    private static void ValidateButtonTargetGraphickRecursive(Transform target, bool fixIt = false)
    {
        var button = target.GetComponent<Button>();
        if (button != null)
        {
            if (button.targetGraphic != null && button.targetGraphic.transform.GetInstanceID() != target.transform.GetInstanceID())
            {
                Debug.LogErrorFormat("Incorrect target graphick on button {0}. Is Child of Button: {1}", target.gameObject.name, button.targetGraphic.transform.IsChildOf(target));
                if (fixIt)
                {
                    var buttonGraphic = button.GetComponent<Graphic>();
                    if (buttonGraphic == null)
                    {
                        Debug.LogErrorFormat("Can't fix target graphic reference because does not have Graphic component");
                    }
                    else
                    {
                        button.targetGraphic = buttonGraphic;
                        Debug.LogFormat("Fixing <b>{0}</b>", target.gameObject.name);
                    }
                }
            }
        }
        var childCount = target.childCount;
        for (int i = 0; i < childCount; i++)
        {
            ValidateButtonTargetGraphickRecursive(target.GetChild(i), fixIt);
        }
    }

    [MenuItem("GameObject/UI_DisableGraphicRaycastFlagOnAllChildren", false, 14)]
    static void DisableGraphicRaycastFlagOnAllChildren()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel);
        if (selection != null && selection.Length > 0)
        {
            for (int i = 0; i < selection.Length; i++)
            {
                int detectedComponentsNumber = 0;
                DisableTargetGraphickFlagRecursive(selection[i], ref detectedComponentsNumber);
                Debug.LogFormat("Processing {0}. Graphic components in children: {1}", selection[i].gameObject.name, detectedComponentsNumber);
            }
        }
    }

    private static void DisableTargetGraphickFlagRecursive(Transform target, ref int count)
    {
        var graphick = target.GetComponent<Graphic>();
        if (graphick != null)
        {
            graphick.raycastTarget = false;
            count++;
        }
        var childCount = target.childCount;
        for (int i = 0; i < childCount; i++)
        {
            DisableTargetGraphickFlagRecursive(target.GetChild(i), ref count);
        }
    }
}
