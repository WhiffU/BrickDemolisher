using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelBlock : MonoBehaviour
{
    [SerializeField] private Color[] colorList;
    [SerializeField] private int hitsRemaining = 15;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshPro hitText;
     
    [SerializeField] GameObject explosionEffect;


    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        hitText = GetComponentInChildren<TMPro.TextMeshPro>();
        //_rb = GetComponentInChildren<Rigidbody2D>();
    }
    private void Start()
    {
        hitText.text = hitsRemaining.ToString();
 
    }
    private void UpdateVisualState()
    {
        hitText.SetText(hitsRemaining.ToString());
        //int colorIndex = hitsRemaining / 10;
        //float mix = (hitsRemaining % 10) / 10f;
        //spriteRenderer.color = Color.Lerp(colorList[colorIndex % colorList.Count], colorList[(colorIndex + 1) % colorList.Count], mix);
        gameObject.transform.GetComponent<SpriteRenderer>().color = colorList[Random.Range(0, colorList.Length)];
    }
    public void SetHit(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitsRemaining--;

        if (hitsRemaining > 0)
        {
            UpdateVisualState();
        }
        else 
        {
            NewLevelUnlock.BlockNumber--;
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
     
}
