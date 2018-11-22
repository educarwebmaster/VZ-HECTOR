using UnityEditor;
using UnityEngine;
using System.Collections;
/*
[CustomEditor(typeof(GENERAL_INTERFAZ))]
[CanEditMultipleObjects]
public class GUI_EDITOR_GENERAL : Editor {
    SerializedProperty tiempo;
    
    void OnEnable()
    {
        
        tiempo = serializedObject.FindProperty("tiempo");
 
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.IntSlider(tiempo, 0, 100, new GUIContent("Tiempo"));
        if (!tiempo.hasMultipleDifferentValues)
			ProgressBar (tiempo.intValue / 100.0f, "Damage");
    }

    void ProgressBar (float value, string label) {
		// Get a rect for the progress bar using the same margins as a textfield:
		Rect rect = GUILayoutUtility.GetRect (18, 18, "TextField");
		EditorGUI.ProgressBar (rect, value, label);
		EditorGUILayout.Space ();
	}

}*/
