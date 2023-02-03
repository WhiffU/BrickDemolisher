using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winPanel : MonoBehaviour
{
    [SerializeField] private Button btnNextLevel;
    [SerializeField] private Button btnGoToMainMenu;
    private MainMenu mainMenu;
    private LevelManager levelManager;

    private void Start()
    {
        btnNextLevel.onClick.AddListener(NextLevel);
        btnGoToMainMenu.onClick.AddListener(GoToMainMenu);

    }
    public void NextLevel()
    {
        this.gameObject.SetActive(false);

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
