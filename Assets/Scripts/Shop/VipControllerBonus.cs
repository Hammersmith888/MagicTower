using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VipControllerBonus : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(!SaveManager.GameProgress.Current.VIP);
    }


}
