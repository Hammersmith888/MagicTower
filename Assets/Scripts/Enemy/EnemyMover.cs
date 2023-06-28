using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public partial class EnemyMover : BaseUpdatableObject
{
    #region VARIABLES
    private const float MAX_Y = 5.8f; // Максимальная высота по Y до которой может подняться персонаж
    private const float MIN_Y = -5.8f; // Минимальная высота по Y до которой может опуститься персонаж
    private const float TOP_MOVEMENT_Y_WORLD = 3.4f; // Высота по Y, выше которой персонаж пытается идти ниже
    private const float BOTTOM_MOVEMENT_Y = -3.8f; // Высота по Y, ниже которой персонаж пытается идти выше
    private const float BASE_SPEED = 1f; // Базовая скорость движения, до появления на экране игрока
    private const float XPositionThresholdForSpeedChange = 10f; // Позиция по Х после которой базовая скорость изменяется
    private const float XPositionThresholdForDestroyingFriendlyUnit = 10f;
    private const float GameFieldWidthInUnits = 12f; // Ширина игрового поля в юнитах

    [HideInInspector]
    public float defaultSpeed;
    [SerializeField]            //[HideInInspector]
    private float specSpeed; // Скорость движения для спец.атаки
    private bool specSpeedEnabled = false;
    private float speedMultiplier = 1.0f;
    private bool crawlSpeedEnabled = false;
    private float crawlSpeed = 0.5f; // Скорость движения когда осталось мало здоровья для BigZombie
    private bool movementCollisionsEnabled = true;

    [SerializeField]
    public float movementRadius = 0.5f;

    [SerializeField]
    public float characterHeight = 0.5f;

    [SerializeField]
    private float attackDistance = 0.5f;

    public EnemyJump enemyJump;

    private bool pushing;
    private float pushTargetX;
    private float pushingSpeed;

    [HideInInspector]
    private bool targetPosXWasSet;
    private float targetPosX;
    public float movespeed_aura_modifier;

    [HideInInspector]
    public bool countInProgress;
    private bool countedProgress;


    private GameObject player;

    private bool startAttack;
    private EnemyCharacter enemyCharacter;
    public SpellEffects enemyEffects;
    private bool isOnGameField = false;
    private bool gameFieldReached = false;
    private float jumpHeightOffset = 0.0f;
    private float offsetBorder = 0.2f;

    public Vector2 positionOnPlane;

    public const float WORLD_PLANE_ANGLE_RAD = Mathf.PI * 0.148f;
    public const float WORLD_PLANE_SIN = 0.4483832f; // Sin(WORLD_PLANE_ANGLE_RAD)
    public const float WORLD_PLANE_COS = 0.8938414f; // Cos(WORLD_PLANE_ANGLE_RAD)

    private const float WALL_LINE_COEFF = 8.0f;
    private const float WALL_LINE_OFFSET = 31.1f;
    private const float BARRIER_LINE_WIDTH_X = 0.3f;
    private const float BARRIER_LINE_OFFSET_X = 1.0f;
    private const float BARRIER_LINE_OFFSET_Y = 0.58f;

    private EnemiesGenerator enemiesGenerator;

    private GameObject hittedObj;
    public GameObject HittedObj
    {
        get
        {
            return hittedObj;
        }
    }

#if LEVEL_EDITOR || UNITY_EDITOR
    const string LEVEL_EDITOR_SCENE_NAME = "LevelEditor";
    private bool sceneCheckCached = false;
    private bool isLevelEditorScene;


    private bool IsLevelEditorScene
    {
        get
        {
            if (!sceneCheckCached)
            {
                sceneCheckCached = true;
                isLevelEditorScene = SceneManager.GetActiveScene().name == "LevelEditor";
            }
            return isLevelEditorScene;
        }
    }
#endif

    #endregion

    public void Init(EnemyCharacter enemyCharacter)
    {
        enemyEffects = GetComponent<SpellEffects>();
        this.enemyCharacter = enemyCharacter;

        // This call is for planePosition initialization
        SetPosition(transform.position);

        if (PlayerController.Instance != null)
        {
            player = PlayerController.Instance.gameObject;
        }
    }

    private bool speedRandomized;
    private void RandomSpeedMode()
    {
        float randomFactor = UnityEngine.Random.Range(0.7f, 1.3f);
        defaultSpeed *= randomFactor;
        specSpeed *= randomFactor;
    }
    public void InitializeSpeed(float speedValue)
    {
        defaultSpeed = speedValue / GameFieldWidthInUnits;
    }

    public void InitialieSpecSpeed(float specSpeedVal)
    {
        specSpeed = specSpeedVal / GameFieldWidthInUnits;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Vector2 wallLinePlanePointStart = new Vector2(-1000.0f, -1000.0f * WALL_LINE_COEFF + WALL_LINE_OFFSET);
        Vector2 wallLinePlanePointEnd = new Vector2(1000.0f, 1000.0f * WALL_LINE_COEFF + WALL_LINE_OFFSET);

        Vector3 wallLinePointStart = new Vector3(wallLinePlanePointStart.x, wallLinePlanePointStart.y * WORLD_PLANE_SIN,
            wallLinePlanePointStart.y * WORLD_PLANE_COS - 6.0f);
        Vector3 wallLinePointEnd = new Vector3(wallLinePlanePointEnd.x, wallLinePlanePointEnd.y * WORLD_PLANE_SIN,
            wallLinePlanePointEnd.y * WORLD_PLANE_COS - 6.0f);

        Gizmos.DrawLine(wallLinePointStart, wallLinePointEnd);

        Gizmos.DrawLine(new Vector3(-1000.0f, MIN_Y * WORLD_PLANE_SIN, MIN_Y * WORLD_PLANE_COS - 6.0f), new Vector3(1000.0f, MIN_Y * WORLD_PLANE_SIN, MIN_Y * WORLD_PLANE_COS - 6.0f));
        Gizmos.DrawLine(new Vector3(-1000.0f, MAX_Y * WORLD_PLANE_SIN, MAX_Y * WORLD_PLANE_COS - 6.0f), new Vector3(1000.0f, MAX_Y * WORLD_PLANE_SIN, MAX_Y * WORLD_PLANE_COS - 6.0f));

        Gizmos.DrawLine(new Vector3(-1000.0f, TOP_MOVEMENT_Y_WORLD, 0.0f), new Vector3(1000.0f, TOP_MOVEMENT_Y_WORLD, 0.0f));
        Gizmos.DrawLine(new Vector3(-1000.0f, BOTTOM_MOVEMENT_Y * WORLD_PLANE_SIN, BOTTOM_MOVEMENT_Y * WORLD_PLANE_COS - 6.0f), new Vector3(1000.0f, BOTTOM_MOVEMENT_Y * WORLD_PLANE_SIN, BOTTOM_MOVEMENT_Y * WORLD_PLANE_COS - 6.0f));

        if (ScrollController.Instance != null)
        {
            foreach (GameObject barrier in ScrollController.Instance.ActiveBarriers)
            {
                float barrierPlaneX = barrier.transform.position.x + BARRIER_LINE_OFFSET_X;
                float barrierPlaneY = barrier.transform.position.y / WORLD_PLANE_SIN + BARRIER_LINE_OFFSET_Y;
                float barrierLineOffset = barrierPlaneY - WALL_LINE_COEFF * barrierPlaneX;

                Vector2 barrierLinePlanePointStart = new Vector2(barrierPlaneX - BARRIER_LINE_WIDTH_X, (barrierPlaneX - BARRIER_LINE_WIDTH_X) * WALL_LINE_COEFF + barrierLineOffset);
                Vector2 barrierLinePlanePointEnd = new Vector2(barrierPlaneX + BARRIER_LINE_WIDTH_X, (barrierPlaneX + BARRIER_LINE_WIDTH_X) * WALL_LINE_COEFF + barrierLineOffset);

                Vector3 barrierLinePointStart = new Vector3(barrierLinePlanePointStart.x, barrierLinePlanePointStart.y * WORLD_PLANE_SIN,
                    barrierLinePlanePointStart.y * WORLD_PLANE_COS - 6.0f);
                Vector3 barrierLinePointEnd = new Vector3(barrierLinePlanePointEnd.x, barrierLinePlanePointEnd.y * WORLD_PLANE_SIN,
                    barrierLinePlanePointEnd.y * WORLD_PLANE_COS - 6.0f);

                Gizmos.DrawLine(barrierLinePointStart, barrierLinePointEnd);
            }
        }

        if (enemiesGenerator != null)
        {
            foreach (EnemyCharacter enemy in enemiesGenerator.enemiesOnLevelComponents)
            {
                Vector2 circleCenter = enemy.enemyMover.positionOnPlane;
                float circleRadius = enemy.enemyMover.movementRadius;
                for (int a = 0; a < 360; a++)
                {
                    float a1 = a;
                    float a2 = (a + 1) % 360;

                    Vector2 circlePointPlane1 = circleCenter + circleRadius * new Vector2(Mathf.Cos(a1 * Mathf.Deg2Rad), Mathf.Sin(a1 * Mathf.Deg2Rad));
                    Vector2 circlePointPlane2 = circleCenter + circleRadius * new Vector2(Mathf.Cos(a2 * Mathf.Deg2Rad), Mathf.Sin(a2 * Mathf.Deg2Rad));

                    Vector3 circlePoint1 = new Vector3(circlePointPlane1.x, circlePointPlane1.y * WORLD_PLANE_SIN,
                        circlePointPlane1.y * WORLD_PLANE_COS - 6.0f);
                    Vector3 circlePoint2 = new Vector3(circlePointPlane2.x, circlePointPlane2.y * WORLD_PLANE_SIN,
                        circlePointPlane2.y * WORLD_PLANE_COS - 6.0f);

                    Gizmos.DrawLine(circlePoint1, circlePoint2);
                }

                Vector3 chracterTopPoint = enemy.transform.position + Vector3.up * enemy.enemyMover.characterHeight;
                Gizmos.DrawLine(enemy.transform.position, chracterTopPoint);
            }
        }
    }
#endif

    public void SetTargetPosX(float newTargetPosX)
    {
        targetPosXWasSet = true;
        targetPosX = newTargetPosX;
    }

    public void SetPosition(Vector3 pos)
    {
        Vector2 newPlanePosition = new Vector2(pos.x, pos.y / WORLD_PLANE_SIN);
        SetPositionOnPlane(newPlanePosition);
    }

    private void SetPositionOnPlane(Vector2 newPosition)
    {
        positionOnPlane = newPosition;
        UpdateWorldPositionByPositionOnPlane();
    }

    private void UpdateWorldPositionByPositionOnPlane()
    {
        transform.position = new Vector3(positionOnPlane.x, positionOnPlane.y * WORLD_PLANE_SIN + jumpHeightOffset,
            positionOnPlane.y * WORLD_PLANE_COS - 6.0f);
    }

    public void SetSpeedMultiplier(float newSpeedMultiplier)
    {
        speedMultiplier = newSpeedMultiplier;
    }

    public void SetSpecSpeedEnabled(bool newSpecSpeedEnabled)
    {
        specSpeedEnabled = newSpecSpeedEnabled;
    }

    public void SetCrawlSpeedEnabled(bool newCrawlSpeedEnabled)
    {
        crawlSpeedEnabled = newCrawlSpeedEnabled;
    }

    public void SetMovementCollisionsEnabled(bool newMovementCollisionsEnabled)
    {
        movementCollisionsEnabled = newMovementCollisionsEnabled;
    }

    public override void UpdateObject()
    {
        if (enemyCharacter == null)
            return;

        if (enemiesGenerator == null)
            enemiesGenerator = EnemiesGenerator.Instance;

#if LEVEL_EDITOR || UNITY_EDITOR
        if (IsLevelEditorScene)
            return;
#endif

        if (!gameFieldReached)
        {
            if (positionOnPlane.x > XPositionThresholdForSpeedChange)
            {
                Vector2 newPositionOnPlane = positionOnPlane;
                newPositionOnPlane.x -= BASE_SPEED * Time.deltaTime;
                SetPositionOnPlane(newPositionOnPlane);
            }
            else
            {
                gameFieldReached = true;
            }
        }

        if (gameFieldReached)
        {
            bool isJumping = false;
            if (enemyJump != null && enemyJump.IsJumping())
                isJumping = true;

            Vector2 newPositionOnPlane = positionOnPlane;
            float deltaX = 0.0f;
            float deltaY = 0.0f;
            hittedObj = null;

            if (isJumping)
            {
                Vector2 jumpDelta = enemyJump.GetJumpDelta();
                deltaX = jumpDelta.x;
                deltaY = jumpDelta.y;
                jumpHeightOffset = enemyJump.GetCurrentJumpHeight();
            }
            else if (pushing)
            {
                if (Mathf.Abs(positionOnPlane.x - pushTargetX) < pushingSpeed * Time.deltaTime)
                {
                    deltaX = pushTargetX - positionOnPlane.x;
                    pushing = false;
                }
                else if (positionOnPlane.x < pushTargetX)
                {
                    deltaX = pushingSpeed * Time.deltaTime;
                }
                else
                {
                    deltaX = -pushingSpeed * Time.deltaTime;
                }
            }
            else 
            {
                float currentSpeed = defaultSpeed;
                if (specSpeedEnabled && specSpeed != 0.0f)
                    currentSpeed = specSpeed;
                else if (crawlSpeedEnabled && crawlSpeed != 0.0f)
                    currentSpeed = crawlSpeed;

                currentSpeed *= speedMultiplier;
                currentSpeed *= (1f + movespeed_aura_modifier);

                if (enemyCharacter.enemyType == EnemyType.skeleton_mage || enemyCharacter.enemyType == EnemyType.skeleton_mage2 ||
                    enemyCharacter.enemyType == EnemyType.skeleton_strong_mage || enemyCharacter.enemyType == EnemyType.skeleton_strong_mage2)
                {
                    currentSpeed *= enemyCharacter.easyCoef;
                }

                float currentDeltaLength = currentSpeed * Time.deltaTime;

                bool directionRight = false;
                if (enemyCharacter.friendly || (targetPosXWasSet && targetPosX > positionOnPlane.x))
                    directionRight = true;

                float movementAngle = 180.0f;
                float maxDistanceX = -1.0f;

                float minAngle;
                float maxAngle;
                float priorityAngle = 10000.0f;

                if (directionRight)
                {
                    if (enemyCharacter.friendly)
                    {
                        minAngle = 0.0f;
                        maxAngle = 0.0f;
                    }
                    else
                    {
                        minAngle = -75.0f;
                        maxAngle = 75.0f;

                        if (transform.position.y + characterHeight > TOP_MOVEMENT_Y_WORLD)
                            priorityAngle = -30.0f;
                        if (positionOnPlane.y < BOTTOM_MOVEMENT_Y)
                            priorityAngle = 30.0f;
                    }
                }
                else
                {
                    minAngle = 105.0f;
                    maxAngle = 255.0f;

                    if (transform.position.y + characterHeight > TOP_MOVEMENT_Y_WORLD)
                        priorityAngle = 210.0f;
                    if (positionOnPlane.y < BOTTOM_MOVEMENT_Y)
                        priorityAngle = 150.0f;
                }

                for (float angle = minAngle; angle <= maxAngle; angle += 15.0f)
                {
                    float distanceWithThisAngle;
                    EnemyCharacter hittedEnemyWithThisAngle;
                    GetCollidedEnemy(angle, currentDeltaLength, out hittedEnemyWithThisAngle, out distanceWithThisAngle);

                    float distanceX = Mathf.Abs(Mathf.Cos(angle * Mathf.Deg2Rad) * distanceWithThisAngle);
                    if (distanceX > maxDistanceX)
                    {
                        maxDistanceX = distanceX;
                        movementAngle = angle;
                    }

                    if (angle == priorityAngle && hittedEnemyWithThisAngle == null)
                    {
                        maxDistanceX = distanceX;
                        movementAngle = angle;
                        break;
                    }
                }

                float deltaLength;
                EnemyCharacter hittedEnemy = null;

                if (!directionRight && maxDistanceX == 0.0f)
                {
                    GetCollidedEnemy(180.0f, currentDeltaLength, out hittedEnemy, out deltaLength);
                    if (hittedEnemy != null && hittedEnemy.enemyMover.positionOnPlane.y <= positionOnPlane.y)
                        movementAngle = 90.0f;
                    else
                        movementAngle = 270.0f;

                    deltaLength = currentDeltaLength / 5.0f;
                }
                else
                {
                    GetCollidedEnemy(movementAngle, currentDeltaLength, out hittedEnemy, out deltaLength);
                }

                if (!movementCollisionsEnabled)
                {
                    hittedEnemy = null;
                    deltaLength = currentDeltaLength;
                    if (directionRight)
                        movementAngle = 0.0f;
                    else
                        movementAngle = 180.0f;
                }

                deltaX = Mathf.Cos(movementAngle * Mathf.Deg2Rad) * deltaLength;
                deltaY = Mathf.Sin(movementAngle * Mathf.Deg2Rad) * deltaLength;

                if (hittedEnemy != null)
                    hittedObj = hittedEnemy.gameObject;

                if (targetPosXWasSet && Mathf.Abs(positionOnPlane.x - targetPosX) < Mathf.Abs(deltaX))
                    deltaX = targetPosX - positionOnPlane.x;

                jumpHeightOffset = 0.0f;
            }

            newPositionOnPlane.x += deltaX;
            newPositionOnPlane.y += deltaY;

            newPositionOnPlane.y = Mathf.Clamp(newPositionOnPlane.y, MIN_Y + movementRadius, MAX_Y - movementRadius);

            float wallAttackX = (newPositionOnPlane.y - WALL_LINE_OFFSET) / WALL_LINE_COEFF;
            if (newPositionOnPlane.x <= wallAttackX + attackDistance)
            {
                newPositionOnPlane.x = wallAttackX + attackDistance - 0.01f;
                hittedObj = PlayerController.Instance.WallObject;
            }

            if (!isJumping && ScrollController.Instance != null && movementCollisionsEnabled)
            {
                foreach (GameObject barrier in ScrollController.Instance.ActiveBarriers)
                {
                    float barrierPlaneX = barrier.transform.position.x + BARRIER_LINE_OFFSET_X;
                    float barrierPlaneY = barrier.transform.position.y / WORLD_PLANE_SIN + BARRIER_LINE_OFFSET_Y;
                    float barrierLineOffset = barrierPlaneY - WALL_LINE_COEFF * barrierPlaneX;

                    Vector2 barrierLinePlanePointStart = new Vector2(barrierPlaneX - BARRIER_LINE_WIDTH_X, (barrierPlaneX - BARRIER_LINE_WIDTH_X) * WALL_LINE_COEFF + barrierLineOffset);
                    Vector2 barrierLinePlanePointEnd = new Vector2(barrierPlaneX + BARRIER_LINE_WIDTH_X, (barrierPlaneX + BARRIER_LINE_WIDTH_X) * WALL_LINE_COEFF + barrierLineOffset);

                    if (newPositionOnPlane.y >= Mathf.Min(barrierLinePlanePointStart.y, barrierLinePlanePointEnd.y) &&
                        newPositionOnPlane.y <= Mathf.Max(barrierLinePlanePointStart.y, barrierLinePlanePointEnd.y))
                    {
                        float barrierAttackX = (newPositionOnPlane.y - barrierLineOffset) / WALL_LINE_COEFF;
                        if (newPositionOnPlane.x + movementRadius > barrierAttackX && newPositionOnPlane.x <= barrierAttackX + attackDistance)
                        {
                            newPositionOnPlane.x = barrierAttackX + attackDistance - 0.01f;
                            hittedObj = barrier;
                        }
                    }
                }
            }

            SetPositionOnPlane(newPositionOnPlane);
        }

        if (!isOnGameField)
        {
            if (positionOnPlane.x < enemyCharacter.invunarableDistance)
            {
            }
            else if (enemyCharacter.friendly && positionOnPlane.x >= XPositionThresholdForDestroyingFriendlyUnit)
            {
                enemyCharacter.OnFriendlyMovedOtOfScreen();
            }
        }

        if (!speedRandomized && positionOnPlane.x < enemyCharacter.invunarableDistance + 1f)
        {
            speedRandomized = true;
            RandomSpeedMode();
        }
        if (countInProgress && !countedProgress && positionOnPlane.x < enemyCharacter.invunarableDistance + 1.5f)
        {
            countedProgress = true;
            enemiesGenerator.progressBar.AddEnteredHealth(enemyCharacter.health);
            if (enemyCharacter != null)
            {
                if ((enemyCharacter.enemyType == EnemyType.zombie_boss && mainscript.CurrentLvl == 15) ||
                    (enemyCharacter.enemyType == EnemyType.skeleton_king && mainscript.CurrentLvl == 30) ||
                    (enemyCharacter.enemyType == EnemyType.burned_king && mainscript.CurrentLvl == 45) ||
                    (enemyCharacter.enemyType == EnemyType.ghoul_boss && mainscript.CurrentLvl == 70) ||
                    (enemyCharacter.enemyType == EnemyType.demon_boss && mainscript.CurrentLvl == 95))
                {
                    UIControl.Current.ShowBoss();
                }
            }
        }
    }

    public void PushItTo(float newPushTargetX, float newPushTime)
    {
        pushing = true;
        pushTargetX = newPushTargetX;
        float pushDistance = Mathf.Abs(transform.position.x - pushTargetX);
        pushingSpeed = pushDistance / newPushTime;
    }

    private void OnEnable()
    {
        if (enemyCharacter != null && enemyCharacter.IsDead)
        {
            enabled = false;
        }
        else
        {
            RegisterForUpdate();
        }
    }

    private void OnDisable()
    {
        UnregisterFromUpdate();
    }

    private void GetCollidedEnemy(float angle, float distance, out EnemyCharacter outCollidedEnemy, out float outDistance)
    {
        float angleRad = Mathf.Deg2Rad * angle;
        float angleCos = Mathf.Cos(angleRad);
        float angleSin = Mathf.Sin(angleRad);

        bool leftDirection = false;
        if (angle > 90.0f && angle < 270.0f)
            leftDirection = true;

        bool isInsideOtherEnemyBeforeMove = false;
        EnemyCharacter collidedEnemyBeforeMove = null;
        bool isInsideOtherEnemyAfterMove = false;

        int enemiesNum = enemiesGenerator.enemiesOnLevelComponents.Count;
        int friendlyCharactersNum = enemiesGenerator.spawnedFriendlyCharacters.Count;
        int charactersNum = enemiesNum + friendlyCharactersNum;

        for (int i = 0; i < charactersNum; i++)
        {
            EnemyCharacter enemy;
            if (i < enemiesNum)
                enemy = enemiesGenerator.enemiesOnLevelComponents[i];
            else
                enemy = enemiesGenerator.spawnedFriendlyCharacters[i - enemiesNum];

            EnemyMover enemyMover = enemy.enemyMover;

            if (leftDirection && enemyMover.positionOnPlane.x >= positionOnPlane.x)
                continue;
            if (!leftDirection && enemyMover.positionOnPlane.x <= positionOnPlane.x)
                continue;

            float dx = positionOnPlane.x - enemyMover.positionOnPlane.x;
            float dy = positionOnPlane.y - enemyMover.positionOnPlane.y;
            float r = movementRadius + enemyMover.movementRadius;
            if (dx * dx + dy * dy < r * r)
            {
                isInsideOtherEnemyBeforeMove = true;
                collidedEnemyBeforeMove = enemy;
            }

            dx += angleCos * distance;
            dy += angleSin * distance;
            if (dx * dx + dy * dy < r * r)
                isInsideOtherEnemyAfterMove = true;
        }

        if (!isInsideOtherEnemyAfterMove)
        {
            outCollidedEnemy = null;
            outDistance = distance;
            return;
        }

        if (isInsideOtherEnemyBeforeMove)
        {
            outCollidedEnemy = collidedEnemyBeforeMove;
            outDistance = 0.0f;
            return;
        }

        outCollidedEnemy = null;
        outDistance = distance * distance;

        for (int i = 0; i < charactersNum; i++)
        {
            EnemyCharacter enemy;
            if (i < enemiesNum)
                enemy = enemiesGenerator.enemiesOnLevelComponents[i];
            else
                enemy = enemiesGenerator.spawnedFriendlyCharacters[i - enemiesNum];

            EnemyMover enemyMover = enemy.enemyMover;

            if (leftDirection && enemyMover.positionOnPlane.x >= positionOnPlane.x)
                continue;
            if (!leftDirection && enemyMover.positionOnPlane.x <= positionOnPlane.x)
                continue;

            Vector2 intersection1, intersection2;
            int intersectionsNum = GetIntersectionsBetweenLineAndCircle(enemyMover.positionOnPlane, movementRadius + enemyMover.movementRadius,
                positionOnPlane, positionOnPlane + new Vector2(angleCos, angleSin), out intersection1, out intersection2);

            if (intersectionsNum == 2)
            {
                if ((leftDirection && intersection1.x < positionOnPlane.x) || (!leftDirection && intersection1.x > positionOnPlane.x))
                {
                    float dx = positionOnPlane.x - intersection1.x;
                    float dy = positionOnPlane.y - intersection1.y;
                    float dist1 = dx * dx + dy * dy;
                    if (dist1 < outDistance)
                    {
                        outCollidedEnemy = enemy;
                        outDistance = dist1;
                    }
                }
                if ((leftDirection && intersection2.x < positionOnPlane.x) || (!leftDirection && intersection2.x > positionOnPlane.x))
                {
                    float dx = positionOnPlane.x - intersection2.x;
                    float dy = positionOnPlane.y - intersection2.y;
                    float dist2 = dx * dx + dy * dy;
                    if (dist2 < outDistance)
                    {
                        outCollidedEnemy = enemy;
                        outDistance = dist2;
                    }
                }
            }
        }

        outDistance = Mathf.Sqrt(outDistance);
    }

    private int GetIntersectionsBetweenLineAndCircle(Vector2 circleCenter, float circleRadius, Vector2 point1, Vector2 point2, out Vector2 intersection1, out Vector2 intersection2)
    {
        float t;

        var dx = point2.x - point1.x;
        var dy = point2.y - point1.y;

        var a = dx * dx + dy * dy;
        var b = 2 * (dx * (point1.x - circleCenter.x) + dy * (point1.y - circleCenter.y));
        var c = (point1.x - circleCenter.x) * (point1.x - circleCenter.x) + (point1.y - circleCenter.y) * (point1.y - circleCenter.y) - circleRadius * circleRadius;

        var determinate = b * b - 4 * a * c;
        if ((a <= 0.0000001) || (determinate < -0.0000001))
        {
            // No real solutions.
            intersection1 = Vector2.zero;
            intersection2 = Vector2.zero;
            return 0;
        }
        if (determinate < 0.0000001 && determinate > -0.0000001)
        {
            // One solution.
            t = -b / (2 * a);
            intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
            intersection2 = Vector2.zero;
            return 1;
        }

        // Two solutions.
        t = (float)((-b + Math.Sqrt(determinate)) / (2 * a));
        intersection1 = new Vector2(point1.x + t * dx, point1.y + t * dy);
        t = (float)((-b - Math.Sqrt(determinate)) / (2 * a));
        intersection2 = new Vector2(point1.x + t * dx, point1.y + t * dy);

        return 2;
    }

    public bool CanJumpOnDelta(Vector2 delta)
    {
        if (transform.position.x + delta.x < PlayerController.Position.x)
            return false;

        return true;
    }

    public void Jump(Vector2 delta)
    {
        if (enemyJump != null)
        {
            delta.y /= WORLD_PLANE_SIN;
            enemyJump.Jump(delta);
        }
    }

    public void InterruptJump()
    {
        if (enemyJump != null)
        {
            enemyJump.InterruptJump();
        }
    }

    public bool IsJumping()
    {
        if (enemyJump != null)
        {
            return enemyJump.IsJumping();
        }

        return false;
    }
}