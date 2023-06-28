
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static float SimpleAbs(this float f)
    {
        return f > 0 ? f : -f;
    }

    public static void GetComponentIfNull<T>(this GameObject gameObj, ref T result) where T : Component
    {
        if (result == null)
        {
            result = gameObj.GetComponent<T>();
        }
    }

    public static void GetComponentIfNull<T>(this Behaviour behaviour, ref T result) where T : Component
    {
        if (result == null)
        {
            result = behaviour.GetComponent<T>();
        }
    }

    public static Transform FindChildWithNameNonRecursive(this Transform transform, string name)
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (transform.GetChild(i).name.Equals(name))
            {
                return transform.GetChild(i);
            }
        }
        return null;
    }

    public static T FindChildWithName<T>(this Transform transform, string name, bool recursive = true) where T : Component
    {
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (transform.GetChild(i).name.Equals(name))
            {
                return transform.GetChild(i).GetComponent<T>();
            }
            else if (recursive)
            {
                var result = transform.GetChild(i).FindChildWithName<T>(name, recursive);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }


    public static Canvas GetFirstRootCanvasInParent(this Transform transform)
    {
        Canvas[] canvasInParent = transform.GetComponentsInParent<Canvas>();
        for (int i = 0; i < canvasInParent.Length; i++)
        {
            if (canvasInParent[i].isRootCanvas)
            {
                return canvasInParent[i];
            }
        }
        return null;
    }

    public static void SetLayerForAllInChildAndParen(this GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        var transform = gameObject.transform;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child != null)
            {
                child.gameObject.SetLayerForAllInChildAndParen(layer);
            }
        }
    }

    public static void SetLayerForAllInChildAndParen(this GameObject gameObject, int layer, out Dictionary<int, int> oldLayersData)
    {
        oldLayersData = new Dictionary<int, int>();
        oldLayersData.Add(gameObject.GetInstanceID(), gameObject.layer);
        gameObject.layer = layer;
        var transform = gameObject.transform;
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child != null)
            {
                child.gameObject.SetLayerForAllInChildAndParen(layer);
            }
        }
        //foreach (var x in gameObject.transform.GetComponentsInChildren<Transform>())
        //    x.gameObject.gameObject.SetLayerForAllInChildAndParen(layer);
    }

    public static void SetLayersForAllInChildAndParen(this GameObject gameObject, Dictionary<int, int> layersData)
    {
        int layer;
        if (layersData.TryGetValue(gameObject.GetInstanceID(), out layer))
        {
            gameObject.layer = layer;
        }
        //var transform = gameObject.transform;
        //var childCount = transform.childCount;
        //for (int i = 0; i < childCount; i++)
        //{
        //    var child = transform.GetChild(i);
        //    if (child != null)
        //    {
        //        child.gameObject.SetLayersForAllInChildAndParen(layersData);
        //    }
        //}
        foreach(var x in gameObject.transform.GetComponentsInChildren<Transform>())
            x.gameObject.gameObject.SetLayerForAllInChildAndParen(layer);
    }

    public static void ToggleComponent<T>(this GameObject gameObject, bool enabled) where T : Behaviour
    {
        T component = gameObject.GetComponent<T>();
        if (component != null)
        {
            component.enabled = enabled;
        }
    }

    public static void ToggleColiders<T>(this GameObject gameObject, bool enabled) where T : Collider
    {
        var components = gameObject.GetComponents<T>();
        if (components != null)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].enabled = enabled;
            }
        }
    }

    public static void Toggle2DColiders<T>(this GameObject gameObject, bool enabled) where T : Collider2D
    {
        var components = gameObject.GetComponents<T>();
        if (components != null)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i].enabled = enabled;
            }
        }
    }

    public static bool IsAnimationClipCurrentlyPlaying(this Animator animator, string animClipName, int layerIndex = 0)
    {
        AnimatorClipInfo[] animatorsClipsInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
        for (int i = 0; i < animatorsClipsInfo.Length; i++)
        {
            if (string.Equals(animatorsClipsInfo[i].clip.name, animClipName, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public static bool HasParameter(this Animator animator, string paramName)
    {
        if (animator == null)
        {
            return false;
        }
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == paramName)
            {
                return true;
            }
        }
        return false;
    }

    public static bool HasParameter(this Animator animator, int nameHash)
    {
        if (animator == null)
        {
            return false;
        }
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.nameHash == nameHash)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsNullOrEmpty<T>(this T[] array)
    {
        return array == null || array.Length == 0;
    }

    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null || list.Count == 0;
    }

    public static void InvokeSafely(this System.Action action)
    {
        if (action != null)
        {
            action();
        }
    }

    public static void InvokeSafely<T1>(this System.Action<T1> action, T1 t1)
    {
        if (action != null)
        {
            action(t1);
        }
    }

    public static void InvokeSafely<T1, T2>(this System.Action<T1, T2> action, T1 t1, T2 t2)
    {
        if (action != null)
        {
            action(t1, t2);
        }
    }

    public static byte[] GetBytes(this string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

    public static string GetString(this byte[] bytes)
    {
        char[] chars = new char[bytes.Length / sizeof(char)];
        System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        return new string(chars);
    }


    public static Vector3 MultiplyVector3(this Vector3 vector3, Vector3 multiplyBy)
    {
        vector3.x *= multiplyBy.x;
        vector3.y *= multiplyBy.y;
        vector3.z *= multiplyBy.z;
        return vector3;
    }

    public static Vector3 GetRectUpperLeftRectCorner(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.rect.size;
        Vector2 pivot = rectTransform.pivot;
        Vector3 offset = new Vector3(Mathf.LerpUnclamped(sizeDelta.x, -sizeDelta.x, pivot.x) / 2f, Mathf.LerpUnclamped(sizeDelta.y, -sizeDelta.y, pivot.y) / 2f, 0f);
        offset.x -= sizeDelta.x / 2f;
        offset.y += sizeDelta.y / 2f;
        return rectTransform.position + offset;
    }

    public static Vector3 GetRectUpperRightRectCorner(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.rect.size;
        Vector2 pivot = rectTransform.pivot;
        Vector3 offset = new Vector3(Mathf.LerpUnclamped(sizeDelta.x, -sizeDelta.x, pivot.x) / 2f, Mathf.LerpUnclamped(sizeDelta.y, -sizeDelta.y, pivot.y) / 2f, 0f);
        offset.x += sizeDelta.x / 2f;
        offset.y += sizeDelta.y / 2f;
        return rectTransform.position + offset;
    }

    public static Vector3 GetRectCenter(this RectTransform rectTransform)
    {
        Vector2 sizeDelta = rectTransform.rect.size;
        Vector2 pivot = rectTransform.pivot;
        Vector3 offset = new Vector3(Mathf.LerpUnclamped(sizeDelta.x, -sizeDelta.x, pivot.x) / 2f, Mathf.LerpUnclamped(sizeDelta.y, -sizeDelta.y, pivot.y) / 2f, 0f);
        return rectTransform.position + offset;
    }

    /// <summary>
    /// normalizedOffsetFactor is multiplicator, each parameter must be from 0 to 1
    /// resulting position will be offsetted by rectSize * normalizedOffsetFactor
    /// </summary>
    public static Vector3 GetRectCenter(this RectTransform rectTransform, Vector2 normalizedOffsetFactor)
    {
        Vector2 sizeDelta = rectTransform.rect.size;
        Vector2 pivot = rectTransform.pivot;
        Vector3 offset = new Vector3(Mathf.LerpUnclamped(sizeDelta.x, -sizeDelta.x, pivot.x) / 2f, Mathf.LerpUnclamped(sizeDelta.y, -sizeDelta.y, pivot.y) / 2f, 0f);
        offset.x += sizeDelta.x * normalizedOffsetFactor.x;
        offset.y += sizeDelta.y * normalizedOffsetFactor.y;
        return rectTransform.position + offset;
    }

    public static void DisableParticlesEmission(this GameObject obj)
    {
        ParticleSystem[] particleSystems = obj.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particleSystems.Length; i++)
        {
            ParticleSystem.EmissionModule emissionModule = particleSystems[i].emission;
            emissionModule.enabled = false;
        }
    }

    public static Coroutine CallActionAfterDelayWithCoroutine(this MonoBehaviour monoBehaviour, float delay, System.Action callback, bool unscaledTime = false)
    {
        try
        {
            if (monoBehaviour.gameObject.activeSelf)
            {
                if (callback == null)
                {
                    Debug.Log("CALLBACK IS NULL");
                    return null;
                }
                return monoBehaviour.StartCoroutine(CallbackCoroutine(delay, callback, unscaledTime));
            }
            
            Debug.Log("Action Coroutine Delay IS NULL");
            return null;
        }
        catch (Exception)
        {
            Debug.Log("Action Coroutine Delay IS NULL");
            return null;
        }
    }

    public static Coroutine PlayAlphaFadeout(this MonoBehaviour monoBehaviour, IColorHolder colorHolder, float animTime)
    {
        return monoBehaviour.StartCoroutine(AlphaFadeoutCoroutine(colorHolder, animTime));
    }

    private static IEnumerator AlphaFadeoutCoroutine(IColorHolder colorHolder, float animTime)
    {
        float timer = 0;
        float startAlpha = colorHolder.alpha;
        while (timer < animTime)
        {
            timer += Time.deltaTime;
            colorHolder.alpha = Mathf.Lerp(startAlpha, 0, timer / animTime);
            yield return null;
        }
    }

    private static IEnumerator CallbackCoroutine(float delay, System.Action callback, bool unscaledTime = false)
    {
        if (unscaledTime)
        {
            if (delay > 0)
            {
                yield return new WaitForSecondsRealtime(delay);
            }
        }
        else
        {
            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }
        }
        callback.InvokeSafely();
    }

    #region DEBUG
    public static void DebugObjectHierarchy(this GameObject obj)
    {
        DebugObjectHierarchy(obj.transform);
    }

    public static void DebugObjectHierarchy(this Transform transform)
    {
        string nextSymbol = " -> ";
        System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
        strBuilder.AppendFormat("DebugObjectHierarchy: {0}", transform.name);
        strBuilder.AppendLine("");
        while (transform.parent != null)
        {
            strBuilder.Append(transform.name);
            transform = transform.parent;
            if (transform.parent != null)
            {
                strBuilder.Append(nextSymbol);
            }
        }
        Debug.Log(strBuilder.ToString());
    }
    #endregion

    public static void StopAnimator(this Animator animator)
    {
        animator.enabled = false;
    }

}
