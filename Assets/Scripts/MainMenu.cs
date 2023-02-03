using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnQuit;
    [SerializeField] private Button btnReturn;
    [SerializeField] public GameObject panelLevel;

    private void Start()
    {
        btnPlay.onClick.AddListener(GoToGameplay);
        btnQuit.onClick.AddListener(QuitGame);
        btnReturn.onClick.AddListener(ReturnToMenu);

    }
    public void GoToGameplay()
    {
        panelLevel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        panelLevel.SetActive(false);
    }
}
