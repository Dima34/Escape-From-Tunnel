using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CustomEditor(typeof(PlayerSettings))]
public class PlayerSettingsEditor : Editor
{
    SerializedProperty settingsDataObject;
    SerializedProperty volume;
    SerializedProperty selectedResolutionIndex;
    SerializedProperty selectedResolutionList;
    SerializedProperty isFullscreen;
    SerializedProperty selectedQualityIndex;
    SerializedProperty selectedQualityList;


    private void OnEnable()
    {
        settingsDataObject = serializedObject.FindProperty("settingsDataObject");
        volume = serializedObject.FindProperty("Volume");
        selectedResolutionIndex = serializedObject.FindProperty("SelectedResolutionIndex");
        isFullscreen = serializedObject.FindProperty("IsFullscreen");
        selectedQualityIndex = serializedObject.FindProperty("SelectedQualityIndex");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        EditorGUILayout.ObjectField(settingsDataObject, typeof(SettingsData));
        // if in setting object data selected
        if (settingsDataObject.objectReferenceValue)
        {
            SettingsData settingsData = (SettingsData)settingsDataObject.objectReferenceValue;

            // Default volume selection
            GUILayout.BeginHorizontal();
            GUILayout.Label("Default volume value");
            volume.floatValue = EditorGUILayout.Slider(volume.floatValue, settingsData.minVolume, settingsData.maxVolume);
            GUILayout.EndHorizontal();

            // Creating resolution selection
            List<Resolution> resList = settingsData.ResolutionsList;
            string[] resListOptionList = new string[resList.Count];

            // fill a resListOptionList by names from resoption list
            for (int i = 0; i < resList.Count; i++)
            {
                resListOptionList[i] = resList[i].ToString();
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Default Resolution");
            selectedResolutionIndex.intValue = EditorGUILayout.Popup(selectedResolutionIndex.intValue, resListOptionList);
            GUILayout.EndHorizontal();

            // Creating isDefaultFullScreen
            GUILayout.BeginHorizontal();
            GUILayout.Label("Is Fullscreen Default");
            EditorGUILayout.PropertyField(isFullscreen, GUIContent.none);
            GUILayout.EndHorizontal();

            // Creating quality selection
            List<Quality> qaList = settingsData.QualityList;
            string[] qaListOptionList = new string[qaList.Count];

            // fill a qaListOptionList by names from resoption list
            for (int i = 0; i < qaList.Count; i++)
            {
                qaListOptionList[i] = qaList[i].GetName();
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Default Quality level");
            selectedQualityIndex.intValue = EditorGUILayout.Popup(selectedQualityIndex.intValue, qaListOptionList);
            GUILayout.EndHorizontal();

        }


        serializedObject.ApplyModifiedProperties();
    }

    string[] createStringList<T>(List<T> list)
    {
        string[] stringList = new string[list.Count];

        for (int i = 0; i < list.Count; i++)
        {
            stringList[i] = list[i].ToString();
        }

        return stringList;
    }
}