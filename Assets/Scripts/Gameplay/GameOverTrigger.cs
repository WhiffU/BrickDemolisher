using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Block")
        {
            levelManager.isWinning = false;
            levelManager.isLosing = true;
            //winPanel.SetActive(false);
            losePanel.SetActive(true);
            DataManager.Cash += 10;
            Debug.Log("You die!");
            Debug.Log(DataManager.Cash);
            FindObjectOfType<AudioManager>().Play("Lose");

        }
    }
}
