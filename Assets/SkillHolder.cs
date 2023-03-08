using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SkillHolder:MonoBehaviour
{
    [SerializeField] private int skillID;
    [SerializeField] private string skillName;
    [SerializeField] private GameObject skillPrefab;

    private void Start()
    {
        skillID = PlayerPrefs.GetInt("ID");
        skillName = PlayerPrefs.GetString("skillName");
    }
}
