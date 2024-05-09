using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class TestSaveLoadData : MonoBehaviour, IEventListener
{
    [SerializeField]
    private TMP_InputField InputField;
    [SerializeField] private bool Encrypted;
    private GameData GameData = new GameData();
    private IDataService DataService = new JsonDataServiceManager();
    private string path = "/player_data.json";
    private void Awake()
    {
        EventManager.Instant.AddListener(this, EventChanelID.GamePlay);
    }

    private void OnDestroy()
    {
        EventManager.Instant?.RemoveListener(this);
    }
    public void SaveData()
    {
        long startTime = DateTime.Now.Ticks;
        if (DataService.SaveData(path, GameData, Encrypted))
        {
            var SaveTime = DateTime.Now.Ticks - startTime;
            Debug.Log($"SAVE DATA SUCCESS!!. Save Time: {(SaveTime / TimeSpan.TicksPerMillisecond):N4}ms");

            EventManager.Instant.Push(EventChanelID.GamePlay, EventName.GamePlay.ACTION_DONE, null);
        }
        else
        {
            Debug.Log($"SAVE DATA FAILED");
        }
    }
    public void LoadData()
    {
        long startTime = DateTime.Now.Ticks;
        try
        {
            GameData data = DataService.LoadData<GameData>(path, Encrypted);

            var LoadTime = DateTime.Now.Ticks - startTime;
            InputField.text = "Loaded from file:\r\n" + JsonConvert.SerializeObject(data, Formatting.Indented);
            Debug.Log($"Load Time: {(LoadTime / TimeSpan.TicksPerMillisecond):N4}ms");
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void OnReceiveEvent(EventMessage message)
    {
        if (message.eventChanelId == EventChanelID.GamePlay)
        {
            switch (message.eventName)
            {
                case EventName.GamePlay.ACTION_DONE:
                    Debug.Log("receive event");
                    break;
            }
        }
    }
}
