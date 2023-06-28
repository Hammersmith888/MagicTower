using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronsourceGotCreditsUI : MonoBehaviour
{
    [SerializeField] Text _creditsAmount;
    [SerializeField] ParticleSystem _coinsParticles;

    public Text CreditsAmount
    {
        get => _creditsAmount;
        set => _creditsAmount = value;
    }

    public ParticleSystem CoinsParticles
    {
        get => _coinsParticles;
        set => _coinsParticles = value;
    }
}
