using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scale", menuName = "Bonus/Scale", order = 52)]
public class ScaleBonus : Bonus 
{
    [SerializeField] private float _scaleMultiply;

    public float ScaleMultiply { get => _scaleMultiply; }
}
