using UnityEngine;

public class UsePowerPotion : MonoBehaviour
{
    public static UsePowerPotion Current;
    [SerializeField] private GameObject effect;
    [SerializeField] private Transform centerPosition;
    void Start()
    {
        Current = this;
    }

    public void SpawnPotionEffect()
    {
        Instantiate(effect, centerPosition.position, Quaternion.identity, transform);
    }
}
