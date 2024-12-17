using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneManager : MonoBehaviour
{
    public GameObject[] graves;

    public float neighborDistance = 10f;

    public GravestoneButtonManager buttonManager;
    public CardManager cardManager;

    public Camera cameraa;

    public bool isMorning = true;

    public int dayCycle = 3;

    private void Start()
    {

    }

    private void Update()
    {
        if (isMorning)
        {
            dayCycle = 3;
            TimePassed();
        }
    }

    public void TimePassed()
    {
        if (isMorning)
        {
            isMorning = false;
        }
        else if (!isMorning)
        {

        }
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
                    Debug.Log("for");
                    adjacentGraves[count] = obj;
                    count++;
                }
            }
        }

        return adjacentGraves;
    }

    public void applyRadioactive(GameObject[] adjacentGraves)
    {
        foreach(GameObject obj in adjacentGraves)
        {
            Transform poison = obj.transform.Find("Poison");
            poison.gameObject.SetActive(true);
            buttonManager.hasRadioactive = true;
        }
    }
}
