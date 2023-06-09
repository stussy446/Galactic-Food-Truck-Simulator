using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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

    [Header("Scene transition image")]
    [SerializeField] private Image transitionImage;

    [Header("Scene transition speed")]
    [SerializeField] private float alphaIncreaseRate = 1f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip transitionAudio;

    private Button[] buttons;
    private InputManager playerInputManager;
    private Transform customer;

    private void Awake()
    {
        if(menuButtons != null)
        {
            buttons = menuButtons.GetComponentsInChildren<Button>();
        }

        if(transitionImage != null)
        {
            transitionImage.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        playerInputManager = FindObjectOfType<InputManager>();
    }

    /// <summary>
    /// Loads the first playable scene of the game 
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// enables the settings panel and disables any title text/buttons or other pause menus that exist in the scene
    /// </summary>
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

    /// <summary>
    /// Disables the settings panel and enables any title text/buttons or other pause menus that exist in the scene
    /// </summary>
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

    /// <summary>
    /// Pauses the game and disables player movement
    /// </summary>
    public void Pause()
    {
        this.gameObject.SetActive(true);
        playerInputManager.DisableMovement(pauseCamera:true);
        GameManager.instance.gamePaused = true;
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the game and enables player movement
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1f;
        GameManager.instance.gamePaused = false;
        playerInputManager.EnableMovement();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// Quits the game if the game is being played in an build
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Quits out from the game back into the main menu
    /// </summary>
    public void QuitToMenu()
    {
        if (Time.timeScale < 0.1f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Toggles all buttons on and off based on the provided toggle boolean value
    /// </summary>
    /// <param name="toggle">bool</param>
    private void ToggleButtons(bool toggle)
    {
        if(buttons != null)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(toggle);
            }
        }
    }

    /// <summary>
    /// Loads the next scene after finishing any scene transition behavior
    /// </summary>
    public void LoadNextScene()
    {
        if(transitionImage != null)
        {
            transitionImage.gameObject.SetActive(true);
        }

        ToggleButtons(false);

        if(audioSource != null)
        {
            audioSource.clip = transitionAudio;
            audioSource.loop = false;
            audioSource.Play();
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            customer = GameObject.FindGameObjectWithTag("Intro Customer").transform;
        }

        StartCoroutine(FadeOut());
    }

    /// <summary>
    /// fades a scene to darkness at a configurable rate
    /// </summary>
    /// <returns>enumerator</returns>
    private IEnumerator FadeOut()
    {
        while (transitionImage.color.a < 1)
        {
            Color currentColor = transitionImage.color;
            currentColor.a += alphaIncreaseRate;
            transitionImage.color = currentColor;

            if(titleText != null)
            {
                titleText.transform.position += new Vector3(0f, 1.5f, 0f);
            }

            if(customer != null && customer.position.y < 0f)
            {
                customer.Translate(Vector3.up * Time.deltaTime * 2.5f);
            }

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(LoadNextSceneCoroutine());
    }

    /// <summary>
    /// Loads the next scene of the game, if it is the last scene in the game then loads the first scene
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadNextSceneCoroutine()
    {
        while (transitionImage.color.a < 1)
        {
            yield return null;
        }

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

