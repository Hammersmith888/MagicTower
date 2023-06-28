using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTest : MonoBehaviour {

    public bool create = false;
    public Transform[] tra;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (create)
        {
            PopupText.Show("Some text!", tra[0], 3, 0.7f);
            create = false;
        }
	}
}
