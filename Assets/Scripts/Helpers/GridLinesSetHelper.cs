using UnityEngine;
using System.Collections;

public class GridLinesSetHelper : MonoBehaviour
{
    public float num;

	void Start ()
    {
        Vector3 newPos = transform.localPosition;
	    newPos.x = -4.2f + num*(10f/13f);
        transform.localPosition = newPos;
    }
	
	
}
