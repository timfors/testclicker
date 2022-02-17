using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsContainerUI : MonoBehaviour
{
    [Header("Global Variables")]
    [SerializeField] private GlobalSettings _globalSettings;
    [Header("Prefabs")]
    [SerializeField] private LevelWindowUI _levelWindowPrefab;

    void Start()
    {
        for (int i = 0; i <= _globalSettings.LevelsCompleted && i < _globalSettings.Levels.Length; i++)
        {
            var levelWindow = Instantiate<LevelWindowUI>(_levelWindowPrefab, transform);
            levelWindow.Init(_globalSettings.Levels[i]);
        }
    }
}
