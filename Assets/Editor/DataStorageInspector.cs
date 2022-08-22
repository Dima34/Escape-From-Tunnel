using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataStorageHandler))]
public class DataStorageInspector : Editor {

    SerializedProperty _coinsAmount;
    SerializedProperty _volume;
    SerializedProperty _resolutionsList;
    
    GUIStyle _headingStyle;


    private void OnEnable() {
        _headingStyle = new GUIStyle(){
            alignment = TextAnchor.MiddleCenter,
            fontStyle = FontStyle.Bold,
            fontSize = 20,
            
            normal = new GUIStyleState(){
                textColor = Color.white,
            }
        };

        _coinsAmount = serializedObject.FindProperty("defaultCoinsAmount");
        _volume = serializedObject.FindProperty("defaultVolume");
    }
    public override void OnInspectorGUI() {

        string headingText = "Default data settings";
        Vector2 size = _headingStyle.CalcSize( new GUIContent(headingText) );
        _headingStyle.normal.background = MakeTex(
            (int)size.x,
            (int)size.y,  
            new Color(convertFrom255(0), convertFrom255(0), convertFrom255(255), 1f)
        );
        GUILayout.Label(headingText, _headingStyle);

        EditorGUILayout.Space(10);
        // Coins amount
        GUILayout.BeginHorizontal();
        GUILayout.Label("Coins amount");
        EditorGUILayout.PropertyField(_coinsAmount, GUIContent.none, GUILayout.MaxWidth(50));
        GUILayout.EndHorizontal();

        // Volume
        GUILayout.Label("Volume");
        EditorGUILayout.Slider(_volume, -80, 20);


        //Resolution
    
        serializedObject.ApplyModifiedProperties();
    }

    float convertFrom255(float num){
        Debug.Log("res - " + (num/255));
        return num/255;
    }

    private Texture2D MakeTex(int width, int height, Color color)
    {
        Color[] pixArr = new Color[width*height];
 
        for(int i = 0; i < pixArr.Length; i++)
        {
            pixArr[i] = color;
        }
 
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pixArr);
        result.Apply();
 
        return result;
    }
}