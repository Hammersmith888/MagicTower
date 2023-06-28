
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicaCharacterCamera
{
    public const string CharacterRenderLayer = "CharacterOverUI";

    private Camera camera;
    public static ReplicaCharacterCamera current;
    private static int activationsNumber;

    private static void EnsureInstance()//disabling for now highlited characters
    {
        if (current == null)
        {
            current = new ReplicaCharacterCamera(); 
        }
    }

    public ReplicaCharacterCamera()
    {
        var mainCamera = Helpers.getMainCamera;
        if (mainCamera != null)
        {
            var cameraObject = new GameObject("ReplicasCharacterCamera");
            cameraObject.SetActive(false);
            cameraObject.transform.position = mainCamera.transform.position;
            cameraObject.transform.rotation = mainCamera.transform.rotation;
            camera = cameraObject.AddComponent<Camera>();
            camera.CopyFrom(mainCamera);
            camera.clearFlags = CameraClearFlags.Depth;
            camera.depth = 1;
            camera.cullingMask = 1 << LayerMask.NameToLayer(CharacterRenderLayer);
            camera.gameObject.AddComponent<OnDestroyResender>().OnDestroyEvent += OnCameraDestroyed;
        }
    }

    private void OnCameraDestroyed()
    {
        activationsNumber = 0;
        current = null;
    }

    public static void Activate()
    {
        EnsureInstance();
        current.camera.gameObject.SetActive(true);
        activationsNumber++;
    }

    public static void Disable()
    {
        if (current != null)
        {
            activationsNumber--;
            current.camera.gameObject.SetActive(activationsNumber > 0);
        }
    }
}

public class CharacterLayerChangerForReplica
{
    private Dictionary<int,int>[] defaultLayersData;
    private GameObject[] characterRendererObjects;

    public CharacterLayerChangerForReplica(GameObject[] _characterRendererObjects)
    {
        
        characterRendererObjects = _characterRendererObjects;
        defaultLayersData = new Dictionary<int, int>[_characterRendererObjects.Length];
        int layer = LayerMask.NameToLayer(ReplicaCharacterCamera.CharacterRenderLayer);
        Debug.Log($"_characterRendererObjects.Length: {_characterRendererObjects.Length}");
        for (int i = 0; i < _characterRendererObjects.Length; i++)
        {
            if (_characterRendererObjects[i] != null)
                _characterRendererObjects[i].SetLayerForAllInChildAndParen(layer, out defaultLayersData[i]);
            else
                Debug.Log($"_characterRendererObjects[i]: {_characterRendererObjects[i]}", _characterRendererObjects[i]);
        }
        ReplicaCharacterCamera.Activate();
    }

    public void SetDefaultLayers()
    {
        try
        {
            for (int i = 0; i < characterRendererObjects.Length; i++)
            {
                if(characterRendererObjects[i] == null) continue;
                
                characterRendererObjects[i].SetLayersForAllInChildAndParen(defaultLayersData[i]);
                
            }
            characterRendererObjects = null;
            defaultLayersData = null;
            ReplicaCharacterCamera.Disable();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            characterRendererObjects = null;
            defaultLayersData = null;
            ReplicaCharacterCamera.Disable();
        }
    }
}
