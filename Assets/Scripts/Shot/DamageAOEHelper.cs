using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageAOEHelper", menuName = "Custom/DamageAOEHelper")]
public class DamageAOEHelper : ScriptableObject
{

    private static DamageAOEHelper _instance;
    public static DamageAOEHelper Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<DamageAOEHelper>("DamageAOEHelper");
            }
            return _instance;
        }
    }


    [HideInInspector]
    public Transform mainTargetTransform;

    public float CalculatedAOEDamage(float incomeDamage, Transform targetTransform)
    {
        float lessModifier = 0.66f;
        if (targetTransform == mainTargetTransform)
        {
            return incomeDamage;
        }
        else
        {
            return incomeDamage * lessModifier;
        }
    }

    public int CalculatedAOEDamage(int incomeDamage, Transform targetTransform)
    {
        float lessModifier = 0.66f;
        if (targetTransform == mainTargetTransform)
        {
            return incomeDamage;
        }
        else
        {
            return (int)((float)incomeDamage * lessModifier);
        }
    }
}
