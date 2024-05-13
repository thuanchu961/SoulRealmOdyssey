using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class GameManager : FSMManager, EventListener<GameEvent>
{
    protected override void Awake()
    {
        base.Awake();
        this.ObserverStartListening<GameEvent>();
    }
    protected override void Start()
    {
        base.Start();
        fSMSystem.SetupStateData(dependency);

        GameEvent gameEvent = new(GameEventState.GAME_INIT_STATE.ToString(), null);
        ObserverManager.TriggerEvent<GameEvent>(gameEvent);
    }
    public void OnMMEvent(GameEvent eventType)
    {
        (string eventName, object data) navigatorData = navigator.GetData(adapter, eventType.EventName, eventType.EventData);
        fSMSystem.GotoState(navigatorData.eventName, navigatorData.data);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        this.ObserverStopListening<GameEvent>();
    }
}
