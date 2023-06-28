using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedMaterialsStorage
{
    private static Dictionary<int,Material> MaterialsStorage = new Dictionary<int, Material>();

    public static Material GetMaterialFromStorage(Material source, Shader shader)
    {
        Material material;
        var instanceID = source.GetInstanceID();
        if (!MaterialsStorage.TryGetValue(instanceID, out material))
        {
            //Debug.LogFormat("New material created {0}. Shader {1}", source.name, shader.name);
            material = new Material(source);
#if UNITY_EDITOR
            material.name += "_Instance";
#endif
            material.shader = shader;
            MaterialsStorage.Add(instanceID, material);
        }
        return material;
    }

    public static void Clear()
    {
        if (MaterialsStorage != null)
        {
            foreach (var material in MaterialsStorage.Values)
            {
                if (material != null)
                {
                    Material.Destroy(material);
                }
            }
        }
        MaterialsStorage.Clear();
    }
}
