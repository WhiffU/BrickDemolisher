using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ConfirmDialogUI : MonoBehaviour
{
    public static ConfirmDialogUI Instance { get; private set; }
    private TextMeshProUGUI textMeshPro;
    private Button yesBtn;
    private Button noBtn;

    private void Awake()
    {
        Instance = this;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        yesBtn = transform.Find("YesBtn").GetComponent<Button>();
        noBtn = transform.Find("NoBtn").GetComponent<Button>();

        Hide();
    }
    public void ShowQuestion(string questionText,Action yesAction,Action noAction)
    {
        yesBtn.onClick.RemoveAllListeners();
        gameObject.SetActive(true);
        textMeshPro.text = questionText;
        yesBtn.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
         });
        noBtn.onClick.RemoveAllListeners();
        noBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
         });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
