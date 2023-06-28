using UnityEngine;

public class MaterialColorPropertyNameProvider : MonoBehaviour, IMaterialColorPropertyNameProvider {

	private enum EMaterialColorPropetyName
	{
		_Color, _EmisColor, _TintColor
	}

	[SerializeField]
	private EMaterialColorPropetyName materialColorPropetyName;
	
	public string getMaterialColorPropertyName
	{
		get {
			return materialColorPropetyName.ToString();
		}
	}

}
