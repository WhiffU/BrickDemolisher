using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class RedBall : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;


    public Rigidbody2D _rb;
    public Collider2D coll;
    private BallLauncher ballLauncher;

    private void Start()
    {
        ballLauncher = FindObjectOfType<BallLauncher>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _rb.velocity.normalized * _speed;
    }
    public float fieldOfImpact;
    public float explosiveForce;
    public LayerMask LayerToHit;
    public GameObject ExplosionEffect;
    public void ExplodeBall()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);

        foreach (Collider2D obj in objects)
        {
            obj.GetComponent<LevelBlock>().hitsRemaining -= 5;
        }
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 2f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("Firebolt");

        if (collision.gameObject.tag == "Block")
        {
            ExplodeBall();
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
            ResetState();
        }
        else
        {
            GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(ExplosionEffectIns, 2f);
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
            ResetState();
        }
    }

    private void ResetState()
    {
        ballLauncher.BallCount = ballLauncher.BallCountDefault;
        ballLauncher._ballPrefab = ballLauncher.BallSprite;
        ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
        ballLauncher.Reset.transform.gameObject.SetActive(false);
        ballLauncher.ReturnBall();
    }
}
