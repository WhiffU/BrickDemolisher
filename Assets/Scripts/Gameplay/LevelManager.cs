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
    public bool isLosing = false;

    public int currentLevelIndex;
    public GameObject[] levels;
    public GameObject currentLevel;
    int numberOfUnlockedLevels;
    public int levelToUnlock;
    [SerializeField] private BallReturn ballReturn;
    [SerializeField] private BallLauncher ballLauncher;
    [SerializeField] private Dialogue dialogueBox;
    string url = "Skill";
    private void Start()
    {
        currentLevelIndex = PlayerPrefs.GetInt("levelIndex");
        CreateLevel();
        LoadSkill();
        if (currentLevelIndex == 0)
        {
            dialogueBox.gameObject.SetActive(true);
            Debug.Log("dialouge");
        }
    }
    private void LoadSkill()
    {
        GameObject go = Resources.Load<GameObject>(url + PlayerPrefs.GetInt("skillName"));
    }

    private void Update()
    {
        CompleteLevelCheck();
    }

    public void CreateLevel()
    {
        currentLevel = Instantiate(levels[currentLevelIndex]);
        currentLevel.transform.parent = gameObject.transform;
    }
    public void CompleteLevelCheck()
    {
        BlockNumber = GameObject.FindGameObjectsWithTag("Block").Length;
        BallNumber = GameObject.FindGameObjectsWithTag("Ball").Length;
       
        //MaxLevel
        if (currentLevelIndex >= 6)
        {
            Destroy(currentLevel);
            Destroy(winPanel);
            endPanel.SetActive(true);
        }
        if (BlockNumber == 0 && !isLosing)
        {
            if (BallNumber != 0 )
            {
                if (ballReturn.firstHit && ballLauncher.transform.childCount == 0)
                {
                    Debug.Log("new level!");
                    winPanel.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Win");
                    UnlockLevel();
                    Destroy(currentLevel);
                    currentLevelIndex += 1;
                    levelToUnlock = currentLevelIndex;
                    isWinning = true;
                    CreateLevel();
                    currentLevel.gameObject.transform.position = new Vector3(0, 9.5f, 0);
                    DataManager.Cash += 100;
                    ResetSkill();
                }
            }
            else
            {
                winPanel.SetActive(true);
                FindObjectOfType<AudioManager>().Play("Win");
                UnlockLevel();
                Destroy(currentLevel);
                currentLevelIndex += 1;
                levelToUnlock = currentLevelIndex;
                isWinning = true;
                CreateLevel();
                DataManager.Cash += 100;
                ResetSkill();
                Debug.Log(DataManager.Cash);
                currentLevel.gameObject.transform.position = new Vector3(0, 9f, 0);
            }
        }
    }
    [SerializeField] private Button[] skillButtons;

    private void ResetSkill()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("reset skills");
            skillButtons[i].interactable = true;
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
