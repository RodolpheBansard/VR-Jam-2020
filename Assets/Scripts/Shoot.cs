using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Shoot : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float shootSpeed = 20;

    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }


    void Update()
    {
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;

            if (fireAction[source].stateDown)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firepoint.forward * shootSpeed;
        print(rb.velocity);
        Destroy(bullet, 5);
    }
}
