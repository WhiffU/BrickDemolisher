using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private Button btnGoToMainMenu;
    private void Start()
    {
        btnGoToMainMenu.onClick.AddListener(GoToHome);
    }
    public void GoToHome()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }
}
