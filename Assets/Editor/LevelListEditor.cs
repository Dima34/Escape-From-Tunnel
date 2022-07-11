using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelListGenerator))]
public class LevelListEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        
        if(GUILayout.Button("Generate")){
            LevelListGenerator objTarget = (LevelListGenerator)target;

            objTarget.GenerateCards();
        }
    }
}