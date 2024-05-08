using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
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
        SoundManager.PlaySound("MenuSound");
    }
}
