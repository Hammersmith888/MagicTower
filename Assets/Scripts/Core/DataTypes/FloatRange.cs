using UnityEngine;

[System.Serializable]
public class FloatRange
{
	public float min;
	public float max;

	public FloatRange( )
	{
	}

	public FloatRange(float _min, float _max)
	{
		min = _min;
		max = _max;
	}

	public float Lerp(float t)
	{
		return Mathf.Lerp( min, max, t );
	}

	public float LerpUnclamped(float t)
	{
		return Mathf.LerpUnclamped( min, max, t );
	}

	public float GetInverseLerpValue(float value)
	{
		return Mathf.InverseLerp( min, max, value );
	}

	public float random
	{
		get
		{
			return UnityEngine.Random.Range( min, max );
		}
	}
}

