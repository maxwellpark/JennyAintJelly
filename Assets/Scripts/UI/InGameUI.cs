using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public static string pickupLabelText;
    public static string enemyLabelText;
    public static string killCountLabelText = $"Kill Count: {PlayerData.killCount}";

    public Texture2D labelBackground; 

    private Rect labelRect;
    private float top = 16f;
    private float left = 16f;
    private float width = 120f;
    private float height = 32f;
    private float delta = 32f; 

    void Start()
    {
        labelBackground = new Texture2D((int)width, (int)height);
        //labelBackground.SetPixel
        labelRect = new Rect(top, left, width, height);
    }

    void Update()
    {
        
    }

    // we either need an event to invoke that updates the labels
    // or a static field 

    private void OnGUI()
    {
        GUI.Label(labelRect, labelBackground, killCountLabelText);
    }

    private void UpdateLabel(string text)
    {

    }
}
