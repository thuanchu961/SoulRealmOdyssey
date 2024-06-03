using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        source.volume = (float)PlayerPrefsManager.Instant.Load(Constant.GENERAL_KEY.MUSIC_VOLUME);
    }
}
