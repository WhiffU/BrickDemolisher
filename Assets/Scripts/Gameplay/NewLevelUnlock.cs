using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelUnlock : MonoBehaviour
{
    public static int BlockNumber;
    public bool isWin=false;
    public int levelToUnlock;
    int numberOfUnlockedLevels;
    private void Start()
    {
        //FindObjectOfType<AudioManager>().Play("GameTheme");
    }
    private void Update()
    {
        BlockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        if(BlockNumber== 0)
        {
            isWin= true;
            UnlockLevel();
        }
    }
    private void UnlockLevel()
    {
        if (isWin)
        {
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            }
        }
    }
}
