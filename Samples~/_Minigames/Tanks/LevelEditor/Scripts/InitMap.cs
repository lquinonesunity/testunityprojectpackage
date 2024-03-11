using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InitMap : MonoBehaviour
{
    private string savedMapsPath;
    DirectoryInfo savedMapsDir;
    GameObject TheMap;

    // Start is called before the first frame update
    void Start()
    {
        CheckIfMap();
        //Directory.Exists("Assets/Prefabs"))
        savedMapsPath = "Assets/_Minigames/Tanks/LevelEditor/Editor/Resources/MapsPrefabs/";
        DirectoryInfo dir = new DirectoryInfo(savedMapsPath);
        int count = dir.GetFiles().Length;
        Debug.Log("count:"+count/2);
        string gottenPath = "SavedMap_" + (UnityEngine.Random.Range(1, count / 2));
        Debug.Log(gottenPath);
        GameObject G = Instantiate(Resources.Load("MapsPrefabs/" + gottenPath)) as GameObject;
    }

    void CheckIfMap()
    {
        try
        {
            TheMap = GameObject.FindGameObjectWithTag("Map");
        }
        catch (Exception e) { }

        if (TheMap)
        {
            Destroy(TheMap.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
