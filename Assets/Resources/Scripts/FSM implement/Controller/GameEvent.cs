using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public struct GameEvent : EventListener<GameEvent>
{
    public string EventName;
    public object EventData;
    public GameEvent(string nameEvent, object dataEvent)
    {
        EventName = nameEvent;
        EventData = dataEvent;
    }
    public void OnMMEvent(GameEvent eventType)
    {
        
    }
}
public enum GameEventState 
{ 
    GAME_INIT_STATE,
    GAME_START_MENU_STATE,
    GAME_SELECT_SLOT_STATE,
    GAME_SELECT_LEVEL_STATE,
}
