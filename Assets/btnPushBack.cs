using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class btnPushBack : MonoBehaviour
{
    [SerializeField] public Button btnPush;
     [SerializeField] public PushBackSkill pushBackSkill;
 
    private void Start()
    {
        gameObject.SetActive(false);

        btnPush.onClick.AddListener(PushBackPowerUp);
        if (SkillShopItem.isEquipPushBack == true)
        {
            gameObject.SetActive(true);
        }
    }
    private void PushBackPowerUp()
    {
        ConfirmDialogUI.Instance.ShowQuestion("Do you want to use KAMEHAMEHA?", () =>
        {
            
            Instantiate(pushBackSkill);
            FindObjectOfType<AudioManager>().Play("Blow");
            btnPush.interactable = false;
         }, () =>
        {
            //Do nothing on No
        });
    }
    
}
