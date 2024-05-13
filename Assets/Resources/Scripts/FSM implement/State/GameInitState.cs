using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using FSM;

public class GameInitState : FSMState
{
    private GameInitStateDependency dependency;
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken token;
    public override void OnEnter(object data)
    {
        base.OnEnter(data);
        cancellationTokenSource = new();
        DoWork();
    }
    public override void SetUp(object data)
    {
        dependency = (GameInitStateDependency)data;
    }
    private async void DoWork()
    {
        token = cancellationTokenSource.Token;
        dependency.PlayButton.onClick.AddListener(OnPlayButtonClick);
        dependency.QuitButton.onClick.AddListener(OnQuitButtonClick);
        await Task.Delay(1000, cancellationToken: token);
    }
    private void OnPlayButtonClick()
    {
        dependency.MainMenuObject.SetActive(false);
        dependency.LoadSelection.SetActive(true);
        dependency.MainMenu.PlayMenuSound();
        dependency.SaveSystem.CheckSaveSlots();
    }
    private void OnQuitButtonClick()
    {
        dependency.MainMenu.QuitGame();
    }
    public override void OnExit()
    {
        base.OnExit();
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
    }
}
public class GameInitStateData
{

}
public class GameInitStateDependency
{
    public GameObject MainMenuObject { get; set; }
    public GameObject LoadSelection { get; set; }
    public Button PlayButton { get; set; }
    public Button QuitButton { get; set; }
    public CallSaveSystem SaveSystem { get; set; }
    public MainMenu MainMenu { get; set; }
}