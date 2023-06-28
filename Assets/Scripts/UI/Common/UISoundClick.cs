using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundClick : MonoBehaviour {

	public AudioClip clickSFX;
	private AudioSource _source;
	// Use this for initialization
	void Start () {
		_source = gameObject.AddComponent <AudioSource>();
		//_source.clip = clickSFX;
	}
	
	public void playSound()
	{
		if (_source != null)
			_source.PlayOneShot (clickSFX);
	}
}
