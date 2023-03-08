using EZCameraShake;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PushBackSkill : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private float speed=8;
    [SerializeField] private float damge = 3f;

    [SerializeField] private float fieldOfImpact;
    [SerializeField] private float force;
    [SerializeField] private LayerMask layerToHit;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,15), speed*Time.deltaTime);
        
        if(transform.position.y > 14)
        {
            Destroy(gameObject);
        }
    }

    private void PushBack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction*force*Time.deltaTime);
            obj.GetComponent<LevelBlock>().hitsRemaining -= (int)damge;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
        PushBack();
    }

}
