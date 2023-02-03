using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public BallLauncher ballLauncher;
    public GameObject spawnerParent;
    public Button btnPause;
    public Button btnX2Balls;
    public Button btnBoom;
    public GameObject slider;


    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        ballLauncher.GetComponent<BallLauncher>()._canMove = false;
        spawnerParent.SetActive(false);
        btnPause.interactable= false;
        btnX2Balls.interactable= false;
        btnBoom.interactable= false;
        slider.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            ballLauncher.GetComponent<BallLauncher>()._canMove = true;
            gameObject.SetActive(false);
            spawnerParent.SetActive(true);
            btnPause.interactable = true;
            btnX2Balls.interactable = true;
            btnBoom.interactable = true;
            slider.SetActive(true);
            return;
        }
       
    }
}
