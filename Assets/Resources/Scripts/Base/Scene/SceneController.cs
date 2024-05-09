using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    [SerializeField] private GameObject LoadingCanvas;
    [SerializeField] private Image progressSlider;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneCoroutine(index));
    }
    private IEnumerator LoadSceneCoroutine(int index)
    {
        LoadingCanvas.SetActive(true);
        progressSlider.fillAmount = 0;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            progressSlider.fillAmount = progress;
            if (progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        LoadingCanvas.SetActive(false);
    }
}
