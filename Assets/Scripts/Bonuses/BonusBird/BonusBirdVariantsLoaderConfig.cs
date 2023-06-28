using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BonusBirdVariantsLoaderConfig", menuName = "Custom/BonusBirdVariantsLoaderConfig")]
public class BonusBirdVariantsLoaderConfig : ScriptableObject {
	[SerializeField]
	private BirdLevelParams[] birdVariants;

	public BirdLevelParams GetVariant(int id)
	{
		BirdLevelParams to_return = new BirdLevelParams ();
		if (id >= birdVariants.Length) {
			return to_return;
		}

		if (id == -1) {
			to_return = birdVariants [UnityEngine.Random.Range (0, birdVariants.Length)];
		} else {
			to_return = birdVariants [id];
		}

		return to_return;
	}

	public int compareVariant(BirdLevelParams variant)
	{
		for (int i = 0; i < birdVariants.Length; i++) {
			if (variant.useSpawnPoint != null && variant.useSpawnPoint.Length != 0) {
				for (int j = 0; j < 5; j++) {
					if (!variant.useSpawnPoint [j]) {
						return -1;
					}
				}
			}
			if (variant.birdsLimit == birdVariants [i].birdsLimit && variant.chanceSpawn == birdVariants [i].chanceSpawn && variant.flySpeed == birdVariants [i].flySpeed && 
				variant.hitsNeed == birdVariants [i].hitsNeed && variant.numberOfPoints == birdVariants [i].numberOfPoints && variant.respawnOnReplay == birdVariants [i].respawnOnReplay
				&& variant.soarEveryPoint == birdVariants [i].soarEveryPoint && variant.soarTime == birdVariants [i].soarTime && variant.spawnEachSeconds == birdVariants [i].spawnEachSeconds && 
				!variant.useRandomVariant && variant.maxFreeTime == birdVariants[i].maxFreeTime) {
				return i;
			}
		}
		return -1;
	}

	public int totalVariants
	{
		get {
			return birdVariants.Length;
		}
	}
}
