using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random=UnityEngine.Random;


public class CheckCards : MonoBehaviour
{
    public ShuffleCards Card1;
    public ShuffleCards Card2;
    public ShuffleCards Card3;
    public ShuffleCards Card4;
    public ShuffleCards Card5;

    public ShuffleCards Player1Card1;
    public ShuffleCards Player1Card2;

    public ShuffleCards Player2Card1;
    public ShuffleCards Player2Card2;    

    public Text player1Text;
    public Text player2Text;
    public Text WinnerText;

    int cardPairCount = 0;

    // void Start () {
    //     player1Text = gameObject.GetComponent<Text>(); 
    // }


    public void CheckCard(){
        string sCardNum1;
        string sCardNum2;
        string sCardNum3;
        string sCardNum4;
        string sCardNum5;

        string sPlayer1CardNum1;
        string sPlayer1CardNum2;

        string sPlayer2CardNum1;
        string sPlayer2CardNum2;

        // Random r = new Random();

        List<string> cards = new List<string>()
        {
            "2D", "2H", "2S", "2C",
            "3D", "3H", "3S", "3C",
            "4D", "4H", "4S", "4C",
            "5D", "5H", "5S", "5C",
            "6D", "6H", "6S", "6C",
            "7D", "7H", "7S", "7C",
            "8D", "8H", "8S", "8C",
            "9D", "9H", "9S", "9C",
            "0D", "0H", "0S", "0C",
            "JD", "JH", "JS", "JC",
            "QD", "QH", "QS", "QC",
            "KD", "KH", "KS", "KC",
            "AD", "AH", "AS", "AC"
        };

        //randomize cards

        Random r = new Random();

        sCardNum1 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum1));

        sCardNum2 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum2));

        sCardNum3 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum3));

        sCardNum4 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum4));

        sCardNum5 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum5));

        sCardNum5 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sCardNum5));

        sPlayer1CardNum1 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sPlayer1CardNum1));

        sPlayer1CardNum2 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sPlayer1CardNum2));

        sPlayer2CardNum1 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sPlayer2CardNum1));

        sPlayer2CardNum2 = cards[Random.Range(0, cards.Count)];
        cards.RemoveAt(cards.IndexOf (sPlayer2CardNum2));

        //shuffle cards

        Card1.ShuffleCard(sCardNum1);
        Card2.ShuffleCard(sCardNum2);
        Card3.ShuffleCard(sCardNum3);
        Card4.ShuffleCard(sCardNum4);
        Card5.ShuffleCard(sCardNum5);

        Player1Card1.ShuffleCard(sPlayer1CardNum1);
        Player1Card2.ShuffleCard(sPlayer1CardNum2);

        Player2Card1.ShuffleCard(sPlayer2CardNum1);
        Player2Card2.ShuffleCard(sPlayer2CardNum2);
        
        //Player1 Cards
        int[] player1Cards = { 
            convertToInt(sCardNum1[0].ToString()), 
            convertToInt(sCardNum2[0].ToString()), 
            convertToInt(sCardNum3[0].ToString()), 
            convertToInt(sCardNum4[0].ToString()), 
            convertToInt(sCardNum5[0].ToString()), 
            convertToInt(sPlayer1CardNum1[0].ToString()), 
            convertToInt(sPlayer1CardNum2[0].ToString()) 
        };

        int[] player1CardSuits = { 
            cardSuit(sCardNum1[1].ToString()), 
            cardSuit(sCardNum2[1].ToString()), 
            cardSuit(sCardNum3[1].ToString()), 
            cardSuit(sCardNum4[1].ToString()), 
            cardSuit(sCardNum5[1].ToString()), 
            cardSuit(sPlayer1CardNum1[1].ToString()), 
            cardSuit(sPlayer1CardNum2[1].ToString()) 
        };

        //Player1 Base Cards
        int[] player12Cards = { 
            convertToInt(sPlayer1CardNum1[0].ToString()), 
            convertToInt(sPlayer1CardNum2[0].ToString()) 
        };

        //Player2 Cards
        int[] player2Cards = { 
            convertToInt(sCardNum1[0].ToString()), 
            convertToInt(sCardNum2[0].ToString()), 
            convertToInt(sCardNum3[0].ToString()), 
            convertToInt(sCardNum4[0].ToString()), 
            convertToInt(sCardNum5[0].ToString()), 
            convertToInt(sPlayer2CardNum1[0].ToString()), 
            convertToInt(sPlayer2CardNum2[0].ToString()) 
        };

        int[] player2CardSuits = { 
            cardSuit(sCardNum1[1].ToString()), 
            cardSuit(sCardNum2[1].ToString()), 
            cardSuit(sCardNum3[1].ToString()), 
            cardSuit(sCardNum4[1].ToString()), 
            cardSuit(sCardNum5[1].ToString()), 
            cardSuit(sPlayer2CardNum1[1].ToString()), 
            cardSuit(sPlayer2CardNum2[1].ToString()) 
        };

        //Player2 Base Cards
        int[] player22Cards = { 
            convertToInt(sPlayer2CardNum1[0].ToString()), 
            convertToInt(sPlayer2CardNum2[0].ToString()) 
        };

        //sorted cards with players cards
        Array.Sort(player1Cards);
        Array.Sort(player1CardSuits);

        //sorted players cards
        Array.Sort(player12Cards);

        string sPlayer1Cards = "";

        for(var i = 0; i < player1Cards.Length; i++){
            sPlayer1Cards = sPlayer1Cards + player1Cards[i].ToString();
        }

        //sorted cards with players cards
        Array.Sort(player2Cards);
        Array.Sort(player2CardSuits);

        //sorted players cards
        Array.Sort(player22Cards);

        string sPlayer2Cards = "";

        for(var i = 0; i < player2Cards.Length; i++){
            sPlayer2Cards = sPlayer2Cards + player2Cards[i].ToString();
        }

        int player1CardCombo = checkCards(player1Cards, player1CardSuits, sPlayer1Cards);
        int player2CardCombo = checkCards(player2Cards, player2CardSuits, sPlayer2Cards);

        player1Text.text = checkCardCombo(player1CardCombo);
        player2Text.text = checkCardCombo(player2CardCombo);

        WinnerText.text = checkWinner(player1CardCombo, player2CardCombo, player12Cards, player22Cards);
    }

    public string checkWinner(int player1CardCombo, int player2CardCombo, int[] player1HighCard, int[] player2HighCard){
        var sWinner = "";

        if(player1CardCombo > player2CardCombo){
            sWinner = "Player 1 Won";
        } else if(player1CardCombo == player2CardCombo){
            if((player1HighCard[0] + player1HighCard[1]) > (player2HighCard[0] + player2HighCard[1]))
            {
                sWinner = "Player 1 Won";
            } else if ((player1HighCard[0] + player1HighCard[1]) == (player2HighCard[0] + player2HighCard[1])){
                    sWinner = "Draw";
            } else {
                sWinner = "Player 2 Won";    
            }
        } else {
            sWinner = "Player 2 Won";
        }

        return sWinner;
    }

    public int checkCards(int[] playerCards, int[] playerCardSuits, string sPlayerCards){
        int potentialRoyal = checkStraight(sPlayerCards);
        
        int[] cardComboIds = {
            checkPairs(playerCards),
            checkStraight(sPlayerCards),
            checkSuits(playerCardSuits, potentialRoyal)
        };

        Array.Sort(cardComboIds);

        return cardComboIds[2];
    }

    public int checkPairs(int[] playerCards)
    {
        int cardComboId = 0;

        var dict = new Dictionary < int, int > ();
        foreach(var count in playerCards) {
            if (dict.ContainsKey(count))
               dict[count]++;
            else
               dict[count] = 1;
        }

        foreach(var val in dict)
        {
            if(val.Value == 2){
                cardPairCount++;
            } else if(val.Value == 4){
                //"Four of a Kind"
                cardComboId = 7;
            } else if(val.Value == 3){
                //"Three of a Kind");
                cardComboId = 3;
            }
        }
        
        if(!(cardComboId > 2)){
            if(cardPairCount > 1){
                //"Two Pair"
                cardComboId = 2;
            } else if(cardPairCount == 1){
                //"One Pair"
                cardComboId = 1;
            }
        }

        if(cardComboId == 3){
            if(cardPairCount == 1){
                //Full House
                cardComboId = 5;
            }
        }

        cardPairCount = 0;

        return cardComboId;
    }

    public int checkStraight(string cards){
        int cardComboId = 0;

        if(cards.Contains("1011121314")){
            //Potential Royal Flush
            cardComboId = 10;

        } else if((cards.Contains("2345") && cards.Contains("14")) ||
        cards.Contains("23456") || 
        cards.Contains("34567") ||
        cards.Contains("45678") ||
        cards.Contains("56789") ||
        cards.Contains("678910") ||
        cards.Contains("7891011") ||
        cards.Contains("89101112") ||
        cards.Contains("910111213") ||
        cards.Contains("1011121314"))
        {
            //"Straight"
            cardComboId = 4;
        }

        return cardComboId;
    }

    public int checkSuits(int[] player1CardSuits, int potentialRoyal){
        int cardComboId = 0; 

        var dict = new Dictionary < int, int > ();
        foreach(var count in player1CardSuits) {
            if (dict.ContainsKey(count))
               dict[count]++;
            else
               dict[count] = 1;
        }

        foreach(var val in dict)
        {
            if(val.Value == 5){
                if(potentialRoyal == 10){
                    //Royal Flush
                    cardComboId = 9;
                } else if(potentialRoyal == 4){
                    //Straight Flush
                    cardComboId = 8;
                } else {
                    //Flush
                    cardComboId = 6;
                }
            }
        }

        return cardComboId;
    }

    public int cardSuit(string cardSuit)
    {
        switch(cardSuit){
            case "D":
                return 1;
            case "H":
                return 2;
            case "S":
                return 3;
            case "C":
                return 4;
            default:
                return 0;
        }
    }

    public int convertToInt(string cardNum)
    {
        switch(cardNum){
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "0":
                return 10;
            case "J":
                return 11;
            case "Q":
                return 12;
            case "K":
                return 13;
            case "A":
                return 14;
            default:
                return 0;
        }
    }

    public string checkCardCombo(int cardCombo){
        var sCardCombo = "High Card";

        switch(cardCombo){
            case 1:
                sCardCombo = "One Pair";
                break;
            case 2:
                sCardCombo = "Two Pair";
                break;
            case 3:
                sCardCombo = "Three of a Kind";
                break;
            case 4:
                sCardCombo = "Straight";
                break;
            case 5:
                sCardCombo = "Full House";
                break;
            case 6:
                sCardCombo = "Flush";
                break;
            case 7:
                sCardCombo = "Four of a Kind";
                break;
            case 8:
                sCardCombo = "Straight Flush";
                break;
            case 9:
                sCardCombo = "Royal Flush";
                break;
            default:
                break;
        }

        return sCardCombo;
    }
}
