using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class EditorEnemyMover : MonoBehaviour
{
    public static int enemyCount;

    public EnemyType enemyType = EnemyType.zombie_walk;
    public float speed; // Скорость движения
    public int changeSpeed; // Позиция по Х после которой базовая скорость изменяется

    private Vector3 startPosition;

    private float baseSpeed = 1f; // Базовая скорость движения, до появления на экране игрока
    private float currentSpeed;
    private bool mayMove;

    [HideInInspector]
    public int casketChance, casketContent;
	bool mouse;
    public bool simulateTouchWithMouse = true;
    void Start()
    {
        currentSpeed = baseSpeed;
        enemyCount++;
		Invoke ("AutoShowAura", 0.2f);
    }

    // Передаем текущие настройки сундука
    public void SetCasketParameters(int _chance, int _content)
    {
        casketChance = _chance;
        casketContent = _content;
    }
    private Vector2 lastMousePosition;

    void Update()
    {
        if (mayMove)
        {
            transform.Translate(-currentSpeed * Time.deltaTime, 0, 0, Helpers.getMainCamera.transform);

            if (transform.position.x < changeSpeed)
                currentSpeed = speed;

            if (transform.position.x < -4)
            {
                enemyCount--;
                Destroy(gameObject);
            }           
        }

        if (timer)
        {
            tempDelay += Time.deltaTime;
            if (tempDelay >= delay)
            {
                timer = false;
                tempDelay = 0;
            }
        }
    }

    private float delay = 2f;
    private float tempDelay = 0f;
    bool timer = false;

    private void CharCall()
    {
        timer = false;
        tempDelay = 0;

        EditorPopupCustomDrop.Instance.CallToChar(GetComponent<EnemyCharacter>(), Input.mousePosition);
    }

    public void StartMove()
    {
        mayMove = true;
        GetComponent<Animator>().enabled = true;
    }

    public void OnMouseDrag()
    {
        if (!mayMove)
        {
            print("OnMouseDrag" + name);
            Vector3 spawPosition = new Vector3(Helpers.getMainCamera.ScreenToWorldPoint(Input.mousePosition).x, Helpers.getMainCamera.ScreenToWorldPoint(Input.mousePosition).y, -1);
            transform.position = spawPosition;
            CameraMover.scrollCanvas.SetActive(false);


        }
    }

    public void OnMouseUp()
    {
		if (Input.mousePosition.y < 100) 
		{
			Destroy (gameObject);
		} 

        if (!timer)
            timer = true;
        else
            CharCall();

        CameraMover.scrollCanvas.SetActive(true);
    }
    [SerializeField]
	private List<GameObject> aurasObjs = new List<GameObject> ();
	private void AutoShowAura()
	{
		int auraId = 0;
		if (GetComponent<EnemyCharacter>() != null) {
			auraId = GetComponent<EnemyCharacter> ().gives_aura_id;
		}
		while (true) {
			Transform tempAura = transform.Find ("Aura" + (aurasObjs.Count + 1).ToString());
			if (tempAura == null)
				break;

			aurasObjs.Add (tempAura.gameObject);
		}
		for (int i = 0; i < aurasObjs.Count; i++) {
			aurasObjs [i].SetActive (i == auraId - 1);
		}

	}

	void OnMouseEnter()
	{
		mouse = true;
	}
	void OnMouseExit()
	{
		mouse = false;
	}
}