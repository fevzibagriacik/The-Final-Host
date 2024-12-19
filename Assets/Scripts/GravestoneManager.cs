using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class GravestoneManager : MonoBehaviour
{
    public GameObject[] graves;

    public float neighborDistance = 10f;

    public GravestoneButtonManager buttonManager;

    public Camera cameraaa;

    int day = 0;
    public int DayCycle = 3;

    public int[] PoisonApplyed;
    public int[] holdPoisonApplyed;
    public int[] burntApplyed;
    public int[] holdBurntApplyed;
    public int[] gluttonApplyed;
    public int[] holdGluttonApplyed;

    public string nightColor;
    public string dayColor;

    public bool isDeletedBurnt = false;
    public bool isDeletedPoison = false;

    Color backgroundColor;

    private void Start()
    {
        //graves = new GameObject[9];
        //cameraaa.backgroundColor = Color.
        PoisonApplyed = new int[25];
        holdPoisonApplyed = new int[25];
        for (int i = 0; i < PoisonApplyed.Length; i++)
        {
            PoisonApplyed[i] = 0;
        }
        for (int i = 0; i < PoisonApplyed.Length; i++)
        {
            holdPoisonApplyed[i] = 0;
        }

        burntApplyed = new int[25];
        holdBurntApplyed = new int[25];
        for (int i = 0; i < PoisonApplyed.Length; i++)
        {
            burntApplyed[i] = 0;
        }
        for (int i = 0; i < PoisonApplyed.Length; i++)
        {
            holdBurntApplyed[i] = 0;
        }

        gluttonApplyed = new int[25];
        holdGluttonApplyed = new int[25];
        for (int i = 0; i < gluttonApplyed.Length; i++)
        {
            gluttonApplyed[i] = 0;
        }
        for (int i = 0; i < gluttonApplyed.Length; i++)
        {
            holdGluttonApplyed[i] = 0;
        }
    }


    private void Update()
    {
        if (DayCycle == 0)
        {
            DayCycle = 3;
            for(int i = 0; i < PoisonApplyed.Length; i++)
            {
                if (!isDeletedBurnt)
                {
                    holdBurntApplyed[i] = burntApplyed[i];
                }

                if(!isDeletedPoison)
                    holdPoisonApplyed[i] = PoisonApplyed[i];
               
                holdGluttonApplyed[i] = gluttonApplyed[i];
            }
            TimePassed();

        }

    }

    //public void GetAdjacentGraves(GameObject centerGrave)
    //{




    //    for (int count=0; count<graves.Length;count++)
    //    {

    //        if (graves[count].transform.position != centerGrave.transform.position)
    //        {

    //            Debug.Log(centerGrave.transform.rotation);
    //            float distance = Vector2.Distance(graves[count].transform.position, centerGrave.transform.position);

    //            Debug.Log(distance);
    //            if (distance <= neighborDistance)
    //            {
    //                Debug.Log("for");

    //                Debug.Log("aaaaaa" + PoisonApplyed[count]);
    //                PoisonApplyed[count] = 1;

    //                Debug.Log("aaaaaa" + PoisonApplyed[count]);

    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("found me");
    //            Debug.Log("aaaaaa" + PoisonApplyed[count]);
    //            PoisonApplyed[count] = 1;

    //            Debug.Log("aaaaaa" + PoisonApplyed[count]);
    //        }
    //    }


    //}
    public void TimePassed()
    {
        if (day == 1)
        {
            //if (ColorUtility.TryParseHtmlString(dayColor, out backgroundColor))
            //{
            //    cameraaa.backgroundColor = backgroundColor;
            //    Debug.Log("asd");

            //}
            cameraaa.backgroundColor = new Color(27f, 1f, 109f, 250f);


            day--;


        }
        else if (day == 0)
        {
            //if (ColorUtility.TryParseHtmlString(nightColor, out backgroundColor))
            //{
            //    cameraaa.backgroundColor = backgroundColor;
            //    Debug.Log("asd");
            //    day++;
            //}
            cameraaa.backgroundColor = new Color(217f, 211f, 45f, 250f);

            

            Debug.Log(graves.Length);
            for (int i = 0; i < graves.Length; i++)
            {
                Debug.Log(graves[i]);
                /*if(gluttonApplyed[i] == 1)
                {
                    /*int k = 1;
                    int[] gluttonApplyedTrue = new int[k];
                    int rnd = Random.Range(0, k);
                    k++;
                    buttonManager.hasCoffin = false;
                }*/
                if (gluttonApplyed[i] == 1 && buttonManager.hasCoffin)
                {
                    Debug.Log("glotton");
                    buttonManager.hasCoffin = false;
                    Transform coffin = buttonManager.graveStone.transform.Find("Coffin");
                    coffin.gameObject.SetActive(false);
                }
                else if (burntApplyed[i] == 1 && !isDeletedBurnt)
                {
                    Transform coffin = buttonManager.graveStone.transform.Find("Coffin");
                    Transform burnt = graves[i].transform.Find("Burnt");
                    Transform poison = graves[i].transform.Find("Poison");
                    if (burnt.tag == "Burnt")
                    {
                        poison.gameObject.SetActive(false);
                        burnt.gameObject.SetActive(true);
                    }
                }
                else if (PoisonApplyed[i] == 1 && !isDeletedPoison && !isDeletedBurnt)
                {
                    Transform coffin = buttonManager.graveStone.transform.Find("Coffin");
                    Transform burnt = graves[i].transform.Find("Burnt");
                    Transform poison = graves[i].transform.Find("Poison");
                    if (poison.tag == "Poison")
                    {
                        poison.gameObject.SetActive(true);
                        burnt.gameObject.SetActive(false);
                    }
                }
            }
        }

    }

    public void DeleteBurnt()
    {
        isDeletedBurnt = true;
        isDeletedPoison = true;
        for(int i = 0; i < graves.Length; i++)
        {
            if (burntApplyed[i] == 1)
            {
                Transform burnt = graves[i].transform.Find("Burnt");
                Transform poison = graves[i].transform.Find("Poison");
                Transform coffin = graves[i].transform.Find("Coffin");
                if(burnt.tag == "Burnt")
                {
                    coffin.tag = "Normal";
                    burnt.gameObject.SetActive(false);
                    burntApplyed[i] = 0;
                    holdBurntApplyed[i] = 0;
                }
            }
        }
        isDeletedBurnt = false;
        isDeletedPoison = false;
    }

    public void DeleteRadioactive()
    {
        isDeletedPoison = true;
        for (int i = 0; i < graves.Length; i++)
        {
            if (PoisonApplyed[i] == 1)
            {
                Transform burnt = graves[i].transform.Find("Burnt");
                Transform poison = graves[i].transform.Find("Poison");
                Transform coffin = graves[i].transform.Find("Coffin");
                if (poison.tag == "Poison")
                {
                    coffin.tag = "Normal";
                    poison.gameObject.SetActive(false);
                    PoisonApplyed[i] = 0;
                    holdPoisonApplyed[i] = 0;
                }
            }
        }
        isDeletedPoison = false;
    }
}