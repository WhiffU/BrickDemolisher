using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int Cash
    {
        get => PlayerPrefs.GetInt("Cash", 100);
        set => PlayerPrefs.SetInt("Cash", value);
    }
}
