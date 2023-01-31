using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private int _numOfExtraBalls = 2;
    [SerializeField] private PointBall PointBallPrefab;
    [SerializeField] private float _distanceBetweenExtraBalls = 0.5f;
    private int _rowSpawned = 0;
    private List<PointBall> _extraSpawned = new List<PointBall>();
    


    private void OnEnable()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        foreach(var ball in _extraSpawned)
        {
             
                ball.transform.position += Vector3.down * _distanceBetweenExtraBalls;
             
        }
        for(int i = 0; i <= _numOfExtraBalls; i++)
        {
            if (UnityEngine.Random.Range(0, 100) > 50)
            {
                var ball = Instantiate(PointBallPrefab, GetPosition(i), Quaternion.identity);

                _extraSpawned.Add(ball);
            }
        }
        _rowSpawned++;
    }
    
    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.left * i * _distanceBetweenExtraBalls;
            return position;
    }
}
