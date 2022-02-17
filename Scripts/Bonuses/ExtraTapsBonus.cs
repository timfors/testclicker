using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtraTap", menuName = "Bonus/ExtraTap", order = 52)]
public class ExtraTapsBonus : Bonus 
{
    [SerializeField] private int _extraValue;

    public int ExtraValue { get => _extraValue; }
}
