using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CopyTransformHierarchy : EditorWindow
{
    private Transform sourceTransform;
    private Transform parentOfTransfromToApplyTo;
    private bool checkOnlyByName;

    [MenuItem("Tools/Copy Transform Hierarchy")]
    public static void OpenWindow()
    {
        var window = EditorWindow.GetWindow<CopyTransformHierarchy>() as CopyTransformHierarchy;
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUIUtility.labelWidth = 200f;
        sourceTransform = EditorGUILayout.ObjectField("Source transform:", sourceTransform, typeof(Transform)) as Transform;
        parentOfTransfromToApplyTo = EditorGUILayout.ObjectField("Parent Of Transfrom To Apply To:", parentOfTransfromToApplyTo, typeof(Transform)) as Transform;
        EditorGUIUtility.labelWidth = 0f;

        checkOnlyByName = EditorGUILayout.Toggle("Check Only By Name", checkOnlyByName);

        var dataIsNotNull = (sourceTransform != null && parentOfTransfromToApplyTo != null);
        bool dataIsValid = true;
        //if (dataIsNotNull)
        //{
        //    dataIsValid = parentOfTransfromToApplyTo == sourceTransform.parent.parent;
        //    if (!dataIsValid)
        //    {
        //        EditorGUILayout.HelpBox("Wrong parent transform, parent transform must be parent of parent of sourceTransform", MessageType.Error);
        //    }
        //}
        GUI.enabled = dataIsNotNull && dataIsValid;
        EditorGUILayout.Space();
        if (GUILayout.Button("Copy"))
        {
            Copy();
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Replace"))
        {
            Replace();
        }
    }

    private void Copy()
    {
        var parentTransformChildCount = parentOfTransfromToApplyTo.childCount;
        var sourceChildIndex = sourceTransform.GetSiblingIndex();
        for (int i = 0; i < parentTransformChildCount; i++)
        {
            var targetChild = parentOfTransfromToApplyTo.GetChild(i);
            if (targetChild.GetInstanceID() == sourceTransform.parent.GetInstanceID())
            {
                Debug.LogFormat("{0} is skipped because it is parent of SourceTransform", targetChild.name);
                continue;
            }
            var child = targetChild.GetChild(sourceChildIndex);
            if (child.name != sourceTransform.name)
            {
                Debug.LogFormat("Target: {0}. Names differs {1} source: {2}", targetChild.name, child.name, sourceTransform.name);
                continue;
            }
            CopyTransformParametersForAllChildrens(sourceTransform, child);
        }

        Debug.Log("Copy opreation completed");
    }

    private void CopyTransformParametersForAllChildrens(Transform copyFrom, Transform copyTo)
    {
        CopyTransformParameters(copyFrom, copyTo);
        Debug.LogFormat("{0} modified as {1}", copyTo.gameObject.name, copyFrom.gameObject.name);
        var childCount = Mathf.Min(copyTo.childCount, copyFrom.childCount);
        for (int j = 0; j < childCount; j++)
        {
            CopyTransformParametersForAllChildrens(copyFrom.GetChild(j), copyTo.GetChild(j));
        }
    }

    private void Replace()
    {
        var parentTransformChildCount = parentOfTransfromToApplyTo.childCount;
        var sourceChildIndex = sourceTransform.GetSiblingIndex();
        int replacedNumber = 0;
        for (int i = 0; i < parentTransformChildCount; i++)
        {
            var targetChild = parentOfTransfromToApplyTo.GetChild(i);
            if (targetChild.GetInstanceID() == sourceTransform.parent.GetInstanceID())
            {
                Debug.LogFormat("{0} is skipped because it is parent of SourceTransform", targetChild.name);
                continue;
            }

            Transform child = null;
            if (checkOnlyByName)
            {
                child = targetChild.FindChildWithNameNonRecursive(sourceTransform.name);
                if (child == null)
                {
                    Debug.LogFormat("Can't find child with Name:{0} in Transform: {1}", sourceTransform.name, targetChild.name);
                    continue;
                }
            }
            else
            {
                child = targetChild.GetChild(sourceChildIndex);
                if (child.name != sourceTransform.name)
                {
                    Debug.LogFormat("Target: {0}. Names differs {1} source: {2}", targetChild.name, child.name, sourceTransform.name);
                    continue;
                }
            }
            var gameObjectActiveState = child.gameObject.activeSelf;
            DestroyImmediate(child.gameObject);
            var newObject = GameObject.Instantiate(sourceTransform.gameObject, targetChild).transform;
            newObject.name = newObject.name.Replace("(Clone)", "");
            newObject.gameObject.SetActive(gameObjectActiveState);
            newObject.SetSiblingIndex(sourceChildIndex);
            CopyTransformParameters(sourceTransform, newObject);
            replacedNumber++;
        }

        Debug.LogFormat("Replace operation completed. ReplacedNumber: {0}", replacedNumber);
    }

    private void CopyTransformParameters(Transform copyFrom, Transform copyTo)
    {
        var templateRectTransf = copyFrom as RectTransform;
        if (templateRectTransf != null)
        {
            var rectTransfToModify = copyTo as RectTransform;
            if (rectTransfToModify == null)
            {
                rectTransfToModify = copyTo.gameObject.AddComponent<RectTransform>();
            }
            rectTransfToModify.sizeDelta = templateRectTransf.sizeDelta;
            rectTransfToModify.anchorMax = templateRectTransf.anchorMax;
            rectTransfToModify.anchorMin = templateRectTransf.anchorMin;
            rectTransfToModify.pivot = templateRectTransf.pivot;
            rectTransfToModify.offsetMax = templateRectTransf.offsetMax;
            rectTransfToModify.offsetMin = templateRectTransf.offsetMin;
            rectTransfToModify.anchoredPosition3D = templateRectTransf.anchoredPosition3D;
        }
        else
        {
            copyTo.localPosition = copyFrom.localPosition;
        }
        copyTo.localScale = copyFrom.localScale;
    }
}
