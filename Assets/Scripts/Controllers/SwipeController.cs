using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    public enum SwipeDirection { none, up, down, right, left }
    public SwipeDirection swipeDirection = SwipeDirection.none;

    public RectTransform swipeRT;
    private Vector2 swipeSize, prevPos;
    private float swipeDelta;

    // Параметры свайпов
    public float minSwipeDistY, minSwipeDistX;
    public float maxSwipeTime;

    // Управление мышью
    public bool simulateTouchWithMouse = true;
    private Vector2 lastMousePosition;

    private Vector2 startPosition;
    private float startTime;
    private bool swipe;

    private float dpm; // Количество пикселей на миллиметр экрана

    // Выстрелы
    private ShotController shotController;

    void Start()
    {
        dpm = Screen.dpi / 25.4f; // Расчёт плотности точек на миллиметр

        swipeSize = swipeRT.sizeDelta;

        shotController = GetComponent<ShotController>();
    }

    void Update()
    {
        // Taч
        int i;
        for (i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];
            UpdateTouch(touch.fingerId, touch.phase, touch.position);
        }
        // Мышь
        if (simulateTouchWithMouse)
        {
            Vector2 mousePosition = Input.mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                UpdateTouch(i, TouchPhase.Ended, mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                UpdateTouch(i, Input.GetMouseButtonDown(0) ? TouchPhase.Began : (mousePosition.Equals(lastMousePosition) ? TouchPhase.Stationary : TouchPhase.Moved), mousePosition);
            }
            lastMousePosition = mousePosition;
        }
    }

    void UpdateTouch(int num, TouchPhase phase, Vector2 position)
    {
        // При нажатии на элемент интерфейса, тачи не обрабатываются
        if (EventSystem.current.IsPointerOverGameObject() && phase == TouchPhase.Began)
        {
            return;
        }

        if (phase == TouchPhase.Began)
        {
            startPosition = position;
            prevPos = position;
            startTime = Time.time;
            swipe = true;

            swipeRT.gameObject.SetActive(true);
            swipeRT.position = startPosition;
        }

        if (phase == TouchPhase.Moved && swipe)
        {
            float swipeDistY = (new Vector3(0, position.y, 0) - new Vector3(0, startPosition.y, 0)).magnitude / dpm;
            float swipeDistX = (new Vector3(position.x, 0, 0) - new Vector3(startPosition.x, 0, 0)).magnitude / dpm;

            // Вертикальный свайп И (Направление свайпа еще не задано ИЛИ Направление свайпа вверх ИЛИ Направление свайпа сниз)
            if (Mathf.Abs(swipeDistY) > Mathf.Abs(swipeDistX) && (swipeDirection == SwipeDirection.none || swipeDirection == SwipeDirection.up || swipeDirection == SwipeDirection.down))
            {
                swipeDelta = startPosition.y - position.y;
                // Направление свайпа вниз
                if (swipeDelta > 0)
                {
                    // Если в процессе свайпа вниз, начали двигать вверх, то сбрасываем всё
                    if (prevPos.y < position.y)
                    {
                        swipe = false;
                        phase = TouchPhase.Ended;
                    } else {
                        // Всё ок, отображение свайпа вниз
                        swipeDirection = SwipeDirection.down;
                        swipeRT.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }    
                else
                {
                    if (prevPos.y > position.y)
                    {
                        swipe = false;
                        phase = TouchPhase.Ended;
                    } else {
                        swipeDirection = SwipeDirection.up;
                        swipeRT.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
            }

            if (Mathf.Abs(swipeDistY) < Mathf.Abs(swipeDistX) && (swipeDirection == SwipeDirection.none || swipeDirection == SwipeDirection.right || swipeDirection == SwipeDirection.left))
            {
                swipeDelta = startPosition.x - position.x;
                if (swipeDelta > 0)
                {
                    if (prevPos.x < position.x)
                    {
                        swipe = false;
                        phase = TouchPhase.Ended;
                    } else {
                        swipeDirection = SwipeDirection.left;
                        swipeRT.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                else
                {
                    if (prevPos.x > position.x)
                    {
                        swipe = false;
                        phase = TouchPhase.Ended;
                    }
                    else {
                        swipeDirection = SwipeDirection.right;
                        swipeRT.rotation = Quaternion.Euler(0, 0, -90);
                    }
                }                    
            }

            swipeRT.sizeDelta = new Vector2(22, Mathf.Abs(swipeDelta));
            prevPos = position;
        }

        if (phase == TouchPhase.Ended && swipe)
        {
            float swipeTime = Time.time - startTime;

            float swipeDistY = (new Vector3(0, position.y, 0) - new Vector3(0, startPosition.y, 0)).magnitude / dpm;
            float swipeDistX = (new Vector3(position.x, 0, 0) - new Vector3(startPosition.x, 0, 0)).magnitude / dpm;

            // Распознаем вертикальный свайп
            if (swipeDistY > minSwipeDistY && swipeTime < maxSwipeTime && Mathf.Abs(swipeDistY) > Mathf.Abs(swipeDistX))
            {
                float swipeValue = Mathf.Sign(position.y - startPosition.y);
                if (swipeValue > 0)
                {
                    //shotController.SetActiveSpell(Spell.SpellType.bowlder);
                    //shotController.Shot(startPosition);
                }

                else if (swipeValue < 0)
                {
                    //shotController.SetActiveSpell(Spell.SpellType.fireBall);
                    //shotController.Shot(startPosition);
                }
            }

            // Распознаем горизонтальный свайп
            if (swipeDistX > minSwipeDistX && swipeTime < maxSwipeTime && Mathf.Abs(swipeDistX) > Mathf.Abs(swipeDistY))
            {
                float swipeValue = Mathf.Sign(position.x - startPosition.x);
                if (swipeValue > 0)
                {
                    //shotController.SetActiveSpell(Spell.SpellType.lightning);
                    //shotController.Shot(startPosition);
                }
                else if (swipeValue < 0)
                {
                    //shotController.SetActiveSpell(Spell.SpellType.iceStrike);
                    //shotController.Shot(startPosition);
                }
            }

            startTime = 0;
            swipe = false;

            swipeRT.gameObject.SetActive(false);
            swipeRT.sizeDelta = swipeSize;

            swipeDirection = SwipeDirection.none;
        }

        if (phase == TouchPhase.Ended && !swipe)
        {
            startTime = 0;
            swipeRT.gameObject.SetActive(false);
            swipeRT.sizeDelta = swipeSize;

            swipeDirection = SwipeDirection.none;
        }
    }
}