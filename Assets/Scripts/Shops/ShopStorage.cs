public static class ShopStorage
{
    public static ShopType? currentType { get; set; } = null;

    public enum ShopType
    {
        Basic,
        Special,
        Super
    }

    public static void ResetType()
    {
        currentType = null;
    }
}