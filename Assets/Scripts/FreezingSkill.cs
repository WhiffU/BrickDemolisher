using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingSkill : MonoBehaviour
{
    public int fieldOfImpact;
    public LayerMask LayerToHit;
    public Animator animator;
    public LevelBlock levelBlock;
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
            obj.GetComponent<LevelBlock>().hitsRemaining -= 4;
            

        }
    }
     private void Awake()
    {
        Explode();
        animator.Play("Skill3");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

    public void EndSkill()
    {
        Destroy(gameObject);
    }
}
