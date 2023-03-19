using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Style", menuName = "Map Style", order = 51)]
public class MapData : ScriptableObject
{
    public ButtonStyle[] buttonStyles;
}

[System.Serializable]
public class ButtonStyleS
{
    [SerializeField]
    public Texture2D Icon;
    [SerializeField]
    public string ButtonText;
    [SerializeField, HideInInspector]
    public GUIStyle NodeStyle;
    [SerializeField]
    public GameObject prefabCell;
}
