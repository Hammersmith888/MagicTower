using UnityEngine;

namespace Animations
{
	public class MaterialColorHolder : MonoBehaviour, IColorHolder
	{
		//[GetComponentInEditor]
		[SerializeField]
		private Renderer _Renderer;
		[SerializeField]
		private bool useSharedMaterial;
		[SerializeField]
		private string colorPropertyName;
		private int propertyHash;
		private Material material;

		public float alpha
		{
			get
			{
				return material.GetColor( propertyHash ).a;
			}

			set
			{
				Color currentColor = material.GetColor( propertyHash );
				currentColor.a = value;
				material.SetColor( propertyHash, currentColor );
			}
		}

		public Color color
		{
			get
			{
				return material.GetColor( propertyHash );
			}

			set
			{
				material.SetColor( propertyHash, value );
			}
		}

		public void Init( )
		{
			propertyHash = Shader.PropertyToID( colorPropertyName );
			material = useSharedMaterial ? _Renderer.sharedMaterial : _Renderer.material;
		}

		void Awake( )
		{
			Init();
		}
	}
}
