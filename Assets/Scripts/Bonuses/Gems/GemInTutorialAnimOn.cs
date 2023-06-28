using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemInTutorialAnimOn : MonoBehaviour
{
    public Animation _animation;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayAnimationOnTutorial"))
            return;

        _animation.Play();
        PlayerPrefs.SetInt("PlayAnimationOnTutorial", 1);
    }
}