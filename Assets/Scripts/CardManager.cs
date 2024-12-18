using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Image> cards;

    public int currentIndex;
    private int startIndex = 0;
    public int score = 0;

    public bool isCardActive = false;
    public bool isPutable = false;

    public Button btnNextCard;
    public Button btnCloseCard;

    public Image currentCard;
    public Image ImgCurrentCard;

    public GravestoneButtonManager buttonManager;

    public GameObject player;

    public Text txtScore;
    private void Start()
    {
        BtnCloseCardDisenabled();

        isPutable = false;
    }

    private void Update()
    {

    }

    public void GenerateRandomCard()
    {
        if(startIndex <= 1)
        {
            currentCard = cards[2];
            startIndex++;
        }
        else
        {
            currentIndex = Random.Range(0, cards.Count);
            currentCard = cards[currentIndex];
        }

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

        BtnCloseCardDisenabled() ;

        ImgCurrentCard.gameObject.SetActive(true);
        ImgCurrentCard.color = currentCard.color;

        buttonManager.BtnPutEnabled();

        isPutable = true;
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

    public void PutControl()
    {
        if (currentCard.tag == "Normal")
        {
            score += 20;
            txtScore.text = score.ToString();
        }
        else if(currentCard.tag == "Rich")
        {
            score += 40;
            txtScore.text = score.ToString();
        }
        else if(currentCard.tag == "Burnt")
        {
            score += 60;
            txtScore.text = score.ToString();
        }
    }
}
