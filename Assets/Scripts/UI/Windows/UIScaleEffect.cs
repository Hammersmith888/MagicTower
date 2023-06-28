using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleEffect : MonoBehaviour
{
    [SerializeField]
    Transform windowTransform;
    Transform fromTarget = null;
    bool isWindowAnimPlaying;
    public bool isAnimation = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Open(Transform btn)
    {
        fromTarget = btn;
        gameObject.SetActive(true);
        if (!isAnimation)
        {
            windowTransform.gameObject.SetActive(true);
            windowTransform.localScale = new Vector3(1, 1, 1);
            return;
        }
        //if(fromTarget != null)
        StartCoroutine(AppearWindow());
    }

    public void Close(GameObject obj)
    {
        if (!isAnimation)
        {
            gameObject.SetActive(false);
            windowTransform.gameObject.SetActive(false);
            return;
        }
        //if (fromTarget != null)
        StartCoroutine(DisappearWindow(false, obj));
    }

    private IEnumerator AppearWindow()
    {
        gameObject.transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
        isWindowAnimPlaying = true;
        Vector3 signPosition = fromTarget.position;
        //signPosition.z = 0f;
        windowTransform.localPosition = signPosition;
        windowTransform.localScale = Vector3.zero;
        windowTransform.gameObject.SetActive(true);
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            windowTransform.localPosition = Vector3.Lerp(signPosition, Vector3.zero, animProgress);
            windowTransform.localScale = new Vector3(animProgress, animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
        isWindowAnimPlaying = false;
        yield return new WaitForEndOfFrame();
        yield break;

    }

    private IEnumerator DisappearWindow(bool showSign, GameObject obj)
    {
        Debug.Log("DisappearWindow");
        isWindowAnimPlaying = true;
        //Vector3 signPosition = WindowObj.transform.InverseTransformPoint(UIActionButton.Position);
        Vector3 signPosition = fromTarget.position;
        signPosition.z = 0f;
        windowTransform.localScale = Vector3.one;
        int steps = 10;
        float timer = 0.15f;
        float animProgress;
        //float speed = Vector3.Distance( EndPos, SignPos ) / timer;
        for (int i = 0; i < steps; i++)
        {
            animProgress = (i + 1) / (float)steps;
            windowTransform.localPosition = Vector3.Lerp(Vector3.zero, signPosition, animProgress);
            animProgress = 1f - animProgress;
            windowTransform.localScale = new Vector3(animProgress, animProgress, animProgress);
            yield return new WaitForSecondsRealtime(timer / steps);
        }
        obj.SetActive(false);
        UIActionButton.Toggle(showSign);
        windowTransform.localPosition = Vector3.zero;
        isWindowAnimPlaying = false;
        gameObject.transform.SetSiblingIndex(transform.GetSiblingIndex() - 1);
        yield break;
    }


}
