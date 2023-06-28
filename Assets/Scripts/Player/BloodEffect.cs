using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    public static BloodEffect instance;

    void Awake()
    {
        instance = this;
    }
    [SerializeField]
    CanvasGroup[] objs;
    [SerializeField]
    Animation[] _anims;

    float lastEffect, last = 0;

    float timerBtns = 0;

    float health;
  
    IEnumerator Start()
    {
        foreach (var o in objs)
        {
            o.alpha = 0;
            o.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        health = PlayerController.Instance.CurrentHealth;
    }

    void Update()
    {
        lastEffect -= Time.deltaTime;
        if(lastEffect <= 0)
        {
            objs[2].gameObject.SetActive(!(objs[0].alpha < 0.5f));
        }
        if (PlayerController.Instance.CurrentHealth < (health / 2))
        {
            timerBtns -= Time.deltaTime;
            if (timerBtns < 0)
            {
                StartCoroutine(_Play());
                timerBtns = 6;
            }
        }
    }

    IEnumerator _Play()
    {
        if(_anims[0].gameObject.GetComponent<Button>().interactable)
            _anims[0].Play();
        yield return new WaitForSeconds(0.5f);
        if (objs[2].gameObject.activeSelf && _anims[1].gameObject.GetComponent<Button>().interactable)
            _anims[1].Play();
    }
   
    public void Set(float value)
    {
        objs[2].gameObject.SetActive(value < 0.5f);
        
        if (last != value)
        {
            last = value;
            lastEffect = 7;
        }
    }
}
