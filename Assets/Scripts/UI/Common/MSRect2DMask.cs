
using System.Collections;
using UnityEngine.UI;
using Tutorials;

namespace UI
{
    public class MSRect2DMask : RectMask2D
    {
        override protected void OnEnable()
        {
            TutorialUtils.TutorialCanvasOverride.OnCanvasOverrideCleared += RebuildMask;
            base.OnEnable();
        }

        override protected void OnDisable()
        {
            TutorialUtils.TutorialCanvasOverride.OnCanvasOverrideCleared -= RebuildMask;
            base.OnDisable(); 
        }

        private void RebuildMask()
        {
            StartCoroutine(RebuildMaskNextFrame());
        }

        private IEnumerator RebuildMaskNextFrame()
        {
            yield return null;
            MaskUtilities.Notify2DMaskStateChanged(this);
        }
    }
}
