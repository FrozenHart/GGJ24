using System;
using System.Collections.Generic;

public class Player
{
    private int mana = 0;
    private List<Card> inventory = new List<Card>();
    private List<Card> hand = new List<Card>();

    public List<Card> GetInventory()
    {
        return inventory;
    }

    public List<Card> GetHand()
    {
        return hand;
    }

    public int GetMana() { return mana; }

    public void SetMana(int value) { mana = value; }

    internal void AddCard(Card card)
    {
        inventory.Add(card);
    }
} 