using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnLang : MonoBehaviour
{
    [SerializeField] private RectTransform pos;
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetString("CurrentLanguage"))
        {
            case "English":
            pos.localPosition = new Vector3(188,-288.8f,0);
                break;
            case "Russian":
            pos.localPosition = new Vector3(158,-288.8f,0);
                break;
            case "German":
            pos.localPosition = new Vector3(86,-288.8f,0);
                break;
            case "Spanish":
            pos.localPosition = new Vector3(196,-288.8f,0);
                break;
            case "Japanese":
            pos.localPosition = new Vector3(140,-288.8f,0);
                break;
            case "Chinese":
            pos.localPosition = new Vector3(242,-288.8f,0);
                break;
            case "Korean":
            pos.localPosition = new Vector3(200,-288.8f,0);
                break;
            default:
                pos.localPosition = new Vector3(188,-288.8f,0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
