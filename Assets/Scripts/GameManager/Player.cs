using System;
using System.Collections.Generic;

public class Player
{
    private int mana = 0;
    private List<string> hand = new List<string>();
    private Dictionary<string, Card> inventory = new Dictionary<string, Card>();
    private List<string> deck = new List<string>();
    private List<HumourType> effects = new List<HumourType>();

    private void DrawCard(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            int cardNumber = new Random().Next(0, deck.Count - 1);
            hand.Add(deck[cardNumber]);
            deck.RemoveAt(cardNumber);
        }
    }

    public int GetMana() { return mana; }

    public void SetMana(int value) { mana = value; }
} 