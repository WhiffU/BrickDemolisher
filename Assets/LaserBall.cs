using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBall : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
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
    public LayerMask LayerToHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LaserHit();
    }
    public void LaserHit()
    {
        line.gameObject.SetActive(true);
        line.SetPosition(0, new Vector2(-3, transform.position.y));
        line.SetPosition(1, new Vector2(transform.position.x, transform.position.y));
        line.SetPosition(2, new Vector2(3, transform.position.y));
        line.SetPosition(3, new Vector2(transform.position.x, transform.position.y));


        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(transform.position.x, transform.position.y));
        //Debug.DrawLine(hit.point, hit.normal, color: Color.green);
    }

}
