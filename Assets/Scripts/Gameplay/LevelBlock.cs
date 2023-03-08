using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelBlock : MonoBehaviour
{
    [SerializeField] private Color[] colorList;
    [SerializeField] public int hitsRemaining = 15;
    [SerializeField] private TextMeshPro hitText;
     
    [SerializeField] GameObject explosionEffect;


    private void Awake()
    {
        hitText = GetComponentInChildren<TMPro.TextMeshPro>();
    }
    private void Start()
    {
        hitText.text = hitsRemaining.ToString();
 
    }
    private void UpdateVisualState()
    {
        hitText.SetText(hitsRemaining.ToString());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;
        FindObjectOfType<AudioManager>().Play("Hurt");
        FindObjectOfType<AudioManager>().Play("Hit");


    }
    private void Update()
    {

        if (hitsRemaining > 0)
        {
            UpdateVisualState();
        }
        else
        {
            NewLevelUnlock.BlockNumber--;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Die");
            Destroy(gameObject);
        }
    }

}
