using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisabledObjectRemover : EditorWindow
{
    const string k_DebugPrefix = "Disabled Object Remover: ";

    [MenuItem("Tools/Disabled Object Remover")]
    public static void ShowWindow()
    {
        GetWindow(typeof(DisabledObjectRemover));
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Remove Disabled Child Objects"))
        {
            RemoveGameObjects();
        }
    }

    private void RemoveGameObjects()
    {
        Debug.Log(k_DebugPrefix + "Started");

        List<GameObject> parentObjects = GetParentObjects();

        List<GameObject> toDestroy = GetDestroyables(parentObjects);

        DestroyDestroyables(toDestroy);

        Debug.Log(k_DebugPrefix + "Finished");
    }

    private static void DestroyDestroyables(List<GameObject> toDestroy)
    {
        int destroyedCount = 0;
        foreach (GameObject go in toDestroy)
        {
            DestroyImmediate(go, true);
            destroyedCount++;
        }
        toDestroy.Clear();

        Debug.Log(k_DebugPrefix + "Destroyed " + destroyedCount + " objects");
    }

    private static List<GameObject> GetDestroyables(List<GameObject> parentObjects)
    {
        List<GameObject> toDestroy = new List<GameObject>();
        foreach (GameObject parentObject in parentObjects)
        {
            Debug.Log(k_DebugPrefix + "Child count: " + parentObject.GetComponentsInChildren<Transform>(true).Length);

            foreach (Transform childTransform in parentObject.GetComponentsInChildren<Transform>(true))
            {
                GameObject childObject = childTransform.gameObject;

                if (!childObject.activeInHierarchy)
                {
                    toDestroy.Add(childObject);
                }
            }
        }

        return toDestroy;
    }

    private static List<GameObject> GetParentObjects()
    {
        List<GameObject> parentObjects = new List<GameObject>();
        int parentObjectsLength = 0;
        foreach (DestroyDisabledChildren ddcComponent in FindObjectsOfType<DestroyDisabledChildren>())
        {
            parentObjects.Add(ddcComponent.gameObject);
            parentObjectsLength++;
        }
        Debug.Log(k_DebugPrefix + "Found " + parentObjectsLength + "parent objects");
        return parentObjects;
    }
}