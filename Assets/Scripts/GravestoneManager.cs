using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneManager : MonoBehaviour
{
    public GameObject[] graves;

    public float neighborDistance = 9f;

    public GravestoneButtonManager buttonManager;

    private void Start()
    {
        graves = new GameObject[9];
    }

    public GameObject[] GetAdjacentGraves(GameObject centerGrave)
    {
        Debug.Log(graves.Length);

        GameObject[] adjacentGraves = new GameObject[5];

        int count = 0;

        foreach (GameObject obj in graves)
        {
            Debug.Log("obj.name");
            if (obj != centerGrave)
            {
                Debug.Log("ff");
                Debug.Log(centerGrave.transform.rotation);
                float distance = Vector2.Distance(obj.transform.position, centerGrave.transform.position);
                if (distance <= neighborDistance)
                {
                    Debug.Log("insideif");
                    for(int i = 0; i < graves.Length; i++)
                    {
                        Debug.Log("for");
                        adjacentGraves[i] = obj;
                        count++;
                    }
                    Debug.Log(count);
                }
            }
        }

        return adjacentGraves;
    }
}
