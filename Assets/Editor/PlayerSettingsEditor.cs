using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerSettings))]
public class PlayerSettingsEditor : Editor {
    SerializedProperty settingsDataObject;
    SerializedProperty volume;
    SerializedProperty selectedResolutionIndex;
    SerializedProperty selectedResolutionList;
    SerializedProperty isFullscreen;
    SerializedProperty selectedQualityIndex;
    SerializedProperty selectedQualityList;


    private void OnEnable() {
        settingsDataObject = serializedObject.FindProperty("settingsDataObject");
        volume = serializedObject.FindProperty("Volume");
        selectedResolutionIndex = serializedObject.FindProperty("SelectedResolutionIndex");
        selectedResolutionList = settingsDataObject.serializedObject.FindProperty("Resolution");
        isFullscreen = serializedObject.FindProperty("IsFullscreen");
        selectedQualityIndex = serializedObject.FindProperty("SelectedQualityIndex");
        selectedQualityList = settingsDataObject.serializedObject.FindProperty("Quality");
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();
        
        EditorGUILayout.ObjectField(settingsDataObject, typeof(SettingsData));

        serializedObject.ApplyModifiedProperties();
    }
}