using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static int BlockNumber;
    public int BallNumber;

    public GameObject winPanel;
    //public GameObject losePanel;
    public GameObject endPanel;


    public bool isWinning = false;
    public int currentLevelIndex;
    public GameObject[] levels;
    private GameObject currentLevel;
    int numberOfUnlockedLevels;
    public int levelToUnlock;
    [SerializeField] private BallReturn ballReturn;
    [SerializeField] private BallLauncher ballLauncher;

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
        btnFreezing.interactable = true;
        btnX2Ball.interactable = true;
        btnBomb.interactable = true;
    }
    private void CompleteLevelCheck()
    {
        BlockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        BallNumber = GameObject.FindGameObjectsWithTag("Ball").Length;
        if (currentLevelIndex > 6)
        {
            Debug.Log("hello!");
            Destroy(currentLevel);
            Destroy(winPanel);
            //winPanel.SetActive(false);
            endPanel.SetActive(true);
        }
        if (BlockNumber == 0)
        {
            DataManager.Cash += 50;
            Debug.Log(DataManager.Cash);
            if (BallNumber != 0)
            {
                if (ballReturn.firstHit && ballLauncher.transform.childCount == 0)
                {
                    Debug.Log("new level!");
                    winPanel.SetActive(true);
                    UnlockLevel();
                    Destroy(currentLevel);
                    currentLevelIndex += 1;
                    levelToUnlock = currentLevelIndex;
                    isWinning = true;
                    CreateLevel();
                    currentLevel.gameObject.transform.position = new Vector3(0, 9.5f, 0);
                }
            }
            else
            {
                //Invoke("callWinPanel", 0.5f);
                winPanel.SetActive(true);
                UnlockLevel();
                Destroy(currentLevel);
                currentLevelIndex += 1;
                levelToUnlock = currentLevelIndex;
                isWinning = true;
                CreateLevel();
                currentLevel.gameObject.transform.position = new Vector3(0, 8.5f, 0);
            }

        }
        //End game

    }
    [SerializeField] private Button btnFreezing;
    [SerializeField] private Button btnX2Ball;
    [SerializeField] private Button btnBomb;


    private void callWinPanel()
    {
        winPanel.SetActive(true);

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
