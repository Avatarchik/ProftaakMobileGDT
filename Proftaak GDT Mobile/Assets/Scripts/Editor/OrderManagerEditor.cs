//namespace Assets.Scripts.Editor
//{
//    using UnityEditor;
//    using UnityEditorInternal;
//    using UnityEngine;

//    [CustomEditor(typeof(OrderManager))]
//    internal class OrderManagerEditor : Editor
//    {
//        private ReorderableList _list;

//        private void OnEnable()
//        {
//            Debug.Log("OrderManagerEditor OnEnable");
//            SerializedProperty test = this.serializedObject.FindProperty("test");
//            SerializedProperty test2 = this.serializedObject.FindProperty("test2");
//            SerializedProperty items = this.serializedObject.FindProperty("Items");
//            this._list = new ReorderableList(this.serializedObject, this.serializedObject.FindProperty("Items"),
//                true, true, true, true);
//            Debug.Log("OrderManager items: " + this._list.count);
//        }

//        public override void OnInspectorGUI()
//        {
//            Debug.Log("OrderManager OnInspectorGUI");
//            Debug.Log("OrderManager items: " + this._list.count);
//            this.serializedObject.Update();
//            this._list.DoLayoutList();
//            this.serializedObject.ApplyModifiedProperties();
//        }
//    }
//}
