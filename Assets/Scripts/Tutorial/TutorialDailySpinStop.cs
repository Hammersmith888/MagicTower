using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public class TutorialDailySpinStop : MonoBehaviour
    {
        [SerializeField]
        private GameObject tutorialMainObject;
        [SerializeField]
        private Animator tutorialAnimator;
        [SerializeField]
        [AnimatorHashParameter(animatorPropertyName ="tutorialAnimator")]
        private AnimatorPropertyHash fadeOutAnimProperty;

        private void Start()
        {
            fadeOutAnimProperty.Hash();
            tutorialMainObject.SetActive(true);
        }
    }
}