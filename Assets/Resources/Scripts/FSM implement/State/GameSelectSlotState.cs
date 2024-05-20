using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class GameSelectSlotState : FSMState
{
    private GameSelectSlotStateDependency dependency;
    public override void OnEnter(object data)
    {
        base.OnEnter(data);
        GameSelectSlotStateData slotStateData = (GameSelectSlotStateData)data;
        DoWork(slotStateData);
    }
    public override void SetUp(object data)
    {
        dependency = (GameSelectSlotStateDependency)data;
    }
    private void DoWork(GameSelectSlotStateData slotStateData)
    {
        dependency.SlotSelection.SetActive(false);
        dependency.LevelSelection.SetActive(true);
        dependency.SaveSystem.SetActiveSlot(slotStateData.SlotIndex);
        dependency.SaveSystem.CheckSaveLevel(); 
    }
}
public class GameSelectSlotStateData
{
    public int SlotIndex { get; set; }
}
public class GameSelectSlotStateDependency
{
    public GameObject SlotSelection { get; set; }
    public GameObject LevelSelection { get; set; }
    public CallSaveSystem SaveSystem { get; set; }
}