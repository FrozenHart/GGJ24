using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static ShopType? currentShopType = null;
    public static int currentShopLoopFrame = 0;
    public static Player player = new Player();

    public static void ResetShopType()
    {
        currentShopType = null;
    }

    public static void StartNewGame()
    {
        player = new Player();
    }

    internal static List<Card> GetCards(ShopType? currentShopType)
    {
        List<Card> cards = new List<Card>();
        if (currentShopType == null)
            return cards;

        foreach (Card card in DefaultGameStorage.cardList)
        {
            if (player.GetInventory().Contains(card) || player.GetHand().Contains(card))
                continue;
            if (card.GetCardType() != currentShopType) 
                continue;

            cards.Add(card);
        }

        return cards;
    }
}