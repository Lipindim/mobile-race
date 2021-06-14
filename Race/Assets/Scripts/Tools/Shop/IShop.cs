namespace Tools.Shop
{
    public interface IShop
    {
        void Buy(string id);
        string GetCost(string productId);
        void RestorePurchase();
        IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        IReadOnlySubscriptionAction OnFailedPurchase { get; }
    }
}
