using UnityEngine;

namespace Animations
{
	public interface IColorHolder
	{
		Color color
		{
			get; set;
		}
		float alpha
		{
			get; set;
		}
		void Init( );
	}

	public static class ColorHolderExtensions
	{
		public static IColorHolder GetColorHolder(this GameObject gameOjbect, bool addColorHolderIfNull = true, bool collectAllColorHoldersIncludingChild = false )
		{
			if(addColorHolderIfNull)
			{
				if(gameOjbect.GetComponent<SpriteRenderer>() != null)
				{
					return gameOjbect.AddComponent<SpriteRendererColorHolder>();
				}
				else if(gameOjbect.GetComponent<UnityEngine.UI.Graphic>() != null)
				{
					return  gameOjbect.AddComponent<UIGraphicColorHolder>();
				}
				//else if( GetComponent<TextMesh>() != null )
				//{
				//    colorHolder = gameobjectCached.AddComponent<TextMeshColorHolder>();
				//}
				else if(gameOjbect.GetComponent<CanvasGroup>() != null)
				{
					return gameOjbect.AddComponent<CanvasGroupAlphaHolder>();
				}
				else
				{
					Debug.LogWarning("Can't find suitable component to add color holder for object " + gameOjbect.name);
				}
			}
			else
			{
				if(collectAllColorHoldersIncludingChild)
				{
					return new MultipleObjectsColorHolder(gameOjbect.GetComponentsInChildren<IColorHolder>());
				}
				else
				{
					return gameOjbect.GetComponentInChildren<IColorHolder>();
				}
			}
			return null;
		}
	}
}
