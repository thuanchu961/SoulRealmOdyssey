using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EventChanelID
{
    DefaultChanel,
    GameState,
    GamePlay,
    Guide,
    AccessPermission,
    AppManager,
}

[Serializable]
public class EventChanel
{
    public EventChanelID chanelId;
    private List<IEventListener> listeners;
    private List<IEventListener> deadListener;

    public EventChanel()
    {
        listeners = new List<IEventListener>();
        deadListener = new List<IEventListener>();
    }

    public void AddListener(IEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void PushEvent(EventMessage message)
    {
        var mListeners = new List<IEventListener>();
        mListeners.AddRange(listeners);

        foreach (var listener in mListeners)
        {
            try
            {
                listener.OnReceiveEvent(message);
            }
            catch (Exception)
            {
                deadListener.Add(listener);
            }
        }

        foreach (var listener in deadListener)
        {
            RemoveListener(listener);
        }

        deadListener.Clear();
    }
}
