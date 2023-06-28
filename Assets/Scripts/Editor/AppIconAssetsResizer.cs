using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AppIconAssetsResizer : EditorWindow
{
	private Texture2D iconQuad;
	private Texture2D iconWide;
	private Texture2D splashWide;
	private Texture2D splashFit;

	private string quadPath;
	private string widePath;
	private string splashWidePath;
	private string splashFitPath;

	private bool overwriteFiles = true;

	#region SIZES
	List<Vector2> sizesQuad = new List<Vector2>() {

		#region WIN_10
		new Vector2(16, 16),
		new Vector2(32,32),
		new Vector2(48, 48),
		new Vector2(55, 55),
		new Vector2(66, 66),
		new Vector2(88, 88),
		new Vector2(89, 89),
		new Vector2(107, 107 ),
		new Vector2(142, 142),
		new Vector2(176, 176),
		new Vector2(188, 188),
		new Vector2(225, 225),
		new Vector2(256, 256),
		new Vector2(284, 284),
		new Vector2(300, 300),
		new Vector2(388, 388),
		new Vector2(465, 465),
		new Vector2(600, 600),
		new Vector2(620, 620),
#endregion

		new Vector2(50, 50),
			new Vector2(63, 63),

			new Vector2(70, 70),
			new Vector2(75, 75),
			new Vector2(90, 90),
			new Vector2(100, 100),
			new Vector2(120, 120),
			new Vector2(200, 200),

			new Vector2(24, 24),
			new Vector2(30, 30),
			new Vector2(42, 42),
			new Vector2(54, 54),
			new Vector2(150, 150),
			new Vector2(210, 210),
			new Vector2(270, 270),

			new Vector2(56, 56),
			new Vector2(70, 70),
			new Vector2(98, 98),
			new Vector2(126, 126),

			new Vector2(248, 248),
			new Vector2(310, 310),
			new Vector2(434, 434),
			new Vector2(558, 558),

			new Vector2(44, 44),
			new Vector2(62, 62),
			new Vector2(106, 106),

			new Vector2(71, 71),
			new Vector2(99, 99),
			new Vector2(170, 170),

			new Vector2(150, 150),
			new Vector2(210, 210),
			new Vector2(360, 360)
		};

	List<Vector2> sizesWide = new List<Vector2>() {
			new Vector2(248, 120),
			new Vector2(310, 150),
			new Vector2(434, 210),
			new Vector2(558, 270),

			new Vector2(310, 150),
			new Vector2(434, 210),
			new Vector2(744, 360),
		};

	List<Vector2> sizesSplashWide = new List<Vector2>() {
			new Vector2(620, 300),
			new Vector2(775, 375),
			new Vector2(868, 420),
			new Vector2(930, 450),
			new Vector2(1116, 540),
			new Vector2(1240, 600),
			new Vector2(2480, 1200),
		};

	List<Vector2> sizesSplashFit = new List<Vector2>() {
			new Vector2(480, 800),
			new Vector2(672, 1120),
			new Vector2(1152, 1920),
		};
	#endregion

	[MenuItem( "Tools/Resize for WSA" )]
	static void Init( )
	{
		// Get existing open window or if none, make a new one:
		AppIconAssetsResizer window = ( AppIconAssetsResizer )EditorWindow.GetWindow( typeof( AppIconAssetsResizer ) );
		window.Show();
	}

	void OnGUI( )
	{
		DrawResizeZone( ref iconQuad, ref quadPath, sizesQuad, "quadIcon" );
		DrawResizeZone( ref iconWide, ref widePath, sizesWide, "wideIcon" );
		DrawResizeZone( ref splashWide, ref splashWidePath, sizesSplashWide, "splashWide" );
		DrawResizeZone( ref splashFit, ref splashFitPath, sizesSplashFit, "splashFit" );
		overwriteFiles = EditorGUILayout.Toggle( "Overwrite: ", overwriteFiles );
		//GUILayout.Label( "Base Settings", EditorStyles.boldLabel );
		//myString = EditorGUILayout.TextField( "Text Field", myString );

		//groupEnabled = EditorGUILayout.BeginToggleGroup( "Optional Settings", groupEnabled );
		//myBool = EditorGUILayout.Toggle( "Toggle", myBool );
		//myFloat = EditorGUILayout.Slider( "Slider", myFloat, -3, 3 );
		//EditorGUILayout.EndToggleGroup();
	}

	private void DrawResizeZone(ref Texture2D textureRef, ref string path, List<Vector2> newSizes, string newFileName)
	{
		EditorGUILayout.BeginHorizontal();
		textureRef = EditorGUILayout.ObjectField( newFileName, textureRef, typeof( Texture2D ) ) as Texture2D;
		if( GUILayout.Button( string.IsNullOrEmpty( path ) ? "Select path" : path ) )
		{
			path = EditorUtility.OpenFolderPanel( "Select folder", "Assets", "" );
		}
		if( textureRef != null && !string.IsNullOrEmpty( path ) )
		{
			if( GUILayout.Button( "Resize " ) )
			{
				Resize( textureRef, path, newSizes, newFileName );
			}
		}
		EditorGUILayout.EndHorizontal();
	}

	private void Resize(Texture2D source, string newFilePath, List<Vector2> sizes, string fileName)
	{
		List<string> paths = new List<string>();

		foreach( Vector2 size in sizes )
		{
			int width = ( int )size.x;
			int height = ( int )size.y;
			string newFileName = string.Format( "{0}_{1}_{2}.png", fileName, width, height );
			string fullPath = string.Format( "{0}/{1}", newFilePath, newFileName );

			if( !overwriteFiles && System.IO.File.Exists( fullPath ) )
			{
				continue;
			}

			Texture2D newTexture = Object.Instantiate( source );
			TextureScale.Bilinear( newTexture, width, height );
			byte[ ] bytes = newTexture.EncodeToPNG();
			if( !System.IO.Directory.Exists( newFilePath ) )
			{
				System.IO.Directory.CreateDirectory( newFilePath );
			}
			System.IO.File.WriteAllBytes( fullPath, bytes );
			paths.Add( fullPath );
			Object.DestroyImmediate( newTexture, true );
		}

		AssetDatabase.Refresh( ImportAssetOptions.Default );
		AssetDatabase.SaveAssets();
		int length = paths.Count;
		for( int i = 0; i < length; i++ )
		{
			var assetsPath = paths[i].Replace( Application.dataPath, "" );
			var importer = AssetImporter.GetAtPath( "Assets" + assetsPath ) as TextureImporter;
			importer.textureType = TextureImporterType.Default;
			importer.textureCompression = TextureImporterCompression.Uncompressed;
			importer.npotScale = TextureImporterNPOTScale.None;
			importer.mipmapEnabled = false;
			importer.alphaIsTransparency = true;
		}
		AssetDatabase.Refresh( ImportAssetOptions.Default );
		AssetDatabase.SaveAssets();
	}

	//private static string ResizeTexture(Texture2D original, Vector2 newSize, string folder, string fileName)
	//{
	//	int width = ( int )newSize.x;
	//	int height = ( int )newSize.y;
	//	string newFilePath = string.Format( "{0}/AppIcons/{1}/", Application.dataPath, folder );
	//	string newFileName = string.Format( "{0}_{1}_{2}.png", fileName, width, height );
	//	string fullPath = newFilePath + newFileName;

	//	Texture2D newTexture = Object.Instantiate( original );
	//	TextureScale.Bilinear( newTexture, width, height );
	//	byte[ ] bytes = newTexture.EncodeToPNG();
	//	if( !System.IO.Directory.Exists( newFilePath ) )
	//	{
	//		System.IO.Directory.CreateDirectory( newFilePath );
	//	}
	//	System.IO.File.WriteAllBytes( fullPath, bytes );
	//	Object.DestroyImmediate( newTexture, true );

	//	return fullPath;
	//}

}
