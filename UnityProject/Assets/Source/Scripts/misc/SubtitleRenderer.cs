﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTitles
{
    public Color Colour;
    public int Size;
    public string Text;
    public float Alive;
}

public class SubtitleRenderer : MonoBehaviour
{
    private static List<DuckTitles> queue;

    public static void AddSubtitle(DuckTitles title)
    {
        title.Alive = 1.0f / title.Size * 50.0f;
        queue.Add(title);
    }

    // Use this for initialization
    void Start()
    {
        queue = new List<DuckTitles>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DuckTitles title in queue)
        {
            title.Alive -= Time.deltaTime;
            if (title.Alive <= 0.0f)
            {
                queue.Remove(title);
                break;
            }
        }
    }

    void OnGUI()
    {
        float heightOff = 0.0f;
        foreach (DuckTitles current in queue)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = current.Size;
            GUI.color = current.Colour;
            GUI.contentColor = current.Colour;

            GUI.Label(new Rect(128, 256 + heightOff, Screen.width - 256, 256), current.Text, style);
            heightOff += style.CalcSize(new GUIContent(current.Text)).y;
        }

    }
}
