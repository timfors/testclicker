using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BonusContainerUI))]
public class BonusContainerUIEditor : Editor
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
        SerializedProperty scenes = serializedObject.FindProperty("_allBonuses");
        SerializedProperty starts = serializedObject.FindProperty("_bonusPrefab");
        Color firstColor = new Color(190f / 255, 190f / 255, 190f / 255, 1f);
        starts.arraySize = scenes.arraySize;
        Rect rect = EditorGUILayout.BeginHorizontal();
        rect.xMin -= 10;
        rect.xMax += 2;
        rect.yMin -= 5;
        //rect.yMax += 2;
        DrawBox(rect, firstColor);
        EditorStyles.wordWrappedLabel.fontSize = 13;
        GUILayout.Label("Bonus", EditorStyles.wordWrappedLabel);
        GUILayout.Space(50);
        GUILayout.Label("Prefab", EditorStyles.wordWrappedLabel);
        //GUILayout.Label("\n");
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
        rect = EditorGUILayout.BeginVertical();
        rect.xMin -= 10;
        rect.yMin -= 3;
        rect.yMax += 0;
        rect.xMax += 2;
        DrawBox(rect, new Color(210f / 255, 210f / 255, 210f / 255, 1));
        for (int i = 0; i < scenes.arraySize; i++)
        {
            SerializedProperty sceneEl = scenes.GetArrayElementAtIndex(i);
            EditorGUILayout.BeginHorizontal();
            if (i == 0)
                rect.yMin -= 5;
            rect.xMin -= 10;
            EditorGUILayout.PropertyField(sceneEl, GUIContent.none);
            serializedObject.ApplyModifiedProperties();
            SerializedProperty clipEl = starts.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(clipEl, GUIContent.none);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_sessionInfo"), GUIContent.none);
        EditorGUILayout.LabelField("\n");
        Draw();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+", EditorStyles.toolbarButton, GUILayout.Width(40), GUILayout.Height(40)))
        {
            serializedObject.FindProperty("_allBonuses").arraySize++;
            serializedObject.ApplyModifiedProperties();
        }
        if (GUILayout.Button("-", EditorStyles.toolbarButton, GUILayout.Width(40), GUILayout.Height(40)))
        {
            serializedObject.FindProperty("_allBonuses").arraySize--;
            serializedObject.ApplyModifiedProperties();
        }
        EditorGUILayout.EndHorizontal();
    }
}
