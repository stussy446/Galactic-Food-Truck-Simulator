using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitGameButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private GameObject menuButtons;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterSettings()
    {
        // TODO: make a settings page
        settingsPanel.SetActive(true);
        menuButtons.SetActive(false);
        ToggleTitle(false);
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        ToggleTitle(true);
        menuButtons.SetActive(true);
    }

    public void QuitGame()
    {
        // TODO: Quit Game
        Application.Quit();
    }

    private void ToggleTitle(bool toogle)
    {
        titleText.enabled = toogle;
    }
}
