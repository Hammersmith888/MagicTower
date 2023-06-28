using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicroInfoResist : MonoBehaviour {
    [SerializeField]
    private OverUIPopup uIPopup;

    public Text descriptionText;

    public void OpenIt(string description)
    {
        descriptionText.text = description;

        if (uIPopup == null)
        {
            uIPopup = GetComponent<OverUIPopup>();
        }

        uIPopup.OpenIt(transform.position);
        uIPopup.placeObject.transform.SetParent(transform.parent.transform.parent);
    }
}
