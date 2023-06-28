#if UNITY_EDITOR
#define ENABLE_LOG
#endif
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DebugFBID : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler*/
{
    //    private const int TouchesToShowID = 3;
    //    private const float TouchMinTime = 1.25f;

    [SerializeField]
    private Text LabelToShowID;
    //private int DebugCounter;

    //private Graphic Graphick;

    //private void Awake()
    //{

    //Graphick = GetComponent<Graphic>();
    //LabelToShowID.gameObject.SetActive(false);
    //if (Graphick != null)
    //{
    //    Graphick.raycastTarget = true;
    //}
    //else
    //{
    //    Log("DebugFBID: Where is no graphick component attached");
    //}

    //}

    private void OnEnable()
    {
        if (Social.FacebookManager.Instance.isLoggedIn)
        {
            LabelToShowID.gameObject.SetActive(true);
            LabelToShowID.text = "ID: " + Social.FacebookManager.Instance.User.id.ToString();
        }
        else
        {
            LabelToShowID.gameObject.SetActive(false);
        }
        //if (LabelToShowID != null)
        //{
        //    LabelToShowID.gameObject.SetActive(false);
        //}
        //DebugCounter = 0;
        //StopAllCoroutines();
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    StartCoroutine(WaitBeforeShowID());
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    StopAllCoroutines();
    //}

    //private IEnumerator WaitBeforeShowID()
    //{
    //    DebugCounter = 0;
    //    float timer = 0;
    //    while (true)
    //    {
    //        timer += Time.unscaledDeltaTime;
    //        if (timer >= TouchMinTime)
    //        {
    //            DebugCounter++;
    //            BlinkWithGraphick();
    //            timer = 0;
    //        }
    //        if (DebugCounter >= TouchesToShowID)
    //        {
    //            DebugCounter = 0;
    //            if (LabelToShowID == null)
    //            {
    //                Log("DebugFBID: LabelToShowID is not set");

    //            }
    //            else
    //            {
    //                LabelToShowID.gameObject.SetActive(true);
    //                if (Social.FacebookManager.Instance.isLoggedIn)
    //                {
    //                    LabelToShowID.text = Social.FacebookManager.Instance.User.id.ToString();
    //                }
    //                else
    //                {
    //                    LabelToShowID.text = "You are not logged in with Facebook";
    //                }
    //            }
    //            break;
    //        }
    //        yield return null;
    //    }

    //}

    //private void BlinkWithGraphick()
    //{
    //    if (Graphick != null)
    //    {
    //        Graphick.color = Color.green;
    //        this.CallActionAfterDelayWithCoroutine(0.1f, () =>
    //        {
    //            Graphick.color = Color.white;
    //        });
    //    }
    //}

    //[System.Diagnostics.Conditional("ENABLE_LOG")]
    //private void Log(string text, params object[] parameters)
    //{
    //    Debug.LogFormat(text, parameters);
    //}
}
