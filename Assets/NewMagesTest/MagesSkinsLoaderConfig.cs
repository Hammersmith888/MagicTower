using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagesSkinsLoaderConfig", menuName = "Custom/MagesSkinsLoaderConfig")]
public class MagesSkinsLoaderConfig : ScriptableObject {
    [System.Serializable]
    private class MageTexture
    {
        [ResourceFile(resourcesFolderPath = "Mage/Textures")]
        public string textureName;
        public int mageNumber;
    }


    [SerializeField]
    [ResourceFile(resourcesFolderPath = "Mage/Textures")]
    private string defaultMageTexture;
    [SerializeField]
    private MageTexture[] mageTextures;

    [System.Serializable]
    private class StaffObj
    {
        [ResourceFile(resourcesFolderPath = "Mage/Staves")]
        public string staffName;
        public int staffNumber;
    }


    [SerializeField]
    [ResourceFile(resourcesFolderPath = "Mage/Staves")]
    private string defaultStaff;
    [SerializeField]
    private StaffObj[] staves;

    public string GetMage(int mageNumber)
    {
        if (mageTextures.IsNullOrEmpty() || mageNumber == -1)
        {
            return defaultMageTexture;
        }
        for (int i = 0; i < mageTextures.Length; i++)
        {
            if (mageTextures[i].mageNumber == mageNumber || i == mageTextures.Length - 1)
            {
                return mageTextures[i].textureName;
            }
            else if (mageTextures[i].mageNumber > mageNumber)
            {
                return i > 0 ? mageTextures[i - 1].textureName : mageTextures[i].textureName;
            }
        }
        return defaultMageTexture;
    }

    public string GetStaff(int staffNumber)
    {
        if (staves.IsNullOrEmpty() || staffNumber == -1 )
		{
			return defaultStaff;
		}
		for( int i = 0; i < staves.Length; i++ )
		{
			if( staves[ i ].staffNumber == staffNumber || i == staves.Length - 1 )
			{
				return staves[ i ].staffName;
			}
			else if( staves[ i ].staffNumber > staffNumber )
			{
				return i > 0 ? staves[ i - 1 ].staffName : staves[ i ].staffName;
			}
		}
		return defaultStaff;
	}
}
