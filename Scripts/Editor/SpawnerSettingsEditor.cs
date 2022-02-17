using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnerSettings))]
public class SpawnerSettingsEditor : Editor
{
    private Texture2D _texture;

    private void DrawBox(Rect position, Color color)
    {
        if (!_texture)
            _texture = new Texture2D(1, 1);
        if (_texture.GetPixel(0, 0) != color)
        {
            _texture.SetPixel(0, 0, color);
            _texture.Apply();
        }
        GUI.skin.box.normal.background = _texture;
        GUI.Box(position, GUIContent.none, EditorStyles.helpBox);
    }
    private void Draw()
    {
        SerializedProperty bonusObjects = serializedObject.FindProperty("_bonusObjects");
        SerializedProperty minTime = serializedObject.FindProperty("_minTimeSpawn");
        SerializedProperty maxTime = serializedObject.FindProperty("_maxTimeSpawn");
        SerializedProperty probabilities = serializedObject.FindProperty("_spawnProbabilities");
        Color firstColor = new Color(190f / 255, 190f / 255, 190f / 255, 1f);
        minTime.arraySize = bonusObjects.arraySize;
        maxTime.arraySize = bonusObjects.arraySize;
        probabilities.arraySize = bonusObjects.arraySize;
        Rect rect = EditorGUILayout.BeginHorizontal();
        rect.xMin -= 10;
        rect.xMax += 2;
        rect.yMin -= 5;
        //rect.yMax += 2;
        DrawBox(rect, firstColor);
        EditorStyles.wordWrappedLabel.fontSize = 13;
        GUILayout.Label("Bonus", EditorStyles.wordWrappedMiniLabel);
        GUILayout.Space(50);
        GUILayout.Label("Min Time", EditorStyles.wordWrappedMiniLabel);
        GUILayout.Space(10);
        GUILayout.Label("Max Time", EditorStyles.wordWrappedMiniLabel);
        GUILayout.Space(10);
        GUILayout.Label("Probability", EditorStyles.wordWrappedMiniLabel);
        //GUILayout.Label("\n");
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
        rect = EditorGUILayout.BeginVertical();
        rect.xMin -= 10;
        rect.yMin -= 3;
        rect.yMax += 0;
        rect.xMax += 2;
        DrawBox(rect, new Color(210f / 255, 210f / 255, 210f / 255, 1));
        for (int i = 0; i < bonusObjects.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            if (i == 0)
                rect.yMin -= 5;
            rect.xMin -= 10;
            EditorGUILayout.PropertyField(bonusObjects.GetArrayElementAtIndex(i), GUIContent.none);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.PropertyField(minTime.GetArrayElementAtIndex(i), GUIContent.none);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.PropertyField(maxTime.GetArrayElementAtIndex(i), GUIContent.none);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.PropertyField(probabilities.GetArrayElementAtIndex(i), GUIContent.none);
            if (probabilities.GetArrayElementAtIndex(i).floatValue > 1)
                probabilities.GetArrayElementAtIndex(i).floatValue = 1;
            else if (probabilities.GetArrayElementAtIndex(i).floatValue < 0)
                probabilities.GetArrayElementAtIndex(i).floatValue = 0;
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("\n");
        Draw();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+", EditorStyles.toolbarButton, GUILayout.Width(40), GUILayout.Height(40)))
        {
            serializedObject.FindProperty("_bonusObjects").arraySize++;
            serializedObject.ApplyModifiedProperties();
        }
        if (GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(40), GUILayout.Height(40)))
        {
            serializedObject.FindProperty("_bonusObjects").arraySize--;
            serializedObject.ApplyModifiedProperties();
        }
        EditorGUILayout.EndHorizontal();
    }
}
