using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravestoneButtonManager : MonoBehaviour
{
    public GameObject graveStone;

    public CardManager cardManager;

    public Button btnPut;
    private void Start()
    {
        BtnPutDisenabled();
    }

    public void ClickBtnPut()
    {
        cardManager.BtnNextCardEnabled();

        Transform coffin = graveStone.transform.Find("Coffin");
        coffin.gameObject.SetActive(true);

        BtnPutDisenabled();
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
