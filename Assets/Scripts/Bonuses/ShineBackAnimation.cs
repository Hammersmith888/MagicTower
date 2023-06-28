using UnityEngine;

public class ShineBackAnimation : MonoBehaviour
{
    [SerializeField]
    private int  degree = 35;

    [SerializeField]
    private bool isAnimate = true;
    
    void Update ()
	{
        if (isAnimate)
            transform.Rotate(new Vector3(0, 0, -degree*Time.deltaTime));
    }
}
