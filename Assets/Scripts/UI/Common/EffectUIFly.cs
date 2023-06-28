using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectUIFly : MonoBehaviour
{
    [SerializeField]
    RectTransform[] rect;
    public Transform target;
    bool play = false;
    Animator _anim;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float distanceToDestroy = 1;
    public float timerToTarget;
    public int indexStart;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        _anim = GetComponent<Animator>();
        rect[indexStart].gameObject.SetActive(true);
        yield return new WaitForSeconds(timerToTarget);
        StartToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            foreach (var t in rect)
            {
                if (t != null)
                {
                    t.position = Vector3.Lerp(t.position, target.position, Time.unscaledDeltaTime * speed);
                    if (Vector3.Distance(t.position, target.position) < distanceToDestroy)
                    {
                        UIMap.Current.PlayEffectBoss();
                        Destroy(t.gameObject);
                    }
                }
            }
            if (rect[0] == null && rect[1] == null && rect[2] == null)
                Destroy(gameObject);
        }
    }

    public void StartToTarget()
    {
        _anim.enabled = false;
        play = true;
    }
}
