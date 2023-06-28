using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownEffect : MonoBehaviour
{
    [SerializeField]
    GameObject mask, particles;
   
    public void Open()
    {
        gameObject.SetActive(true);
        StartCoroutine(_Open());
    }
    IEnumerator _Open()
    {
     
        yield return new WaitForSecondsRealtime(0.3f);
        mask.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSecondsRealtime(0.25f);
        particles.SetActive(true);
    }

}
