using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SettingsData))]
public class SettingsDataEditor : Editor
{
    SettingsData settingsData;
    SerializedProperty ControlListField;
    SerializedProperty ResolutionListField;
    SerializedProperty QualityListField;
    ReorderableList controlList;
    ReorderableList resolutionList;
    ReorderableList qualityList;


    private void OnEnable()
    {
        ControlListField = serializedObject.FindProperty("Controls");
        ResolutionListField = serializedObject.FindProperty("ResolutionsList");
        QualityListField = serializedObject.FindProperty("QualityList");

        // Creating Reorderable list
        controlList = new ReorderableList(serializedObject, ControlListField, true,false,true,true);
        controlList.drawElementCallback = drawControlList;

        resolutionList = new ReorderableList(serializedObject, ResolutionListField, true,false,true,true);
        resolutionList.drawElementCallback = drawResolutionList;

        qualityList = new ReorderableList(serializedObject, QualityListField, true,false,true,true);
        qualityList.drawElementCallback = drawQualityList;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Styles
        GUIStyle headingStyle = new GUIStyle(GUI.skin.label){
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.UpperCenter
        };
        GUIStyle listTitleStyle = new GUIStyle(GUI.skin.label){
            fontSize = 15,
            alignment = TextAnchor.UpperCenter
        };


        // Controls list
        GUILayout.Space(15);
        GUILayout.Label("Controls List", headingStyle);
        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Control Name", listTitleStyle);
        GUILayout.Label("Key", listTitleStyle);
        GUILayout.EndHorizontal();

        controlList.DoLayoutList();


        // Resolutions list
        GUILayout.Space(15);
        GUILayout.Label("Resolutions List", headingStyle);
        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Width", listTitleStyle);
        GUILayout.Label("Height", listTitleStyle);
        GUILayout.EndHorizontal();

        resolutionList.DoLayoutList();


        // Quality list
        GUILayout.Space(15);
        GUILayout.Label("Quality List", headingStyle);
        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", listTitleStyle);
        GUILayout.Label("SettingIndex", listTitleStyle);
        GUILayout.EndHorizontal();

        qualityList.DoLayoutList();


        serializedObject.ApplyModifiedProperties();
    }

    void drawControlList(Rect rect, int index, bool isActive, bool isFocused){
        SerializedProperty element = controlList.serializedProperty.GetArrayElementAtIndex(index);

        Rect leftRect = new Rect(rect.x, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);
        Rect rightRect = new Rect(rect.x + rect.width / 2, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(
            leftRect,
            element.FindPropertyRelative("Name"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            rightRect,
            element.FindPropertyRelative("KeyCode"),
            GUIContent.none
        );
    }

    void drawResolutionList(Rect rect, int index, bool isActive, bool isFocused){
        SerializedProperty element = resolutionList.serializedProperty.GetArrayElementAtIndex(index);

        Rect leftRect = new Rect(rect.x, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);
        Rect rightRect = new Rect(rect.x + rect.width / 2, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(
            leftRect,
            element.FindPropertyRelative("Width"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            rightRect,
            element.FindPropertyRelative("Height"),
            GUIContent.none
        );
    }

    void drawQualityList(Rect rect, int index, bool isActive, bool isFocused){
        SerializedProperty element = qualityList.serializedProperty.GetArrayElementAtIndex(index);

        Rect leftRect = new Rect(rect.x, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);
        Rect rightRect = new Rect(rect.x + rect.width / 2, rect.y + 3, rect.width / 2, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(
            leftRect,
            element.FindPropertyRelative("Name"),
            GUIContent.none
        );

        EditorGUI.PropertyField(
            rightRect,
            element.FindPropertyRelative("SettingIndex"),
            GUIContent.none
        );
    }
}