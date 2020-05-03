using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digicode : MonoBehaviour
{
    public string code;
    public Text displayText;
    public bool isCoffre;
    public GameObject door = null;

    private bool isSolved = false;
    private string inputPlayer;

    private void Start()
    {
        Clear();
    }

    public void PressNumber(string number)
    {
        if (!isSolved)
        {
            inputPlayer += number;
            displayText.text += number;
        }
            
    }

    public void Clear()
    {
        if (!isSolved)
        {
            displayText.text = "";
            inputPlayer = "";
        }
            
    }

    public void Validate()
    {
        if (!isSolved)
        {
            if (inputPlayer == code)
            {
                if (door != null)
                {
                    door.GetComponent<Animator>().SetTrigger("Open");
                }
                isSolved = true;
                displayText.text = "GRANTED";
                if (isCoffre)
                {
                    GetComponent<Animator>().SetTrigger("Open");
                }
            }
            else
            {
                StartCoroutine(Reset());
            }
        }
        
    }

    IEnumerator Reset()
    {
        displayText.text = "DENIED";
        yield return new WaitForSeconds(1);
        Clear();
    }
}
