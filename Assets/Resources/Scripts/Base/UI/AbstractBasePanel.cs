using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbstractBasePanel : MonoBehaviour
{
    protected RectTransform rectTransform;
    protected CanvasGroup canvasGroup;
    protected Vector3 originAnchoredPosition;
    protected Vector3 originLocalScale;

    protected virtual void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    protected virtual void Start()
    {
        originAnchoredPosition = rectTransform.anchoredPosition;
        originLocalScale = rectTransform.localScale;
    }
    public abstract void SetUp(object data);
    public abstract void Show(float duration);
    public abstract void Hide(float duration);
    public virtual void SetInteractable(bool value)
    {
        canvasGroup.interactable = value;
    }
}
