using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 52)]
public class GlobalSettings : ScriptableObject
{
    public int LevelsCompleted = 0;
    public bool IsMusic = true;
    public bool IsSound = true;

    [SerializeField] private List<LevelInfo> _levels;

    public LevelInfo[] Levels { get => _levels.ToArray(); }

}
