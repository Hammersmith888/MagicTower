
using UnityEngine;

public class WindowsAnimationController : MonoBehaviour
{

	void OnEnable()
	{
		//Debug.Log ("animate windows");
		if (gameObject.GetComponent<RectTransform> () != null)
        {
			transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			LeanTween.scale (gameObject.GetComponent<RectTransform> (), Vector3.one, 0.7f).setEaseSpring ().setIgnoreTimeScale (true);
		}
	}
}
