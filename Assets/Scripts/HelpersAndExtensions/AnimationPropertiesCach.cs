using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPropertiesCach
{
    public class AnimProperty
    {
        private int propertyID;

        public AnimProperty(string propertyName)
        {
            propertyID = Animator.StringToHash(propertyName);
        }

        public static implicit operator int(AnimProperty animProperty)
        {
            return animProperty.propertyID;
        }
    }

    //Related to characters
    public AnimProperty walkAnim;
    public AnimProperty runAnim;
    public AnimProperty jumpForwardAnimation;
    public AnimProperty jumpBackwardAnimation;
    public AnimProperty attackAnimation;
    public AnimProperty shootAnim;
    public AnimProperty specialMoveAnim;
    public AnimProperty summonAnim;
    public AnimProperty spawnAnim;
    public AnimProperty enrageAnim;
    public AnimProperty enrageAnim2;
    public AnimProperty getHitAnim;
    public AnimProperty crawlAnim;
    public AnimProperty rollAnim;
    public AnimProperty lostShieldAnim;
    public AnimProperty deathAnim;
    public AnimProperty deathAnim2;

    public AnimProperty attackOneAnim;
    public AnimProperty attackTwoAnim;
    public AnimProperty undirectedAnim;
    public AnimProperty iceBreathAnim;

    //Objects and UI related
    public AnimProperty restartAnim;
    public AnimProperty openCasketAnim;
    public AnimProperty disappearingAnim;

    private static AnimationPropertiesCach _instance;
    public static AnimationPropertiesCach instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AnimationPropertiesCach();
            }
            return _instance;
        }
    }

    public AnimationPropertiesCach()
    {
        walkAnim = new AnimProperty("walk");
        runAnim = new AnimProperty("run");
        jumpForwardAnimation = new AnimProperty("jumpforward");
        jumpBackwardAnimation = new AnimProperty("jumpbackward");
        attackAnimation = new AnimProperty("attack");
        shootAnim = new AnimProperty("shoot");
        specialMoveAnim = new AnimProperty("specialMove");
        getHitAnim = new AnimProperty("getHit");
        summonAnim = new AnimProperty("summer");
        spawnAnim = new AnimProperty("spawn");
        enrageAnim = new AnimProperty("enrage");
        enrageAnim2 = new AnimProperty("enrage2");
        lostShieldAnim = new AnimProperty("shieldLost");
        crawlAnim = new AnimProperty("crawl");
        rollAnim = new AnimProperty("roll");
        deathAnim = new AnimProperty("die");
        deathAnim2 = new AnimProperty("Die");

        attackOneAnim = new AnimProperty("Attack1");
        attackTwoAnim = new AnimProperty("Attack2");
        undirectedAnim = new AnimProperty("Undirected");
        iceBreathAnim = new AnimProperty("IceBreath");

        restartAnim = new AnimProperty("restart");
        openCasketAnim = new AnimProperty("open_casket");
        disappearingAnim = new AnimProperty("disappering");
    }

}
