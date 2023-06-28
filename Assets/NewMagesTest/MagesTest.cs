using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagesTest : MonoBehaviour {

	[System.Serializable]
	private class MagesTextures
	{
		public string name;
		public Texture texture;
	}

	[System.Serializable]
	private class Staves
	{
		public string name;
		public GameObject _obj;
	}
	[SerializeField]
	private SkinnedMeshRenderer mesh;
	[SerializeField]
	private UnityEngine.UI.Text mageText, staffText, mageTextNext, staffTextNext ;
	// Use this for initialization
	private int mageCount, staffCount;

	[SerializeField]
	[ResourceFile(resourcesFolderPath ="Mage/Textures")]
	private string defaultMageTexture;
	[SerializeField]
	[ResourceFile(resourcesFolderPath ="Mage/Staves")]
	private string defaultStaff;
	//[HideInInspector]
	public GameObject currentStaff;
	private Texture currentMageTexture;

	const string LOCATIONS_CONFIG_FILE = "MagesSkinsLoaderConfig";
	private MagesSkinsLoaderConfig mageSkinConfig;
	private void Awake( )
	{
		mageSkinConfig = Resources.Load<MagesSkinsLoaderConfig>( LOCATIONS_CONFIG_FILE );
	}

	IEnumerator Start()
	{
		//		mageCount = magesTextures.Count - 1;
		//		staffCount = staves.Count - 1;
		//		mageText.text = magesTextures [magesTextures.Count - 1].name;
		//		staffText.text = staves [staves.Count - 1].name;
		//		mageTextNext.text = "---> " + magesTextures [0].name;
		//		staffTextNext.text = "---> " + staves [0].name;
		//Debug.Log($"Posoh_002_02: {BuffsLoader.Instance.GetActiveWearId(WearType.staff)}");
		yield return new WaitForEndOfFrame();
		SetStaffById(BuffsLoader.Instance.GetActiveWearId(WearType.staff));
		SetMageById(BuffsLoader.Instance.GetActiveWearId(WearType.cape));
	}

	public void SetMageById(int id)
	{
		if( mageSkinConfig == null )
            currentMageTexture = Resources.Load(defaultMageTexture) as Texture;
        else
		{
			Texture newTexture = Resources.Load(mageSkinConfig.GetMage(id)) as Texture;
			if( newTexture == null )
                currentMageTexture = Resources.Load(defaultMageTexture) as Texture;
            else
                currentMageTexture = newTexture;
        }

        //Debug.Log("currentMageTexture: " + currentMageTexture + ", id wear: " + id + ", path: " + mageSkinConfig.GetMage(id));

		if (currentMageTexture != null)
			mesh.material.mainTexture = currentMageTexture;
	}
	public Transform staffParent;
	public void SetStaffById(int id)
	{
		if (currentStaff != null)
			Destroy (currentStaff);
		if( mageSkinConfig == null )
		{
			GameObject newStaff = Resources.Load (defaultStaff) as GameObject;
			currentStaff = Instantiate( newStaff );
			currentStaff.transform.localScale = newStaff.transform.localScale;
			newStaff = null;
		}
		else
		{
			GameObject newStaff = Resources.Load( mageSkinConfig.GetStaff( id ) ) as GameObject;
			if( newStaff == null )
			{
				currentStaff = Instantiate( Resources.Load( defaultStaff ) as GameObject, staffParent);
			}
			else
			{
				currentStaff = Instantiate( newStaff , staffParent);
			}
			//currentStaff.transform.localScale = newStaff.transform.localScale;
			newStaff = null;
		}
		if (staffParent != null) {
			//currentStaff.transform.SetParent (staffParent);
		}
	}

	public void ChangeMage()
	{
//		mageCount++;
//		if (mageCount >= magesTextures.Count)
//			mageCount = 0;
//		mageText.text = magesTextures [mageCount].name;
//		mesh.material.mainTexture = magesTextures [mageCount].texture;
//		int next = mageCount + 1;
//		if (next >= magesTextures.Count)
//			next = 0;
//		mageTextNext.text = "---> " + magesTextures [next].name;
	}

	public void ChangeStaff()
	{
//		staves [staffCount]._obj.SetActive (false);
//		staffCount++;
//		if (staffCount >= staves.Count)
//			staffCount = 0;
//		staffText.text = staves [staffCount].name;
//		staves[staffCount]._obj.SetActive (true);
//		int next = staffCount + 1;
//		if (next >= staves.Count)
//			next = 0;
//		staffTextNext.text = "---> " + staves [next].name;
	}
}
