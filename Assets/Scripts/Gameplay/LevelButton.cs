using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    public int levelValue;
    public void OpenScene()
    {
        SceneManager.LoadScene("Gameplay");
        PlayerPrefs.SetInt("levelIndex",levelValue);
     }
}
