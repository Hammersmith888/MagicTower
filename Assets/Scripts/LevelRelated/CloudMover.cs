using UnityEngine;

public class CloudMover : MonoBehaviour {

    public float speed;
    private float sizeX;

	private Transform transf;
	private Vector3 position;

    void Start()
    {
        sizeX = GetComponent<Renderer>().bounds.size.x;
		transf = transform;

	}

    void Update()
    {
		position = transf.position;
		position.x = Mathf.Repeat( Time.time * speed, sizeX );
        transform.position = position;
    }
}
