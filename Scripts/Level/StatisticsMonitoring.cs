using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StatisticsMonitoring : MonoBehaviour
{
    [Header("Global Variables")]
    [SerializeField] private GlobalSettings _globalSettings;
    [SerializeField] private SessionInfo _sessionInfo;
    private LevelStatistics _stats;

    public void Init()
    {
        _stats = _sessionInfo.LevelInfo.Statistics;
        _stats.Tries++;
    }

    public void CountBonus()
    {
        _stats.UsedBonuses++;
    }

    public void CountWin()
    {
        _stats.SuccessTries++;
        if (_sessionInfo.PlayTime < _stats.BestTime || _stats.BestTime == 0) 
            _stats.BestTime = _sessionInfo.PlayTime;
        var levelIndex = Array.FindIndex<LevelInfo>(_globalSettings.Levels, level => level == _sessionInfo.LevelInfo);
        if (_globalSettings.LevelsCompleted == levelIndex)
            _globalSettings.LevelsCompleted++;
    }
}
