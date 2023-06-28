using UnityEngine;
//This file must not be placed in the editor folder

public class ResourceFile : PropertyAttribute
{
	public string resourcesFolderPath;
}

public class AnimatorParameterAttribute : PropertyAttribute
{
	public AnimatorControllerParameterType parameterType = AnimatorControllerParameterType.Trigger;
	public string animatorPropertyName = "animator";
}

public class AnimatorHashParameterAttribute : AnimatorParameterAttribute
{
}

/*
public class TagsFieldAttr : PropertyAttribute
{
}


public class ComponentInChildAttribute : PropertyAttribute
{
    public Component componentType;
    public Transform parent;
}

public class BaseSceneObjectAttribute : PropertyAttribute
{
    public string tag = "";
    public string parent = "";
}

public class GameEffectAttr : PropertyAttribute
{}


public class AudioResourcesFile : ResourceFile
{
    public AudioResourcesFile( )
    {
        resourcesFolderPath = "Sounds";
    }
}

public class LocalizationAlias : PropertyAttribute
{
    public string language = "English";
}

public class GetComponentInEditor : PropertyAttribute
{
    public System.Type componentType;
}*/

