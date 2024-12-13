using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Image> cards;

    private int currentIndex;

    public bool isCardActive = false;

    public Button btnNextCard;
    public Button btnCloseCard;

    private Image currentCard;
    public Image ImgCurrentCard;

    public GravestoneButtonManager buttonManager;

    public GameObject player;
    private void Start()
    {
        BtnCloseCardDisenabled();
    }

    public void GenerateRandomCard()
    {
        currentIndex = Random.Range(0, cards.Count);
        currentCard = cards[currentIndex];
        currentCard.gameObject.transform.position = player.transform.position;
        currentCard.gameObject.SetActive(true);

        BtnNextCardDisenabled();
        BtnCloseCardEnabled();

        ImgCurrentCard.gameObject.SetActive(false);
        ImgCurrentCard.color = currentCard.color;

        isCardActive = true;
    }

    public void CloseCard()
    {
        isCardActive = false;

        currentCard.gameObject.SetActive(false);

        BtnNextCardEnabled();
        BtnCloseCardDisenabled() ;

        ImgCurrentCard.gameObject.SetActive(true);
        ImgCurrentCard.color = currentCard.color;

        buttonManager.BtnPutEnabled();
    }

    public void BtnNextCardEnabled()
    {
        btnNextCard.interactable = true;
        btnNextCard.GetComponent<Image>().color = Color.white;
    }

    public void BtnNextCardDisenabled()
    {
        btnNextCard.interactable = false;
        btnNextCard.GetComponent<Image>().color = Color.gray;
    }

    public void BtnCloseCardEnabled()
    {
        btnCloseCard.interactable = true;
        btnCloseCard.GetComponent<Image>().color = Color.white;
    }

    public void BtnCloseCardDisenabled()
    {
        btnCloseCard.interactable = false;
        btnCloseCard.GetComponent<Image>().color = Color.gray;
    }
}
