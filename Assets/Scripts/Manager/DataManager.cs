using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static int Cash
    {
        get => PlayerPrefs.GetInt("Cash", 0);
        set => PlayerPrefs.SetInt("Cash", value);
    }
    public static void OwnSkill(string name, bool isOwn)
    {
        PlayerPrefs.SetInt($"skill-{name}", isOwn ? 1 : 0);
    }
    public static void EquipSkill(string name, bool isEquip)
    {
        PlayerPrefs.SetInt($"skill-{name}", isEquip ? 1 : 0);
    }
    public static bool HaveSkill(string name)
    {
        return PlayerPrefs.GetInt($"skill-{name}", 0) == 1;
    }
     
    public static bool SelectSkill(string name)
    {
        return PlayerPrefs.GetInt($"skill-{name}", 0) == 1;
    }
}
