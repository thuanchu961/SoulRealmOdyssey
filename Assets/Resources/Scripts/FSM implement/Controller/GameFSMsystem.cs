using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using System;
public class GameFSMsystem : FSMSystem
{
    private FSMState initState;
    private void Awake()
    {
        initState = new GameInitState();
    }
    public override void SetupStateData<T>(T data)
    {
        if(data is Dependency dependency)
        {
            GameInitStateDependency initStateDependency = dependency.GetStateData<GameInitStateDependency>();
            initState.SetUp(initStateDependency);
        }
    }
    public override void GotoState(string eventName, object data)
    {
        GameEventState state = (GameEventState)Enum.Parse(typeof(GameEventState), eventName);
        switch (state)
        {
            case GameEventState.GAME_INIT_STATE:
                GotoState(initState, data);
                break;
        }
    }
}
