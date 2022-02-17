using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyPoint : MonoBehaviour
{
    [SerializeField] private Image _inner;

    public void SetState(bool state)
    {
        _inner.enabled = state  ;
    }
}
