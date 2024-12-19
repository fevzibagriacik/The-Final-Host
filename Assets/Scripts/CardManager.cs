using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cards;

    public int currentIndex;
    private int startIndex = 0;
    public int score = 0;

    public bool isCardActive = false;
    public bool isPutable = false;

    public Button btnNextCard;
    public Button btnCloseCard;

    public GameObject currentCard;
    //public GameObject smallCurrentCard;

    public GravestoneButtonManager buttonManager;

    public GameObject player;

    public Text txtScore;

    public AudioSource cardOpenPlayer;
    public AudioSource cardClosePlayer;

    //public Vector3 smallScale = new Vector3(3f, 3f, 0);
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
        cardOpenPlayer.Play();
        if(startIndex <= 1)
        {
            /*currentCard = cards[2];
            startIndex++;*/

            currentIndex = Random.Range(0, 3);
            currentCard = cards[currentIndex];
            startIndex++;
        }
        else
        {
            currentIndex = Random.Range(0, cards.Count);
            currentCard = cards[currentIndex];
        }

        currentCard.transform.position = player.transform.position;
        currentCard.SetActive(true);

        BtnNextCardDisenabled();
        BtnCloseCardEnabled();

        /*currentCard.transform.localScale = new Vector3(1, 1, 1);
        currentCard.transform.position = player.transform.position;*/

        isCardActive = true;
    }

    public void CloseCard()
    {
        cardClosePlayer.Play();

        isCardActive = false;

        currentCard.SetActive(false);

        BtnCloseCardDisenabled() ;

        //smallCurrentCard.gameObject.SetActive(true);
        //smallCurrentCard.sprite = currentCard.GetComponent<SpriteRenderer>().sprite;

        /*currentCard.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        currentCard.transform.position = new Vector3(player.transform.position.x + 25, player.transform.position.y + 10);*/

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
            score += 40;
            txtScore.text = score.ToString();
        }
        else if(currentCard.tag == "Glutton")
        {
            score += 30;
            txtScore.text = score.ToString();
        }
        else if(currentCard.tag == "Radioactive")
        {
            score += 40;
            txtScore.text = score.ToString();
        }
    }
}
