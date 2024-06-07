using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGUI : MonoBehaviour, IEventListener
{
    private bool pauseMenuActive;
    private bool inventoryMenuActive;
    public GameObject pauseMenuBackground;
    public GameObject inventoryMenu;
    public GameObject pauseMenu;
    public GameObject dialogueMenu;
    public GameObject gameOverMenu;
    public GameObject gameVictoryMenu;
    public GameObject marineSelection;

    private Scene activeScene;
    private DialogueManager dialogueManager;
    private PlayerHealth playerHealth;
    private void Awake()
    {
        EventManager.Instant.AddListener(this, EventChanelID.GameState, EventChanelID.GamePlay);
    }
    void Start() {
        pauseMenuActive = false;
        inventoryMenuActive = false;
        activeScene = SceneManager.GetActiveScene();

        dialogueManager = FindObjectOfType<DialogueManager>();

        playerHealth = FindObjectOfType<PlayerHealth>();

        marineSelection.SetActive(true);
        pauseMenuBackground.SetActive(true);
    }
    
    void Update() {
        bool dialogueCheck = dialogueManager.DialoguePanelIsActive;

        if (Input.GetKeyDown(KeyCode.Escape) && !inventoryMenuActive && !dialogueCheck && !playerHealth.IsKill && !marineSelection.activeSelf)
            ShowPauseMenu();

        if (Input.GetKeyDown(KeyCode.E) && !pauseMenuActive && !dialogueCheck && !playerHealth.IsKill && !marineSelection.activeSelf)
            ShowInventory();

        if (playerHealth.IsKill && Time.timeScale != 0) {
            Time.timeScale = 0;
            pauseMenuBackground.SetActive(true);
            Cursor.visible = true;
            gameOverMenu.SetActive(true);
            FindObjectOfType<SoundManager>().StopAllSongs();
            SoundManager.Instant.PlaySound(Constant.SFX.GameOver);
        }
    }

    public void ShowPauseMenu() {
        PlayMenuSound();
        pauseMenuActive = !pauseMenuActive;
        pauseMenuBackground.SetActive(pauseMenuActive);
        pauseMenu.SetActive(pauseMenuActive);
        Cursor.visible = pauseMenuActive;
        Time.timeScale = pauseMenuActive ? 0 : 1;
    }

    public void ShowInventory() {
        PlayMenuSound();
        
        if (!inventoryMenuActive) {
            inventoryMenuActive = true;
            pauseMenuBackground.SetActive(inventoryMenuActive);
            inventoryMenu.SetActive(inventoryMenuActive);
            Cursor.visible = true;
            Time.timeScale = 0;
        } else {
            inventoryMenuActive = false;
            pauseMenuBackground.SetActive(inventoryMenuActive);
            inventoryMenu.SetActive(inventoryMenuActive);
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void Restart() {
        PlayMenuSound();
        FindObjectOfType<SoundManager>().StopAllSongs();
        ItemsInventory.itemsInInventory.Clear();
        SceneManager.LoadScene(activeScene.name);
    }

    public void Continue() {
        ShowPauseMenu();
    }

    public void ReturnToMenu() {
        PlayMenuSound();
        FindObjectOfType<SoundManager>().StopAllSongs();
        ItemsInventory.itemsInInventory.Clear();
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayMenuSound() {
        SoundManager.Instant.PlaySound(Constant.SFX.MenuSound);
    }

    public void ShowVictoryPanel()
    {
        Time.timeScale = 0;
        pauseMenuBackground.SetActive(true);
        Cursor.visible = true;
        gameVictoryMenu.SetActive(true);
        SoundManager.Instant.StopAllSongs();
        SoundManager.Instant.PlaySound(Constant.SFX.GameOver);
    }

    public void NextLevel()
    {
        SceneController.Instant.LoadScene(activeScene.buildIndex + 1);
    }

    public void OnReceiveEvent(EventMessage message)
    {
        if(message.eventChanelId == EventChanelID.GamePlay)
        {
            switch (message.eventName)
            {
                case EventName.GamePlay.GAME_PLAY_END:
                    ShowVictoryPanel();
                    break;
            }
        }
    }

    public GameObject DialoguePanel {
        get { return dialogueMenu; }
    }

    private void OnDestroy()
    {
        EventManager.Instant.RemoveListener(this);
    }
}
