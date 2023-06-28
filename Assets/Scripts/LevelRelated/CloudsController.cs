
using UnityEngine;

public class CloudsController : MonoBehaviour, IUpdatable
{
    [System.Serializable]
    private class CloudScrollData
    {
        public float scrollSpeed;
        public FloatRange cloudsYSpawnRange;
        public Sprite[] cloudSprites;

        public Sprite GetRandomCloudSprite
        {
            get
            {
                return cloudSprites[Random.Range(0, cloudSprites.Length)];
            }
        }
    }

    private const float RandomSpawnOffsetRange = 2f;

    [SerializeField]
    public float cloudFadeOutXBorder;
    [SerializeField]
    public float cloudSpawnXBorder;

    [SerializeField]
    private CloudScrollData[] cloudsScrollData;
    [SerializeField]
    private GameObject cloudsObjectTemplate;
    private ObjectsPoolMono<CloudObject> cloudsPool;

    public bool canBeRemovedFromUpdate
    {
        get
        {
            return false;
        }
    }

    private void Awake()
    {
        cloudsPool = new ObjectsPoolMono<CloudObject>(cloudsObjectTemplate, transform, 4);
        CloudObject.OnCloudDisabled += OnCloudDisabled;
        cloudsObjectTemplate.gameObject.SetActive(false);
        for (int i = 0; i < cloudsScrollData.Length; i++)
        {
            SpawnCloudOnLayer(i, GetRandomXInsideField());
            SpawnCloudOnLayer(i);
        }

        UpdatableHolder.Current.AddToUpdate(this);
    }

    private float GetRandomXInsideField()
    {
        var halfFieldSize = (cloudSpawnXBorder - cloudFadeOutXBorder) / 2f;
        var fieldCenter = cloudSpawnXBorder - halfFieldSize;
        var offsetValue = halfFieldSize / 2f;
        return fieldCenter + Random.Range(-offsetValue, offsetValue);
    }

    private void OnDestroy()
    {
        CloudObject.OnCloudDisabled -= OnCloudDisabled;
    }

    private void OnCloudDisabled(int layer)
    {
        SpawnCloudOnLayer(layer);
    }

    private void SpawnCloudOnLayer(int layer, float xSpawnPos)
    {
        var cloud = cloudsPool.GetObjectFromPool();
        var layerCloudsScrollData = cloudsScrollData[layer];
        var spawnPosition = new Vector3(xSpawnPos, layerCloudsScrollData.cloudsYSpawnRange.random, 0f);
        cloud.Spawn(layerCloudsScrollData.GetRandomCloudSprite, spawnPosition, layerCloudsScrollData.scrollSpeed, cloudFadeOutXBorder, layer);
    }

    private void SpawnCloudOnLayer(int layer)
    {
        SpawnCloudOnLayer(layer, cloudSpawnXBorder + Random.Range(0f, RandomSpawnOffsetRange));
    }

    public void UpdateObject()
    {
        cloudsPool.ExecuteOnAll(UpdateCloud);
    }

    private void UpdateCloud(CloudObject cloud)
    {
        if (cloud.gameObject.activeSelf)
        {
            cloud.UpdateCloud(Time.deltaTime);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(cloudFadeOutXBorder, 10f, 0f), new Vector3(cloudFadeOutXBorder, -10f, 0f));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(cloudSpawnXBorder, 10f, 0f), new Vector3(cloudSpawnXBorder, -10f, 0f));

        for (int i = 0; i < cloudsScrollData.Length; i++)
        {
            var gizmosColor = Color.yellow * (i + 1) / (float)cloudsScrollData.Length;
            gizmosColor.a = 1f;
            Gizmos.color = gizmosColor;
            var currentCloudsScrollData = cloudsScrollData[i];
            Gizmos.DrawLine(new Vector3(cloudFadeOutXBorder, currentCloudsScrollData.cloudsYSpawnRange.max, 0), new Vector3(cloudSpawnXBorder, currentCloudsScrollData.cloudsYSpawnRange.max, 0));
            Gizmos.DrawLine(new Vector3(cloudFadeOutXBorder, currentCloudsScrollData.cloudsYSpawnRange.min, 0), new Vector3(cloudSpawnXBorder, currentCloudsScrollData.cloudsYSpawnRange.min, 0));
        }
    }
#endif
}
