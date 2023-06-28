using UnityEngine;
using System.Collections;

public class SpellBase : BaseUpdatableObject, IOutOfGameFieldEventReceiver
{
    public Sprite icon; // Иконка заклинания в интерфейсе
    public float rechargeTime; // Время перезарядки заклинания
    public int manaValue; // Требуемое количество маны
    public float timeOfSecondEffect;

    protected bool currentlyOnField = true;

    protected const float GAME_FIELD_WIDTH_IN_UNITS = 13f; // Ширина игрового поля в юнитах
    const float DISABLE_DELAY = 0.8f;

    public bool isDestroy = true;

    private static float defaultMaxShotFlyDistance = 0;
    public static float DefaultMaxShotFlyDistance
    {
        get
        {
            if (defaultMaxShotFlyDistance == 0)
            {
                Camera cam = Camera.main;
                float heightCamera = 2f * cam.orthographicSize;
                float widthCamera = heightCamera * cam.aspect;
                defaultMaxShotFlyDistance = ((cam.transform.position.x + widthCamera / 2) - ShotController.Current.StartPositionShotX);
            }
            return defaultMaxShotFlyDistance;
        }
    }
    virtual public void OnOutOfGameField()
    {
        //Debug.Log( "OnOutOfGameField " + gameObject.name );
        currentlyOnField = false;
        Collider2D _collider = GetComponent<Collider2D>();
        if (_collider != null)
        {
            _collider.enabled = false;
        }
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(DISABLE_DELAY);
        UnregisterFromUpdate();
        if(isDestroy)
            Destroy(gameObject);//TODO: Add Object Pooling logic
    }
}
