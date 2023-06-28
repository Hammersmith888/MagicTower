using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer( typeof( ResourceFile ) )]
public class ResourcesFileAttributeDrawer : PropertyDrawer
{
    protected const string NoneLabel = "<None>";

    protected string[] fileNamesInDirectory;

	const string FULL_PATH_FORMAT = "{0}/{1}";

    protected ResourceFile TargetAttribute { get { return ( ResourceFile ) attribute; } }

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
        //Debug.Log( "File list updatet for " + TargetAttribute.resourcesFolderPath );
        Object[] objectsInDir = Resources.LoadAll<Object>( TargetAttribute.resourcesFolderPath );
        fileNamesInDirectory = new string[ objectsInDir.Length ];
        for( int i = 0; i < fileNamesInDirectory.Length; i++ )
        {
            fileNamesInDirectory[ i ] = objectsInDir[ i ].name;
        }
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if( !ValidPropertyType( property.propertyType, position ) )
        {
            return;
        }
        if( fileNamesInDirectory == null )
        {
            UpdateFilesList();
        }

        position = EditorGUI.PrefixLabel( position, label );

        if( GUI.Button( position,  string.IsNullOrEmpty( property.stringValue ) ? NoneLabel : property.stringValue, EditorStyles.popup ) )
        {
            Selector( property );
        }
    }

    protected virtual void Selector(SerializedProperty property)
    {
        GenericMenu menu = new GenericMenu();
        PopulateMenu( menu, property );
        menu.ShowAsContext();
    }

    protected void PopulateMenu(GenericMenu menu, SerializedProperty property)
    {
        // <None> item
        menu.AddItem( new GUIContent( NoneLabel ), string.IsNullOrEmpty( property.stringValue ), HandleSelect, new DrawerValuePair( null, property ) );

        string name;
        for( int i = 0; i < fileNamesInDirectory.Length; i++ )
        {
            name = fileNamesInDirectory[ i ];
            menu.AddItem( new GUIContent( name ), string.Format( FULL_PATH_FORMAT, TargetAttribute.resourcesFolderPath, fileNamesInDirectory[ i ] ) == property.stringValue, HandleSelect, new DrawerValuePair( fileNamesInDirectory[ i ], property ) );
        }
    }

    protected virtual void HandleSelect(object val)
    {
        var pair = ( DrawerValuePair ) val;
        pair.property.stringValue = string.Format( FULL_PATH_FORMAT, TargetAttribute.resourcesFolderPath, pair.fileName );
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

public class ResourcesFileAttributeDrawer_Generic<T> : ResourcesFileAttributeDrawer where T: Object
{
    const string RESOURCES_FOLDER = "Resources";
    const char EXTENSION_POINT = '.';

    override protected void UpdateFilesList( )
    {
        T[] objectsInDir = Resources.LoadAll<T>( TargetAttribute.resourcesFolderPath );
        fileNamesInDirectory = new string[ objectsInDir.Length ];
        string path;
        int substringIndex;
        for( int i = 0; i < fileNamesInDirectory.Length; i++ )
        {
            //fileNamesInDirectory[ i ] = objectsInDir[ i ].name;
            path =  AssetDatabase.GetAssetPath( objectsInDir[ i ].GetInstanceID() );
            substringIndex = path.IndexOf( RESOURCES_FOLDER )+ RESOURCES_FOLDER.Length + TargetAttribute.resourcesFolderPath.Length + 2;//2 is number of folder separators '/'
            path = path.Substring( substringIndex, path.Length - substringIndex );
            //Removing file extension
            substringIndex = path.IndexOf( EXTENSION_POINT );
            path = path.Substring( 0, substringIndex );
            fileNamesInDirectory[ i ] = path;
        }
    }
}
/*
[CustomPropertyDrawer (typeof( AudioResourcesFile ) )]
public class SoundFileAttributeDrawer : ResourcesFileAttributeDrawer_Generic<AudioClip>
{

}*/
