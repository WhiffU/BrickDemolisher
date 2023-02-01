using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public static HudController Instance { get; set; }
    private int score = 0;
    [SerializeField] private TMP_Text scoreText, highScoreText;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject pauseMenu;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //score = 0;
        //scoreText.text = score.ToString();
       

    }
    public void UpdateScore()
    {
        //score +=1;
        //scoreText.text = score.ToString();
        ////PlayerPrefs.SetInt("score", score);
        //highScoreText.text = scoreText.text;
    }
    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        //scoreText.gameObject.SetActive(false);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false); 
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    public void GoToHome()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
