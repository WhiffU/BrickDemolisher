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
    private bool exploded = false;

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            exploded = true;
            Destroy(obj.gameObject);

            Debug.Log(obj);

            //obj.gameObject.SetActive(false); 
        }

        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 5f);
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
