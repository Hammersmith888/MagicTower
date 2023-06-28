using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildAnimator : MonoBehaviour
{
    private EnemyCharacter character;
    private DemonFatty demonFatty;
    private DemonBoss demonBoss;
    private DemonBomb demonBomb;
    private DemonGrunt demonGrunt;
    private GhoulGrotesque ghoulGrotesque;
    private GhoulFestering ghoulFestering;
    private GhoulScavenger ghoulScavenger;
    private GhoulBoss ghoulBoss;
    private SkeletonArcher skeletonArcher;
    private SkeletonMage skeletonMage;
    private SkeletonKing skeletonKing;
    private BurnedKing burnedKing;
    private ZombieMurderer zombieMurderer;
    // Use this for initialization
    void Start()
    {
        if (character == null)
        {
            if (transform.parent != null)
                character = transform.parent.GetComponent<EnemyCharacter>();
        }

        if (character == null)
        {
            character = GetComponent<EnemyCharacter>();
        }

        if (character != null)
        {
            demonFatty = character.GetComponent<DemonFatty>();
            demonBoss = character.GetComponent<DemonBoss>();
            demonBomb = character.GetComponent<DemonBomb>();
            demonGrunt = character.GetComponent<DemonGrunt>();
            ghoulGrotesque = character.GetComponent<GhoulGrotesque>();
            ghoulFestering = character.GetComponent<GhoulFestering>();
            ghoulScavenger = character.GetComponent<GhoulScavenger>();
            ghoulBoss = character.GetComponent<GhoulBoss>();
            skeletonArcher = character.GetComponent<SkeletonArcher>();
            skeletonMage = character.GetComponent<SkeletonMage>();
            skeletonKing = character.GetComponent<SkeletonKing>();
            burnedKing = character.GetComponent<BurnedKing>();
            zombieMurderer = character.GetComponent<ZombieMurderer>();
        }
    }

    void Anim_OnWalkAnimationStarted()
    { 
    }

    void Anim_OnCrawlAnimationStarted()
    {
    }

    void Anim_OnGetHitAnimationStarted()
    {
    }

    void Anim_OnGetHitAnimationFinished()
    {
        character.OnGetHitAnimationFinished();
    }

    void Anim_OnDeathAnimationStarted()
    {
    }

    public void Anim_OnDestroyEnemyTime()
    {
        character.DestroyEnemy();
    }

    void Anim_OnDeathAnimationFinished()
    {
        if (ghoulFestering != null)
            ghoulFestering.OnDeath();
        if (ghoulBoss != null)
            ghoulBoss.OnDeath();
        if (demonBoss != null)
            demonBoss.OnDeathAnimationFinished();
    }

    public void Anim_OnAttackAnimationStarted()
    {
        if (skeletonArcher != null)
            skeletonArcher.OnAttackAnimationStarted();
        if (ghoulScavenger != null)
            ghoulScavenger.OnAttackAnimationStarted();
        if (zombieMurderer != null)
            zombieMurderer.OnAttackAnimationStarted();
    }

    public void Anim_OnAtackAnimationFinished()
    {
        if (ghoulScavenger != null)
            ghoulScavenger.OnAttackAnimationFinished();
    }

    public void Anim_OnProjectileTime()
    {
        if (skeletonArcher != null)
            skeletonArcher.OnProjectileTime();
        if (ghoulScavenger != null)
            ghoulScavenger.OnProjectileTime();
        if (zombieMurderer != null)
            zombieMurderer.OnProjectileTime();
    }

    public void Anim_OnSummonTime()
    {
        if (skeletonMage != null)
            skeletonMage.OnSummonTime();
        if (skeletonKing != null)
            skeletonKing.OnSummonTime();
        if (burnedKing != null)
            burnedKing.OnSummonTime();
    }

    public void Anim_OnSummonAnimationFinished()
    {
        character.OnSummonAnimationFinished();
    }

    public void Anim_OnJumpAnimationStarted()
    {
        character.OnJumpAnimationStarted();
    }

    public void Anim_OnJumpAnimationFinished()
    {
    }

    public void Anim_OnLostShieldAnimationFinished()
    {
    }

    public void Anim_OnDamageTime()
    {
        character.Damage();
    }

    public void Anim_OnEnrageTime()
    {
        if (demonBoss != null)
            demonBoss.GiveAuras();
    }

    public void Anim_OnDemonBossEatTime()
    {
        if (demonBoss != null)
            demonBoss.EatSomeone();
    }

    public void Anim_OnDemonBossGrabTime()
    {
        //if (demonBoss != null)
        //    StartCoroutine(demonBoss.GrabSomeone());
    }

    public void Anim_OnEnrageAnimationFinished()
    {
        if (demonGrunt != null)
            demonGrunt.OnEnrageAnimationFinished();
        if (demonBoss != null)
            demonBoss.OnEnrageAnimationFinished();
    }

    public void Anim_OnSpawnAnimationFinished()
    {
    }

    public void Anim_OnExplosionTime()
    {
        if (demonBomb != null)
            demonBomb.Explode();
    }

    public void Anim_OnShootTime()
    {
        if (demonFatty != null)
            demonFatty.Action();
        if (ghoulGrotesque != null)
            ghoulGrotesque.Shooting();
        if (ghoulBoss != null)
            ghoulBoss.SpawnEnemy();
    }

    public void Anim_OnShootAnimationFinished()
    {
        character.OnShootAnimationFinished();
    }
}
