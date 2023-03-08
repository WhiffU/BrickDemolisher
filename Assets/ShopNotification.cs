using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNotification : MonoBehaviour
{
    [SerializeField] Image notiSign;

    private void Start()
    {
        notiSign.enabled = false;
    }
    private void Update()
    {
        if (DataManager.Cash >= 100 && !notiSign)
        {
            Debug.Log("Rich!");
            notiSign.enabled = true;
        }
    }

}
