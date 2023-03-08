using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnGoToMainMenu;
    [SerializeField] private Button btnResume;

    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Button[] skillButtons;

    private void Start()
    {
        btnGoToMainMenu.onClick.AddListener(GoToHome);
        btnRestart.onClick.AddListener(RestartGame);
        btnResume.onClick.AddListener(ResumeGame);

    }
    private void ResetSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("reset skills");
            skillButtons[i].interactable = true;
        }
    }
    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        //Application.LoadLevel(Application.loadedLevel);
        Debug.Log("restart level!");
        Destroy(levelManager.currentLevel);
        levelManager.CreateLevel();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        ResetSkill();
        

    }
    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void GoToHome()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }
}
