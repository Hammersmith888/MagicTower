using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationLoader : MonoBehaviour
{
    public static LocationLoader Current;

    [SerializeField]
    [ResourceFile(resourcesFolderPath ="Locations")]
    private string defaultLocation;

    private GameObject currentlocationObject;

    const string LOCATIONS_CONFIG_FILE = "LocationsByLevelConfig";

    private LocationsByLevelConfig locationsConfig;

    private void Awake()
    {
        Current = this;

        locationsConfig = Resources.Load<LocationsByLevelConfig>(LOCATIONS_CONFIG_FILE);

        SetLocationView();
    }

    private void SetupWall(GameObject location)
    {
        if (location != null)
        {
            WallController wallController = FindObjectOfType<WallController>();
            if (wallController != null)
            {
                WallConfig wallConfig = location.GetComponent<WallConfig>();
                if (wallConfig != null)
                {
                    wallController.SetupWallSprites(wallConfig.normalWallSprite, wallConfig.upgradedWallSprite);
                }
            }
        }
    }

#if UNITY_EDITOR
    [Header("Debug options")]
    [SerializeField]
    private bool reloadSceneInEditor;
    [SerializeField]
    [ResourceFile(resourcesFolderPath ="Locations")]
    private string selectedSceneFile;

    private void OnDrawGizmosSelected()
    {
        if (reloadSceneInEditor)
        {
            reloadSceneInEditor = false;
            GameObject newLocation = Resources.Load(selectedSceneFile) as GameObject;
            if (newLocation != null)
            {
                if (currentlocationObject != null)
                {
                    if (Application.isPlaying)
                    {
                        Destroy(currentlocationObject);
                    }
                    else
                    {
                        DestroyImmediate(currentlocationObject);
                    }
                }
                currentlocationObject = Instantiate(newLocation);
                SetupWall(currentlocationObject);
                newLocation = null;
            }
            else
            {
                Debug.LogErrorFormat("Can't load location. Location file is null Path: {0}", selectedSceneFile);
            }
        }
    }
#endif

    public void SetLocationView()
    {
        if (currentlocationObject != null)
        {
            Destroy(currentlocationObject);
        }

        if (locationsConfig == null)
        {
            currentlocationObject = Instantiate(Resources.Load(defaultLocation) as GameObject);
        }
        else
        {
            GameObject newLocation = Resources.Load(locationsConfig.GetLocationByLevel(mainscript.CurrentLvl)) as GameObject;
            if (newLocation == null)
            {
                currentlocationObject = Instantiate(Resources.Load(defaultLocation) as GameObject);
            }
            else
            {
                currentlocationObject = Instantiate(newLocation);

            }
            newLocation = null;
        }
        SetupWall(currentlocationObject);
    }
}
