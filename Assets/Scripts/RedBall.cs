using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            
                Destroy(obj.gameObject);
        }

        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 2f);
    }

    public static bool firstHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            firstHit = true;
            Destroy(collision.gameObject);
            ExplodeBall();
            Debug.Log("Boom!");
            Destroy(gameObject);
            CameraShaker.Instance.ShakeOnce(4, 4, 0.1f, 1f);
            ResetState();
        }
    }

    private void ResetState()
    {
        ballLauncher._canMove = true;
        ballLauncher._canDrag = true;
        ballLauncher.slider.transform.gameObject.SetActive(true);
        ballLauncher.BallCount = ballLauncher.BallCountDefault;
        ballLauncher.spriteRenderer.color = Color.white;
        ballLauncher._ballPrefab = ballLauncher.BallSprite;
        ballLauncher.ballCountText.text = ballLauncher.BallCount + "x";
        ballLauncher.Reset.transform.gameObject.SetActive(false);
        ballLauncher.ReturnBall();
    }
}
