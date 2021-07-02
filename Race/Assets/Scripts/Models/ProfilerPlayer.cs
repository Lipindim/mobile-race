using System.Collections.Generic;
using Tools;
using Tools.Analytic;
using Tools.Shop;

namespace Models
{
    public class ProfilePlayer
    {

        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; }
        public IShop Shop { get; }

        public Currencies Currencies { get; }


        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            AnalyticTools = new UnityAnalyticTools();
            Currencies = new Currencies();
            Shop = new ShopTools(new List<ShopProduct>()
            {
                new ShopProduct()
                {
                    Id = "1",
                    CurrentProductType = UnityEngine.Purchasing.ProductType.Consumable
                }
            });
        }
        
    }
}