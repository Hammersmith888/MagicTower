using UnityEditor;
using UnityEngine;

namespace CustomProprtyDrawers
{
	[CustomPropertyDrawer(typeof(PickStringValueFromOtherPropertyAttribute ) )]
	public class PickStringValueFromOtherPropertyAttrDrawer : PropertyDrawer
	{
		private PickStringValueFromOtherPropertyAttribute attributeCach;
		protected PickStringValueFromOtherPropertyAttribute TargetAttribute
		{
			get {
				if( attributeCach == null )
				{
					attributeCach = attribute as PickStringValueFromOtherPropertyAttribute;
				}
				return attributeCach;
			}
		}

		private bool isError;
		const float ERROR_PROP_HEIGHT = 20f;

		protected virtual bool ValidPropertyType( SerializedPropertyType propertyType, Rect errorMessagePos )
		{
			if( propertyType != SerializedPropertyType.String )
			{
				isError = true;
				EditorGUI.LabelField( errorMessagePos, "ERROR: May only apply to type string" );
				return false;
			}
			return true;
		}


		public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
		{
			isError = false;
			if( !ValidPropertyType( property.propertyType, position ) )
			{
				return;
			}
			if( string.IsNullOrEmpty( TargetAttribute.propertyToGetValueName.Trim() ) )
			{
				isError = true;
				EditorGUI.LabelField( position, "ERROR: Property to get value name not set" );
				return;
			}
			SerializedProperty serializedProp =	 property.FindPropertyOnSameLevelWithCurrent( TargetAttribute.propertyToGetValueName );
			if( serializedProp == null )
			{
				isError = true;
				EditorGUI.LabelField( position, "ERROR: Can't find any property with name: " + TargetAttribute.propertyToGetValueName );
				return;
			}
			property.stringValue = serializedProp.GetValueAsStringValue();
		}

		public override float GetPropertyHeight( SerializedProperty property, GUIContent label )
		{
			return isError ? ERROR_PROP_HEIGHT : 0f;
		}

	}
}
