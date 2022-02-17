using UnityEngine;
using System;
using UnityEngine.Events;

public class GameEventsListener : MonoBehaviour
{
    [SerializeField] private GameEvent[] _gameEvents;
    [SerializeField] private UnityEvent[] _responces;

    private void OnEnable()
    {
        for (int i = 0; i < _gameEvents.Length; i++)
            _gameEvents[i].RegisterListener(this);
    }

    private void OnDisable()
    {
        for (int i = 0; i < _gameEvents.Length; i++)
            _gameEvents[i].UnregisterListener(this);
    }
    private void OnDestroy()
    {
        for (int i = 0; i < _gameEvents.Length; i++)
            _gameEvents[i].UnregisterListener(this);
    }

    public void OnEventRaised(GameEvent eventData)
    {
        int index = Array.FindIndex<GameEvent>(_gameEvents, el => el == eventData);

        if (index < 0)
            return;
        _responces[index].Invoke();
    }
}