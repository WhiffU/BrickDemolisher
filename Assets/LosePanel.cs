using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnGoToMainMenu;
    [SerializeField] private Button btnQuitGame;

    private LevelManager levelManager;
    private void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnGoToMainMenu.onClick.AddListener(GoToMainMenu);
        btnQuitGame.onClick.AddListener(QuitGame);

    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        this.gameObject.SetActive(false);
        levelManager.currentLevelIndex = PlayerPrefs.GetInt("levelIndex");

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
