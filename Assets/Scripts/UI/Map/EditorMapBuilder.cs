using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorMapBuilder : MonoBehaviour {

#if UNITY_EDITOR
	[SerializeField]
	private Transform levelParentTransf;
	[SerializeField]
	private RectTransform pathTransf;
	[SerializeField]
	private RectTransform	mapViewportRect;
	[SerializeField]
	private RectTransform   mapScrollViewportRect;

	[Space(20f)]
	[SerializeField]
	private float pathSectorSize = 1825f;
	//[SerializeField]
	//private float mapSetorSize = 2048;
	[SerializeField]
	private float pathSidesOffset = 225f;
	[SerializeField]
	private float levelsPerSector = 6;

	private UIMapLevelData[] uiLevelsData;


	[Space(20f)]
	//[SerializeField]
	//private int addLevels;
	//[SerializeField]
	//private bool calculate;
	[SerializeField]
	private bool addLevelsSector;

	[Space(20f)]
	[SerializeField]
	private int levelsNumber;
	[SerializeField]
	private bool drawLevelsPositionsGizmos;
	[SerializeField]
	private float gizmosSize = 1f;
	[Space(20f)]
	[SerializeField]
	private int levelToRescale;
	[SerializeField]
	private bool rescaleToLevel;

	private void OnDrawGizmosSelected( )
	{
		if( addLevelsSector )
		{
			addLevelsSector = false;

			uiLevelsData = levelParentTransf.GetComponentsInChildren<UIMapLevelData>();
			int currentLevelsNumber = uiLevelsData.Length;
			if( currentLevelsNumber >= levelsPerSector )
			{
				float currentWholeSectorsNumber = ( mapViewportRect.sizeDelta.x - ( pathSidesOffset * 2 ) ) / pathSectorSize;
				if( ( currentWholeSectorsNumber - (int)currentWholeSectorsNumber ) != 0 )
				{
					Debug.LogErrorFormat( "currentWholeSectorsNumber ({0}) not a whole number!", currentWholeSectorsNumber );
					return;
				}
				Debug.LogFormat( "Current number of sectors {0} levelsNumber: {1}", currentWholeSectorsNumber, currentLevelsNumber );

				mapViewportRect.sizeDelta = new Vector2( mapViewportRect.sizeDelta.x + pathSectorSize, mapViewportRect.sizeDelta.y );
				mapScrollViewportRect.sizeDelta = new Vector2( mapScrollViewportRect.sizeDelta.x + pathSectorSize, mapScrollViewportRect.sizeDelta.y );

				Vector3 levelOffset;
				for( int i = 0; i < levelsPerSector; i++ )
				{
					levelOffset = uiLevelsData[ i ].transform.localPosition;
					levelOffset.x += currentWholeSectorsNumber * pathSectorSize;
					GameObject newLevel = Instantiate( uiLevelsData[ i ].gameObject, levelParentTransf, false ).gameObject;
					newLevel.transform.localPosition = levelOffset;
					newLevel.transform.SetAsLastSibling();
					//newLevel.GetComponent<UIMapLevelData>().InitInEditor( currentLevelsNumber + i + 1 );
				}
				Debug.LogFormat( "New levelsNumber: {0}", currentLevelsNumber + levelsPerSector );
				UnityEditor.SceneView.RepaintAll();
				Canvas.ForceUpdateCanvases();
				FindObjectOfType<UIMap>().UpdateLevelUIDataInEditor();
			}

			//if( currentLevelsNumber >= levelsPerSector )
			//{
			//	int completeLevelsCycles = ( int ) ( currentLevelsNumber / levelsPerSector );
			//	int levelInNewCycle = currentLevelsNumber - ( int ) ( levelsPerSector * completeLevelsCycles );
			//	float size = ( levelsNumber / levelsPerSector ) * pathSectorSize;
			//	size += pathSidesOffset * 2f;

			//	Vector3[ ] levelsPerSectorOffsets = new Vector3[ ( int ) levelsPerSector ];
			//	for( int i = 0; i < levelsPerSectorOffsets.Length; i++ )
			//	{
			//		levelsPerSectorOffsets[ i ] = uiLevelsData[ i ].transform.localPosition;
			//	}


			//	Debug.Log( size );
			//}
		}

		if( rescaleToLevel )
		{
			rescaleToLevel = false;
			uiLevelsData = levelParentTransf.GetComponentsInChildren<UIMapLevelData>();
			if( uiLevelsData.Length >= levelToRescale )
			{
				UIMapLevelData lastLevel = uiLevelsData[ levelToRescale - 1 ];

				Vector3 startPosition = uiLevelsData[ 0 ].transform.position;

				float viewPortX = ( lastLevel.transform.position.x - startPosition.x ) + pathSidesOffset * 2f;

				mapViewportRect.sizeDelta = new Vector2( viewPortX, mapViewportRect.sizeDelta.y );
				mapScrollViewportRect.sizeDelta = new Vector2( viewPortX, mapScrollViewportRect.sizeDelta.y );

				for( int i = 0; i < uiLevelsData.Length; i++ )
				{
					uiLevelsData[ i ].gameObject.SetActive( i < levelToRescale );
				}

				//Vector3 levelOffset;
				//for( int i = 0; i < levelsPerSector; i++ )
				//{
				//	levelOffset = uiLevelsData[ i ].transform.localPosition;
				//	levelOffset.x += currentWholeSectorsNumber * pathSectorSize;
				//	GameObject newLevel = Instantiate( uiLevelsData[ i ].gameObject, levelParentTransf, false ).gameObject;
				//	newLevel.transform.localPosition = levelOffset;
				//	newLevel.transform.SetAsLastSibling();
				//	newLevel.GetComponent<UIMapLevelData>().InitInEditor( currentLevelsNumber + i + 1 );
				//}
				//Debug.LogFormat( "New levelsNumber: {0}", currentLevelsNumber + levelsPerSector );
				//UnityEditor.SceneView.RepaintAll();
				//Canvas.ForceUpdateCanvases();
			}
		}
	}

	private void OnDrawGizmos( )
	{
		if( drawLevelsPositionsGizmos )
		{
			uiLevelsData = levelParentTransf.GetComponentsInChildren<UIMapLevelData>();
			if( uiLevelsData.Length >= levelsPerSector )
			{
				Vector3[ ] levelsPerSectorOffsets = new Vector3[ ( int ) levelsPerSector ];
				Vector3 scale = uiLevelsData[ 0 ].transform.lossyScale;

				for( int i = 0; i < levelsPerSectorOffsets.Length; i++ )
				{
					levelsPerSectorOffsets[ i ] = uiLevelsData[ i ].transform.localPosition;
					levelsPerSectorOffsets[ i ].x *= scale.x;
					levelsPerSectorOffsets[ i ].y *= scale.y;
					levelsPerSectorOffsets[ i ].z *= scale.z;
				}

				Vector3 startPosition = uiLevelsData[ 0 ].transform.position;
				startPosition -= levelsPerSectorOffsets[ 0 ];

				Gizmos.color = Color.green;
				for( int i = 0; i < levelsNumber; i++ )
				{
					int completeLevelsCycles = ( int ) ( i / levelsPerSector );
					int levelInNewCycle = i - ( int ) ( levelsPerSector * completeLevelsCycles );
					float xOffset = completeLevelsCycles * pathSectorSize;
					Vector3 position = startPosition + levelsPerSectorOffsets[ levelInNewCycle ];
					position.x += xOffset;
					Gizmos.DrawSphere( position, gizmosSize );
				}
			}
		}
	}
#endif

}
