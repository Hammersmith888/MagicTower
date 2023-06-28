using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineController : MonoBehaviour {

	public float speed = 1f;
	// Use this for initialization
	private RectTransform _transform;
	public bool _rnd = false;
	public bool custom = false;
	float speeds = 0;
	void Start ()
	{
		speeds  = _rnd ? (Random.Range(speed - 0.5f, speed + 0.5f)) : speed;
		if (custom)
			return;
		_transform = GetComponent <RectTransform>();
		LeanTween.rotateZ (gameObject, 180f, speeds).setRect(_transform).setIgnoreTimeScale(true).setLoopClamp();
	}

	void Update()
	{
		if (custom)
		{
			transform.Rotate(Vector3.down, Time.unscaledDeltaTime * speeds);
		}
	}
}
