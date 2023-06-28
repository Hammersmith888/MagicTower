
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugTools
{
    public static void DrawCross(Vector3 point, float lineLength, Color color, float duration)
    {
        Debug.DrawLine(point + Vector3.up * lineLength, point - Vector3.up * lineLength, color, duration);
        Debug.DrawLine(point + Vector3.left * lineLength, point - Vector3.left * lineLength, color, duration);
    }

    public static void DrawRect(Vector3 center, Vector2 halfSize, Color color, float duration)
    {
        Debug.DrawLine(center + new Vector3(-halfSize.x, -halfSize.y), center + new Vector3(-halfSize.x, halfSize.y), color, duration);//LeftLine
        Debug.DrawLine(center + new Vector3(halfSize.x, -halfSize.y), center + new Vector3(halfSize.x, halfSize.y), color, duration);//RightLine
        Debug.DrawLine(center + new Vector3(-halfSize.x, halfSize.y), center + new Vector3(halfSize.x, halfSize.y), color, duration);//TopLine
        Debug.DrawLine(center + new Vector3(-halfSize.x, -halfSize.y), center + new Vector3(halfSize.x, -halfSize.y), color, duration);//BotLine
    }

    public static void DebugStringChars(this string s)
    {
        System.Text.StringBuilder debugString = new System.Text.StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            debugString.AppendLine(s[i] + "  " + (int)s[i]);
        }
        Debug.Log(debugString.ToString());
    }

    public static void DebugStrings(this string[] stringsArray)
    {
        System.Text.StringBuilder debugString = new System.Text.StringBuilder();
        for (int i = 0; i < stringsArray.Length; i++)
        {
            debugString.AppendLine(stringsArray[i]);
        }
        Debug.Log(debugString.ToString());
    }

    public static void DebugCollection<T>(this IEnumerable<T> collection, bool addIndex = false)
    {
        System.Text.StringBuilder debugString = new System.Text.StringBuilder();
        int index = 0;
        foreach (var value in collection)
        {
            if (addIndex)
            {
                debugString.AppendLine(index + ": " + value.ToString());
            }
            else
            {
                debugString.AppendLine(value.ToString());
            }
            index++;
        }
        Debug.Log(debugString.ToString());
    }
}
