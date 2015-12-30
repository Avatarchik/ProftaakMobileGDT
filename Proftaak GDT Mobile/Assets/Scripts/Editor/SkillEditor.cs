namespace Assets.Scripts.Editor
{
    using Assets.Scripts.Enhancements;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(Skill))]
    public class SkillEditor : Editor
    {
        private bool showBtn = false;

        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            this.showBtn = EditorGUILayout.Toggle("Show normal elements", this.showBtn);
            if (this.showBtn)
            {
                this.DrawDefaultInspector();
                EditorGUILayout.Separator();
            }

            Skill skillScript = (Skill)this.target;

            this.serializedObject.Update();
            SkillEditor.show1item(this.serializedObject.FindProperty("upgradeObj"));

            EditorGUILayout.Separator();

            SkillEditor.show(this.serializedObject.FindProperty("requiredSkills"));


            this.serializedObject.ApplyModifiedProperties();
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

            if (GUILayout.Button("Add required skill"))
            {
                list.arraySize += 1;
            }
        }

        private static void show1item(SerializedProperty item)
        {
            EditorGUILayout.PropertyField(item);
        
        }
    }
}
