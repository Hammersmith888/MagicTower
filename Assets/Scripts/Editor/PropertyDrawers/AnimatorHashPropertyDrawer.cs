using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer( typeof( AnimatorHashParameterAttribute ) )]
public class AnimatorHashPropertyDrawer : StringPopupDrawerBase<AnimatorHashParameterAttribute>
{
	private Animator targetAnimator;

	const string RELATIVE_PROPERTY_NAME = "propertyName";

	protected override SerializedProperty GetTargetStringSerializedProperty(SerializedProperty source)
	{
		return source.FindPropertyRelative( RELATIVE_PROPERTY_NAME );
	}

	protected override bool ValidPropertyType(SerializedPropertyType propertyType, Rect errorMessagePos)
	{
		if( propertyType != SerializedPropertyType.Generic )
		{
			EditorGUI.LabelField( errorMessagePos, "ERROR:", string.Format( "May only apply to type string, current is {0}", propertyType ) );
			return false;
		}
		return true;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if( !ValidPropertyType( property.propertyType, position ) )
		{
			return;
		}

		//if( targetAnimator == null )
		{
			string animatorPropertyName = TargetAttribute.animatorPropertyName;
			if( string.IsNullOrEmpty( animatorPropertyName ) )
			{
				targetAnimator = ( property.serializedObject.targetObject as Component ).GetComponentInChildren<Animator>();
			}
			else
			{
				SerializedProperty animatorProperty = property.serializedObject.FindProperty( animatorPropertyName );
				if(animatorProperty == null)
				{
					animatorProperty = property.FindPropertyOnSameLevelWithCurrent(animatorPropertyName);
				}
				if( animatorProperty != null && animatorProperty.objectReferenceValue != null )
				{
					targetAnimator = animatorProperty.objectReferenceValue as Animator;
					//Debug.Log(targetAnimator.gameObject.name);
				}
				if( targetAnimator == null )
				{
					targetAnimator = ( property.serializedObject.targetObject as Component ).GetComponentInChildren<Animator>();
				}
			}
		}


		if( targetAnimator == null )
		{
			EditorGUI.PropertyField( position, property );
			return;
		}
		//if( popupContent == null )
		//{
		//	UpdateFilesList();
		//}
		position = EditorGUI.PrefixLabel( position, label );

		string stringVal = GetTargetStringSerializedProperty( property ).stringValue;

		if( GUI.Button( position, string.IsNullOrEmpty( stringVal ) ? NoneLabel : stringVal, EditorStyles.popup ) )
		{
			UpdateFilesList();
			Selector( GetTargetStringSerializedProperty( property ) );
		}
	}

	override protected void UpdateFilesList( )
	{
		System.Collections.Generic.List<string> parametersList = new System.Collections.Generic.List<string>();
		AnimatorControllerParameterType animParamtereType = TargetAttribute.parameterType;
		for( int i = 0; i < targetAnimator.parameterCount; i++ )
		{
			if( targetAnimator.parameters[i].type == animParamtereType )
			{
				parametersList.Add( targetAnimator.parameters[i].name );
			}
		}
		popupContent = parametersList.ToArray();
	}

}
