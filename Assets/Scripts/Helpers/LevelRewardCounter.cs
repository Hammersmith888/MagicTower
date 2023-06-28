using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelRewardCounter : MonoBehaviour {
	[System.Serializable]
	private class LevelRewards
	{
		public string name;
		public int minimal;
		public int To;
	}
	[SerializeField]
	private LevelWavesPrefab levels;
	[SerializeField]
	private List<LevelRewards> _table = new List<LevelRewards> ();


	void Start () {
		#if UNITY_EDITOR

		DontDestroyOnLoad (gameObject);
		_table.Clear();
		Dictionary<EnemyType, GameObject> enemyPrefabs = new Dictionary<EnemyType, GameObject>();
		for( int i = 0; i < levels.waves.Count; i++ )
		{
			LevelRewards thisLevelReward = new LevelRewards ();
			List<EnemyWave> enemyWaves = new List<EnemyWave> ();
			thisLevelReward.name = levels.waves [i].fileName;
			int levelId =  - 1;
			int.TryParse (thisLevelReward.name, out levelId);
			enemyWaves = levels.waves[ i ].waves;
			for (int j = 0; j < enemyWaves.Count; j++)
			{
				if (enemyWaves [j].enemies != null && enemyWaves[ j ].enemies.Count > 0 )
				{
					int count = enemyWaves[ j ].enemies.Count;
					for (int e = 0; e < count; e++)
					{
						Enemy enemy = enemyWaves [j].enemies [e];
						string path = "Enemies/";
						if( !enemyPrefabs.ContainsKey( enemy.enemyNumber ) && enemy.enemyNumber != EnemyType.casket )
						{
							enemyPrefabs.Add( enemy.enemyNumber, Resources.Load<GameObject>( path + Enum.GetName( typeof( EnemyType ), enemy.enemyNumber ) ) );
						}
						if (enemy.enemyNumber != EnemyType.casket) {
							thisLevelReward.minimal += enemyPrefabs [enemy.enemyNumber].GetComponent<EnemyCharacter> ().gold + 
								(int)((float)(enemyPrefabs [enemy.enemyNumber].GetComponent<EnemyCharacter> ().coinChance)*10f/100f);
						}
					}
				}
			}
			thisLevelReward.minimal += (int)((float)(thisLevelReward.minimal)*2f/5f);
			if ( LevelSettings.Current != null)
			thisLevelReward.minimal += LevelSettings.Current.GetGoldFromLevel (levelId - 1) + 100;
			_table.Add (thisLevelReward);
		}
		#else

		Destroy(gameObject);

		#endif
	}
	
}
