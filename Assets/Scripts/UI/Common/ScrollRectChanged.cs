using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectChanged : MonoBehaviour
{
    public ShopWearItemSettings wears;

    public void Change(Vector2 vector)
    {
        if (wears != null)
            wears.MovePanel();
    }
}
