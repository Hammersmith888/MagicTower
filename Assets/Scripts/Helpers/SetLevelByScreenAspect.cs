using UnityEngine;

public interface ICameraOrthoSizeHolder
{
	float getCameraOrthoSize
	{
		get;
	}

	void SetCameraOrthoSizeScale( float scale );
}

public class SetLevelByScreenAspect : MonoBehaviour, ICameraOrthoSizeHolder
{
	[SerializeField]
	private Camera _camera;
	[SerializeField]
	private float defaultCameraOrthoSize;
	[SerializeField]
	private FloatRange screenAspectRange;
	[Space(10f)]
	[SerializeField]
	private Transform topBackgroundTransf;
	[SerializeField]
	private FloatRange topBackScaleRange;
	//[SerializeField]
	//private GameObject bottomFog;

	private float currentDefaultCameraOrthoSize;

	public float getCameraOrthoSize
	{
		get {
			return currentDefaultCameraOrthoSize;
		}
	}

	private void Awake( )
	{
		gameObject.GetComponentIfNull( ref _camera );
		float cameraAspect = _camera.pixelWidth / (float)_camera.pixelHeight;

		float aspectFactor = screenAspectRange.max / cameraAspect;
		_camera.orthographicSize = currentDefaultCameraOrthoSize =  defaultCameraOrthoSize * aspectFactor;

		if( topBackgroundTransf != null )
		{
			Vector3 topBackScale = topBackgroundTransf.localScale;
			topBackScale.y = topBackScaleRange.Lerp( screenAspectRange.GetInverseLerpValue( cameraAspect ) );
			topBackgroundTransf.localScale = topBackScale;
		}

		//bottomFog.SetActive( cameraAspect < screenAspectRange.max );
	}

	public void SetCameraOrthoSizeScale( float scale )
	{
		_camera.orthographicSize = currentDefaultCameraOrthoSize * scale;
	}

#if UNITY_EDITOR
	[Header("Editor")]
	[SerializeField]
	private bool updateAspectInEditor;
	private void OnDrawGizmos( )
	{
		if( updateAspectInEditor )
		{
			Awake();
		}
	}
#endif

}
