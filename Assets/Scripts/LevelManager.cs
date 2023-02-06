using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int BlockNumber;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject endPanel;


    public bool isWinning = false;
    public int currentLevelIndex;
    public GameObject[] levels;
    private GameObject currentLevel;
    int numberOfUnlockedLevels;
    public int levelToUnlock;
    [SerializeField] private BallReturn ballReturn;

    private void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("levelIndex");
        CreateLevel();
    }
    private void Update()
    {
        CompleteLevelCheck();
    }

    private void CreateLevel()
    {
        currentLevel = Instantiate(levels[currentLevelIndex]);
        currentLevel.transform.parent = gameObject.transform;
        
    }
    [SerializeField] private GetDown getDown;
    private void CompleteLevelCheck()
    {
        BlockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        if (BlockNumber == 0 && ballReturn.firstHit == true)
        {
            winPanel.SetActive(true);
            getDown.step = 0;
            UnlockLevel();
            Destroy(currentLevel);
            currentLevelIndex += 1;
            levelToUnlock = currentLevelIndex;
            isWinning = true;
            CreateLevel();
            currentLevel.transform.position = new Vector3(0, 8, 0);
        }
        //End game
        if (currentLevelIndex > 5)
        {
            endPanel.SetActive(true);
        }
    }
    private void UnlockLevel()
    {
        if (isWinning)
        {
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            }
        }
    }

}
