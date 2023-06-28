using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnPlayerHelpers : MonoBehaviour {
    public static LevelSpawnPlayerHelpers Current;

    private void Awake()
    {
        Current = this;
    }

    public void SpawnPlayerHelpers(LevelPlayerHelpers levelPlayerHelpers)
    {
        if (levelPlayerHelpers.barriersPositions != null && levelPlayerHelpers.barriersPositions.Count > 0)
        {
            for (int i = 0; i < levelPlayerHelpers.barriersPositions.Count; i++)
            {
                Vector3 barrierPosition = new Vector3(levelPlayerHelpers.barriersPositions[i].spawnPointX, levelPlayerHelpers.barriersPositions[i].spawnPointY, levelPlayerHelpers.barriersPositions[i].spawnPointZ);

                ScrollController.Instance.SpawnBarrier(barrierPosition);
            }
        }

        if (levelPlayerHelpers.minesNumber > 0)
        {
            ScrollController.Instance.SpawnMines(levelPlayerHelpers.minesNumber);
        }

    }


}
