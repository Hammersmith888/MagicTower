using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAnimationWithMaterial : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider;
    [SerializeField] 
    private SpriteRenderer shadow;
    [SerializeField]
    private Renderer[] renderers;
    [SerializeField]
    private ShaderWithMaterialPropertiesData newMaterialPropertiesData;
    [SerializeField]
    private string materialAnimPropertyName;
    [SerializeField]
    private GameObject auraAnimation;
    [SerializeField]
    private GameObject summonBorder;
    [SerializeField]
    private float summinAnimLength;
    //[HideInInspector]
    public bool dontUse = true;

    void Start()
    {
        StartEffect();
    }

    public void StartEffect(UnityEngine.Events.UnityAction postAction = null)
    {
        if (dontUse)
        {
            if (auraAnimation != null)
            {
                auraAnimation.SetActive(false);
            }
            this.enabled = false;
            return;
        }
        if (auraAnimation != null)
        {
            auraAnimation.SetActive(true);
        }
        StartCoroutine(SummonAnimatonCycle(postAction));
    }

    private IEnumerator SummonAnimatonCycle(UnityEngine.Events.UnityAction postAction = null)
    {
        int materialAnimPropertyID = Shader.PropertyToID(materialAnimPropertyName);
        Material[] savedMaterials = new Material[renderers.Length];
        Material[] temporaryMaterials = new Material[renderers.Length];
        int i;
        int length = savedMaterials.Length;
        for (i = 0; i < length; i++)
        {
            savedMaterials[i] = renderers[i].sharedMaterial;
            temporaryMaterials[i] = renderers[i].material;
            if (temporaryMaterials[i] != null && newMaterialPropertiesData != null)
            {
                newMaterialPropertiesData.ApplyProperties(temporaryMaterials[i]);
            }
            else
            {
                if (postAction != null)
                {
                    postAction.Invoke();
                }
                yield break;
            }
        }

        float startAnimTime = Time.time;
        float timeElapsed = Time.time - startAnimTime;


        

        while (timeElapsed < summinAnimLength)
        {
            if (shadow != null)
            {
                Color col = shadow.color;
                shadow.color = new Color(col.r, col.g, col.b, Mathf.Clamp(timeElapsed/summinAnimLength, 0f, 1f));
            }
           
            
            timeElapsed = Time.time - startAnimTime;
            for (i = 0; i < length; i++)
            {
                temporaryMaterials[i].SetFloat(materialAnimPropertyID, 1f - (timeElapsed / summinAnimLength));
            }
            yield return null;
        }

        for (i = 0; i < length; i++)
        {
            renderers[i].sharedMaterial = savedMaterials[i];
        }

        if (postAction != null)
        {
            postAction.Invoke();
        }

    }

    private IEnumerator DissapearAnimationCycle(UnityEngine.Events.UnityAction actionOnEnd)
    {
        int materialAnimPropertyID = Shader.PropertyToID(materialAnimPropertyName);
        Material[] savedMaterials = new Material[renderers.Length];
        Material[] temporaryMaterials = new Material[renderers.Length];
        int i;
        int length = savedMaterials.Length;
        for (i = 0; i < length; i++)
        {
            savedMaterials[i] = renderers[i].material;
            temporaryMaterials[i] = renderers[i].sharedMaterial;
            if (temporaryMaterials[i] != null && newMaterialPropertiesData != null)
            {
                newMaterialPropertiesData.ApplyProperties(savedMaterials[i]);
            }
            else
            {
                yield break;
            }
        }

        float startAnimTime = Time.time;
        float timeElapsed = Time.time - startAnimTime;

        while (timeElapsed < summinAnimLength)
        {
            if (shadow != null)
            {
                Color col = shadow.color;
                shadow.color = new Color(col.r, col.g, col.b, Mathf.Clamp(1 - timeElapsed/summinAnimLength, 0f, 1f));
            }
            
            timeElapsed = Time.time - startAnimTime;
            for (i = 0; i < length; i++)
            {
                temporaryMaterials[i].SetFloat(materialAnimPropertyID, (timeElapsed / summinAnimLength));
            }
            yield return null;
        }

        for (i = 0; i < length; i++)
        {
            renderers[i].sharedMaterial = savedMaterials[i];
        }

        if (actionOnEnd != null)
        {
            actionOnEnd.Invoke();
        }

        yield break;
    }

    public void StartHideEffect(UnityEngine.Events.UnityAction actionOnEnd)
    {
        StartCoroutine(DissapearAnimationCycle(actionOnEnd));
    }
}
