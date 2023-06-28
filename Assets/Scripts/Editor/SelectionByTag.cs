using UnityEngine;
using UnityEditor;

public class SelectionByTag : EditorWindow
{
    [MenuItem("GameObject/SelectWithTag", false, 13)]
    static void SelectWithTag()
    {
        SelectionByTag window = GetWindow<SelectionByTag>();
        window.Show();
    }

    private string selectedTag;
    private void OnGUI()
    {
        selectedTag = EditorGUILayout.TextField("Tag:", selectedTag);
        if (GUILayout.Button("Search"))
        {
            Selection.objects = GameObject.FindGameObjectsWithTag(selectedTag);
            Close();
        }
    }
}
