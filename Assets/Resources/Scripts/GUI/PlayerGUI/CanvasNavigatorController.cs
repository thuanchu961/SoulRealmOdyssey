using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNavigatorController : MonoBehaviour
{
    [SerializeField] private GameObject joystickPanel;
    [SerializeField] private GameObject buttonsPanel;
    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        joystickPanel.SetActive(false);
        buttonsPanel.SetActive(false);
#elif PLATFORM_ANDROID
        joystickPanel.SetActive(true);
        buttonsPanel.SetActive(true);
#endif
    }
}
