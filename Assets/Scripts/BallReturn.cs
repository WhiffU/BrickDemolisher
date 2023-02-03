using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    private BallLauncher _ballLauncher;
    public bool firstHit;

    private void Start()
    {
        firstHit = false;
        _ballLauncher = FindObjectOfType<BallLauncher>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        { 
            firstHit= true;
        }
            Destroy(collision.collider.gameObject);
    }
    private void Update()
    {
        if (firstHit == true)
        {
            if (_ballLauncher.transform.childCount == 0)
            {
                _ballLauncher.ReturnBall();
                firstHit= false;
            }
        } 
    }
    
}
