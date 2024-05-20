using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using System;
public class GameNavigator : Navigator, IEventListener
{
    private void Awake()
    {
        EventManager.Instant.AddListener(this, EventChanelID.GameState, EventChanelID.GamePlay);
    }
    private void OnDestroy()
    {
        EventManager.Instant.RemoveListener(this);
    }
    public override (string, object) GetData(Adapter adapter, string eventName, object eventData)
    {
        GameEventState state = (GameEventState)Enum.Parse(typeof(GameEventState), eventName);
        switch (state)
        {
            case GameEventState.GAME_INIT_STATE:
                return (GameEventState.GAME_INIT_STATE.ToString(), null);

            case GameEventState.GAME_SELECT_LEVEL_STATE:
                GameSelectLevelStateData selectLevelStateData = (GameSelectLevelStateData)eventData;
                return (GameEventState.GAME_SELECT_LEVEL_STATE.ToString(), selectLevelStateData);

            case GameEventState.GAME_SELECT_SLOT_STATE:
                GameSelectSlotStateData selectSlotStateData = (GameSelectSlotStateData)eventData;
                return (GameEventState.GAME_SELECT_SLOT_STATE.ToString(), selectSlotStateData);
        }
        return ("", null); 
    }

    public void OnReceiveEvent(EventMessage message)
    {
        
    }
}
