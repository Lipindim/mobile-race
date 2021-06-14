using Tools;
using Tools.Analytic;

namespace Models
{
    internal class ProfilePlayer
    {
        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            AnalyticTools = new UnityAnalyticTools();
            CurrentCar = new Car(speedCar);
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
        public IAnalyticTools AnalyticTools { get; internal set; }
    }
}