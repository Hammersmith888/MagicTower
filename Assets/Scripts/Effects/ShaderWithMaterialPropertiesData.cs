using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShaderWithMaterialPropertiesData.asset", menuName = "Custom/Create ShaderWithMaterialPropertiesData")]
public class ShaderWithMaterialPropertiesData : MaterialPropertiesData
{
    [SerializeField]
    [Space(10f)]
    private Shader shader;

    public override void ApplyProperties(Renderer renderer)
    {
        ConvertAllMaterialsOnRenderer(renderer);
        base.ApplyProperties(renderer);
    }

    public override void ApplyProperties(Renderer[] renderers)
    {
        CachIdsIfNeeded();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();

        for (int i = 0; i < renderers.Length; i++)
        {
            ConvertAllMaterialsOnRenderer(renderers[i]);
            ApplyProperties(renderers[i], propertyBlock);
        }
    }

    override public void ApplyProperties(Material material)
    {
        material.shader = shader;
        base.ApplyProperties(material);
    }

    override public void ApplyProperties(Material[] materials)
    {
        CachIdsIfNeeded();
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].shader = shader;
            floatMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
            colorMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
            textureMaterialProperties.ApplyMaterialPropertiesArray(materials[i]);
        }
    }

    private void ConvertAllMaterialsOnRenderer(Renderer renderer)
    {
        var newMaterials = new Material[renderer.sharedMaterials.Length];
        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = SharedMaterialsStorage.GetMaterialFromStorage(renderer.sharedMaterials[i], shader);
        }
        renderer.sharedMaterials = newMaterials;
    }
}
