using UnityEngine;

namespace Animations
{
	public class CanvasGroupAlphaHolder : CacheComponentOfType<CanvasGroup>, IColorHolder
	{
		void Awake( )
		{
			if( cachedComponent == null )
			{
				Init();
			}
		}

		public Color color
		{
			get {
				return new Color( 0, 0, 0, cachedComponent.alpha );
			}
			set {
				cachedComponent.alpha = value.a;
			}
		}

		public float alpha
		{
			get {
				return cachedComponent.alpha;
			}
			set {
				cachedComponent.alpha = value;
			}
		}
	}
}
