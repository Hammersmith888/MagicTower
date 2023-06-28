using ADs;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public class TutorialBird : MonoBehaviour
    {
        public GameObject pointerHand;
        [SerializeField]
        private RectTransform blackObject;
        [SerializeField]
        private Camera uiCamera;
        private bool animatePointer;
        [SerializeField]
        private GameObject messageObject;
        [SerializeField]
        private UIPauseController pause;
        private Vector3 birdPos;
        private Vector3 HandDefaultScale;

        private bool isPressed;
        //TODO AddGlobal game event on tutorial start, close all windows popup on this event
        // Use this for initialization

        public void ShowMessage(Vector3 pointPos)
        {
            TutorialsManager.OnTutorialStart(ETutorialType.BIRD);
            birdPos = pointPos;
            HandDefaultScale = pointerHand.transform.localScale;
            CenterBlackOnObject(blackObject, birdPos);
            var birdPosInUISpace = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(birdPos));
            PlaceHandPointer(birdPosInUISpace + new Vector3(-0.1f, 0.5f, 0f), true);
            messageObject.SetActive(true);
            Time.timeScale = 0f;
            pause.pauseCalled = true;
        }

        private void CenterBlackOnObject(RectTransform black, Vector3 objectPos)
        {
            Vector3 new_pos = uiCamera.ViewportToWorldPoint(Helpers.getMainCamera.WorldToViewportPoint(objectPos));
            new_pos.z = 0;
            black.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.8f);
            black.position = new Vector3(new_pos.x, new_pos.y, black.position.z);
        }

        #region HAND POINTER RELATED
        public void PlaceHandPointer(Vector3 rectPos, bool loopIt)
        {
            rectPos.z = 0;
            pointerHand.GetComponent<RectTransform>().position = rectPos;
            animatePointer = true;
            if (loopIt)
            {
                StartCoroutine(LoopHandPoint());
            }
        }

        public void RotateHandPointer(float zAngle)
        {
            pointerHand.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, zAngle);
        }

        IEnumerator LoopHandPoint()
        {
            GameObject hand1 = pointerHand.transform.Find("Hand").gameObject;
            GameObject hand2 = pointerHand.transform.Find("FingerPointerPress").gameObject;
            hand1.GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
            while (animatePointer == true)
            {
                float _timer = 1f;
                for (int i = 0; i < 100; i++)
                {
                    if (animatePointer != true)
                        break;
                    yield return new WaitForSecondsRealtime(_timer / 100f);
                }
                hand1.SetActive(false);
                hand2.SetActive(true);
                _timer = 0.2f;
                for (int i = 0; i < 10; i++)
                {
                    if (animatePointer != true)
                        break;
                    yield return new WaitForSecondsRealtime(_timer / 10f);
                }
                hand2.SetActive(false);
                hand1.SetActive(true);
                _timer = 2f;
                for (int i = 0; i < 100; i++)
                {
                    if (animatePointer != true)
                        break;
                    yield return new WaitForSecondsRealtime(_timer / 100f);
                }
            }
            hand1.GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0f);
            yield break;
        }

        private void HideHandPointer()
        {
            StopAllCoroutines();
            StartCoroutine(HandPointerFadeOut());
        }

        private IEnumerator HandPointerFadeOut()
        {
            GameObject hand1 = pointerHand.transform.Find("Hand").gameObject;
            GameObject hand2 = pointerHand.transform.Find("FingerPointerPress").gameObject;
            Image activeHandImage = hand1.activeSelf ? hand1.GetComponent<Image>() : hand2.GetComponent<Image>();
            float startAlpha = activeHandImage.color.a;
            if (startAlpha <= 0)
            {
                ResetHands();
                yield break;
            }
            float fadeOutTime = 5f;
            float targetAlpha = 0;
            float timePassed = 0f;
            Color color = activeHandImage.color;
            while (timePassed < fadeOutTime)
            {
                timePassed += Time.unscaledTime;
                color.a = Mathf.Lerp(startAlpha, targetAlpha, timePassed / fadeOutTime);
                activeHandImage.color = color;
                yield return null;
            }
        }

        private void ResetHands()
        {
            GameObject hand1 = pointerHand.transform.Find("Hand").gameObject;
            GameObject hand2 = pointerHand.transform.Find("FingerPointerPress").gameObject;
            hand1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            hand1.SetActive(true);
            hand2.SetActive(false);
            pointerHand.transform.localScale = HandDefaultScale;
            pointerHand.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            Debug.Log("Reset Tutorial Hands");
        }
        #endregion

        public void ContinueGame()
        {
            animatePointer = false;
            Time.timeScale = LevelSettings.Current.usedGameSpeed;
            pause.pauseCalled = false;
            messageObject.SetActive(false);
            AnalyticsController.Instance.Tutorial((int)ETutorialType.BIRD, 1);

            TutorialUtils.ClearAllCanvasOverrides();
            pointerHand.transform.localScale = HandDefaultScale;
            TutorialsManager.OnTutorialCompleted();
        }
    }
}