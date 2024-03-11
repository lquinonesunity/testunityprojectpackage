using UnityEngine;
using UnityEditor;
using System.Collections;

public class AboutWindow : EditorWindow
{

    string Product = "Scene Doors";
    string Version = "1.0";

    bool AboutFoldout = true;
    bool VersionFoldout = true;

    [MenuItem("Tools/Scene Doors/About %&s")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(AboutWindow), false, "About");
    }

    void OnGUI()
    {
        //Debug.Log("Window width: " + position.width);
        //Debug.Log("Window height: " + position.height);
        GUILayout.Label("About Scene Doors", EditorStyles.boldLabel);
        //GUILayout.Label ("About", EditorStyles.foldout);
        AboutFoldout = EditorGUILayout.Foldout(AboutFoldout, "About");
        if (AboutFoldout)
        {
            GUILayout.Label("Scene Doors - Created By Kyle Briggs,Labyrith and Don Briggs Ltd", EditorStyles.boldLabel);
            GUILayout.Label("Scene Doors ");
            if (GUILayout.Button("labyrith.co.uk"))
                Application.OpenURL("http://www.labyrith.co.uk/");
        }

        VersionFoldout = EditorGUILayout.Foldout(VersionFoldout, "Version");
        if (VersionFoldout)
        {
            GUILayout.Label("Product Name: " + Product, EditorStyles.boldLabel);
            GUILayout.Label("Version: " + Version, EditorStyles.boldLabel);
            GUILayout.Label("Changelog: ", EditorStyles.boldLabel);
            GUILayout.Label("- Unity 5 Support Added");
            GUILayout.Label("- Unity 5 GUI Support Added");
            GUILayout.Label("- Unity 5 Support Added");
            GUILayout.Label("- Increased Support for Mobile Devices");
            GUILayout.Label("- C# Versions Introduced");
            GUILayout.Label("- Re-optimised Code");
            if (GUILayout.Button("Contact Us"))
                Application.OpenURL("mailto:kyle@kylebriggs.co.uk?subject=Scene Doors");
        }

    }
}