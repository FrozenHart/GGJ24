using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static ShopType? currentShopType = null;
    public static int currentShopLoopFrame = 0;
    public static Player player = new Player();
    public static List<Enemy> enemies = new List<Enemy>() 
    {
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.x),HumourType.Banana),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Intelligent,HumourType.x),HumourType.Banana),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.Intelligent),HumourType.Banana),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.x),HumourType.Intelligent),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.Banana),HumourType.Intelligent),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Banana,HumourType.x),HumourType.Intelligent),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Intelligent,HumourType.x),HumourType.Dark),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Banana,HumourType.x),HumourType.Dark),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Banana,HumourType.Intelligent),HumourType.Dark),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.Banana),HumourType.x),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Dark,HumourType.Intelligent),HumourType.x),
        new Enemy(0.5f,new Tuple<HumourType, HumourType>(HumourType.Banana,HumourType.Intelligent),HumourType.x),
    };

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


        return cards;
    }
}