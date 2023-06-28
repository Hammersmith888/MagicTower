using UnityEngine;
namespace Animations
{
	public class ColorAnimation : MonoBehaviour
	{
		public enum EAnimationType
		{
			ONCE, LOOP, PING_PONG
		}

		public IColorHolder colorHolder;
		public bool setColorHolderAutomatically;

		public Color fromColor;
		public Color toColor;
		public float animationTime;
		public FloatRange randomizeAnimationTimeBy;

		public AnimationCurve effectCurve;
		public bool useCurve;
		public EAnimationType animationType = EAnimationType.ONCE;
		public bool autoStart;
		public bool disableObjectAtEnd;

		protected bool forwardDirection = true;
		protected BaseTimer timer;
		protected System.Action actionOnAnimationEnd;
		public GameObject gameObjCached
		{
			get; protected set;
		}

		protected bool inited = false;

		public float getAnimationTime
		{
			get
			{
				return animationTime;
			}
		}
		public bool isPlaying
		{
			get
			{
				return timer.isActive;
			}
		}

		// Use this for initialization
		protected void Awake( )
		{
			Init();
			if( autoStart )
			{
				Animate();
			}
		}

		public void Init( )
		{
			if( !inited )
			{
				inited = true;
				gameObjCached = gameObject;
				animationTime += randomizeAnimationTimeBy.random;
				timer = new BaseTimer( animationTime, false, OnAnimationEnd );
				if( colorHolder == null )
				{
					if( setColorHolderAutomatically )
					{
						if( GetComponent<SpriteRenderer>() != null )
						{
							colorHolder = gameObjCached.AddComponent<SpriteRendererColorHolder>();
						}
						else if( GetComponent<UnityEngine.UI.Image>() != null )
						{
							colorHolder = gameObjCached.AddComponent<UIImageColorHolderComponent>();
						}
						//else if( GetComponent<TextMesh>() != null )
						//{
						//    colorHolder = obj.AddComponent<TextMeshColorHolder>();
						//}
						else
						{
							Debug.LogWarning( "Can't find suitable component to add color holder for object " + gameObjCached.name );
						}
					}
					else
					{
						colorHolder = GetComponentInChildren<IColorHolder>();
					}
				}
			}
		}

		public void Pause( )
		{
			timer.Pause();
		}

		public void SetColor(Color color)
		{
			colorHolder.color = color;
		}

		public void RegisterCallbackOnAnimationEnd(System.Action callback)
		{
			actionOnAnimationEnd = callback;
		}

		public void AddOnAnimationEndCallback(System.Action callback)
		{
			actionOnAnimationEnd += callback;
		}
		#region Animate functions
		public void Animate( )
		{
			Animate( animationTime );
		}

		public void Animate(System.Action callback, bool forward = true)
		{
			forwardDirection = forward;
			Animate( animationTime, fromColor, callback );
		}

		public void Animate(float animTime, System.Action callback, bool forward = true)
		{
			forwardDirection = forward;
			Animate( animTime, fromColor, callback );
		}

		public void Animate(float time, System.Action callback = null)
		{
			Animate( time, fromColor, callback );
		}

		public void Animate(float time, Color startColor, System.Action callback = null)
		{
			gameObjCached.SetActive( true );
			fromColor = startColor;
			colorHolder.color = forwardDirection ? fromColor : toColor;
			timer.Start( time, callback );
		}

		public void AnimateFromCurrentColor(Color endColor, System.Action callback = null)
		{
			gameObjCached.SetActive( true );
			fromColor = colorHolder.color;
			toColor = endColor;
			timer.Start( animationTime, callback );
		}
		#endregion
		protected void OnAnimationEnd( )
		{
			if( actionOnAnimationEnd != null )
			{
				actionOnAnimationEnd();
			}
			if( disableObjectAtEnd && !timer.isActive )
			{
				gameObjCached.SetActive( false );
			}
		}

		private float timerProgress;
		protected void Update( )
		{
			if( timer.isActive )
			{
				timer.Update();
				timerProgress = forwardDirection ? timer.progress : 1f - timer.progress;
				colorHolder.color = Color.Lerp( fromColor, toColor, useCurve ? effectCurve.Evaluate( timerProgress ) : timerProgress );
				if( !timer.isActive )
				{
					OnAnimationEnd();
					if( animationType == EAnimationType.LOOP )
					{
						timer.Start();
					}
					else if( animationType == EAnimationType.PING_PONG )
					{
						forwardDirection = !forwardDirection;
						timer.Start();
					}
				}
			}
		}

#if UNITY_EDITOR
		[Header( "Editor variables" )]
		public bool swapColors;
		public bool updateTime;
		protected void OnDrawGizmosSelected( )
		{
			if( swapColors )
			{
				swapColors = false;
				Color temp = fromColor;
				fromColor = toColor;
				toColor = temp;
			}
			if( updateTime )
			{
				updateTime = false;
				timer.Start( animationTime );
			}
		}
#endif
	}
}
