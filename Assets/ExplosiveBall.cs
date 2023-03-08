using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosiveBall : MonoBehaviour
{
    [SerializeField] public Button btnBoom;
    [SerializeField] private BallLauncher ballLauncher;
    public static string isOwned;

    private void Start()
    {
        gameObject.SetActive(false);

        btnBoom.onClick.AddListener(ExplosivePowerUp);
        if (SkillShopItem.isEquipMeteor == true)
        {
            gameObject.SetActive(true);
        }
    }
    public void ExplosivePowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use FireBolt?", () =>
        {
            ballLauncher.isExplosiveUsed = true;
            ballLauncher._ballPrefab = ballLauncher.ExplosiveBulletSprite;
            ballLauncher.BallCount = 1;
            ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
            btnBoom.interactable = false;
        }, () =>
        {
            //Do nothing on No
        });
    }
}
