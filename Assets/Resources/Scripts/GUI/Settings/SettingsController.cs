using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private InputField playerNameInputField;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    private PlayerPrefsManager prefsManager;
    private void Awake()
    {
        prefsManager = PlayerPrefsManager.Instant;
    }
    private void Start()
    {
        playerNameInputField.onValueChanged.AddListener(OnPlayerNameValueChanged);
        playerNameInputField.onEndEdit.AddListener(OnEndEdit);

        musicSlider.value = (float)prefsManager.Load(Constant.GENERAL_KEY.MUSIC_VOLUME);
        soundSlider.value = (float)prefsManager.Load(Constant.GENERAL_KEY.SOUND_VOLUME);
        playerNameInputField.text = (string)prefsManager.Load(Constant.GENERAL_KEY.PLAYER_NAME);
    }
    public void OnMusicVolumeChange()
    {
        prefsManager.Save(Constant.GENERAL_KEY.MUSIC_VOLUME, musicSlider.value);
    }

    public void OnSoundVolumeChange()
    {
        prefsManager.Save(Constant.GENERAL_KEY.SOUND_VOLUME, soundSlider.value);
    }

    private void OnPlayerNameValueChanged(string value)
    {
        
    }

    private void OnEndEdit(string value)
    {
        prefsManager.Save(Constant.GENERAL_KEY.PLAYER_NAME, value);
    }

    public void GetInputFieldValue()
    {
        string currentValue = playerNameInputField.text;
    }


}
