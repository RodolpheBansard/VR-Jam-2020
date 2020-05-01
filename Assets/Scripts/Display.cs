using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] Text displayText;

    private string currentText = "";

    private void Start()
    {
        displayText.text = currentText;
    }

    public void ButtonPress(string nombre)
    {
        displayText.text += nombre;
    }

    public void Reset()
    {
        displayText.text = "";
    }
}
