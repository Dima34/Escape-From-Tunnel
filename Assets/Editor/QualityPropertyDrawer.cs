using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Quality))]
public class QualityPropertyDrawer : PropertyDrawer
{
    Rect left, right;
    SerializedProperty name, settingIndex;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        left = new Rect(position.x, position.y, position.width / 2, position.height);
        right = new Rect(position.x + position.width / 2, position.y, position.width / 2, position.height);

        name = property.FindPropertyRelative("Name");
        settingIndex = property.FindPropertyRelative("SettingIndex");

        EditorGUI.PropertyField(left, name, GUIContent.none);
        EditorGUI.PropertyField(right, settingIndex, GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
