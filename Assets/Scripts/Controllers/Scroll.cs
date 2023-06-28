
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Scroll
{
    public enum ScrollType { Acid, Barrier, FrostyAura, Minefield, Zombie, Haste, None }

    public ScrollType scrollType;
    public GameObject scrollPrefab; // Объект-префаб свитка
    public Transform scrollTrans; // Transform объекта-свитка в интерфейсе
    public Text scrollCountText; // Компонент-текст отображающий количество данных свитков
    public Image scrollIconImg; // Изображение объекта-свитка в интерфейсе
    public UI.NonRenderedGraphic raycastGraphick;

    private int scrollCount;

    public int ScrollCount
    {
        get
        {
            return scrollCount;
        }
        set
        {
            scrollCount = value;
            scrollCountText.text = scrollCount.ToString();

            // Проверяем количество оставшихся свитков (делаем иконку активной/неактивной, изменяем цвет)
            if (scrollCount > 0)
            {
                if (raycastGraphick != null && raycastGraphick.raycastTarget != null)
                {
                    raycastGraphick.raycastTarget = true;
                }
                scrollIconImg.color = new Color(1.0f, 1.0f, 1.0f);
                scrollCountText.color = new Color(1.0f, 1.0f, 1.0f);
            }
            else
            {
                raycastGraphick.raycastTarget = false;
                scrollIconImg.color = new Color(0.5f, 0.5f, 0.5f);
                scrollCountText.color = new Color(0.5f, 0.5f, 0.5f);
            }
        }
    }
}