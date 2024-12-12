using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravestoneButtonManager : MonoBehaviour
{
    public GameObject graveStone;
    public Button btnPut;
    public void ClickBtnPut()
    {
        Transform coffin = graveStone.transform.Find("Coffin");
        coffin.gameObject.SetActive(true);
        btnPut.enabled = false;
        btnPut.GetComponent<Image>().color = Color.gray;
    }
}
