using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "ReplicasData", menuName = "Custom/ReplicasData")]
    public class ReplicasData : ScriptableObject
    {
        private const string RESOURCES_FILE_NAME = "ReplicasData";

        [SerializeField]
        private ReplicaData[] replicasData;

        public ReplicaData GetReplicaDataByIndex(int index)
        {
            if (index >= 0 && index < replicasData.Length)
            {
                return replicasData[index];
            }
            return null;
        }

        public ReplicaData GetReplicaDataByID(EReplicaID replicaID)
        {
            for (int i = 0; i < replicasData.Length; i++)
            {
                if (replicasData[i].replicaID == replicaID)
                {
                    return replicasData[i];
                }
            }
            return null;
        }


        public static void MarkAsShownReplicasForLevel(int level)
        {
            Debug.LogFormat("MarkAsShownReplicasForLevel {0}", level);
            var replicasDataFile = Resources.Load<ReplicasData>(RESOURCES_FILE_NAME);
            for (int i = 0; i < replicasDataFile.replicasData.Length; i++)
            {
                if (replicasDataFile.replicasData[i].level == level)
                {
                    replicasDataFile.replicasData[i].replicaID.SetAsShown();
                }
            }
        }

    }
}
