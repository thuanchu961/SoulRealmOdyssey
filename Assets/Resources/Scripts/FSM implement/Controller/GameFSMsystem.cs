using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using System;
public class GameFSMsystem : FSMSystem
{
    private FSMState initState;
    private FSMState selectLevelState;
    private FSMState selectSlotState;
    private void Awake()
    {
        initState = new GameInitState();
        selectLevelState = new GameSelectLevelState();
        selectSlotState = new GameSelectSlotState();
    }
    public override void SetupStateData<T>(T data)
    {
        if(data is Dependency dependency)
        {
            GameInitStateDependency initStateDependency = dependency.GetStateData<GameInitStateDependency>();
            initState.SetUp(initStateDependency);

            GameSelectLevelStateDependency selectLevelStateDependency = dependency.GetStateData<GameSelectLevelStateDependency>();
            selectLevelState.SetUp(selectLevelStateDependency);

            GameSelectSlotStateDependency selectSlotStateDependency = dependency.GetStateData<GameSelectSlotStateDependency>();
            selectSlotState.SetUp(selectSlotStateDependency);
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

            case GameEventState.GAME_SELECT_LEVEL_STATE:
                GotoState(selectLevelState, data);
                break;

            case GameEventState.GAME_SELECT_SLOT_STATE:
                GotoState(selectSlotState, data);
                break;
        }
    }
}
