using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor (typeof(MapGenerator))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI() //Allows for constant update on tile map without having to click play again
    {
        base.OnInspectorGUI();
        MapGenerator map = target as MapGenerator;

        map.GenerateMap();
    }
}
