using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetailedLevelWindow : PopUpUI
{
    [Header("Global Variables")]
    [SerializeField] private SessionInfo _sessionInfo;
    [Header("Settings")]
    [SerializeField] private Image _levelImage;
    [SerializeField] private DifficultShower _difficultShower;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private TextMeshProUGUI _bestTime;
    [SerializeField] private TextMeshProUGUI _successTries;
    [SerializeField] private TextMeshProUGUI _allTries;
    [SerializeField] private TextMeshProUGUI _bonusesUsed;
    private LevelInfo _levelInfo;

    public void Init(LevelInfo levelInfo)
    {
        var statistics = levelInfo.Statistics;

        _levelInfo = levelInfo;
        _levelImage.sprite = levelInfo.BackgroundImage;
        _difficultShower.ShowDifficulty(levelInfo.Difficulty);
        _levelName.text = levelInfo.LevelName;
        _bestTime.text = $"{(int)statistics.BestTime / 60}:{(int)statistics.BestTime % 60}";
        _successTries.text = $"{statistics.SuccessTries}";
        _allTries.text = $"{statistics.Tries}";
        _bonusesUsed.text = $"{statistics.UsedBonuses}";
    }

    public void SetLevel()
    {
        _sessionInfo.LevelInfo = _levelInfo;
    }
}
