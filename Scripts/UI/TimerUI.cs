using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [Header("Global Variables")]
    [SerializeField] private SessionInfo _sessionInfo;
    [Header("Settings")]
    [SerializeField] private Image _outerRing;
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _outerRing.fillAmount = 1 - (_sessionInfo.PlayTime / _sessionInfo.DieTime);
        _text.text = $"{(int)(_sessionInfo.DieTime - _sessionInfo.PlayTime)}";
    }
}
