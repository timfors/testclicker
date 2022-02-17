using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerSettings", menuName = "Level/SpawnerSettings", order = 51)]
public class SpawnerSettings : ScriptableObject
{
    [SerializeField] private BonusObject[] _bonusObjects = new BonusObject[] { };
    [SerializeField] private int[] _minTimeSpawn = new int[] { };
    [SerializeField] private int[] _maxTimeSpawn = new int[] { };
    [SerializeField] private float[] _spawnProbabilities = new float[] { };

    public int BonusCount
    {
        get => _bonusObjects.Length;
    }

    public (BonusObject bonusObject, int minTIme, int maxTime, float probabiity) ObjectInfo(int index)
    {
        return (_bonusObjects[index], _minTimeSpawn[index], _maxTimeSpawn[index], _spawnProbabilities[index]);
    }
}
