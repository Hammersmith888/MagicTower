using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInvertedPosition : MonoBehaviour {

	[SerializeField]
	private RectTransform targetTransf;
	[SerializeField]
	private RectTransform  currentTransf;
	[SerializeField]
	private float defaultOffset;
	private Vector3 currentPosition;
	[SerializeField] Camera camera;
	[SerializeField] GameObject[] clouds;
	[SerializeField][Range(0,3)] float viewPosition1Range = 1;
	[SerializeField][Range(0,-3)] float viewPosition0Range = 0;

	void Awake( )
	{
		currentPosition = currentTransf.anchoredPosition;
		InvokeRepeating(nameof(HideShowClouds), 0, 0.2f);
	}

	void LateUpdate ()
	{
		currentPosition.x = defaultOffset - targetTransf.anchoredPosition.x;
		currentTransf.anchoredPosition = currentPosition;
	}

	void HideShowClouds()
	{
		foreach (var cloud in clouds)
		{
			var viewPos = camera.WorldToViewportPoint(cloud.transform.position);

			if (viewPos.x >= viewPosition0Range && viewPos.x <= viewPosition1Range && viewPos.y >= viewPosition0Range &&
			    viewPos.y <= viewPosition1Range && viewPos.z > viewPosition0Range)
			{
				cloud.SetActive(true);
			}
			else
			{
				cloud.SetActive(false);
			}
		}
	}
}