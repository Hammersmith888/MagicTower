using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FontLang
{
	main,
	tutorial,
	popup,
    system
}

public class FontsLocalizationConfig : MonoBehaviour
{
	[System.Serializable]
	public class LocFont
	{
		public FontLang _type;
		//public Font _thisFont;
		[ResourceFile(resourcesFolderPath="Fonts")]
		public string fontResourcesPath;
	}

	[System.Serializable]
	public class LocFonts
	{
		public string _langId;
		public LocFont[] _fonts;
	}

	public List<LocFonts> Fonts = new List<LocFonts>();

	private Font[] loadedFonts;

	public void ReloadFonts( string langId )
	{
		int count = Fonts.Count;
		for( int i = 0; i < count; i++ )
		{
			if( Fonts[ i ]._langId == langId )
			{
				loadedFonts = new Font[ Fonts[ i ]._fonts.Length ];
				for( int j = 0; j < Fonts[ i ]._fonts.Length; j++ )
				{
					loadedFonts[j] = Resources.Load<Font>( Fonts[ i ]._fonts[ j ].fontResourcesPath );
				}
				break;
			}
		}
		Resources.UnloadUnusedAssets();
	}

	public Font GetFont( FontLang fontLang )
	{
		int fontIndex = ( int ) fontLang;
		if( loadedFonts != null && fontIndex < loadedFonts.Length )
		{
			return loadedFonts[ fontIndex ];
		}
		return null;
	}

	public Font GetFontByLang( string langID, FontLang fontLang )
	{
		int count = Fonts.Count;
		for( int i = 0; i < count; i++ )
		{
			if( Fonts[ i ]._langId == langID )
			{
				for( int j = 0; j < Fonts[ i ]._fonts.Length; j++ )
				{
					if( Fonts[ i ]._fonts[ j ]._type == fontLang )
					{
						return Resources.Load<Font>( Fonts[ i ]._fonts[ j ].fontResourcesPath);
					}
				}
			}
		}
		return null;
	}
}
