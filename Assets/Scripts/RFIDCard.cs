using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDCard : MonoBehaviour
{
    [SerializeField] bool isValid = false;

    public bool GetIsValid()
    {
        return isValid;
    }
}
