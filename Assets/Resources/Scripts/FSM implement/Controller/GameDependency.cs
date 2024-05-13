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
        else
        {
            data = ConvertToType<T>(null);
        }
        return data;
    }
}
