using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitGameButton;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private GameObject pauseMenu;

    private Button[] buttons;
    private InputManager playerInputManager;

    private void Awake()
    {
        if(menuButtons != null)
        {
            buttons = menuButtons.GetComponentsInChildren<Button>();
        }

    }

    private void OnEnable()
    {
        playerInputManager = FindObjectOfType<InputManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterSettings()
    {
        settingsPanel.SetActive(true);
        if(titleText != null)
        {
            titleText.enabled = false;
            ToggleButtons(false);
        }
        else if(pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        if(titleText != null)
        {
            titleText.enabled = true;
            ToggleButtons(true);
        }
        else if(pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    public void Pause()
    {
        this.gameObject.SetActive(true);
        playerInputManager.DisableMovement(pauseCamera:true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        playerInputManager.EnableMovement();
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ToggleButtons(bool toggle)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(toggle);
        }
    }
}
