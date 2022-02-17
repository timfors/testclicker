using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Freeze", menuName = "Bonus/Freeze", order = 52)]
public class FreezeBonus : Bonus 
{
    [SerializeField] private float _time;

    public float Time { get => _time; }
}
