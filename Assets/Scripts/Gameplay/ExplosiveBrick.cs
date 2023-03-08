using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class ExplosiveBrick : MonoBehaviour
{
    public float fieldOfImpact;
    public float explosiveForce;
    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;
    private BallLauncher ballLauncher;

    private void Start()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
    }
    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
           Destroy(obj.gameObject);
        }

        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("Explode");
        Destroy(ExplosionEffectIns, 5f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
        //ballLauncher.ReturnBall();
    }
}
