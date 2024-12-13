using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List<Image> cards;

    public int currentIndex;

    public Button btnNextCard;
    public Button btnCloseCard;

    public void GenerateRandomCard()
    {
        currentIndex = Random.Range(0, cards.Count);
        
        cards[currentIndex].gameObject.SetActive(true);

        btnNextCard.enabled = false;
        btnNextCard.GetComponent<Image>().color = Color.gray;

        btnCloseCard.enabled = true;
        btnCloseCard.GetComponent<Image>().color = Color.white;
    }

    public void CloseCard()
    {
        cards[currentIndex].gameObject.SetActive(false);

        btnNextCard.enabled = true;
        btnNextCard.GetComponent<Image>().color = Color.white;

        btnCloseCard.enabled = false;
        btnCloseCard.GetComponent<Image>().color = Color.gray;
    }
}
