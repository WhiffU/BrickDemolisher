using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDown : MonoBehaviour
{
    public static bool Move;
    private float speed = 8f;
    public float step;
    public Vector2 newPos;

    private void Start()
    {
        Move = false;
    }
    private void Update()
    {
        if (Move == true)
        {
            Debug.Log("Move!!!");
            step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, newPos, step);
            if (Vector2.Distance(gameObject.transform.position, newPos) < 0.1f)
            {
                Move = false;
            }
        }
    }
}
