using UnityEngine;

[System.Serializable]
public class IntRange
{
	public int min;
	public int max;

	public IntRange( )
	{
	}

	public IntRange(int _min, int _max)
	{
		min = _min;
		max = _max;
	}

	public int random
	{
		get
		{
			return Random.Range( min, max + 1 );
		}
	}
}
