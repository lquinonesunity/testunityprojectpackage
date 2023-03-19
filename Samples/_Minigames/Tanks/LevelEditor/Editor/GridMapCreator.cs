using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class GridMapCreator : EditorWindow
{
    Vector2 offset;// space for the grid
    Vector2 drag;// drag tool to pan

    Color gridColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    //Nodes
    List<List<Node>> nodes;

    List<List<PartScripts>> Parts;

    GUIStyle empty;
    Vector2 nodePos;
    MapData styleman;
    bool isErasing;

    public Rect MenuBar;
    private GUIStyle currentStyle;
    GameObject TheMap;

    //fix offset
    public float offset_X = 25;
    public float offset_Y = 50;

    //Saved maps path
    public string savedMapsPath = "Assets/_Minigames/Tanks/LevelEditor/Resources/MapsPrefabs/";
    public int addcounter;
    bool prefabSuccess;//success saved


    [MenuItem("Tools/GridMapCreator")]
    private static void OpenWindow()
    {
        GridMapCreator window = GetWindow<GridMapCreator>();
        window.titleContent = new GUIContent("Grid Map Creator");
    }

    private void OnEnable()
    {
        SetupStyles();
        SetupNodesAndParts();
        SetUpMap();
        //currentStyle = styleman.buttonStyles[1].NodeStyle;//initialize with empty
    }

    private void SetUpMap()
    {
        try
        {
            TheMap = GameObject.FindGameObjectWithTag("Map");
            RestoreMap(TheMap);
        }
        catch (Exception e){}

        if(TheMap == null)
        {
            TheMap = new GameObject("Map");
            TheMap.tag = "Map";
        }
    }

    private void RestoreMap(GameObject theMap)
    {
        if(theMap.transform.childCount > 0)
        {
            for(int i = 0; i < theMap.transform.childCount; i++)
            {
                int ii = theMap.transform.GetChild(i).GetComponent<PartScripts>().Row;
                int jj = theMap.transform.GetChild(i).GetComponent<PartScripts>().Column;
                GUIStyle TheStyle = theMap.transform.GetChild(i).GetComponent<PartScripts>().style;
                nodes[ii][jj].Setstyle(TheStyle);
                Parts[ii][jj] = theMap.transform.GetChild(i).GetComponent<PartScripts>();
                Parts[ii][jj].Part = theMap.transform.GetChild(i).gameObject;
                Parts[ii][jj].name = theMap.transform.GetChild(i).name;
                Parts[ii][jj].Row = ii;
                Parts[ii][jj].Column = jj;
            }
        }
    }

    private void SetupStyles()
    {
        try
        {
            //
            //styleman = GameObject.FindGameObjectWithTag("StyleManager").GetComponent<StyleManager>();
            styleman = Resources.Load("StyleManager/StyleManagerAsset") as MapData;
            //GameObject G = Instantiate(Resources.Load("MapParts/" + currentStyle.normal.background.name)) as GameObject;

            for (int i = 0; i < styleman.buttonStyles.Length; i++)
            {
                styleman.buttonStyles[i].NodeStyle = new GUIStyle();
                styleman.buttonStyles[i].NodeStyle.normal.background = styleman.buttonStyles[i].Icon;
            }
        }
        catch (Exception e) { }

        empty = styleman.buttonStyles[0].NodeStyle;
        currentStyle = styleman.buttonStyles[1].NodeStyle;
    }

    private void SetupNodesAndParts()
    {
        nodes = new List<List<Node>>();
        Parts = new List<List<PartScripts>>();
        for (int i = 0; i < 20; i++)
        {
            nodes.Add(new List<Node>());
            Parts.Add(new List<PartScripts>());
            for (int j = 0; j < 10; j++)
            {
                nodePos.Set(i * 30, j * 30);
                nodes[i].Add(new Node(nodePos, 30, 30, empty));
                Parts[i].Add(null);
            }
        }
    }

    private void OnGUI()
    {
        DrawGrid(); //Drawing the grid
        DrawNodes(); // Nodes for each tile
        DrawMenuBar();
        ProcessNodes(Event.current);
        ProcessGrid(Event.current); //draging the grid - Pan tool // getting the e event and process
        if (GUI.changed)
        {
            Repaint();
        }
    }

    private void DrawMenuBar()
    {
        MenuBar = new Rect(0, 0, position.width, 20);
        GUILayout.BeginArea(MenuBar, EditorStyles.toolbar);
        GUILayout.BeginHorizontal();

        for(int i = 0; i < styleman.buttonStyles.Length; i++)
        {
            if (GUILayout.Toggle((currentStyle == styleman.buttonStyles[i].NodeStyle), new GUIContent(styleman.buttonStyles[i].ButtonText), EditorStyles.toolbarButton, GUILayout.Width(80)))
                currentStyle = styleman.buttonStyles[i].NodeStyle;
        }
        if (GUILayout.Button("Save Map"))
        {

            savedMapsPath = "Assets/_Minigames/Tanks/LevelEditor/Editor/Resources/MapsPrefabs/";
            DirectoryInfo dir = new DirectoryInfo(savedMapsPath);
            int filesCount = dir.GetFiles().Length;
            FileInfo[] filesNames = dir.GetFiles();
            Debug.Log(filesNames[0].Directory.Name);
            addcounter = filesCount/2;

            PrefabUtility.SaveAsPrefabAsset(TheMap, savedMapsPath + "SavedMap_" + (addcounter + 1) + ".prefab", out prefabSuccess);
            if (prefabSuccess == true)
                Debug.Log("Prefab was saved successfully");
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);/**/
        }
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

    }

    private void ProcessNodes(Event e)
    {
        int Row = (int)((e.mousePosition.x - offset.x) / 30);
        int Col = (int)((e.mousePosition.y - offset.y) / 30);
        if ((e.mousePosition.x - offset.x) < 0 || (e.mousePosition.x - offset.x) > 600 || (e.mousePosition.y - offset.y) < 0 || (e.mousePosition.y - offset.y) > 300)
        {

        }
        else
        {
            if(e.type == EventType.MouseDown)
            {
                if (nodes[Row][Col].style.normal.background.name == "Empty")
                {
                    isErasing = false;
                }
                else
                {
                    isErasing = true;
                }
                PaintNodes(Row, Col);
            }

            if (e.type == EventType.MouseDrag)
            {
                PaintNodes(Row, Col);
                e.Use();
            }
        }
    }

    private void PaintNodes(int Row, int Col)
    {
        if(isErasing)
        {
            nodes[Row][Col].Setstyle(empty);
            GUI.changed = true;

            if(Parts[Row][Col] != null)
            {
                nodes[Row][Col].Setstyle(empty);
                DestroyImmediate(Parts[Row][Col].gameObject);
                GUI.changed = true;
            }
            Parts[Row][Col] = null;
        }
        else
        {
            if (Parts[Row][Col] == null)
            {
                nodes[Row][Col].Setstyle(currentStyle);
                Debug.Log(currentStyle.normal.background.name);
                GameObject G = Instantiate(Resources.Load("MapParts/" + currentStyle.normal.background.name)) as GameObject;
                G.name = currentStyle.normal.background.name;
                G.transform.position = new Vector3((Col*5-offset_X), 0, Row*5-(offset_Y)) + Vector3.forward*2 + Vector3.right*2;
                G.transform.parent = TheMap.transform;
                Parts[Row][Col] = G.GetComponent<PartScripts>();
                Parts[Row][Col].Part = G;
                Parts[Row][Col].name = G.name;
                Parts[Row][Col].Row = Row;
                Parts[Row][Col].Column = Col;
                Parts[Row][Col].style = currentStyle;
                GUI.changed = true;
            }

        }
    }

    private void DrawNodes()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                nodes[i][j].Draw();
            }
        }
    }

    private void ProcessGrid(Event e)
    {
        drag = Vector2.zero; //init on zero
        switch (e.type)//getting the type of event
        {
            case EventType.MouseDrag:
                if(e.button == 0)
                {
                    //Debug.Log(e.delta);
                    OnMouseDrag(e.delta);//amounnt the space dragged
                }
                break;
        }
    }

    private void OnMouseDrag(Vector2 delta)
    {
        drag = delta;

        // Drag for the tiles
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                nodes[i][j].Drag(delta);
            }
        }

        GUI.changed = true;
    }

    //Drawing the grid
    private void DrawGrid()
    {
        int widthDivider = Mathf.CeilToInt(position.width / 20);
        int heightDivider = Mathf.CeilToInt(position.height / 20);
        Handles.BeginGUI();
        Handles.color = gridColor;

        // Offset affected by dragging
        offset += drag;

        Vector3 newOffset = new Vector3(offset.x%20, offset.y%20,0);

        for (int i = 0; i < widthDivider; i++)
        {
            Handles.DrawLine(new Vector3(20*i, -20,0) + newOffset, new Vector3(20*i, position.height,0) + newOffset);
        }
        for (int i = 0; i < heightDivider; i++)
        {
            Handles.DrawLine(new Vector3(-20, 20 * i, 0) + newOffset, new Vector3(position.height, 20 * i, 0) + newOffset);
        }
        Handles.color = Color.white;
        Handles.EndGUI();
    }
}
