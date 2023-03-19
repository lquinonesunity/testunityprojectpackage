using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorWintoWin : EditorWindow
{

    string Product = "Scene Doors";
    string Version = "1.0";

    bool ToolsFoldout = true;
    bool UsageFoldout = true;

    [MenuItem("Tools/Scene Doors/Creator %&c")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(EditorWintoWin), false, "SD Creator");
    }

    void OnGUI()
    {
        //Debug.Log("Window width: " + position.width);
        //Debug.Log("Window height: " + position.height);
        GUILayout.Label("Scene Doors Creator", EditorStyles.boldLabel);
        //GUILayout.Label ("About", EditorStyles.foldout);

        ToolsFoldout = EditorGUILayout.Foldout(ToolsFoldout, "Tools");
        if (ToolsFoldout)
        {
            GUILayout.Label("Scene Doors Object Creator", EditorStyles.boldLabel);
            if (GUILayout.Button("Create SD Object"))
                Application.OpenURL("http://www.labyrith.co.uk/");
        }

        UsageFoldout = EditorGUILayout.Foldout(UsageFoldout, "Usage");
        if (UsageFoldout)
        {
            GUILayout.Label("Product Name: " + Product, EditorStyles.boldLabel);
            GUILayout.Label("Version: " + Version, EditorStyles.boldLabel);
            GUILayout.Label("Usage: ", EditorStyles.boldLabel);
            GUILayout.Label("In the foldout above named Tools");
            GUILayout.Label("choose a method from the dropdown list");
            GUILayout.Label("and click 'Create SD Object' to create");
            GUILayout.Label("a trigger with that script.");
            if (GUILayout.Button("About"))
            {
                AboutWindow window = (AboutWindow)EditorWindow.GetWindow(typeof(AboutWindow), false, "Gib Halp Plis");
            }


        }

    }
}