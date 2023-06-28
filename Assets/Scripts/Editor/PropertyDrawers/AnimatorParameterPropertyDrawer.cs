using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer( typeof(AnimatorParameterAttribute))]
public class AnimatorParameterPropertyDrawer : StringPopupDrawerBase<AnimatorParameterAttribute>
{
	private Animator targetAnimator;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if( !ValidPropertyType( property.propertyType, position ) )
		{
			return;
		}

		if( targetAnimator == null )
		{
			string animatorPropertyName = TargetAttribute.animatorPropertyName;
			if( string.IsNullOrEmpty( animatorPropertyName ) )
			{
				targetAnimator = ( property.serializedObject.targetObject as Component ).GetComponentInChildren<Animator>();
			}
			else
			{
				SerializedProperty animatorProperty = property.FindPropertyRelative( animatorPropertyName );
				if(animatorProperty == null)
				{
					animatorProperty = property.FindPropertyOnSameLevelWithCurrent(animatorPropertyName);
				}
				if( animatorProperty != null && animatorProperty.objectReferenceValue != null )
				{
					targetAnimator = animatorProperty.objectReferenceValue as Animator;
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
		if( popupContent == null )
		{
			UpdateFilesList();
		}
		position = EditorGUI.PrefixLabel( position, label );
		if( GUI.Button( position, string.IsNullOrEmpty( property.stringValue ) ? NoneLabel : property.stringValue, EditorStyles.popup ) )
		{
			Selector( property );
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

	//public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	//{
	//	return targetAnimator == null ? : 18;
	//}

}
