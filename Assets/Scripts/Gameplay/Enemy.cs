using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private GetDown getDown;
    private enum State { idle, walking, hurt }
    private State state = State.idle;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        UpdateAnimationState();
        animator.SetInteger("state", (int)state);
    }

    private void UpdateAnimationState()
    {
        if(GetDown.Move)
        {
            state = State.walking;
         }
        if(GetDown.Move==false) 
        {
            state = State.idle;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();
            //state = State.hurt;
            animator.Play("Enemy_Hurt");
        }
    }
}
