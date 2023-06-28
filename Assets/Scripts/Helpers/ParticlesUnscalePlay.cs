using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesUnscalePlay : MonoBehaviour {

	private ParticleSystem current;
	public bool stopIt;
	// Use this for initialization
	void Start () {
		current = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale < 0.1f && !stopIt)
		{
			current.Simulate (Time.unscaledDeltaTime, true, false);
		}
	}
}
