using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SkillShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text skillName;
    [SerializeField] private int price;
    [SerializeField] Button buyButton;
    [SerializeField] Button selectButton;
    [SerializeField] Image skillIcon;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text cashText;
    [SerializeField] private TMP_Text selectText;
    [SerializeField] private int ID;
    public string status;
    public static bool isEquipDouble;
    public static bool isEquipMeteor;
    public static bool isEquipIceBomb;
    public static bool isEquipPushBack;
    public static bool isPurchased;
    [SerializeField] private Image notiSign;

    public UnlockableMatrix unlockableMatrix;
    private string unlockMatrixPath;

    private void Start()
    {
        buyButton.onClick.AddListener(Buy);
        selectButton.onClick.AddListener(Select);
        if (!DataManager.HaveSkill(name))
        {
            buyButton.gameObject.SetActive(true);
            priceText.text = price.ToString();
        }
        else
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            if(DataManager.SelectSkill(name))
            {
                selectText.text = "EQUIPPED";
                selectButton.interactable = false;
                PlayerPrefs.SetInt("ID", ID);
                switch (ID)
                {
                    case 0:
                        isEquipDouble = true;
                        break;
                    case 1:
                        isEquipMeteor = true;

                        break;
                    case 2:
                        isEquipIceBomb = true;

                        break;
                    case 3:
                        isEquipPushBack = true;

                        break;
                }
            }
        }
        unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";
        //if (File.Exists(unlockMatrixPath))
        //{
        //    string json = File.ReadAllText(unlockMatrixPath);
        //    unlockableMatrix = JsonUtility.FromJson<UnlockableMatrix>(json);
        //}
    }

    private void SaveJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrix);
        File.WriteAllText(unlockMatrixPath, json);
    }
    private void Update()
    {
        cashText.text = DataManager.Cash.ToString();
        if (DataManager.Cash < price)
        {
            buyButton.interactable = false;
            notiSign.enabled = false;
            return;

        }
        else
        {
            buyButton.interactable = true;
            notiSign.enabled = true;
            return;

        }
    }

    public void Buy()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to learn this skill?", () =>
        {
            DataManager.Cash -= price;
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
            DataManager.OwnSkill(name, true);
        }, () =>
        {
            //Do nothing on No
        });

    }
    public void Select()
    {
        selectText.text = "EQUIPPED";
        selectButton.interactable = false;
        PlayerPrefs.SetInt("ID", ID);
        SaveJson();
        switch (ID)
        {
            case 0:
                isEquipDouble = true;
                break;
            case 1:
                isEquipMeteor = true;

                break;
            case 2:
                isEquipIceBomb = true;

                break;
            case 3:
                isEquipPushBack = true;

                break;
        }
        DataManager.EquipSkill(name, true);
        PlayerPrefs.SetString("skillName", skillName.text);
        PlayerPrefs.SetString("Status", "isOwned");

    }

}
