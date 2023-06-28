
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialPropertiesData.asset", menuName = "Custom/Create MaterialPropertiesData")]
public class MaterialPropertiesData : ScriptableObject
{
    [SerializeField]
    protected FloatMaterialProperty[ ]      floatMaterialProperties;
    [SerializeField]
    protected ColorMaterialProperty[ ]      colorMaterialProperties;
    [SerializeField]
    protected TextureMaterialProperty[ ]    textureMaterialProperties;

    private bool idsCached = false;

    protected void CachIdsIfNeeded()
    {
        if (!idsCached)
        {
            idsCached = true;
            floatMaterialProperties.CachMaterialPropertiesID();
            colorMaterialProperties.CachMaterialPropertiesID();
            textureMaterialProperties.CachMaterialPropertiesID();
        }
    }

    virtual public void ApplyProperties(Renderer renderer)
    {
        CachIdsIfNeeded();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        ApplyProperties(renderer, propertyBlock);
    }

    virtual public void ApplyProperties(Renderer[] renderers)
    {
        CachIdsIfNeeded();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

        for (int i = 0; i < renderers.Length; i++)
        {
            ApplyProperties(renderers[i], propertyBlock);
        }
    }

    virtual public void ApplyProperties(Material material)
    {
        CachIdsIfNeeded();
        floatMaterialProperties.ApplyMaterialPropertiesArray(material);
        colorMaterialProperties.ApplyMaterialPropertiesArray(material);
        textureMaterialProperties.ApplyMaterialPropertiesArray(material);
    }

    virtual public void ApplyProperties(Material[] materials)
    {
        CachIdsIfNeeded();
        for (int i = 0; i < materials.Length; i++)
        {
            floatMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
            colorMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
            textureMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
        }
    }

    protected void ApplyProperties(Renderer renderer, MaterialPropertyBlock propertyBlock)
    {
        renderer.GetPropertyBlock(propertyBlock);
        floatMaterialProperties.ApplyMaterialPropertiesArray(propertyBlock);
        colorMaterialProperties.ApplyMaterialPropertiesArray(propertyBlock);
        textureMaterialProperties.ApplyMaterialPropertiesArray(propertyBlock);
        renderer.SetPropertyBlock(propertyBlock);
    }
}
