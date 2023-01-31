using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RowSpawner : MonoBehaviour
{
    private int _numOfBlock = 8;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private float _distanceBetweenBlocks = 0.5f;
    private List<Block> _blockSpawned = new List<Block>();
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject slider;

    [SerializeField] private PointBall pointBall;
    private List<PointBall> _ballSpawned = new List<PointBall>();

    private int _rowSpawned = 0;


    private void OnEnable()
    {
        SpawnRow();
    }
    public void SpawnRow()
    {
        foreach (var block in _blockSpawned)
        {
            if (block != null)
            {
                block.transform.position += Vector3.down * _distanceBetweenBlocks;
                 if (block.transform.position.y < 0.5)
                {
                    Debug.Log("you lose!");
                    losePanel.SetActive(true);
                    Time.timeScale = 0;
                    slider.transform.gameObject.SetActive(false);
                }
            }
        }
        for (int i = 0; i < _numOfBlock; i++)
        {
            if (UnityEngine.Random.Range(0, 100) > 50)
            {
                var block = Instantiate(_blockPrefab, GetBlockPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 4) + _rowSpawned;
                block.SetHit(hits);
                _blockSpawned.Add(block);

            }
        }
        foreach (var ball in _ballSpawned)
        {
            if (ball != null)
            {
                ball.transform.position += Vector3.down * _distanceBetweenBlocks;
            }
        }

        if (UnityEngine.Random.Range(0, 100) < 100)
        {
            var ball = Instantiate(pointBall, GetBallPosition(UnityEngine.Random.Range(1, 8)), Quaternion.identity);
            _ballSpawned.Add(ball);

        }
        _rowSpawned++;
    }


    private Vector3 GetBlockPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * _distanceBetweenBlocks;
        return position;
    }
    private Vector3 GetBallPosition(int j)
    {
        Vector3 position = transform.position;
        position += Vector3.right * j * _distanceBetweenBlocks;
        return position;
    }
}
