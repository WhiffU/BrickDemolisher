using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleImage : MonoBehaviour
{    
    public bool isOn;

    public GameObject onIcon;
    public GameObject offIcon;
    private void Update()
    {
        if (isOn)
        {
            onIcon.gameObject.SetActive(true);
            offIcon.gameObject.SetActive(false);
        }
        else
        {
             
            onIcon.gameObject.SetActive(false);
            offIcon.gameObject.SetActive(true);
        }
    }

    public void Toggle(bool toggleStatus)
    {
        isOn = !isOn;
    }

}
