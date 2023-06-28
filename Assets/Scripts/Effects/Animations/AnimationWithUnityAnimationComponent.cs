using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWithUnityAnimationComponent : AnimationBase {

	[SerializeField]
	private Animation animComponent;

	public override void PlayAnimation( )
	{
		if( animComponent.isPlaying )
		{
			animComponent.Stop();
		}
		animComponent.Play();
	}
}
