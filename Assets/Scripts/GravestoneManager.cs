using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GravestoneManager : MonoBehaviour
{
    public GameObject[] graves;

    public float neighborDistance = 10f;

    public GravestoneButtonManager buttonManager;
    public CardManager cardManager;

    public Camera cameraa;

    public int dayCycle = 0;

    private void Start()
    {

    }

    private void Update()
    {

    }

    public GameObject[] GetAdjacentGraves(GameObject centerGrave)
    {
        GameObject[] adjacentGraves = new GameObject[8];

        int count = 0;

        foreach (GameObject obj in graves)
        {
            if (obj != centerGrave)
            {
                float distance = Vector2.Distance(obj.transform.position, centerGrave.transform.position);
                if (distance <= neighborDistance)
                {
                    adjacentGraves[count] = obj;
                    count++;
                }
            }
        }

        return adjacentGraves;
    }

    public void applyRadioactive(GameObject[] adjacentGraves)
    {
        if(adjacentGraves.Length == 0 && adjacentGraves == null)
        {
            return;
        }

        foreach(GameObject obj in adjacentGraves)
        {
            if(obj == null)
            {
                continue;
            }

            Transform poison = obj.transform.Find("Poison");
            poison.gameObject.SetActive(true);
        }
    }
}
