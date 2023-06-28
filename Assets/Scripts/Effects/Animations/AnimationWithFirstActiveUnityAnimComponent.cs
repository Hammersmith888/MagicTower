
using UnityEngine;

public class AnimationWithFirstActiveUnityAnimComponent : AnimationBase
{
	[SerializeField]
	private Animation[] animComponents;

	public override void PlayAnimation( )
	{
		for( int i = 0; i < animComponents.Length; i++ )
		{
			if( animComponents[ i ].gameObject.activeSelf )
			{
				if( animComponents[ i ].isPlaying )
				{
					animComponents[ i ].Stop();
				}
				animComponents[ i ].Play();
				break;
			}
		}
	}
}
