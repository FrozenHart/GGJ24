using System;

public static class GameManager
{
    public static ShopType? currentShopType { get; set; } = null;

    public static void ResetShopType()
    {
        currentShopType = null;
    }

    public static void StartNewGame()
    {
        
    }
}