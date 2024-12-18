using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravestoneButtonManager : MonoBehaviour
{
    public GameObject graveStone;

    public CardManager cardManager;
    //public GravestoneManager gravestoneManager;

    public Button btnPut;

    public GravestoneManager gm;

    public AudioSource graveStonePlayer;

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
        graveStonePlayer.Play();
        for (int i = 0; i < gm.graves.Length; i++) 
        {
            if(gm.graves[i].transform.position == gameObject.transform.position)
            {
                whichGraveAmIIn = i;
            }
        }

        if (cardManager.isPutable && gm.holdPoisonApplyed[whichGraveAmIIn]==0 && gm.holdBurntApplyed[whichGraveAmIIn] == 0)
        {
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

            if(coffin.tag == "Glutton")
            {
                ApplyGlutton();
                Debug.Log("burda");
            }
            else if (coffin.tag == "Burnt")
            {
                ApplyBurnt();
            }
            else if (coffin.tag == "Radioactive")
            {
                ApplyRadioactive();
            }
        }
    }

    public void ApplyBurnt()
    {
        for (int count = 0; count < gm.graves.Length; count++)
        {
            if (gm.graves[count].transform.position != gameObject.transform.position)
            {
                float distance = Vector2.Distance(gm.graves[count].transform.position, gameObject.transform.position);
                if (distance <= (gm.neighborDistance +1000f))
                {

                    gm.burntApplyed[count] = 1;
                }
            }
            else
            {
                gm.burntApplyed[count] = 1;
            }
        }
    }

    public void ApplyRadioactive()
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
                gm.PoisonApplyed[count] = 1;
            }
        }
    }

    public void ApplyGlutton()
    {
        for (int count = 0; count < gm.graves.Length; count++)
        {
            if (gm.graves[count].transform.position != gameObject.transform.position)
            {

                Debug.Log(gameObject.transform.rotation);
                float distance = Vector2.Distance(gm.graves[count].transform.position, gameObject.transform.position);

                Debug.Log(distance);
                //if (distance <= gm.neighborDistance - 3)
                //{

                //    gm.gluttonApplyed[count] = 1;
                //}
                if (distance <= gm.neighborDistance-3f)
                {

                    gm.gluttonApplyed[count] = 1;
                }
            }
            else
            {
                gm.gluttonApplyed[count] = 0;
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