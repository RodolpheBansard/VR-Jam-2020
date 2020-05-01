using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digicode : MonoBehaviour
{
    public string code;
    public Text displayText;

    private bool isSolved = false;
    private string inputPlayer;

    private void Start()
    {
        Clear();
    }

    public void PressNumber(string number)
    {
        inputPlayer += number;
        displayText.text += number;
    }

    public void Clear()
    {
        displayText.text = "";
        inputPlayer = "";
    }

    public void Validate()
    {
        if(inputPlayer == code)
        {
            isSolved = true;
            displayText.text = "GRANTED";
        }
        else
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        displayText.text = "DENIED";
        yield return new WaitForSeconds(1);
        Clear();
    }
}
