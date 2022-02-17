using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BonusHandler : MonoBehaviour
{
    [Header("Global Variables")]
    [SerializeField] private SessionInfo _sessionInfo;
    [Header("Settings")]
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private int _maxBonusCount = 1;
    private MainObject _clicker;
    private Coroutine _unfreezer;

    public void Init(MainObject newClicker)
    {
        _clicker = newClicker;
    }

    private void FreeSpace(Bonus bonus)
    {
        if (_sessionInfo.Bonuses.FindIndex(el => bonus.GetType() == el.GetType()) is var index && index != -1)
            UnsetBonus(_sessionInfo.Bonuses[index]);
        if (_sessionInfo.Bonuses.Count == _maxBonusCount)
            UnsetBonus(_sessionInfo.Bonuses[0]);
    }

    private void UnsetBonus(Bonus bonus)
    {
        if (bonus is FreezeBonus)
            UnsetBonus((FreezeBonus)bonus);
        else if (bonus is ScaleBonus)
            UnsetBonus((ScaleBonus)bonus);
        else if (bonus is ExtraTapsBonus)
            UnsetBonus((ExtraTapsBonus)bonus);
    }

    public void SetBonus(FreezeBonus freezeBonus)
    {
        FreeSpace(freezeBonus);
        _sessionInfo.Bonuses.Add(freezeBonus);
        _clicker.Freeze();
        if (_unfreezer != null)
            StopCoroutine(_unfreezer);
        _unfreezer = StartCoroutine(ActionAfter(freezeBonus.Time, () => UnsetBonus(freezeBonus)));
    }


    private void UnsetBonus(FreezeBonus freezeBonus)
    {
        if (_sessionInfo.Bonuses.FindIndex(el => freezeBonus == el) is var index && index != -1)
            _sessionInfo.Bonuses.RemoveAt(index);
        _clicker.UnFreeze();
    }

    private IEnumerator ActionAfter(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
    public void SetBonus(ScaleBonus scaleBonus)
    {
        FreeSpace(scaleBonus);
        _sessionInfo.Bonuses.Add(scaleBonus);
        _clicker.Scale(scaleBonus.ScaleMultiply);
    }

    private void UnsetBonus(ScaleBonus scaleBonus)
    {
        if (_sessionInfo.Bonuses.FindIndex(el => scaleBonus == el) is var index && index != -1)
            _sessionInfo.Bonuses.RemoveAt(index);
        _clicker.Unscale(scaleBonus.ScaleMultiply);
    }

    public void SetBonus(ExtraTapsBonus extraTapBonnus)
    {
        FreeSpace(extraTapBonnus);
        _sessionInfo.Bonuses.Add(extraTapBonnus);
        _levelManager.AddIncreaseValue(extraTapBonnus.ExtraValue);
    }

    private void UnsetBonus(ExtraTapsBonus extraTapBonus)
    {
        if (_sessionInfo.Bonuses.FindIndex(el => extraTapBonus == el) is var index && index != -1)
            _sessionInfo.Bonuses.RemoveAt(index);
        _levelManager.RemoveIncreaseValue(extraTapBonus.ExtraValue);
    }
}
