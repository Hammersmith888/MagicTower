using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WallSet
{
	public GameObject none, broken, full;
}

public class WallController : MonoBehaviour
{
	private GameObject none, broken, full;
	public List<WallSet> Walls = new List<WallSet>();

	public void SetupWalls( bool upped )
	{
		if( upped )
		{
			none = Walls[ 1 ].none;
			broken = Walls[ 1 ].broken;
			full = Walls[ 1 ].full;
			Walls[ 0 ].none.SetActive( false );
			Walls[ 1 ].none.SetActive( true );
		}
		else
		{
			none = Walls[ 0 ].none;
			broken = Walls[ 0 ].broken;
			full = Walls[ 0 ].full;
			Walls[ 1 ].none.SetActive( false );
			Walls[ 0 ].none.SetActive( true );
		}
	}

	public void PartiallyBroken( )
	{
		broken.SetActive( true );
	}

	public void FullBroken( )
	{
		none.SetActive( true );
		broken.SetActive( true );
		full.SetActive( true );
	}

	public void FullRestored( )
	{
		none.SetActive( true );
		broken.SetActive( false );
		full.SetActive( false );
	}

    public void SetupWallSprites(Sprite normal, Sprite upgraded)
    {
        Walls[0].none.GetComponent<SpriteRenderer>().sprite = normal;
        Walls[1].none.GetComponent<SpriteRenderer>().sprite = upgraded;
    }
}
