using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleBall : MonoBehaviour
{
    [SerializeField] private BallLauncher ballLauncher;
    [SerializeField] public Button btnX2Ball;
    //private SkillShopItem skillShopItem;
    public static string isOwned;

    private void Start()
    {
        gameObject.SetActive(false);
        btnX2Ball.onClick.AddListener(DoubleBallPowerUp);

        if (SkillShopItem.isEquipDouble == true)
        {
            gameObject.SetActive(true);
        }

    }
    public void DoubleBallPowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use CloneBall?", () =>
        {
            ballLauncher.isDoubleUsed = true;
            ballLauncher.BallCount = ballLauncher.BallCount * 2;
            ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
            btnX2Ball.interactable = false;
        }, () =>
        {
            //Do nothing on No
        });
    }
}
