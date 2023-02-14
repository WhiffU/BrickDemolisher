using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBuyButton : MonoBehaviour
{
    public string skillStatus1;
    public string skillStatus2;

    [SerializeField] private Button btnPurchaseSkillFireBall;
    [SerializeField] private Button btnPurchaseSkillIceBomb;


    private void Start()
    {
        btnPurchaseSkillFireBall.onClick.AddListener(PurchaseSkillFireBall);
        btnPurchaseSkillIceBomb.onClick.AddListener(PurchaseSkillIceBomb);
    }

    public void PurchaseSkillFireBall()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to purchase this?", () =>
        {
            skillStatus1 = "PurchasedFireBall";
            btnPurchaseSkillFireBall.interactable = false;
            PlayerPrefs.SetString("skillStatus1", "PurchasedFireBall");
        }, () =>
        {
            //Do nothing on No
        });
    }
    public void PurchaseSkillIceBomb()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to purchase this?", () =>
        {
            skillStatus2 = "PurchasedIceBomb";
            btnPurchaseSkillIceBomb.interactable = false;
            PlayerPrefs.SetString("skillStatus2", "PurchasedIceBomb");
        }, () =>
        {
            //Do nothing on No
        });

    }
}
