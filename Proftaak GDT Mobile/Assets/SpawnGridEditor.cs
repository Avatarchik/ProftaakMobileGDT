﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpawnGrid))]
public class ObjectBuilderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpawnGrid spawnScript = (SpawnGrid)target;
        //if (GUILayout.Button("Display all objects in range of"))
        //{
        //    spawnScript.GetLocationsClosestToCenter(spawnScript.radius, spawnScript.position.location, true);
        //}
    }
}
