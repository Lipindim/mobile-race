using Models;
using Tools;


namespace Controllers
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            SubscriptionProperty<float> leftMove = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMove = new SubscriptionProperty<float>();

            CarController carController = new CarController();
            BackgroundMoveController backgroundMoveController = new BackgroundMoveController(leftMove, rightMove);
            InputGameController inputGameController = new InputGameController(leftMove, rightMove, profilePlayer.CurrentCar);

            AddController(carController);
            AddController(backgroundMoveController);
            AddController(inputGameController);
        }
    }
}
