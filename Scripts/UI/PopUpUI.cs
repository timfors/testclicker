using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private GameEvent _closeUI;

    public void Close()
    {
        _closeUI.Raise();
        Destroy(gameObject);
    }
}
