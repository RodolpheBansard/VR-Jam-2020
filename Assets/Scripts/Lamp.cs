using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject light;
    public Material lampOn;
    public Material lampOff;
    public Material baseMat;
    public Material Wood;
    public MeshRenderer meshRenderer;

    public float timeBetweenElement = .5f;
    public float timeBetweenNumber = 1;
    public float timeBetweenSequence = 2;
    public float timeShort = 0.2f;
    public float timeLong = 0.6f;

    private int[] code = new int[3];
    private int index = 0;

    private void Start()
    {
        meshRenderer.materials = new Material[] { baseMat, Wood, lampOff };


        light.SetActive(false);

        for(int i=0; i < 3; i++)
        {
            code[i] = Random.Range(0, 10);
            print(code[i]);
        }
        
        StartCoroutine(GenerateMorseCode());
    }   
    

    IEnumerator GenerateMorseCode()
    {
        while (true)
        {
            StartCoroutine(GenerateSequence());
            yield return new WaitForSeconds(GetSequenceDuration());
        }     
    }
    

    IEnumerator GenerateSequence()
    {
        foreach(int number in code)
        {
            StartCoroutine(GenerateNumber(number));
            yield return new WaitForSeconds(GetNumberDuration(number));
        }
    }


    IEnumerator GenerateNumber(int number)
    {
        int[] elements = GetElements(number);
        foreach(int element in elements)
        {
            meshRenderer.materials = new Material[] { baseMat, Wood, lampOn };
            light.SetActive(true);
            if (element == 0)                           
                yield return new WaitForSeconds(timeShort);            
            else
                yield return new WaitForSeconds(timeLong);
            light.SetActive(false);
            meshRenderer.materials = new Material[] { baseMat, Wood, lampOff };
            yield return new WaitForSeconds(timeBetweenElement);
        }
        yield return new WaitForSeconds(timeBetweenNumber);
    }

    private int[] GetElements(int number)
    {
        if (number == 0)
            return new int[] { 1, 1, 1, 1, 1 };
        else if (number == 1)
            return new int[] { 0, 1, 1, 1, 1 };
        else if (number == 2)
            return new int[] { 0, 0, 1, 1, 1 };
        else if (number == 3)
            return new int[] { 0, 0, 0, 1, 1 };
        else if (number == 4)
            return new int[] { 0, 0, 0, 0, 1 };
        else if (number == 5)
            return new int[] { 0, 0, 0, 0, 0 };
        else if (number == 6)
            return new int[] { 1, 0, 0, 0, 0 };
        else if (number == 7)
            return new int[] { 1, 1, 0, 0, 0 };
        else if (number == 8)
            return new int[] { 1, 1, 1, 0, 0 };
        else
            return new int[] { 1, 1, 1, 1, 0 };
    }

    private float GetSequenceDuration()
    {
        float duration = 0;

        foreach(int number in code)
        {
            foreach(int element in GetElements(number))
            {
                if (element == 1)
                    duration += timeLong;
                else
                    duration += timeShort;
                duration += timeBetweenElement;
            }
            duration += timeBetweenNumber;
        }
        duration += timeBetweenSequence;

        return duration;
    }
    private float GetNumberDuration(int number)
    {
        float duration = 0;

        foreach (int element in GetElements(number))
        {
            if (element == 1)
                duration += timeLong;
            else
                duration += timeShort;
            duration += timeBetweenElement;
        }

        duration += timeBetweenNumber;

        return duration;
    }
}
