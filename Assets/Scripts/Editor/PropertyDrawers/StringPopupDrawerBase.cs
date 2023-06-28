using UnityEngine;
using UnityEditor;

public class StringPopupDrawerBase<T> : PropertyDrawer where T : PropertyAttribute
{
    protected const string NoneLabel = "<None>";

    protected string[] popupContent;

	private T attributeCach;
	protected T TargetAttribute
	{
		get
		{
			if( attributeCach == null )
			{
				attributeCach = attribute as T;
			}
			return attributeCach;
		}
	}

	protected virtual SerializedProperty GetTargetStringSerializedProperty(SerializedProperty source)
	{
		return source;
	}

	protected virtual bool ValidPropertyType(SerializedPropertyType propertyType, Rect errorMessagePos)
    {
        if( propertyType != SerializedPropertyType.String )
        {
            EditorGUI.LabelField( errorMessagePos, "ERROR:", "May only apply to type string" );
            return false;
        }
        return true;
    }

    virtual protected void UpdateFilesList( )
    {
        popupContent = new string[ 0 ];
    }

    public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
    {
        if( !ValidPropertyType( property.propertyType, position ) )
        {
            return;
        }
        if( popupContent == null )
        {
            UpdateFilesList();
        }

        position = EditorGUI.PrefixLabel( position, label );

		string stringVal = GetTargetStringSerializedProperty( property ).stringValue;

		if( GUI.Button( position, string.IsNullOrEmpty( stringVal ) ? NoneLabel : stringVal, EditorStyles.popup ) )
		{
			Selector( GetTargetStringSerializedProperty( property ) );
		}
    }

    protected virtual void Selector(SerializedProperty property)
    {
        GenericMenu menu = new GenericMenu();
        PopulateMenu( menu, property );
        menu.ShowAsContext();
    }

    virtual protected void PopulateMenu(GenericMenu menu, SerializedProperty property)
    {
        // <None> item
        menu.AddItem( new GUIContent( NoneLabel ), string.IsNullOrEmpty( property.stringValue ), HandleSelect, new DrawerValuePair( null, property ) );

        string name;
        for( int i = 0; i < popupContent.Length; i++ )
        {
            name = popupContent[ i ];
            menu.AddItem( new GUIContent( name ), popupContent[ i ] == property.stringValue, HandleSelect, new DrawerValuePair( popupContent[ i ], property ) );
        }
    }

    protected virtual void HandleSelect(object val)
    {
        var pair = ( DrawerValuePair ) val;
        pair.property.stringValue = pair.fileName;
        pair.property.serializedObject.ApplyModifiedProperties();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18;
    }

    public struct DrawerValuePair
    {
        public string fileName;
        public SerializedProperty property;

        public DrawerValuePair(string val, SerializedProperty property)
        {
            this.fileName = val;
            this.property = property;
        }
    }
}
