using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SessionInfo", menuName = "Level/SessionInfo", order = 51)]
public class SessionInfo : ScriptableObject
{
    public LevelInfo LevelInfo;
    public float DieTime;
    public int WinScore;
    public List<Bonus> Bonuses = new List<Bonus>();

    private float _playTime;
    private int _score;

    public float PlayTime
    {
        get => _playTime;
        set
        {
            if (value > DieTime)
                _playTime = DieTime;
            else
                _playTime = value;
        }
    }

    public int Score
    {
        get => _score;
        set
        {
            if (value > WinScore)
                _score = WinScore;
            else
                _score = value;
        }
    }
}
