using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelListGenerator))]
public class LevelListEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        LevelListGenerator objTarget = (LevelListGenerator)target;
        
        if(GUILayout.Button("Generate cards")){
            objTarget.GenerateCards();
        }

        if(GUILayout.Button("Fill level list")){
            objTarget.FillLevelList();
        }
    }
}


