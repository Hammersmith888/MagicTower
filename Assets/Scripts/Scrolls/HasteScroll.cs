using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasteScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject line, appear, hands, effect;
    [SerializeField]
    private float durationFlyLine = 0.5f;
    [SerializeField]
    private float durationAppear = 3f;
    private Vector3 target;
    public float addSpeed, workTime, healthRegen;
    public float speedEffect = 2;

    Transform e1,e2;
    Vector3 t1, t2;

    private GameObject appearObj, handsObj, lineObj;
    private void Start()
    {
        ScrollController.Instance.listHaste.Add(this);
        var tar = PlayerController.Instance.mageSkins.currentStaff.transform.Find("targetHand");
        target = (tar == null ? (PlayerController.Instance.mageSkins.staffParent.transform.GetChild(0).position + Vector3.back) : tar.position);

        PlayerController.Instance.SemiDarkBack.SetActive(true);

        if (ScrollController.Instance.listHaste.Count > 1)
        {
            for (int i = 1; i < ScrollController.Instance.listHaste.Count; i++)
            {
                Destroy(ScrollController.Instance.listHaste[i].gameObject);
            }
        }

        StartCoroutine(DrawLine());
    }

    private IEnumerator DrawLine()
    {
        yield return StartCoroutine(FlyLine());

        SoundController.Instanse.playScrollPowerSFX();
        appearObj = Instantiate(appear, target, Quaternion.identity);
        StartCoroutine(SlowMotion());
        Destroy(appearObj, durationAppear);
        handsObj = Instantiate(hands, target, Quaternion.identity);
        var tar = PlayerController.Instance.mageSkins.currentStaff.transform.Find("targetHand");
        handsObj.transform.SetParent(tar == null ? PlayerController.Instance.mageSkins.currentStaff.transform : tar);
        handsObj.transform.localPosition = Vector3.zero;
        float timer = workTime;
        int steps = 200;
        float faitForSeconds = timer / (float)steps;
        if (Mana.Current != null)
        {
            Mana.Current.valueHaste = ((float)addSpeed / 100f) + 1f;
            Mana.Current.valueHasteTime = workTime;
        }
       
        StartCoroutine(_Regen(steps, faitForSeconds));

        yield return new WaitForSeconds(timer);

        handsObj.GetComponent<RootParticlesUnscalePlay>().Stop();

        ScrollController.Instance.listHaste.Remove(this);

        Destroy(handsObj, timer / 2);
    }

    IEnumerator _Regen(int steps, float faitForSeconds)
    {
        EffectScrollUI.instance.Play(handsObj.transform);
        
     
        if (steps > 0)
        {
            WaitForSeconds wait = new WaitForSeconds(faitForSeconds);
            for (int i = 0; i < steps; i++)
            {
                LevelSettings.Current.hasteScrollCoef = 1f + addSpeed / 100f;
                PlayerController.Instance.baseHealthRegen = healthRegen;
                yield return wait;
            }
        }
        LevelSettings.Current.hasteScrollCoef = 1f;
        PlayerController.Instance.baseHealthRegen = 0f;
        LevelSettings.Current.shotController.SetManaHasteView(false);
        PlayerController.Instance.EffectHealth(false);
        yield break;

    }

    private IEnumerator FlyLine()
    {
        Vector3 hastePosition = ScrollController.Instance.GetPanelPos((int)Scroll.ScrollType.Haste) - Vector3.back;
        lineObj = Instantiate(line, hastePosition, Quaternion.identity);

        float currentTime = 0;
        while(currentTime < durationFlyLine)
        {
            currentTime += Time.unscaledDeltaTime;
            if (currentTime > durationFlyLine)
            {
                currentTime = durationFlyLine;
            }
            float perc = currentTime / durationFlyLine;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            lineObj.transform.position = Vector3.Lerp(hastePosition, target, perc);
            yield return null;
        }
        Destroy(lineObj);
    }

    private IEnumerator SlowMotion()
    {
        
        Time.timeScale = 0.05f;
        float timer = 3f * Time.timeScale;
        yield return new WaitForSeconds(timer);
        PlayerController.Instance.SemiDarkBack.SetActive(false);
        Time.timeScale = LevelSettings.Current.usedGameSpeed;
        yield break;
    }

    void Update()
    {
        if (e1 != null && handsObj != null)
        {
           e1.position = Vector3.Lerp(handsObj.transform.position, t1, Time.unscaledDeltaTime * speedEffect);
        }
    }
}