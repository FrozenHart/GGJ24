using System.Collections.Generic;
using System;

public static class DefaultGameStorage
{
    public static List<Enemy> enemyList = new List<Enemy>()
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

    public static List<Card> cardList = new List<Card>()
    {
        new Card("basic10", 10, null, 0, "a2", ShopType.Basic),
        new Card("basic10-2", 10, null, 0, "a2", ShopType.Basic),
        new Card("basic10-3", 10, null, 0, "a2", ShopType.Basic),
        new Card("basic10-4", 10, null, 0, "a2", ShopType.Basic),
        new Card("super100", 100, null, 0, "a2", ShopType.Special),
        new Card("special1000", 1000, null, 0, "a2", ShopType.Super)
    };
}