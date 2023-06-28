using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScrollUI : MonoBehaviour
{
    [SerializeField]
    private GameObject hPrefab, mPrefab;
    Transform health, mana;
    public float speed = 1;
    public float radiusStop = 1;
    public static EffectScrollUI instance;
    ParticleSystem[] p1, p2;
    public Transform manaTarget;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (health != null)
        {
            health.position = Vector3.Lerp(health.position, PlayerController.Instance.healthBarRect.transform.position, speed * Time.unscaledDeltaTime );
            foreach (var o in p1)
                o.Simulate(Time.unscaledDeltaTime, true, false);
            if (Vector3.Distance(health.position, PlayerController.Instance.healthBarRect.transform.position) < radiusStop)
            {
                PlayerController.Instance.EffectHealth(true);
                Destroy(health.gameObject);
            }
        }

        if (mana != null)
        {
            mana.position = Vector3.Lerp(mana.position, manaTarget.position, speed * Time.unscaledDeltaTime);
            foreach (var o in p2)
                o.Simulate(Time.unscaledDeltaTime, true, false);
            if (Vector3.Distance(mana.position, manaTarget.position) < radiusStop)
            {
                LevelSettings.Current.shotController.SetManaHasteView(true);
                Destroy(mana.gameObject);
            }
        }
    }

    public void Play(Transform from)
    {
        Vector3 newPosition = new Vector3(from.position.x, from.position.y, 0f);
        newPosition = Helpers.getMainCamera.WorldToScreenPoint(newPosition);
        Vector3 pos = UIControl.Current.GetScreenPosition(newPosition);
        health = Instantiate(hPrefab, pos, Quaternion.identity, transform.parent).transform;
        health.gameObject.SetActive(true);
        p1 = health.GetComponentsInChildren<ParticleSystem>();
        mana = Instantiate(mPrefab, pos, Quaternion.identity, transform.parent).transform;
        mana.gameObject.SetActive(true);
        p2 = mana.GetComponentsInChildren<ParticleSystem>();
    }
}
