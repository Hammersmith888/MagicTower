using UnityEngine;
using System.Collections;

public class MinesController : MonoBehaviour {

    public int lifeTime; // Время существования мины
    public int minDamage, maxDamage; // Минимальный и максимальный урон от мины
    public float radius; // Радиус коллайдера мины
    public int parts; // Количество мин
    public GameObject mine; // Объект-префаб мины

    // Границы (координаты) расположения мин
    private const float leftBorder = -3.5f;
    private const float rightBorder = 7.5f;
    private const float bottomBorder = -2.2f;
    private const float topBorder = 2.4f;

    private int setMines; // Количество уже установленных мин
    private Vector3 minePos; // Позиция мины

	void Start () {
        Destroy(gameObject, lifeTime);
        SetMines();
	}

    private void SetMines()
    {
        // Пока не будут установлены все мины
        // While потому что мина может быть не установлена с первого раза, так как вычисленная позиция пересекается с другой миной
        while (setMines < parts)
        {
            bool set = true; // Устанавливаем ил мины или ее позиция пересекается с уже установленными
            minePos = new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(bottomBorder, topBorder), -1.5f);

            // Проверяем пересечение с уже установленными минами
            GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
            for (int i=0; i<mines.Length; i++)
            {
                if (minePos.x < mines[i].transform.position.x + radius && minePos.x > mines[i].transform.position.x - radius && minePos.y < mines[i].transform.position.y + radius && minePos.y > mines[i].transform.position.y - radius)
                {
                    set = false;
                    break;
                } 
            }

            // Устанавливаем мину
            if (set)
            {
                GameObject mineObj = Instantiate(mine, minePos, Quaternion.identity) as GameObject;
                mineObj.transform.SetParent(gameObject.transform);
                mineObj.GetComponent<MinesScroll>().SetMineParam(Random.Range(minDamage, maxDamage), radius);
                setMines++;
            }  
        }
    }
}