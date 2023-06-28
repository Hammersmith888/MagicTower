using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class EditorExtensions
{
    public static string GetValueAsStringValue(this SerializedProperty property)
    {
        switch (property.propertyType)
        {
            case SerializedPropertyType.AnimationCurve:
                return property.animationCurveValue.ToString();

            case SerializedPropertyType.Boolean:
                return property.boolValue.ToString();

            case SerializedPropertyType.Enum:
                if (property.enumValueIndex < 0)
                {
                    property.enumValueIndex = 0;
                }
                return property.enumNames[property.enumValueIndex];

            case SerializedPropertyType.Integer:
                return property.intValue.ToString();

            case SerializedPropertyType.Float:
                return property.floatValue.ToString();

            case SerializedPropertyType.String:
                return property.stringValue;

            case SerializedPropertyType.Quaternion:
                return property.quaternionValue.ToString();

            case SerializedPropertyType.Vector4:
                return property.vector4Value.ToString();

            case SerializedPropertyType.Vector3:
                return property.vector3Value.ToString();

            case SerializedPropertyType.Vector2:
                return property.vector2Value.ToString();

        }
        return string.Format("Value of type: {0} not implemented", property.propertyType);
    }

    public static string GetPropertyParentPath(this SerializedProperty serializedProperty)
    {
        int indexOfPoint = serializedProperty.propertyPath.LastIndexOf('.') + 1;
        return serializedProperty.propertyPath.Substring(0, indexOfPoint);
    }

    public static SerializedProperty FindPropertyOnSameLevelWithCurrent(this SerializedProperty serializedProperty, string propertyName)
    {
        //Debug.Log(serializedProperty.GetPropertyParentPath() + propertyName);
        return serializedProperty.serializedObject.FindProperty(serializedProperty.GetPropertyParentPath() + propertyName);
    }

    public static SerializedProperty FindPropertyInParent(this SerializedProperty serializedProperty, string propertyName)
    {
        string currentPath = serializedProperty.propertyPath;
        int indexOfPoint = currentPath.LastIndexOf('.') + 1;
        currentPath = currentPath.Substring(0, indexOfPoint);
        SerializedProperty result = null;
        int k = 0;
        while (true)
        {
            k++;
            if (k > 50)
            {
                Debug.LogError("FindPropertyInParent over 50 cycles, force break called!");
                break;
            }

            result = serializedProperty.serializedObject.FindProperty(currentPath + propertyName);
            if (result == null)
            {
                currentPath = currentPath.Remove(indexOfPoint - 1, 1);
                indexOfPoint = currentPath.LastIndexOf('.') + 1;
                if (indexOfPoint == 0)
                {
                    break;
                }
                currentPath = currentPath.Substring(0, indexOfPoint);
            }
            else
            {
                break;
            }
        }
        return result;
    }
}
