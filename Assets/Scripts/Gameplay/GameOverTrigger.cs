using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject losePanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Block")
        {
            losePanel.SetActive(true);
            Debug.Log("You die!");
        }
    }
}
