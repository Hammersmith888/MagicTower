using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;

public class AddCoin : BaseCollectableItem, IPoolObject
{
    private const float DIST_SQR = 2.5f * 2.5f;
    private const float FastAutoLootWaitTime = 0.35f;
    private const float DefaultAutoLootWaitTime = 5f;

    public static int countInScene { get; set; } = 0;

    #region VARIABLES
    [SerializeField]
    private int collectCost, waitCost; // Величина добавляемого золота при сборе игроком / при автоматическом сборе

    private LevelSettings levelSettings;
    private CircleCollider2D colliderCoponent;
    private float waitTimer;
    private int rareCounter;
    private float startColliderRadius;

    [SerializeField]
    private GameObject mainObject;
    [SerializeField]
    private ItemDropAnimation itemDropAnimation;

    private int cost; // Золото устанавливается, когда монета долетит до кошелька, а сколько золото, определяется раньше
    private float currentAutolootWaiTime; // Время ожидания, после которого монета автоматически отправляется в "кошелек"
    private bool autoLoot;
    private bool collect;
    private Transform transf;
    private Transform mainObjTransf;
    #endregion

    #region IPoolObject implementation
    public void Init()
    {
        transf = transform;
        if (mainObject == null)
        {
            mainObject = transf.parent.parent.gameObject;
        }
        if (itemDropAnimation == null)
        {
            itemDropAnimation = transf.parent.GetComponent<ItemDropAnimation>();
        }
        itemDropAnimation.Init();
        mainObjTransf = mainObject.transform;
        levelSettings = LevelSettings.Current;
        colliderCoponent = GetComponent<CircleCollider2D>();
        startColliderRadius = colliderCoponent.radius;
        mainObject.SetActive(false);
    }

    public bool canBeUsed
    {
        get
        {
            return !mainObject.activeSelf;
        }
    }
    #endregion

    public void Spawn(Vector3 pos, Quaternion rotation, bool autoLoot = false, bool playSound = true)
    {
        countInScene++;

        rareCounter = 0;
        waitTimer = 0;
        this.autoLoot = autoLoot;
        currentAutolootWaiTime = autoLoot ? FastAutoLootWaitTime : DefaultAutoLootWaitTime;
        colliderCoponent.enabled = !autoLoot;
        colliderCoponent.radius = startColliderRadius;
        collect = false;
        mainObjTransf.localPosition = pos;
        mainObjTransf.rotation = rotation;
        transf.localPosition = new Vector3(0f, 0f, 0f);
        mainObject.SetActive(true);
        itemDropAnimation.Play();
        RegisterForUpdate();
        if (playSound)
        {
            SoundController.Instanse.PlayDropCoinSFX();
        }
    }

    protected override void OnStartCollect()
    {
        base.OnStartCollect();
        collect = true;
        Tutorial_1.Current.shouldStartCoinTutorial = true;
        SoundController.Instanse.PlayDropCoinSFX();
        countInScene--;
        colliderCoponent.enabled = false;
    }

    public override void UpdateObject()
    {
        waitTimer += Time.deltaTime;
        // По времени
        if (waitTimer > currentAutolootWaiTime && !collect)
        {
            OnStartCollect();
            cost = autoLoot ? collectCost : waitCost;
        }

        // Перемещаем в "кошелек"
        if (collect)
        {
            UpdateFlyAnimation();
        }
        if (autoLoot)
        {
            return;
        }
        if (rareCounter >= 20)
        {
            rareCounter = 0;
            CheckEnemiesAround();
        }
        else
        {
            rareCounter++;
        }
    }

    protected override void OnUIElementReached()
    {
        base.OnUIElementReached();
        levelSettings.coinsValue.text = (int.Parse(levelSettings.coinsValue.text.ToString()) + cost).ToString();
        EnemiesGenerator.Instance.RemoveDropFromList(mainObject);
        mainObject.SetActive(false);
        UnregisterFromUpdate();
    }

    private void CheckEnemiesAround()
    {
        if (levelSettings == null || levelSettings.enemies == null)
        {
            return;
        }

        bool isEnemyNear = false;
        var position = transf.position;
        int count = levelSettings.enemies.enemiesOnLevel.Count;
        for (int i = 0; i < count; i++)
        {
            float distance = Vector3.SqrMagnitude(position - levelSettings.enemies.enemiesOnLevel[i].position);
            if (distance < DIST_SQR)
            {
                isEnemyNear = true;
                break;
            }
        }
        colliderCoponent.radius = isEnemyNear ? startColliderRadius : startColliderRadius * 2f;
    }

    public void TakeCoin()
    {
        try
        {
            if (collect || autoLoot)
                return;

            itemDropAnimation.Stop();
            OnStartCollect();
            cost = collectCost;

            Vector3 helperSpawnPos = Input.mousePosition;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.touches[i];
                helperSpawnPos = touch.position;
            }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_EDITOR
            helperSpawnPos = Input.mousePosition;
#endif
            UIControl.SpawnCoinDoubleHelper(helperSpawnPos);

            TapController.Current.SetActiveShot(0.2f);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}