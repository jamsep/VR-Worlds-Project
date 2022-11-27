using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrowth : MonoBehaviour
{
    private bool alreadyGrown;
    private GameObject parent;


    private GrowBranch growAnimation;
    private Vector3 spawnPos;
    public GameObject[] availableBranches;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        Debug.Log("the parent object is " + parent);
        spawnPos = parent.transform.Find("SpawnPosition").transform.position;
        Debug.Log("position is " + spawnPos);
        alreadyGrown = false;
    }


    public void DoGrow()
    {
        if (!alreadyGrown)
        {   
            SpawnRandomBranch();
            alreadyGrown = true;
        }
            
    }

    void SpawnRandomBranch()
    {
        int i = Random.Range(0, availableBranches.Length);
        GameObject branch = availableBranches[i];
        Debug.Log("selected branch is: " + branch);
        Debug.Log(spawnPos);
        Debug.Log(Randomize());
        Instantiate(branch, spawnPos, Randomize());
        growAnimation = branch.GetComponent<GrowBranch>();
        growAnimation.growthTriggered = true;
    }

    Quaternion Randomize()
    {
        Quaternion randrotation = Quaternion.Euler(Random.Range(20, 30), Random.Range(0, 360), 0);
        //obj.transform.rotation = randrotation;
        return randrotation;
    }
}
