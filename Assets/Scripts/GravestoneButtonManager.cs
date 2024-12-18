using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravestoneButtonManager : MonoBehaviour
{
    public GameObject graveStone;

    public CardManager cardManager;
    public GravestoneManager gravestoneManager;

    public Button btnPut;

    public GravestoneManager gm;

    public bool hasCoffin = false;

    public int whichGraveAmIIn = -1;


    //public Camera camera;
    //int day = 1;

    //public int DayCycle = 3;
    private void Start()
    {
        btnPut.gameObject.SetActive(false);
        gm = gameObject.GetComponentInParent<GravestoneManager>();

    }

    private void Update()
    {
        if (cardManager.isPutable && !hasCoffin)
        {
            BtnPutEnabled();
        }
        else
        {
            BtnPutDisenabled();
        }
        //if (DayCycle == 3)
        //{
        //    TimePassed();
        //}
    }
    //public void TimePassed()
    //{
    //    if (day == 1)
    //    {
    //        camera.backgroundColor = new Color(27f,1f,109f);


    //        day--;
    //    }
    //    if (day == 0)
    //    {
    //        camera.backgroundColor = new Color(251f, 226f, 83f);

    //        day++;
    //    }

    //}

    public void ClickBtnPut()
    {
        Debug.Log("clicked");
        for (int i = 0; i < gm.graves.Length; i++) 
        {
            Debug.Log("döngüde");
            if(gm.graves[i].transform.position == gameObject.transform.position)
                whichGraveAmIIn = i;
        }

        if (cardManager.isPutable && gm.holdPoisonApplyed[whichGraveAmIIn]==0 && gm.holdBurntApplyed[whichGraveAmIIn] == 0)
        {
            Debug.Log("ccccccccccccccc");
            cardManager.BtnNextCardEnabled();

            Transform coffin = graveStone.transform.Find("Coffin");
            coffin.tag = cardManager.currentCard.tag;
            coffin.gameObject.SetActive(true);
            hasCoffin = true;

            BtnPutDisenabled();
            cardManager.BtnNextCardEnabled();

            cardManager.PutControl();

            gm.DayCycle--;


            cardManager.isPutable = false;


            if (coffin.tag == "Burnt")
            {
                for (int count = 0; count < gm.graves.Length; count++)
                {
                    if (gm.graves[count].transform.position != gameObject.transform.position)
                    {

                        Debug.Log(gameObject.transform.rotation);
                        float distance = Vector2.Distance(gm.graves[count].transform.position, gameObject.transform.position);

                        Debug.Log(distance);
                        if (distance <= gm.neighborDistance+100000000f)
                        {

                            gm.burntApplyed[count] = 1;
                        }
                    }
                    else
                    {
                        Debug.Log("found me");
                        Debug.Log("aaaaaa" + gm.burntApplyed[count]);
                        gm.burntApplyed[count] = 1;

                        Debug.Log("aaaaaa" + gm.burntApplyed[count]);
                    }
                }

            }
            else if (coffin.tag == "Radioactive")
            {
                for (int count = 0; count < gm.graves.Length; count++)
                {
                    if (gm.graves[count].transform.position != gameObject.transform.position)
                    {

                        Debug.Log(gameObject.transform.rotation);
                        float distance = Vector2.Distance(gm.graves[count].transform.position, gameObject.transform.position);

                        Debug.Log(distance);
                        if (distance <= gm.neighborDistance)
                        {

                            gm.PoisonApplyed[count] = 1;
                        }
                    }
                    else
                    {
                        Debug.Log("found me");
                        Debug.Log("aaaaaa" + gm.PoisonApplyed[count]);
                        gm.PoisonApplyed[count] = 1;

                        Debug.Log("aaaaaa" + gm.PoisonApplyed[count]);
                    }
                }
            }
        }
    }

    public void BtnPutEnabled()
    {
        btnPut.interactable = true;
        btnPut.GetComponent<Image>().color = Color.white;
    }

    public void BtnPutDisenabled()
    {
        btnPut.interactable = false;
        btnPut.GetComponent<Image>().color = Color.gray;
    }
}