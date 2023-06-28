
using UnityEngine;

public abstract class MaterialProperty<T>
{
    [SerializeField]
    protected string propertyName;
    [SerializeField]
    protected T propertyValue;

    protected int propertyID;

    public void CachPropertyID()
    {
        propertyID = Shader.PropertyToID(propertyName);
    }

    public abstract void ApplyToMaterial(Material material);

    public abstract void ApplyToPropertiesBlock(MaterialPropertyBlock propertyBlock);
}

[System.Serializable]
public class FloatMaterialProperty : MaterialProperty<float>
{
    public override void ApplyToMaterial(Material material)
    {
        material.SetFloat(propertyID, propertyValue);
    }

    public override void ApplyToPropertiesBlock(MaterialPropertyBlock propertyBlock)
    {
        propertyBlock.SetFloat(propertyID, propertyValue);
    }
}


[System.Serializable]
public class ColorMaterialProperty : MaterialProperty<Color>
{
    public override void ApplyToMaterial(Material material)
    {
        material.SetColor(propertyID, propertyValue);
    }

    public override void ApplyToPropertiesBlock(MaterialPropertyBlock propertyBlock)
    {
        propertyBlock.SetColor(propertyID, propertyValue);
    }
}


[System.Serializable]
public class TextureMaterialProperty : MaterialProperty<Texture2D>
{
    public override void ApplyToMaterial(Material material)
    {
        material.SetTexture(propertyID, propertyValue);
    }

    public override void ApplyToPropertiesBlock(MaterialPropertyBlock propertyBlock)
    {
        propertyBlock.SetTexture(propertyID, propertyValue);
    }
}

public static class MaterialPropertiesExtensions
{
    public static void ApplyMaterialPropertiesArray<T>(this MaterialProperty<T>[] materialProperties, Material materialToApply)
    {
        for (int i = 0; i < materialProperties.Length; i++)
        {
            materialProperties[i].ApplyToMaterial(materialToApply);
        }
    }

    public static void ApplyMaterialPropertiesArray<T>(this MaterialProperty<T>[] materialProperties, MaterialPropertyBlock propertyBlock)
    {
        for (int i = 0; i < materialProperties.Length; i++)
        {
            materialProperties[i].ApplyToPropertiesBlock(propertyBlock);
        }
    }

    public static void CachMaterialPropertiesID<T>(this MaterialProperty<T>[] materialProperties)
    {
        for (int i = 0; i < materialProperties.Length; i++)
        {
            materialProperties[i].CachPropertyID();
        }
    }
}
