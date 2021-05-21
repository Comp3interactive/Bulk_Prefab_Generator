using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabGeneratorWindow : EditorWindow
{
    private string pathName = "Prefabs/";

    [MenuItem("Custom Utilites/Mass Prefab Generator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(PrefabGeneratorWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Mass Prefab Generator", EditorStyles.boldLabel);
        pathName = EditorGUILayout.TextField("Save Path", pathName);

        if (GUILayout.Button("Build Prefabs"))
            GeneratePrefabs();
    }

    private void GeneratePrefabs()
    {
        if (!Directory.Exists($"Assets/{pathName}"))
            Directory.CreateDirectory($"Assets/{pathName}");

        foreach (GameObject go in Selection.gameObjects)
        {
            string localPath = AssetDatabase.GenerateUniqueAssetPath($"Assets/{pathName}{go.name}.prefab");
            PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction);
        }    
    }
}
