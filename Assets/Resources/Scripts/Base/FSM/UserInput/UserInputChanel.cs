using FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UserInputChanel : EventListener<UserInputChanel>
{
    public string EventName;
    public object EventData;
    public void OnMMEvent(UserInputChanel eventType)
    {
        
    }

    public UserInputChanel(string nameEvent, object dataEvent)
    {
        EventName = nameEvent;
        EventData = dataEvent;      
    }

    public const string SELECT_CHARACTER_PREVIEW_CLICK = "SELECT_CHARACTER_PREVIEW_CLICK";

}
