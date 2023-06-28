using UnityEngine;

namespace Animations
{

	public class MultipleObjectsColorHolder : IColorHolder
	{
		private int i;
		private IColorHolder[ ] colorHolders;

		public MultipleObjectsColorHolder(IColorHolder[ ] setColorHolders)
		{
			SetColorHolders( setColorHolders );
		}

		public void Init( )
		{
		}

		public void SetColorHolders(IColorHolder[ ] setColorHolders)
		{
			colorHolders = setColorHolders;
		}

		/// <summary>
		/// get always return Color.black, call ontly set function
		/// </summary>
		public Color color
		{
			get
			{
				return Color.black;
			}
			set
			{
				for( i = 0; i < colorHolders.Length; i++ )
				{
					colorHolders[i].color = color;
				}
			}
		}

		/// <summary>
		/// get always return 0, call ontly set function
		/// </summary>
		public float alpha
		{
			get
			{
				return 0;
			}
			set
			{
				for( i = 0; i < colorHolders.Length; i++ )
				{
					colorHolders[i].alpha = value;
				}
			}
		}
	}
}
