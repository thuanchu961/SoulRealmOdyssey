using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Text gameTitleText;
    [SerializeField] private Text tapToStartText;
    [SerializeField] private float duration;
    private void Awake()
    {
        gameTitleText.text = "Sou<color=red>l</color> rea<color=red>l</color>m Ody<color=red>ss</color>ey";
    }

    private void Start()
    {
        tapToStartText.DOFade(0.25f, duration).SetEase(Ease.InOutBack).SetLoops(-1, LoopType.Yoyo);
    }

    public void PlayTutorial() {
        PlayMenuSound();
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayLevel1() {
        PlayMenuSound();
        SceneManager.LoadScene("Level3");
    }
    
    public void PlayLevel2() {
        PlayMenuSound();
        SceneManager.LoadScene("Level4");
    }

    public void PlayLevel3() {
        PlayMenuSound();
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame() {
        PlayMenuSound();
        Application.Quit();
    }

    public void PlayMenuSound() {
        SoundManager.Instant.PlaySound(Constant.SFX.MenuSound);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
