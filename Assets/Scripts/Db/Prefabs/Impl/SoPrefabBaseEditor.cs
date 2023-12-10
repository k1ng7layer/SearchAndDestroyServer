using UnityEditor;
using UnityEngine;

namespace Db.Prefabs.Impl
{
    [CustomEditor(typeof(SoPrefabsBase))]
    public class SoPrefabBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var initializer = (IPrefabInitializer)target;

            if (GUILayout.Button("Initialize prefabs"))
            {
                initializer.Initialize();
            }
        }
    }
}