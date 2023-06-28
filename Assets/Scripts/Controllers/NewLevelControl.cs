using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelControl : MonoBehaviour
{
    public static NewLevelControl instance;
    private void Awake()
    {
        instance = this;
    }


    public void DeathDemonBoss()
    {

    }

    IEnumerator _DeathDemonBoss()
    {
        yield return new WaitForSeconds(4);
        var effect = Instantiate(Resources.Load("Effects/DaemonBossRessurect")) as GameObject;

        var obj = Instantiate(Resources.Load("Enemies/demon_boss")) as GameObject;
       
        var character = obj.GetComponent<EnemyCharacter>();
        character.health = character.health / 100 * 25;
        character.animator.SetTrigger("respawn");
        obj.transform.position = new Vector3(0, 0, 0);
        effect.transform.position = new Vector3(0, 0, 0); 

        yield return new WaitForSeconds(4);
        Destroy(effect);
    }
}
