using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class FreezingSkill : MonoBehaviour
{
    public int fieldOfImpact;
    public LayerMask LayerToHit;
    public Animator animator;
    public LevelBlock levelBlock;
    public GameObject ExplosionEffect;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public BallLauncher ballLauncher;
    public void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldOfImpact,LayerToHit,0,0);
        foreach(Collider2D obj in objects)
        {
            //DAMAGE OUTPUT
            obj.GetComponent<LevelBlock>().hitsRemaining -= 1;
        }
        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("IceExplode");

        Destroy(ExplosionEffectIns, 3f);
    }
     private void Awake()
    {
        Explode();
        //animator.Play("Skill3");
    }
    public void EndSkill()
    {
        Destroy(gameObject);
    }
}
