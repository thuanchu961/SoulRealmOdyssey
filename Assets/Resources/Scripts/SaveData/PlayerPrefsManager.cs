using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefsManager : Singleton<PlayerPrefsManager>
{
    public void Save(Constant.GENERAL_KEY general_key, object value)
    {
        string key = general_key.ToString();
        Type valueType = value.GetType();
        if (valueType == typeof(int))
        {
            PlayerPrefs.SetInt(key, (int)value);
        }
        else if(valueType == typeof(float))
        {
            PlayerPrefs.SetFloat(key, (float)value);
        }
        else if(valueType == typeof(string))
        {
            PlayerPrefs.SetString(key, (string)value);
        }

        PlayerPrefs.Save();
    }

    public object Load(Constant.GENERAL_KEY general_key)
    {
        string key = general_key.ToString();
        object value = null;
        switch (general_key)
        {
            case Constant.GENERAL_KEY.PLAYER_NAME:
                {
                    string v = $"Player{UnityEngine.Random.Range(1000, 9999)}";
                    value = PlayerPrefs.GetString(key, v);
                }
                return value;

            case Constant.GENERAL_KEY.MUSIC_VOLUME:
            case Constant.GENERAL_KEY.SOUND_VOLUME:
                {
                    value = PlayerPrefs.GetFloat(key, 1.0f);
                }
                return value;
        }

        return value;
    }
}
