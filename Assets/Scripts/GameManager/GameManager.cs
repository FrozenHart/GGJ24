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
}