using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ShowController : MonoBehaviour
{
    public bool showController = false;

    private void Update()
    {        
        foreach(Hand hand in Player.instance.hands)
        {
            if (showController)
            {
                hand.ShowController();
                hand.SetSkeletonRangeOfMotion(EVRSkeletalMotionRange.WithController);
            }
            else
            {
                hand.HideController();
                hand.SetSkeletonRangeOfMotion(EVRSkeletalMotionRange.WithoutController);
            }
        }
    }
}
