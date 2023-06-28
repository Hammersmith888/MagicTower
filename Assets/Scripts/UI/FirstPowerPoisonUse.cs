using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class FirstPowerPoisonUse : MonoBehaviour
{
    private float delay = 3.1f;
    [SerializeField] private GameObject healthEffect;
    [SerializeField] private GameObject manaEffect;

    private Transform manaTransform;
    private Transform healthTransform;

    private float durationFlyLine = 0.5f;

    private Vector3 target;

    private void Start()
    {
        ReplicasConditionsChecker.Current.ShowMageReplica(EReplicaID.Mage_Poution_Power_Use);

        target = GameObject.FindGameObjectWithTag("TargetEffect").transform.position;

        manaTransform = GameObject.FindGameObjectWithTag("ManaTargetEffect").transform;
        healthTransform = GameObject.FindGameObjectWithTag("HealthTarget").transform;

        StartCoroutine(SetHealthLine(healthEffect, healthTransform.position));
        StartCoroutine(SetHealthLine(manaEffect, manaTransform.position));
    }

    private IEnumerator SetHealthLine(GameObject line, Vector3 targetBar)
    {
        yield return new WaitForSecondsRealtime(0.8f);

        line.SetActive(true);

        float currentTime = 0;
        while (currentTime < durationFlyLine)
        {
            currentTime += Time.unscaledDeltaTime;
            if (currentTime > durationFlyLine)
                currentTime = durationFlyLine;

            float perc = currentTime / durationFlyLine;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);
            line.transform.position = Vector3.Lerp(line.transform.position, target, perc);
            yield return null;
        }

        currentTime = 0;

        while (currentTime < durationFlyLine)
        {
            currentTime += Time.unscaledDeltaTime;
            if (currentTime > durationFlyLine)
                currentTime = durationFlyLine;

            float perc = currentTime / durationFlyLine;
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f) * 0.1f;
            line.transform.position = Vector3.Lerp(line.transform.position, targetBar, perc);
            yield return null;
        }

        SetPowerLine();

        Destroy(line);
    }

    public void SetPowerLine()
    {
        StartCoroutine(StartLineAnimator());
    }

    private IEnumerator StartLineAnimator()
    {
        SetStateAnimator(true);

        yield return new WaitForSeconds(delay);

        SetStateAnimator(false);

        Destroy(gameObject);
    }

    private void SetStateAnimator(bool state)
    {
        PlayerController.Instance.EffectHealth(state);
        LevelSettings.Current.shotController.SetManaHasteView(state);
    }
}