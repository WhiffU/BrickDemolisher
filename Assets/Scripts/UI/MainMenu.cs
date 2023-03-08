using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnSkin;

    [SerializeField] private Button btnReturnFromLevel;
    [SerializeField] private Button btnReturnFromShop;
    [SerializeField] private Button btnReturnFromSkin;

    [SerializeField] public GameObject panelLevel;
    [SerializeField] public GameObject panelShop;
    [SerializeField] public GameObject panelSkin;

    [SerializeField] private TMP_Text cash;
    [SerializeField] private TMP_Text cashSkill;
    [SerializeField] private TMP_Text cashText;





    private void Start()
    {
        btnPlay.onClick.AddListener(GoToGameplay);
        btnShop.onClick.AddListener(OpenShop);
        btnSkin.onClick.AddListener(OpenSkin);

        btnReturnFromLevel.onClick.AddListener(ReturnFromLevel);
        btnReturnFromShop.onClick.AddListener(ReturnFromShop);
        btnReturnFromSkin.onClick.AddListener(ReturnFromSkin);

    }
    private void Update()
    {
        cash.text = DataManager.Cash.ToString();
        cashText.text = DataManager.Cash.ToString();
        cashSkill.text = DataManager.Cash.ToString();
    }
    private void OpenShop()
    {
        panelShop.SetActive(true);
        panelShop.transform.DOLocalMoveY(0, 0.5f);
    }
    private void OpenSkin()
    {
        panelSkin.SetActive(true);
        panelSkin.transform.DOLocalMoveY(0, 0.5f);
    }

    public void GoToGameplay()
    {
        panelLevel.SetActive(true);
        panelLevel.transform.DOLocalMoveY(0, 0.5f);
    }
    public void ReturnFromLevel()
    {
        panelLevel.transform.DOLocalMoveY(-2400, 0.5f);        

    }
    public void ReturnFromShop()
    {
        //panelShop.SetActive(false);
        panelShop.transform.DOLocalMoveY(-2400, 0.5f);

    }
    public void ReturnFromSkin()
    {
        //panelSkin.SetActive(false);
        panelSkin.transform.DOLocalMoveY(-2400, 0.5f);

    }
}
