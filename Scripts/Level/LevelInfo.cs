using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level/LevelInfo", order = 51)]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private Sprite _backgroundImage;
    [SerializeField] private string _levelName;
    [SerializeField] private int _winScore;
    [SerializeField] private MainObject _clickObject;
    [SerializeField] private float _timeForLevel;
    [SerializeField] [Range(1, 5)] private int _difficulty;
    [SerializeField] private LevelStatistics _statistics;
    [SerializeField] private SpawnerSettings _spawnerSettings;

    public Sprite BackgroundImage { get => _backgroundImage; }

    public string LevelName { get => _levelName; }

    public int WinScore { get => _winScore; }

    public MainObject ClickObject { get => _clickObject; }

    public float TimeForLevel { get => _timeForLevel; }

    public int Difficulty { get => _difficulty; }

    public LevelStatistics Statistics { get => _statistics; }

    public SpawnerSettings SpawnerInfo { get => _spawnerSettings; }
}
