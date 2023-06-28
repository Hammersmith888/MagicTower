using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ReplicasConditionsCheckerMap : ReplicasConditionsChecker
    {
        private int AFTER_LEVEL_20 = 19;
        private int AFTER_LEVEL_49 = 48;
        public GameObject bossLabel;
        private bool showReplica = false;
        public bool ShowReplica
        {
            get
            {
                return showReplica;
            }
        }

        private static ReplicasConditionsCheckerMap _current;
        public static ReplicasConditionsCheckerMap Current
        {
            get
            {
                if (_current == null)
                {
                    _current = FindObjectOfType<ReplicasConditionsCheckerMap>();
                }
                return _current;
            }
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            if (bossLabel != null)
            {
                Transform root = bossLabel.transform.root;
                while (!root.gameObject.activeSelf)
                {
                    yield return null;
                }

                if (!EReplicaID.Level20_Boss_Map.WasShown() || !EReplicaID.Level49_Boss_Map.WasShown())
                {
                    if (SaveManager.GameProgress.Current.CompletedLevelsNumber > AFTER_LEVEL_20 && !EReplicaID.Level20_Boss_Map.WasShown())
                    {
                        showReplica = true;
                        ReplicaUI.OnReplicaComplete -= ReplicaEnd;
                        ReplicaUI.OnReplicaComplete += ReplicaEnd;
                        EReplicaID.Level20_Boss_Map.SetAsShown();
                        ReplicaUI.ShowReplica(EReplicaID.Level20_Boss_Map, bossLabel.transform);
                    }
                    else if (SaveManager.GameProgress.Current.CompletedLevelsNumber > AFTER_LEVEL_49 && !EReplicaID.Level49_Boss_Map.WasShown())
                    {
                        showReplica = true;
                        ReplicaUI.OnReplicaComplete -= ReplicaEnd;
                        ReplicaUI.OnReplicaComplete += ReplicaEnd;
                        EReplicaID.Level49_Boss_Map.SetAsShown();
                        ReplicaUI.ShowReplica(EReplicaID.Level49_Boss_Map, bossLabel.transform);
                    }
                }
            }
        }

        private void ReplicaEnd(EReplicaID id)
        {
            showReplica = false;
        }
    }
}