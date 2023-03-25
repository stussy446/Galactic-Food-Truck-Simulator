using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject lostMenu;
    [SerializeField] private TMP_Text lostGameMessage;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        } 
        RemoveListenersFromLostMenu();
        AddListenersToLostMenu();
        ToggleLostMenu(false);
    }

    public void ToggleLostMenu(bool toggle)
    {
        lostMenu.SetActive(toggle);
    }

    public void AddListenersToLostMenu()
    {
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void RemoveListenersFromLostMenu()
    {
        restartButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}