using UnityEngine;

namespace Animations
{
	public abstract class UIAbstractGraphicColorHolder<T> : CacheComponentOfType<T>, IColorHolder where T : UnityEngine.UI.Graphic
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
			get
			{
				return cachedComponent.color;
			}
			set
			{
				cachedComponent.color = value;
			}
		}

		public float alpha
		{
			get
			{
				return cachedComponent.color.a;
			}
			set
			{
				Color color = cachedComponent.color;
				color.a = value;
				cachedComponent.color = color;
			}
		}
	}

    public class UIGraphicColorHolder : UIAbstractGraphicColorHolder<UnityEngine.UI.Graphic>
    { }
}
