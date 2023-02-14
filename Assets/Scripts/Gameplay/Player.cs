using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Animator animator;
    private enum State { idle, charging, attacking }
    private State state = State.idle;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        UpdateAnimationState();
        animator.SetInteger("state", (int)state);
    }

    private void UpdateAnimationState()
    {
        
        if (Input.GetMouseButton(0))
        {
            state = State.charging;
            if (ballLauncher.angle > 90f)
            {
                spriteRenderer.flipX= true;
            }
            else
            {
                spriteRenderer.flipX= false;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            state = State.attacking;
        }
        else
        {
            state = State.idle;
        }
    }
    [SerializeField] private BallLauncher ballLauncher;
    private SpriteRenderer spriteRenderer;

}
