using UnityEngine;

namespace Animations
{
	public class SpriteRendererColorHolder : CacheComponentOfType<SpriteRenderer>, IColorHolder
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
}
