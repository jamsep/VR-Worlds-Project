using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.XR.Interaction.Toolkit;

public class GripManager : MonoBehaviour
{
    [ReadOnly] [SerializeField] private bool isGripped;

    [Space(15)]
    [SerializeField] private Rigidbody body;

    [Space(15)]
    [SerializeField] private Climb left;
    [SerializeField] private Climb right;


    void Start()
    {
        body = GameObject.Find("GorillaPlayer").GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGripped = left.canGrip || right.canGrip;

        if (isGripped)
        {
            Climb(left);
            Climb(right);
        }     

        left.prevPos = left.transform.position;
        right.prevPos = right.transform.position;
    }

    void Climb(Climb theClimb)
    {

        //if (theClimb.thisButton.inputDevice.IsPressed(InputHelpers.Button.SecondaryButton, out bool pressed) || theClimb.controller.inputDevice.IsPressed(InputHelpers.Button.PrimaryButton, out bool itspressed) || theClimb.controller.inputDevice.IsPressed(InputHelpers.Button.TriggerButton, out bool ispressed) || theClimb.controller.inputDevice.IsPressed(InputHelpers.Button.GripButton, out bool isspressed))
        bool pressedTrigger;
        bool pressedGrip;
        theClimb.thisButton.inputDevice.IsPressed(InputHelpers.Button.Grip, out pressedGrip);
        theClimb.thisButton.inputDevice.IsPressed(InputHelpers.Button.Trigger, out pressedTrigger);

        if (pressedGrip || pressedTrigger)
        {
            body.transform.position += (theClimb.prevPos - theClimb.transform.position);
        }
    }

}
