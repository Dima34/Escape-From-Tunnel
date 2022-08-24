using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Resolution))]
public class ResolutionPropertyDrawer : PropertyDrawer
{
    Rect left, right;
    SerializedProperty width, height;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        left = new Rect(position.x, position.y, position.width / 2, position.height);
        right = new Rect(position.x + position.width / 2, position.y, position.width / 2, position.height);

        width = property.FindPropertyRelative("Width");
        height = property.FindPropertyRelative("Height");

        EditorGUI.PropertyField(left, width, GUIContent.none);
        EditorGUI.PropertyField(right, height, GUIContent.none);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label);
    }
}
