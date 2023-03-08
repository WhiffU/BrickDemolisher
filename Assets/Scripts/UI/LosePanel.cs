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
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Button[] skillButtons;



    private void Start()
    {
        btnRestart.onClick.AddListener(RestartLevel);
        btnGoToMainMenu.onClick.AddListener(GoToMainMenu);
        //FindObjectOfType<AudioManager>().Play("Lose");

    }
    public void RestartLevel()
    {
        Debug.Log("restart level2!");
        Destroy(levelManager.currentLevel);
        levelManager.isLosing= false;
        levelManager.CreateLevel();
        gameObject.SetActive(false);
        ResetSkill();
    }
    private void ResetSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("reset skills");
            skillButtons[i].interactable = true;
        }
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
