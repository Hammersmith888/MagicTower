using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
	public class RandomAlphaAnimation:MonoBehaviour
	{
		[SerializeField]
		private FloatRange alphaValueRange;
		[SerializeField]
		private FloatRange changeAlphaRange;
		[SerializeField]
		private FloatRange animationTimeRange;
		[SerializeField]
		private AnimationCurve animationCurve;

		[Space(10f)]
		[SerializeField]
		private bool playOnAwake;
		[SerializeField]
		private bool addColorHolderIfNone;
		[SerializeField]
		private bool collectAllColorHoldersIncludingChild;

		private float fromAlpha, toAlpha;

		private IColorHolder colorHolder;
		private BaseTimer animationTimer;

		// Use this for initialization
		void Awake()
		{
			animationTimer = new BaseTimer(0);
			colorHolder = gameObject.GetColorHolder(addColorHolderIfNone, collectAllColorHoldersIncludingChild);
			//colorHolder
			if(playOnAwake)
			{
				Play();
			}
		}

		public void Play()
		{
			fromAlpha = colorHolder.alpha;
			//float centerAlpha = (alphaValueRange.min + alphaValueRange.max) / 2f;

			bool animateForward = false;
			bool canAnimateForward = (alphaValueRange.max - fromAlpha >= changeAlphaRange.min);
			if(canAnimateForward)
			{
				bool canAnimateBackward = (fromAlpha - alphaValueRange.min >= changeAlphaRange.min);
				if(canAnimateBackward)
				{
					animateForward = Random.Range(0f, 100f) > 50f;
				}
				else
				{
					animateForward = true;
				}
			}

			if(animateForward)
			{
				toAlpha = Mathf.Clamp(Random.Range(fromAlpha + changeAlphaRange.min, fromAlpha + changeAlphaRange.max), alphaValueRange.min, alphaValueRange.max);
			}
			else
			{
				toAlpha = Mathf.Clamp(Random.Range(fromAlpha - changeAlphaRange.min, fromAlpha - changeAlphaRange.max), alphaValueRange.min, alphaValueRange.max);
			}

			animationTimer.Start(animationTimeRange.random);
		}

		private void OnAnimationCycleComplete()
		{
			Play();
		}

		// Update is called once per frame
		void Update()
		{
			if(animationTimer.isActive)
			{
				animationTimer.Update();
				colorHolder.alpha = Mathf.Lerp(fromAlpha, toAlpha, animationCurve.Evaluate(animationTimer.progress));
				if(!animationTimer.isActive)
				{
					OnAnimationCycleComplete();
				}
			}
		}
	}
}
