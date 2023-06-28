
using UnityEngine;

public class CloudObject : MonoBehaviour, IPoolObject
{
    public static event System.Action<int> OnCloudDisabled;

    [SerializeField]
    private Animations.AlphaColorAnimation alphaColorAnimation;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Transform transformComponent;

    private float   moveSpeed;
    private float   fadeOutXBorder;
    private int     layer;

    public bool canBeUsed
    {
        get
        {
            return !gameObject.activeSelf;
        }
    }

    public void Init()
    {
        transformComponent = transform;
        this.GetComponentIfNull(ref spriteRenderer);
        this.GetComponentIfNull(ref alphaColorAnimation);
        gameObject.SetActive(false);
    }

    public void Spawn(Sprite sprite, Vector3 position, float moveSpeed, float fadeOutXBorder, int layer)
    {
        spriteRenderer.sprite = sprite;
        transformComponent.position = position;
        this.moveSpeed = moveSpeed;
        this.fadeOutXBorder = fadeOutXBorder;
        this.layer = layer;
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        gameObject.SetActive(true);
        alphaColorAnimation.Animate();
    }

    public void UpdateCloud(float timeDelta)
    {
        var position = transformComponent.position + new Vector3(moveSpeed * timeDelta, 0f, 0f);
        transformComponent.position = position;
        if (position.x > fadeOutXBorder)
        {
            gameObject.SetActive(false);
            OnCloudDisabled.InvokeSafely(layer);
        }
    }

}
