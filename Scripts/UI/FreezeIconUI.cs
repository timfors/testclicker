using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreezeIconUI : MonoBehaviour
{
    [SerializeField] private FreezeBonus _freezeBonus;
    [SerializeField] private Image _outerRing;
    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;    
    }

    // Update is called once per frame
    private void Update()
    {
        _outerRing.fillAmount = 1 - (Time.time - _startTime) / _freezeBonus.Time;
    }
}
