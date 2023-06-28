using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Animations
{
	public class UIGraphickMaterialColorHolder : MonoBehaviour, IColorHolder
	{
		//[GetComponentInEditor]
		[SerializeField]
		private UnityEngine.UI.Graphic graphickComponent;
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
				return material.GetColor(propertyHash).a;
			}

			set
			{
				Color currentColor = material.GetColor(propertyHash);
				currentColor.a = value;
				material.SetColor(propertyHash, currentColor);
			}
		}

		public Color color
		{
			get
			{
				return material.GetColor(propertyHash);
			}

			set
			{
				material.SetColor(propertyHash, value);
			}
		}

		public void Init()
		{
			propertyHash = Shader.PropertyToID(colorPropertyName);
			if(useSharedMaterial)
			{
				material = graphickComponent.material;
			}
			else
			{
				material = new Material(graphickComponent.material);
				graphickComponent.material = material;
			}
		}

		void Awake()
		{
			Init();
		}
	}
}
