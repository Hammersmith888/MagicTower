using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] Text text;
    public Button button;
    [SerializeField]
    Animator _anim;
    public UnityAction _action;

    public bool GetValue => _anim.GetBool("active");

    public void Set(bool value)
    {
        _anim.speed = 2;
        _anim.SetBool("active", value);
        text.text = value ? TextSheetLoader.Instance.GetString("t_0269") : TextSheetLoader.Instance.GetString("t_0270");
        SoundController.Instanse.windowsActivitySFX.Play();
    }

    public void SetDefault(bool value)
    {
        _anim.speed = 1000;
        _anim.SetBool("active", value);
        text.text = value ? TextSheetLoader.Instance.GetString("t_0269") : TextSheetLoader.Instance.GetString("t_0270");
    }

    public void Set()
    {
        _anim.speed = 2;
        _anim.SetBool("active", !_anim.GetBool("active"));
        text.text = _anim.GetBool("active") ? TextSheetLoader.Instance.GetString("t_0269") : TextSheetLoader.Instance.GetString("t_0270");

        if (_action != null)
            _action();
        SoundController.Instanse.windowsActivitySFX.Play();
    }
}
