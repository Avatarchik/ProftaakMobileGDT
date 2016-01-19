namespace Assets.Scripts.Editor
{
    using Assets.Scripts.Enhancements;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(Managers.RandomEventsManager))]
    public class RandomEventsManagerEditor: Editor
    {
        private bool showBtn = false;
        private bool prevValue = false;
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

            bool pauseGame = EditorGUILayout.Toggle("Pause game", this.prevValue);
            if (pauseGame != this.prevValue)
            {
                Time.timeScale = pauseGame ? 0 : 1;
            }
            this.prevValue = pauseGame;
            
            this.serializedObject.ApplyModifiedProperties();
        }
       

    }
}