
using UnityEngine;

public class BaseCollectableItem : BaseUpdatableObject
{
    const float Z_POSITION = -15f;
    [SerializeField]
    private UI.UIBattleElementPositionHolder.EUIElementType flyToUIElementType;
    [ SerializeField]
    private float flyAnimTime;
    [SerializeField]
    private AnimationCurve flyAnimCurve;

    private Vector3 moveFrom,moveTo;
    private UI.UIBattleElementPositionHolder uiElementHolder;
    private float flyAnimTimer;
    protected bool collected;
    protected Vector3 position;



    virtual protected void OnStartCollect() 
    {
        collected = true;
        uiElementHolder = UI.UIBattleElementPositionHolder.GetUIElementHolderByType(flyToUIElementType);
        moveFrom = transform.position;
        moveTo = uiElementHolder.getElementPosition;
        moveTo.z = Z_POSITION;
        flyAnimTimer = 0;
        Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.ON_ITEM_PICKED_BY_PLAYER, flyToUIElementType);
        if(mainscript.CurrentLvl == 2)
        {
            SoundController.Instanse.playDrobScrollSFX();
            flyAnimTime = 1;
        }
    }

    public override void UpdateObject()
    {
        if (collected)
        {
            UpdateFlyAnimation();
        }
    }

    virtual protected void UpdateFlyAnimation()
    {
        flyAnimTimer += Time.unscaledDeltaTime;
        position = transform.position;
        float animProgress = flyAnimTimer / flyAnimTime;
        //Debug.Log($"flyAnimTimer: {flyAnimTimer}, flyAnimTime: {flyAnimTime}");
        //Debug.Log($"moveFrom: {moveFrom}, moveTo: {moveTo}");
        position = Vector3.Lerp(moveFrom, moveTo, flyAnimCurve.Evaluate(animProgress));
        transform.position = position;
        if (animProgress >= 1f)
        {
            OnUIElementReached();
        }
    }

    virtual protected void OnUIElementReached()
    {
        uiElementHolder.OnItemReachedElementPosition();
    }

    public float FlyAnimTime
    {
        get
        {
            return flyAnimTime;
        }
    }
}
