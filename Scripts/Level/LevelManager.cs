using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent _looseEvent;
    [SerializeField] private GameEvent _winEvent;
    [Header("Global Variables")]
    [SerializeField] private SessionInfo _sessionData;
    [Header("Settings")]
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Image _background;
    [SerializeField] private BonusHandler _bonusHandler;
    [SerializeField] private StatisticsMonitoring _stats;
    private LevelInfo _levelInfo;
    private Coroutine _session;
    private int _increaseValue = 1;

    private void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        var levelData = _sessionData.LevelInfo;
        var mainObj = _spawner.InitClicker(levelData.ClickObject);

        _levelInfo = levelData;
        _spawner.SetSettings(levelData.SpawnerInfo);
        _background.sprite = levelData.BackgroundImage;
        _bonusHandler.Init(mainObj);
        _sessionData.DieTime = levelData.TimeForLevel;
        _sessionData.WinScore = levelData.WinScore;
        _sessionData.PlayTime = 0;
        _sessionData.Score = 0;
        _sessionData.Bonuses.Clear();
        _stats.Init();
        StopSession();
        _session = StartCoroutine(MonitoringSession());
    }

    public void StopSession()
    {
        if (_session != null)
            StopCoroutine(_session);
    }

    private IEnumerator MonitoringSession()
    {
        while (_sessionData.PlayTime < _sessionData.DieTime)
        {
            if (_sessionData.Score == _sessionData.WinScore)
            {
                _winEvent.Raise();
                StopSession();
            }
            _sessionData.PlayTime += Time.deltaTime;
            yield return null;
        }
        _looseEvent.Raise();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void AddIncreaseValue(int extra)
    {
        _increaseValue += extra;
    }
    public void RemoveIncreaseValue(int extra)
    {
        _increaseValue -= extra;
    }

    public void IncreaseScore()
    {
        _sessionData.Score += _increaseValue;
    }
}
