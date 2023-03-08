using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceExplode : MonoBehaviour
{
    [SerializeField] public Button btnFreezing;
    [SerializeField] private BallLauncher ballLauncher;
    [SerializeField] public FreezingSkill freezingSkill;
    [SerializeField] private BallReturn ballReturn;

    public static string isOwned;


    private void Start()
    {
        btnFreezing.onClick.AddListener(FreezingPowerUp);
        gameObject.SetActive(false);
        if (SkillShopItem.isEquipIceBomb == true)
        {
            gameObject.SetActive(true);
        }
    }
    private void FreezingPowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use IceBomb?", () =>
        {
            ballLauncher.isFreezingUsed = true;
            Instantiate(freezingSkill);
            btnFreezing.interactable = false;
            ballReturn.firstHit = true;
        }, () =>
        {
            //Do nothing on No
        });
    }
}
