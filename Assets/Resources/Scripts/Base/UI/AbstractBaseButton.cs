using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public abstract class AbstractBaseButton : MonoBehaviour
{
    protected Button button;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
    }
    protected virtual void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    protected abstract void OnClick();
}
