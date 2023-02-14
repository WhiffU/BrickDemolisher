using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStatus : MonoBehaviour
{
    public string skillStatus1;
    public string skillStatus2;

    public Button btnSkill1;
    public Button btnSkill2;


    private void Start()
    {
        btnSkill1.interactable = false; 
        btnSkill2.interactable=false;
        skillStatus1 = PlayerPrefs.GetString("skillStatus1");
        if (skillStatus1 == "PurchasedFireBall")
        {
            btnSkill1.interactable = true;
        }
        skillStatus2 = PlayerPrefs.GetString("skillStatus2");
        if (skillStatus2 == "PurchasedIceBomb")
        {
            btnSkill2.interactable = true;
        }
    }
}
