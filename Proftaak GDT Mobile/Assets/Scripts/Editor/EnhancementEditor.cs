namespace Assets.Scripts.Editor
{
    using Assets.Scripts.Enhancements;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(Enhancement))]
    public class EnhancementEditor : Editor
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
            
            EditorGUILayout.Separator();

            ShowList(this.serializedObject.FindProperty("_requiredEnhancements"));

            EditorGUILayout.Separator();
            
            if (GUILayout.Button("Update status"))
            {
                Enhancement eh = (Enhancement)this.target;
                eh.UpdateStatus();
            }

            this.serializedObject.ApplyModifiedProperties();
        }

        private static void ShowItem(SerializedProperty item)
        {
            EditorGUILayout.PropertyField(item);
        }

        private static void ShowList(SerializedProperty list)
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

            if (GUILayout.Button("Add required Skill"))
            {
                list.arraySize += 1;
            }
        }

    }
}