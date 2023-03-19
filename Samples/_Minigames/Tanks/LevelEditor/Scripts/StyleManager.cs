using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleManager : MonoBehaviour
{
    public ButtonStyle[] buttonStyles;
}

[System.Serializable]
public class ButtonStyle
{
    public Texture2D Icon;
    public string ButtonText;
    [HideInInspector]
    public GUIStyle NodeStyle;

    public GameObject prefabCell;
}
