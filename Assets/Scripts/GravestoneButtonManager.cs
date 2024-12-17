using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

public class GravestoneButtonManager : MonoBehaviour
{
    public GameObject graveStone;

    public CardManager cardManager;
    public GravestoneManager gravestoneManager;

    public Button btnPut;

    public bool isCoffin = false;

    private void Start()
    {
        btnPut.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (cardManager.isPutable && !isCoffin)
        {
            BtnPutEnabled();
        }
        else
        {
            BtnPutDisenabled();
        }
    }

    public void ClickBtnPut()
    {
        if (cardManager.isPutable)
        {
            cardManager.BtnNextCardEnabled();

            Transform coffin = graveStone.transform.Find("Coffin");
            coffin.tag = cardManager.currentCard.tag;
            coffin.gameObject.SetActive(true);
            isCoffin = true;

            BtnPutDisenabled();
            cardManager.BtnNextCardEnabled();

            cardManager.PutControl();

            cardManager.isPutable = false;

            gravestoneManager.dayCycle++;

            if (coffin.tag == "Radioactive" && gravestoneManager.dayCycle % 3 == 0)
            {
                gravestoneManager.applyRadioactive(gravestoneManager.GetAdjacentGraves(graveStone));
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
