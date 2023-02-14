using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private void Update()
    {
        if (GetDown.Move)
        {
            Debug.Log("Boss move!");
        }
    }
}
