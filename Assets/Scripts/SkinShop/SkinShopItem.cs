using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    [SerializeField] private int skinIndex;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text cashText;
    private Skin skin;
    [SerializeField] private Image notiSign;

    public void Start()
    {
        skin = skinManager.skins[skinIndex];
        GetComponent<Image>().sprite = skin.sprite;
       
        if (skinManager.isUnlocked(skinIndex))
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            cashText.text = skin.cash.ToString();
        }
       
    }
    private void Update()
    {
        if (DataManager.Cash >= skin.cash)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;

        }
        if (DataManager.Cash>=skin.cash&&!skinManager.isUnlocked(skinIndex))
        {
            notiSign.enabled= true;
        }
        else
        {
            notiSign.enabled= false;
            return;
        }
        if (skin.cash == 0) 
        {
            Debug.Log("Free");
            //buyButton.gameObject.SetActive(false);
            return;
        }
    }

    public void OnSkinPressed()
    {
        if (skinManager.isUnlocked(skinIndex))
        {
            skinManager.SelectSkin(skinIndex);
        }
    }
    public void OnBuyButtonPressed()
    {
        int Cash = DataManager.Cash;
        //Unlock the skin
        if (Cash >= skin.cash && !skinManager.isUnlocked(skinIndex))
        {
            DataManager.Cash -= skin.cash;
            cashText.text = skin.cash.ToString();
            skinManager.Unlock(skinIndex);
            buyButton.gameObject.SetActive(false);
            skinManager.SelectSkin(skinIndex);
        }
        else
        {
            Debug.Log("Not enough cash!");
        }
    }

}
