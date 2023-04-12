using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitGameButton;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TMP_Text titleText;

    private Button[] buttons;

    private void Awake()
    {
        buttons = menuButtons.GetComponentsInChildren<Button>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterSettings()
    {
        settingsPanel.SetActive(true);
        titleText.enabled = false;
        ToggleButtons(false);
    }

    public void ExitSettings()
    {
        //TODO:Fix buttons not going back to correct place

        settingsPanel.SetActive(false);
        titleText.enabled = true;
        ToggleButtons(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ToggleButtons(bool toggle)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(toggle);
        }
    }
}
