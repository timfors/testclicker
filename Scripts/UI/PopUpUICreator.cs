using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUICreator : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] protected GameEvent _openWindow;
    
    public virtual void OpenWindow(PopUpUI prefab)
    {
        Instantiate<PopUpUI>(prefab);
        _openWindow.Raise();
    }
}
