using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CasketDrop
{
	public int content_id;
	public int chance_id;
}

public class CasketContentScript : MonoBehaviour
{
	public GameObject casket_chance;
	public GameObject casket_drop;
	public List<Transform> contents;
	[SerializeField]
	private Text chanceText;
	[SerializeField]
	private Dropdown contentDD;

	public List<CasketDrop> casket_drops;
	public LevelEditorController levelEditorScript;
	[SerializeField]
	private EditorPopupCustomDrop editorPopupCustomDrop;

	private void Start( )
	{
		casket_drops = new List<CasketDrop>();
		if (chanceText == null) 
		{
			chanceText = casket_chance.transform.GetChild (1).GetChild (0).GetComponent<Text> ();
		}
		if (contentDD == null) 
		{
			contentDD = casket_drop.transform.GetChild (1).GetComponent<Dropdown> ();
		}

	}

	public void LoadWaveCasketContent( EnemyWave wave )
	{
		ClearDropList();
		if( wave.casket_drops != null )
		{
			for( int i = 0; i < wave.casket_drops.Count; i++ )
			{
				AddDropItemCustom( wave.casket_drops[ i ] );
			}
		}
	}

	public void LoadCustomCasketContent(List<CasketDrop> newDrop)
	{
		ClearDropList();
		if( newDrop != null )
		{
			for( int i = 0; i < newDrop.Count; i++ )
			{
				AddDropItemCustom( newDrop[ i ] );
			}
		}
	}

	private void ClearDropList( )
	{
		for( int i = 0; i < contents.Count; i++ )
		{
			contents[ i ].gameObject.SetActive( false );
		}
		casket_drops.Clear();
	}

	private void AddDropItemCustom( CasketDrop custom_item )
	{
		casket_drops.Add( custom_item );
		for( int i = 0; i < contents.Count; i++ )
		{
			if( !contents[ i ].gameObject.activeSelf )
			{
				contents[ i ].gameObject.SetActive( true );
				contents[ i ].GetComponent<PickedItemContent>().content = custom_item.content_id;
				contents[ i ].GetComponent<Text>().text = custom_item.chance_id.ToString() + "% - " + contentDD.options[ custom_item.content_id ].text;
				i = contents.Count;
			}
		}
	}

	public void AddDropItem( )
	{
		if (chanceText == null) 
		{
			chanceText = casket_chance.transform.GetChild (1).GetChild (0).GetComponent<Text> ();
		}
		if (contentDD == null) 
		{
			contentDD = casket_drop.transform.GetChild (1).GetComponent<Dropdown> ();
		}
		bool can_flag = true;
		int chance_param = int.Parse( chanceText.text );
		int content_param = contentDD.value;
		CasketDrop new_drop = new CasketDrop();
		new_drop.chance_id = chance_param;
		new_drop.content_id = content_param;
		casket_drops.Add( new_drop );
		for( int i = 0; i < casket_drops.Count - 1; i++ )
		{
			if( casket_drops[ i ].content_id == content_param )
			{
				can_flag = false;
			}
		}

		if( can_flag != false )
		{
			for( int i = 0; i < contents.Count; i++ )
			{
				if( !contents[ i ].gameObject.activeSelf )
				{
					contents[ i ].gameObject.SetActive( true );
					contents[ i ].GetComponent<PickedItemContent>().content = content_param;
					contents[ i ].GetComponent<Text>().text = chanceText.text + "% - " + contentDD.options[ contentDD.value ].text;
					i = contents.Count;
				}
			}

		}
		else
		{
			casket_drops.RemoveAt( casket_drops.Count - 1 );
		}
		if (editorPopupCustomDrop == null) 
		{
			levelEditorScript.SaveCurrentWave ("drops");
		} 
		else 
		{
			editorPopupCustomDrop.SaveDrops ();
		}
	}

	public void RemoveItem( GameObject obj_from )
	{
		int content_from = obj_from.GetComponent<PickedItemContent>().content;
		for( int i = 0; i < casket_drops.Count; i++ )
		{
			if( casket_drops[ i ].content_id == content_from )
			{
				casket_drops.RemoveAt( i );
				i = casket_drops.Count;
			}
		}
		obj_from.SetActive( false );
		if (editorPopupCustomDrop == null) 
		{
			levelEditorScript.SaveCurrentWave ("drops");
		} 
		else 
		{
			editorPopupCustomDrop.SaveDrops ();
		}
	}

	public void ResetPickParams()
	{
		chanceText.text = "0";
		contentDD.value = 0;
	}
}
