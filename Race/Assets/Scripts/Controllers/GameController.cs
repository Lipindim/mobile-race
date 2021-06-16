using Abilities;
using Inventory;
using Models;
using Tools;
using UnityEngine;


namespace Controllers
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, IInventoryModel inventoryModel, Transform placeForUi)
        {
            SubscriptionProperty<float> leftMove = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMove = new SubscriptionProperty<float>();

            var carController = new CarController();
            var backgroundMoveController = new BackgroundMoveController(leftMove, rightMove);
            var inputGameController = new InputGameController(leftMove, rightMove, profilePlayer.CurrentCar);
            var abilityRepository = new AbilityRepository();
            var abilitiesController = new AbilitiesController(carController, inventoryModel, abilityRepository, placeForUi);

            AddController(carController);
            AddController(backgroundMoveController);
            AddController(inputGameController);
            AddController(abilitiesController);
        }
    }
}
