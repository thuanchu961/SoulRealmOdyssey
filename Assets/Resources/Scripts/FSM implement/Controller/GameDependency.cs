using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FSM;
using System;
public class GameDependency : Dependency
{
    [Space(5)]
    [Header("=====Common Dependency======")]
    [SerializeField] private CallSaveSystem saveSystem;
    [Space(5)]
    [Header("=====Main Menu Dependency======")]
    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject loadSelection;
    [SerializeField] private GameObject levelSelection;
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private MainMenu mainMenu;
    public override T GetStateData<T>()
    {
        T data;

        Type type = typeof(T);
        if(type == typeof(GameInitStateDependency))
        {
            GameInitStateDependency initStateDependency = new();
            initStateDependency.MainMenuObject = mainMenuObject;
            initStateDependency.LoadSelection = loadSelection;
            initStateDependency.PlayButton = playButton;
            initStateDependency.QuitButton = quitButton;
            initStateDependency.MainMenu = mainMenu;
            initStateDependency.SaveSystem = saveSystem;
            data = ConvertToType<T>(initStateDependency);
        }
        else if (type == typeof(GameSelectLevelStateDependency))
        {
            GameSelectLevelStateDependency selectLevelStateDependency = new();
            selectLevelStateDependency.SaveSystem = saveSystem;
            data = ConvertToType<T>(selectLevelStateDependency);
        }
        else if (type == typeof(GameSelectSlotStateDependency))
        {
            GameSelectSlotStateDependency selectSlotStateDependency = new();
            selectSlotStateDependency.SaveSystem = saveSystem;
            selectSlotStateDependency.LevelSelection = levelSelection;
            selectSlotStateDependency.SlotSelection = loadSelection;
            data = ConvertToType<T>(selectSlotStateDependency);
        }
        else
        {
            data = ConvertToType<T>(null);
        }
        return data;
    }
}
