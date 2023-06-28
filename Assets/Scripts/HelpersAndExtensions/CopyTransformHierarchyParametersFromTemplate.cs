#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyTransformHierarchyParametersFromTemplate : MonoBehaviour
{
    public bool RunProcess;

    [Space(15f)]
    public bool CopyImageComponentType;
    public Transform Template;
    public Transform ParentOfObjectsForModifications;

    private void OnDrawGizmosSelected()
    {
        if (RunProcess)
        {
            RunProcess = false;
            if (Template == null || ParentOfObjectsForModifications == null)
            {
                return;
            }
            var childCount = ParentOfObjectsForModifications.childCount;
            var templateChildCount = Template.childCount;
            for (int i = 0; i < childCount; i++)
            {
                var childTransform = ParentOfObjectsForModifications.GetChild(i);
                if (childTransform.GetInstanceID() == Template.GetInstanceID())
                {
                    Debug.LogFormat("<b>{0}</b> object is skipped because it is template", Template.gameObject.name);
                    continue;
                }

                Debug.LogFormat("Processing object <b>{0}</b>", childTransform.gameObject.name);

                var childCount2 = childTransform.childCount;
                if (childCount2 != templateChildCount)
                {
                    Debug.LogErrorFormat("Target childCount ({0}) != template childCount ({1}). TargetObject: {2}", childCount2, templateChildCount, childTransform.gameObject.name);
                    childCount2 = Mathf.Min(childCount2, templateChildCount);
                }

                for (int n = 0; n < childCount2; n++)
                {
                    CopyHierarchyParameters(Template.GetChild(n), childTransform.GetChild(n));
                }
            }
        }
    }

    private void CopyHierarchyParameters(Transform template, Transform transformForModification)
    {
        var templateRectTransf = template as RectTransform;
        if (templateRectTransf != null)
        {
            var rectTransfToModify = transformForModification as RectTransform;
            if (rectTransfToModify == null)
            {
                rectTransfToModify = transformForModification.gameObject.AddComponent<RectTransform>();
            }
            rectTransfToModify.anchorMax = templateRectTransf.anchorMax;
            rectTransfToModify.anchorMin = templateRectTransf.anchorMin;
            rectTransfToModify.pivot = templateRectTransf.pivot;
            rectTransfToModify.offsetMax = templateRectTransf.offsetMax;
            rectTransfToModify.offsetMin = templateRectTransf.offsetMin;
            rectTransfToModify.anchoredPosition3D = templateRectTransf.anchoredPosition3D;
        }
        else
        {
            transformForModification.localPosition = template.localPosition;
        }
        transformForModification.localScale = template.localScale;
        Debug.LogFormat("{0} modified as {1}", transformForModification.gameObject.name, template.gameObject.name);
        if (CopyImageComponentType)
        {
            var templateImage = template.GetComponent<Image>();
            var targetImage = transformForModification.GetComponent<Image>();
            if (templateImage != null && targetImage != null)
            {
                if (targetImage.type != templateImage.type)
                {
                    Debug.LogFormat("Image ({0}) modified {1} => {2}", targetImage.gameObject.name, targetImage.type, templateImage.type);
                    targetImage.type = templateImage.type;
                }
            }
        }

        var templateChildCount = template.childCount;
        var childCount = transformForModification.childCount;
        if (childCount != templateChildCount)
        {
            Debug.LogErrorFormat("Target childCount ({0}) != template childCount ({1}). TargetObject: {2}. Template Object: {3}",
                childCount, templateChildCount, transformForModification.gameObject.name, template.gameObject.name);
            childCount = Mathf.Min(childCount, templateChildCount);
        }

        for (int n = 0; n < childCount; n++)
        {
            CopyHierarchyParameters(template.GetChild(n), transformForModification.GetChild(n));
        }
    }
}
#endif
