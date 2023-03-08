using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    [SerializeField] public Button btnX2Ball;
    [SerializeField] public Button btnBoom;
    [SerializeField] public Button btnFreezing;

    [SerializeField] public FreezingSkill freezingSkill;
    [SerializeField] private BallLauncher ballLauncher;
    [SerializeField] private BallReturn ballReturn;

    private void Start()
    {
        btnX2Ball.onClick.AddListener(DoubleBallPowerUp);
        btnBoom.onClick.AddListener(ExplosivePowerUp);
        btnFreezing.onClick.AddListener(FreezingPowerUp);
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

    public void DoubleBallPowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use CloneBall?", () =>
        {
            ballLauncher.isDoubleUsed = true;
            ballLauncher.BallCount = ballLauncher.BallCount * 2;
            ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
            btnX2Ball.interactable = false;
            this.gameObject.SetActive(false);
        }, () =>
        {
            //Do nothing on No
        });
    }
    public void ExplosivePowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use FireBolt?", () =>
        {
            ballLauncher.isExplosiveUsed = true;
            //ballLauncher._ballPrefab = ballLauncher.ExplosiveBulletSprite;
            ballLauncher.BallCount = 1;
            ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
            btnBoom.interactable = false;
        }, () =>
        {
            //Do nothing on No
        });
    }
}
