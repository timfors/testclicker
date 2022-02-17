using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelStatistics", menuName = "Level/LevelStatistics", order = 52)]
public class LevelStatistics : ScriptableObject
{
    public int Tries = 0;
    public int SuccessTries = 0;
    public int UsedBonuses = 0;
    public float BestTime = 0;
}
