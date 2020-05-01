using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDReader : MonoBehaviour
{
    public Light light;
    public Color grantedColor;
    public Color deniedColor;

    private void Start()
    {
        light.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RFIDCard>().GetIsValid())
        {
            StartCoroutine(Blink(grantedColor));
        }
        else
        {
            StartCoroutine(Blink(deniedColor));
        }
    }

    IEnumerator Blink(Color color)
    {
        light.color = color;
        light.enabled = true;
        yield return new WaitForSeconds(0.5f);
        light.enabled = false;
    }
}
