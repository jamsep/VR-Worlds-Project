using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomRotation();
    }
    
    void RandomRotation()
    {
        Quaternion randrotation = Quaternion.Euler(Random.Range(20,30), Random.Range(0, 360), -90);
        transform.rotation = randrotation;
    }
}
