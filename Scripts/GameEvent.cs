using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class GameEvent : ScriptableObject
{
    private List<GameEventsListener> listeners = new List<GameEventsListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(this);
        }
    }

    public void RegisterListener(GameEventsListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventsListener listener)
    {
        listeners.Remove(listener);
    }
}