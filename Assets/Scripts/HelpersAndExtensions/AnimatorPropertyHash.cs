using UnityEngine;

[System.Serializable]
public class AnimatorPropertyHash
{
	[SerializeField]
	private string propertyName;

	private bool hashed;

	private int propertyHash;
	public int PropertyHash
	{
		get
		{
			if(!hashed)
			{
				Hash();
			}
			return propertyHash;
		}
	}

	public void Hash()
	{
		propertyHash = Animator.StringToHash(propertyName);
		hashed = true;
	}

	public bool IsNullOrEmpty
	{
		get
		{
			return string.IsNullOrEmpty(propertyName);
		}
	}
}
