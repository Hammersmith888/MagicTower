
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace DarkCrystal.Encased.Exp
{
    public class SceneSelector : EditorWindow
    {
        private const string AddedToFavoriteStar = "★";
        private const string NotAddedToFavoriteStar = "☆";

        private const string AddedToFavoritePrefsKeyFormat ="SceneSelectorFavorite_{0}";

        private List<string> scenes;
        private List<string> favoriteScenes;
        private readonly string[] pathsToIngore = new[] { "AdditionalExternalAssets", "Examples", "Demo" };

        private bool ShowOnlyAddedToBuild;
        private bool ShowFullScenePath;
        private Vector2 ScrollPosition = Vector2.zero;

        [MenuItem("Tools/SceneSelector")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            SceneSelector window = (SceneSelector)EditorWindow.GetWindow(typeof(SceneSelector));
            window.Show();
        }

        private void OnEnable()
        {
            ShowOnlyAddedToBuild = EditorPrefs.GetInt("showOnlyAddedToBuild", 0) == 1;
            ShowFullScenePath = EditorPrefs.GetInt("showFullScenePath", 0) == 1;
            if (ShowOnlyAddedToBuild)
            {
                int scenesCountInBuildSettings = EditorBuildSettings.scenes.Length;
                scenes = new List<string>(scenesCountInBuildSettings);
                for (int i = 0; i < scenesCountInBuildSettings; i++)
                {
                    scenes.Add(EditorBuildSettings.scenes[i].path);
                }
            }
            else
            {
                scenes = new List<string>
                (
                    AssetDatabase.GetAllAssetPaths().Where(s => s.EndsWith(".unity") && !pathsToIngore.Any(@string => s.Contains(@string)))
                );
            }
            favoriteScenes = new List<string>();
            int count = scenes.Count;
            for (int i = 0; i < count; i++)
            {
                if (EditorPrefs.GetInt(string.Format(AddedToFavoritePrefsKeyFormat, scenes[i]), 0) == 1)
                {
                    favoriteScenes.Add(scenes[i]);
                    scenes.RemoveAt(i);
                    i--;
                    count--;
                }
            }
        }

        private void OnGUI()
        {
            string[] temp;
            bool newVal = GUILayout.Toggle(ShowOnlyAddedToBuild, "Show only added to build settings");
            ShowFullScenePath = GUILayout.Toggle(ShowFullScenePath, "Show full scene path");
            if (newVal != ShowOnlyAddedToBuild)
            {
                EditorPrefs.SetInt("showOnlyAddedToBuild", newVal ? 1 : 0);
                ShowOnlyAddedToBuild = newVal;
                OnEnable();
            }
            ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);

            int count = favoriteScenes.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (ShowFullScenePath)
                    {
                        if (GUILayout.Button(favoriteScenes[i]))
                        {
                            EditorSceneManager.OpenScene(favoriteScenes[i]);
                        }
                    }
                    else
                    {
                        temp = favoriteScenes[i].Split('/');
                        if (GUILayout.Button(temp[temp.Length - 1].Replace(".unity", "")))
                        {
                            EditorSceneManager.OpenScene(favoriteScenes[i]);
                        }
                    }
                    if (GUILayout.Button(AddedToFavoriteStar, GUILayout.Width(30f)))
                    {
                        EditorPrefs.SetInt(string.Format(AddedToFavoritePrefsKeyFormat, favoriteScenes[i]), 0);
                        scenes.Add(favoriteScenes[i]);
                        favoriteScenes.RemoveAt(i);
                        i--;
                        count--;
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.Space();
            }

            count = scenes.Count;
            for (int i = 0; i < count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (ShowFullScenePath)
                {
                    if (GUILayout.Button(scenes[i]))
                    {
                        EditorSceneManager.OpenScene(scenes[i]);
                    }
                }
                else
                {
                    temp = scenes[i].Split('/');
                    if (GUILayout.Button(temp[temp.Length - 1].Replace(".unity", "")))
                    {
                        EditorSceneManager.OpenScene(scenes[i]);
                    }
                }
                if (GUILayout.Button(NotAddedToFavoriteStar, GUILayout.Width(30f)))
                {
                    EditorPrefs.SetInt(string.Format(AddedToFavoritePrefsKeyFormat, scenes[i]), 1);
                    favoriteScenes.Add(scenes[i]);
                    scenes.RemoveAt(i);
                    i--;
                    count--;
                }
                EditorGUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
    }
}



#endif