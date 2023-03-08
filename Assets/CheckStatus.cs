using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStatus : MonoBehaviour
{
    public GameObject[] skillsPrefab;
     public int skillIndex;
   
    private void Start()
    {
        SetSkill();
        
    }
    private void SetSkill()
    {
        skillIndex = PlayerPrefs.GetInt("ID");
    }
}
