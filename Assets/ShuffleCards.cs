using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleCards : MonoBehaviour
{
public GameObject card;

    public List<GameObject> cardSuits;
    public List<GameObject> redCards;
    public List<GameObject> blackCards;

    private void Start() {
        card.SetActive(false);
        resetCards(cardSuits);
        resetCards(redCards);
        resetCards(blackCards);
    }

    public void ShuffleCard(string cardNum)
    {
        Random r = new Random();
        
        resetCards(cardSuits);
        resetCards(redCards);
        resetCards(blackCards);

        card.SetActive(true);
        cardSuits[checkCardSuit(cardNum[1].ToString())].SetActive(true);

        var iCard = 0;

        if(cardNum[0].ToString() == "J" || cardNum[0].ToString() == "Q" || cardNum[0].ToString() == "K" || cardNum[0].ToString() == "A" || cardNum[0].ToString() == "0"){
            iCard = checkCardNum(cardNum[0].ToString());
        } else {
            iCard = int.Parse(cardNum[0].ToString());
        }

        if(cardNum[1].ToString() == "D" || cardNum[1].ToString() == "H"){
            redCards[iCard - 2].SetActive(true);
        } else {
            blackCards[iCard - 2].SetActive(true);
        }

    }

    public void resetCards(List<GameObject> cards){
        //reset the cards

        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].SetActive(false);
        }
    }

    public int checkCardSuit(string cardSuit)
    {
        var iCardSuit = 0;

        switch(cardSuit){
            case "D":
                iCardSuit = 0;
                break;
            case "H":
                iCardSuit = 1;
                break;
            case "S":
                iCardSuit = 2;
                break;
            case "C":
                iCardSuit = 3;
                break;
            default:
                break;
        }

        return iCardSuit;
    }

    public int checkCardNum(string cardNum)
    {
        int iCardNum = 0;

        switch(cardNum){
            case "0":
                iCardNum = 10;
                break;
            case "J":
                iCardNum = 11;
                break;
            case "Q":
                iCardNum = 12;
                break;
            case "K":
                iCardNum = 13;
                break;
            case "A":
                iCardNum = 14;
                break;
            default:
                break;
        }

        return iCardNum;
    }
}
