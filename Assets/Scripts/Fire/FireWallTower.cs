using System;
using UnityEngine;

public class FireWallTower : MonoBehaviour
{
    [SerializeField]
    private FireWallShot[] fireWallUpgrade;

    float firewallDamageDivider = 1.3f; //retarted stuff

    void Start()
    {
        DecreaseFirewallUpgradeDamage();

        foreach (var firewall in fireWallUpgrade)
            firewall.isPlayerWall = true;
    }

    void DecreaseFirewallUpgradeDamage()
    {
        foreach (var firewall in fireWallUpgrade)
        {
            try
            {
                firewall.minDamage = (int)(firewall.minDamage / firewallDamageDivider);
                firewall.maxDamage = (int)(firewall.maxDamage / firewallDamageDivider);
                firewall.burnDamage = (int)(firewall.burnDamage / firewallDamageDivider);
                firewall.damageTimer = (int)(firewall.damageTimer * firewallDamageDivider);
            }
            catch (DivideByZeroException e)
            {
                Debug.Log($"{e.Message}, thats unfortunate.");
            }
        }
    }

    public FireWallShot SetFireWall()
    {
        LevelSettings levelSettings = GameObject.FindGameObjectWithTag("LevelSettings").GetComponent<LevelSettings>();
        if (levelSettings.upgradeItems[3].unlock && levelSettings.upgradeItems[3].upgradeLevel > 0)
        {

            return fireWallUpgrade[(int)levelSettings.upgradeItems[3].upgradeLevel - 1];
        }

        return null;
    }
}