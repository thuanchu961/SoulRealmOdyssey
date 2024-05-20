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

            case UserInputChanel.SELECT_LEVEL_CLICK:
                GameSelectLevelStateData selectLevelStateData = new();
                selectLevelStateData.SceneIndex = (int)eventType.EventData;
                selectLevelStateData.ActiveLevel = (int)eventType.EventData - 1;
                GameEvent gameEvent = new(GameEventState.GAME_SELECT_LEVEL_STATE.ToString(), selectLevelStateData);
                ObserverManager.TriggerEvent<GameEvent>(gameEvent);
                break;

            case UserInputChanel.SELECT_SLOT_CLICK:
                GameSelectSlotStateData selectSlotStateData = new();
                selectSlotStateData.SlotIndex = (int)eventType.EventData;
                gameEvent = new(GameEventState.GAME_SELECT_SLOT_STATE.ToString(), selectSlotStateData);
                ObserverManager.TriggerEvent<GameEvent>(gameEvent);
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
