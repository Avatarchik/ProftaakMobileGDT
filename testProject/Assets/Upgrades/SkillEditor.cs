using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Skill))]
public class SkillEditor : Editor
{
    private bool showBtn = false;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        showBtn = EditorGUILayout.Toggle("Show normal elements", showBtn);
        if (showBtn)
        {
            DrawDefaultInspector();
            EditorGUILayout.Separator();
        }

        Skill skillScript = (Skill)target;

        serializedObject.Update();
        SkillEditor.show1item(serializedObject.FindProperty("upgradeObj"));

        EditorGUILayout.Separator();

        SkillEditor.show(serializedObject.FindProperty("requiredSkills"));


        serializedObject.ApplyModifiedProperties();



    }

    private static void show(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list);
        for (int i = 0; i < list.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));


        if (GUILayout.Button("Remove"))
            {
                int oldSize = list.arraySize;
                list.DeleteArrayElementAtIndex(i);
                if (list.arraySize == oldSize)
                {
                    list.DeleteArrayElementAtIndex(i);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add skill"))
        {
            list.arraySize += 1;
        }
    }

    private static void show1item(SerializedProperty item)
    {
        EditorGUILayout.PropertyField(item);
        
    }
}
