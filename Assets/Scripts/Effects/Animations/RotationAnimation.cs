
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 axis;
    [SerializeField]
    private float speed;

	private void Awake ()
    {
        if (target == null)
        {
            target = transform;
        }
	}
	
	private void Update ()
    {
        target.localEulerAngles += axis * speed * Time.deltaTime;
    }
}
