using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBarUI : MonoBehaviour
{
    [Header("Global Variables")]
    [SerializeField] private SessionInfo _sessionInfo;
    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _bar;
    private float _lastScore;
    private float _lastWinScore;

    public void UpdateData()
    {
        _lastScore = _sessionInfo.Score;
        _lastWinScore = _sessionInfo.WinScore;
        _bar.fillAmount = _lastScore / _lastWinScore;
        _text.text = $"{_lastScore}/{_lastWinScore}";
    }

    private void Update()
    {
        if (_lastScore != _sessionInfo.Score || _lastWinScore != _sessionInfo.WinScore)
            UpdateData();
    }
}
