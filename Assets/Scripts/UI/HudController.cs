using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public static HudController Instance { get; set; }
    //private int score = 0;
    //[SerializeField] private TMP_Text scoreText, highScoreText;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button btnPause;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        btnPause.onClick.AddListener(PauseGame);

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
        FindObjectOfType<AudioManager>().Play("UI");
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("UI");
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        //scoreText.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("UI");
    }
}
