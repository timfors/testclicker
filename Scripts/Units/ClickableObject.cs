using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameEvent _onClickEvent;

    protected virtual void Click()
    {
        _onClickEvent.Raise();
    }

    public virtual void OnPointerClick(PointerEventData data)
    {
        Click();
    }
}
