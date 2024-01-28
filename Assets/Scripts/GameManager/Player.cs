using System.Collections.Generic;

public class Player
{
    private int mana = 10;
    private int life = 3;
    private List<Card> inventory = new List<Card>();
    private List<Card> hand = new List<Card>();

    public List<Card> availableCards = new List<Card>(DefaultGameStorage.GameCards);

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

    public void TakeDamage()
    {
        life--;
        if (life <= 0 ) life = 0;
    }

    public int GetLife()
    {
        return life;
    }
    
    internal void AddCard_ToHand(Card card) 
    {
        hand.Add(card);
    }
    public void RemoveCardFromHand(Card card)
    {
        hand.Remove(card);
    }
    public void Reset_Hand()
    { hand.Clear(); }
} 