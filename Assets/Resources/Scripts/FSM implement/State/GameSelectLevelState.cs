using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public class GameSelectLevelState : FSMState
{
    private GameSelectLevelStateDependency dependency;
    public override void OnEnter(object data)
    {
        base.OnEnter(data);
        GameSelectLevelStateData selectLevelStateData = (GameSelectLevelStateData)data;
        DoWork(selectLevelStateData);
    }
    public override void SetUp(object data)
    {
        dependency = (GameSelectLevelStateDependency)data;
    }
    private void DoWork(GameSelectLevelStateData selectLevelStateData)
    {
        dependency.SaveSystem.SetActiveLevel(selectLevelStateData.ActiveLevel);
        SceneController.Instant.LoadScene(selectLevelStateData.SceneIndex);
    }

}
public class GameSelectLevelStateData
{
    public int SceneIndex { get; set; }
    public int ActiveLevel { get; set; }
}
public class GameSelectLevelStateDependency
{
    public CallSaveSystem SaveSystem { get; set; }
}