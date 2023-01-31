using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetParent : MonoBehaviour
{
    public static int BlockNumber;
    public GameObject winPanel;
    public bool isWin=false;
    private void Update()
    {
        BlockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        if(BlockNumber== 0)
        {
            isWin= true;
            EndGame();
        }
        
    }

    public int levelToUnlock;
    int numberOfUnlockedLevels;

    private void EndGame()
    {
        if (isWin)
        {
            Debug.Log("you win !!!");
            Invoke("CallWinPanel", 2f);
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if(numberOfUnlockedLevels<=levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            }

        }
    }
    private void CallWinPanel()
    {
        winPanel.SetActive(true);
    }
}
