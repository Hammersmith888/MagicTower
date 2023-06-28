using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UILevelProgressBar : MonoBehaviour
{
    public EnemiesGenerator generator;

    public float speedEffect = 1;
    private int waveCount;
    [SerializeField]
    float speed = 1;
    private const int MAX_VALUE = 229; // max ширина прогресс бара уровня
    private int step; // шаг через который устанавливаются разделители, также величина на которую увеличивается ширина бара

    private RectTransform progressBarRect;

    private int currentMax; // текущая величина, до которой должна увечиться прогресс бар уровня (для каждой волны равна текущая + step)
    private int nextMax;

    private float fillSpeed = 0.05f; // скорость заполнения прогресс бара до следующего деления

    [SerializeField]
    private float fillTime; // время за которое прогресс бар должна заполнится до следующего деления
    [SerializeField]
    private float fastfillTime; // время за которое прогресс бар должна заполнится до следующего деления после смерти последнего из волнЬІ

    private int currentWaveID = -1;
    private int nextWaveID = -1;
    private float currentProgress = 0f;


    float currentHealth, healthWave, lastValue;
    bool show = true;

    void Start()
    {
        // Устанавливаем разделители на прогресс баре
        //  waveCount = generator.enemyWaves.Count;
        waveCount = generator.GetWawes();

        waveCount = (waveCount == 0) ? 3 : waveCount;//TODO: переработать
        step = MAX_VALUE / waveCount;

        progressBarRect = GetComponent<RectTransform>();

        fillTime = (fillTime == 0) ? 1 : fillTime;
        fastfillTime = (fastfillTime == 0) ? 0.5f : fastfillTime;

        fillTime *= waveCount;

        currentWaveID = 0;
        nextWaveID = -1;
    }

    [SerializeField]
    private float totalHealth;
    [SerializeField]
    private float healthEntered;
    public void SetTotalEnemiesHealth(float _health)
    {
        totalHealth = _health;
        fillSpeed = 250f / totalHealth;
    }

    private bool expressFill;
    public void AddEnteredHealth(float _health)
    {
        healthEntered += _health;
    }

    void Update()
    {
        progressBarRect.sizeDelta = new Vector2(Mathf.Lerp(progressBarRect.sizeDelta.x, lastValue , speedEffect * Time.unscaledDeltaTime), progressBarRect.sizeDelta.y);
    }

    public void MinusHealth(float health)
    {
        currentHealth += health;
        float currentProgress = currentHealth / totalHealth;
        lastValue = MAX_VALUE * (currentProgress > 1 ? 1 : currentProgress);
    }
}
