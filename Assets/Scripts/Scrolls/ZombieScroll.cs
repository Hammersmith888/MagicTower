using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScroll : MonoBehaviour
{
    public GameObject spawnCharacter;
    public int upgradeLevel;

    void Start()
    {
        PlayerPrefs.SetInt("SomeScrollUsed", 1);
        MyGSFU.current.ApplyFriendlyParameters(spawnCharacter.GetComponent<EnemyCharacter>(), spawnCharacter.GetComponent<EnemyMover>(), 84 + upgradeLevel);
        StartCoroutine(MainProcess());
    }

    private IEnumerator MainProcess()
    {
        SoundController.Instanse.playScrollZombieSFX();
        yield return new WaitForSeconds(1f);
        GameObject spawnUnit = Instantiate(spawnCharacter, transform.position + new Vector3(0, -1f, 0), spawnCharacter.transform.rotation);
        EnemyCharacter spawnedCharacter = spawnUnit.GetComponent<EnemyCharacter>();
        spawnedCharacter.friendly = true;
        EnemiesGenerator.Instance.OnFriendlyCharacterSpawned(spawnedCharacter);
        Destroy(transform.parent.gameObject, 1f);
        yield break;
    }
}
