using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;


    public Rigidbody2D _rb;
    public Collider2D coll;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _rb.velocity.normalized * _speed;
    }
}
