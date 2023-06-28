using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugEnableObject : MonoBehaviour
{
    [SerializeField] private Image ButtonImage;
    [SerializeField] private Sprite GreenButton;
    [SerializeField] private Sprite GreyButton;
    [SerializeField] private Text CombineText;
    [SerializeField] private Color CombineTextNormalColor;
    [SerializeField] private Color CombineTextNotActiveColor;
    private void OnEnable()
    {
        PlayerPrefs.SetInt("FirstShowDark", 1);
        // if (!PlayerPrefs.HasKey("FirstShowDark"))
        // {
        //     ButtonImage.sprite = GreyButton;
        //     CombineText.color = CombineTextNotActiveColor;
        //     PlayerPrefs.SetInt("FirstShowDark",1);
        // }
        // else
        // {
            ButtonImage.sprite = GreenButton;
            CombineText.color = CombineTextNormalColor;
      //  }

        Debug.Log($"debug object ENABLE", gameObject);
    }

    private void OnDisable()
    {
        Debug.Log($"debug object DISABLE", gameObject);
    }
}
