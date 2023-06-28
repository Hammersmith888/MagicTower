using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelWaves
{
	public string fileName;
	public List<EnemyWave> waves;
}

public class LevelWavesPrefab : MonoBehaviour
{
	public List<LevelWaves> waves;

	void Start(){
	}

}
