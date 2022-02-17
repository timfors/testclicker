using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelWindowUI : PopUpUICreator
{
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private Image _levelImage;
    [SerializeField] private DifficultShower _difficultShower;
    private LevelInfo _levelInfo;

    public void Init(LevelInfo levelInfo)
    {
        _levelInfo = levelInfo;
        _levelName.text = levelInfo.LevelName;
        _levelImage.sprite = levelInfo.BackgroundImage;
        _difficultShower.ShowDifficulty(levelInfo.Difficulty);
    }

    public void OpenWindow(DetailedLevelWindow windowPrefab)
    {
        _openWindow.Raise();
        var newWindow = Instantiate<DetailedLevelWindow>(windowPrefab);
        newWindow.Init(_levelInfo);
    }
}
