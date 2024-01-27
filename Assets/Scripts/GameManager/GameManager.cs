using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static ShopType? currentShopType { get; set; } = null;
    public static Player player { get; set; } = null;

    public static void ResetShopType()
    {
        currentShopType = null;
    }

    public static void StartNewGame()
    {
        player = new Player();
    }
}