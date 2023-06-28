using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootParticlesUnscalePlay : MonoBehaviour {

    [SerializeField]
	private ParticleSystem[] items;
	public bool stopIt;
    bool play;

    [ContextMenu("Initialize")]
    private void Initialize()
    {
        items = GetComponentsInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale < 0.1f && !stopIt)
		{
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    continue;
                }
              
                items[i].Simulate(Time.unscaledDeltaTime, true, false);
            }
		}
        else if(!play)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if(items[i] != null)
                    items[i].Play();
            }
            play = true;
        }
	}

    public void Stop()
    {
        for (int i = 0; i < items.Length; i++)
            items[i].Stop();
    }
}