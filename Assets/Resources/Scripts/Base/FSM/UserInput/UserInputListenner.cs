using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputListenner : MonoBehaviour, EventListener<UserInputChanel>
{
    public virtual void OnMMEvent(UserInputChanel eventType)
    {
        switch (eventType.EventName)
        {
            case UserInputChanel.SELECT_CHARACTER_PREVIEW_CLICK:
                break;
        }
    }

    private void Awake()
    {
        this.ObserverStartListening<UserInputChanel>();
    }
    private void OnDestroy()
    {
        this.ObserverStopListening<UserInputChanel>();
    }
}
