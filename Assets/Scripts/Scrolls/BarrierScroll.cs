using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarrierScroll : MonoBehaviour
{
    public float health;
    //public GameObject healthBar;
    [SerializeField] private Sprite barrierLevel;
    [SerializeField] private Sprite barrierLevel2;
    [SerializeField] private Sprite barrierLevel3;

    [SerializeField] private Sprite barrierDamage;
    [SerializeField] private Sprite barrierDamage2;

    [SerializeField] private GameObject destruction;
    [SerializeField] private SpriteRenderer wallSprite;
    public byte currentLevel;
    [SerializeField] private float fullHP;

    private float currentHealth;
    //private float scaleHealthBar, healthScaleRatio;

    private Animator animator;

    //Debug.LogFormat("Barrier Damaged {0} -> {1}", currentHealth, value);
    // Отображаем изменения здоровья
    //float newScaleX = currentHealth * healthScaleRatio;
    //healthBar.transform.localScale = new Vector3(Mathf.Clamp(newScaleX, 0, 100), healthBar.transform.localScale.y, 1);

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (fullHP == 0)
            {
                fullHP = currentHealth;
            }

            currentHealth = value;

            if (currentHealth < fullHP * .5)
            {
                destruction.SetActive(true);
                if (currentHealth < fullHP * .25)
                {
                    destruction.GetComponent<SpriteRenderer>().sprite = barrierDamage2;
                }
            }

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Destroy");
            }
        }
    }
    // Вычисляем соотношение масштаба бара здоровья по x и его здоровья
    //scaleHealthBar = healthBar.transform.localScale.x;
    //healthScaleRatio = scaleHealthBar / health;

    // Изменяем позицию барьера по Z, чтобы персонажи его не пересекали
    //transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.y - 3) / 0.5f - 0.3f);

    private static List<Vector3> positionHolder = new List<Vector3>();

    void Start()
    {
        SetLevel();
        animator = gameObject.GetComponent<Animator>();

        if (PlayerPrefs.GetInt("SomeScrollUsed") != 1)
            PlayerPrefs.SetInt("SomeScrollUsed", 1);

        CurrentHealth = health;

        if(transform.position.y + 1.5f > Location.instance.max)
        {
            float offset = (transform.position.y + 1.5f) - Location.instance.max;
            transform.position = new Vector3(transform.position.x, offset, offset * 2.0f - 6.0f);
        }
        positionHolder.Add(transform.position);
    }

    private void OnEnable()
    {
        StartCoroutine(SetPosition());
    }

    private IEnumerator SetPosition()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    private void SetLevel()
    {
        if (currentLevel >= 3 && currentLevel <= 6)
        {
            wallSprite.sprite = barrierLevel2;
        }
        else if(currentLevel >= 7)
        {
            wallSprite.sprite = barrierLevel3;
        }
    }

    public void GetHit(float _damage)
    {
        CurrentHealth -= _damage;
    }

    public void DestroyBarrier()
    {
        positionHolder.Remove(transform.position);
        Destroy(gameObject);
    }

    public static bool CheckBarrierPositionForJump(Vector3 position)
    {
        for (int i = 0; i < positionHolder.Count; i++)
        {
            if (position.x != positionHolder[i].x)
            {
                var posX = Mathf.Abs(Mathf.Abs(position.x) - Mathf.Abs(positionHolder[i].x));
                var posY = Mathf.Abs(Mathf.Abs(position.y) - Mathf.Abs(positionHolder[i].y));

                if (posX < 1.1 && posY < 1.4)
                    return false;
            }
        }
        return true;
    }
}