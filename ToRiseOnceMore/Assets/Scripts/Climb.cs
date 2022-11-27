using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.XR.Interaction.Toolkit;

public class Climb : MonoBehaviour
{
    public enum handSide
    {
        left, right
    }

    public handSide thisHandSide;
    public XRController thisButton;

    [Space(15)]
    [ReadOnly] public Vector3 prevPos;

    [Space(15)]
    [ReadOnly] public bool canGrip;

    [Space(15)]
    [ReadOnly] public GameObject grabbingBranch;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "climbable")
        {
            canGrip = true;

            grabbingBranch = other.gameObject;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "climbable")
        {
            canGrip = false;
        }
    }
}
