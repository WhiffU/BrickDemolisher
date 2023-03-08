using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillDatabase : ScriptableObject
{
    public Skills[] skills;

    public int SkillCount
    {
        get
        {
            return skills.Length;
        }
    }

    public Skills GetSkill(int index)
    {
        return skills[index];
    }
}
