using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultShower : MonoBehaviour
{
    [SerializeField] private DifficultyPoint[] _points;

    public void ShowDifficulty(int difficulty)
    {
        for (int i = 0; i < _points.Length; i++)
            _points[i].SetState(i < difficulty);
    }
}
