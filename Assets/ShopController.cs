using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Image selectedSkin;
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private TMP_Text cashText;


    void Update()
    {
        cashText.text = DataManager.Cash.ToString();
        //cherryText.text = "Cherry: " + PlayerPrefs.GetInt("Cherry");
        selectedSkin.sprite = skinManager.GetSelectedSkin().sprite;
    }
}
