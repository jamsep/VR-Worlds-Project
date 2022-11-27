using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowBranch : MonoBehaviour
{
    public List<MeshRenderer> growBranchesMeshes;
    public float timeToGrow = 3;
    public float refreshRate = 0.05f;
    [Range(0, 1)]
    public float minGrow = 0f;
    [Range(0, 1)]
    public float maxGrow = 0.99f;

    private List<Material> growBranchesMaterials = new List<Material>();
    private bool fullyGrown;
    public bool growthTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<growBranchesMeshes.Count; i++)
        {
            for (int j = 0; j < growBranchesMeshes[i].materials.Length; j++)
            {
                if (growBranchesMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    growBranchesMeshes[i].materials[j].SetFloat("Grow_", minGrow);
                    growBranchesMaterials.Add(growBranchesMeshes[i].materials[j]);
                }
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (growthTriggered)
        {
            for (int i=0; i<growBranchesMaterials.Count; i++)
            {
                StartCoroutine(GrowBranches(growBranchesMaterials[i]));
            }
        }

        IEnumerator GrowBranches(Material mat)
        {
            float growValue = mat.GetFloat("Grow_");

            if (!fullyGrown)
            {
                while (growValue < maxGrow)
                {
                    growValue += 1 / (timeToGrow / refreshRate);
                    mat.SetFloat("Grow_", growValue);

                    yield return new WaitForSeconds(refreshRate);
                }
            }
            else
            {
                while (growValue > minGrow)
                {
                    growValue -= 1 / (timeToGrow / refreshRate);
                    mat.SetFloat("Grow_", growValue);

                    yield return new WaitForSeconds(refreshRate);
                }
            }

            if (growValue >= maxGrow)
                fullyGrown = true;
            else
                fullyGrown = false;
        }
    }
}
