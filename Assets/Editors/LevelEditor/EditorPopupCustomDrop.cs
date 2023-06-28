using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyCustomsDropsPack
{
	public BirdLevelParams customBirdParams = new BirdLevelParams ();
	public List<GemDrop> gem_drops = new List<GemDrop> ();
	public List<CasketDrop> casket_drops = new List<CasketDrop> ();
}

public class EditorPopupCustomDrop : MonoBehaviour {
	public static EditorPopupCustomDrop Instance;
	[SerializeField]
	private List<GameObject> panels = new List<GameObject> ();

	[SerializeField]
	private List<Button> toggles = new List<Button>();

	[HideInInspector]
	public EnemyCharacter targetChar;

	[SerializeField]
	private Transform birdSpawnPointsGroup;
	[SerializeField]
	private EditorBirdParams customBird;
	[SerializeField]
	private CasketContentScript customDrop;
	[SerializeField]
	private EditorGems customGems;
	// Use this for initialization
	void Awake () {
		Instance = this;
		gameObject.SetActive (false);
	}

	public void CallToChar(EnemyCharacter eChar, Vector3 pos)
	{
		CloseIt ();
		gameObject.SetActive (true);
		targetChar = eChar;
		transform.position = pos;
		if (targetChar.enemyCustomsDropsPack == null) {
			targetChar.enemyCustomsDropsPack = new EnemyCustomsDropsPack ();
		}

		customBird.SetParams (targetChar.enemyCustomsDropsPack.customBirdParams);
		customDrop.LoadCustomCasketContent(targetChar.enemyCustomsDropsPack.casket_drops);
		customDrop.ResetPickParams ();
		customGems.LoadCustomGemDrops (targetChar.enemyCustomsDropsPack.gem_drops);
		customGems.ResetPickParams ();
	}

	public void SwitchToPanel(int id)
	{
		for (int i = 0; i < panels.Count; i++) 
		{
			panels [i].SetActive (i == id);
			toggles [i].interactable = i != id;
			toggles [i].transform.GetChild(0).gameObject.SetActive ( i == id);
		}
	}

	public void CloseIt()
	{
		targetChar = null;
		gameObject.SetActive (false);
	}

	public void SaveBird()
	{
		targetChar.enemyCustomsDropsPack.customBirdParams = customBird.CurrentBirdParams ();
		bool somePointUsed = false;
		for (int i = 0; i < targetChar.enemyCustomsDropsPack.customBirdParams.useSpawnPoint.Length; i++) 
		{
			if (targetChar.enemyCustomsDropsPack.customBirdParams.useSpawnPoint [i]) 
			{
				somePointUsed = true;
				break;
			}
		}
		if (!somePointUsed) 
		{
			for (int i = 0; i < 5; i++) 
			{
				targetChar.enemyCustomsDropsPack.customBirdParams.useSpawnPoint [i] = true;
			}
		}
	}

	public void SaveDrops()
	{
		targetChar.enemyCustomsDropsPack.casket_drops.Clear ();
		if (customDrop.casket_drops != null) 
		{
			for (int i = 0; i < customDrop.casket_drops.Count; i++) 
			{
				targetChar.enemyCustomsDropsPack.casket_drops.Add (customDrop.casket_drops [i]);
			}
		}
	}

	public void SaveGems()
	{
		targetChar.enemyCustomsDropsPack.gem_drops.Clear ();
		if (customGems.gem_drops != null) 
		{
			for (int i = 0; i < customGems.gem_drops.Count; i++) 
			{
				targetChar.enemyCustomsDropsPack.gem_drops.Add (customGems.gem_drops [i]);
			}
		}
	}
}
