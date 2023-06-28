
using UnityEngine;

public class ArrowFly : BaseUpdatableObject
{
    public  Transform center;
    public  float speed;
    public  EnemyCharacter EnemyCharacter;
    public  MeshRenderer MeshRenderer;
    private GameObject arrowInstance;
    private bool isMoving;
    private Vector3 startPos;
    private Vector3 centerPos;
    private bool isFirst = true;

    private float targetX;

    public void StartAtack()
    {
        if (isFirst)
        {
            startPos = transform.localPosition;
            isFirst = false;
        }
        MeshRenderer.enabled = true;
    }

    override public void UpdateObject()
    {
        if (isMoving)
        {
            MoveArrow();
            if (arrowInstance.transform.position.x < (targetX + 1f))
            {
                EnemyCharacter.Damage();
                isMoving = false;
            }
        }
    }

    private void MoveArrow()
    {
        Vector3 currentPos = arrowInstance.transform.position;
        arrowInstance.transform.RotateAround(centerPos, Vector3.back, -100 * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (arrowInstance != null)
        {
            Destroy(arrowInstance);
        }
    }

    // Возвращаем стрелу на место и вычисляем новые параметры для ее полета
    public void SpawnArrow(float targetX)
    {
        this.targetX = targetX;
        if (arrowInstance == null)
        {
            arrowInstance = Instantiate(gameObject, transform.position, transform.rotation) as GameObject;
        }
        else
        {
            arrowInstance.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
        arrowInstance.transform.localScale = gameObject.transform.lossyScale;
        MeshRenderer.enabled = false;
        var transformPosition = transform.position;
        float distance = Mathf.Abs(targetX - transformPosition.x);
        float centerX = transformPosition.x - distance / 2;
        // Центр стрелы, вокруг которого она летит
        centerPos = new Vector3(centerX, transformPosition.y - 11, 0);
        isMoving = true;
        Vector3 addAngle = new Vector3(-20, 0f, 0f);
        arrowInstance.transform.Rotate(addAngle);
    }
}