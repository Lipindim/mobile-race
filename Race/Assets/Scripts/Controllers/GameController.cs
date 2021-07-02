using Abilities;
using Inventory;
using Models;
using System;
using Tools;
using UnityEngine;


namespace Controllers
{
    public class GameController : BaseController, IShowable
    {
        private const string VIEW_PATH = "Prefabs/Game";

        private readonly ProfilePlayer _profilePlayer;
        private readonly GameView _view;
        private readonly CarController _carController;
        private readonly FightController _fightController;
        private readonly BackgroundMoveController _backgroundMoveController;

        public GameController(ProfilePlayer profilePlayer, IInventoryModel inventoryModel, Transform placeForUi)
        {
            SubscriptionProperty<float> leftMove = new SubscriptionProperty<float>();
            SubscriptionProperty<float> rightMove = new SubscriptionProperty<float>();

            _profilePlayer = profilePlayer;
            _view = LoadView<GameView>(VIEW_PATH, placeForUi);
            _view.GoToFight.onClick.AddListener(GoToFight);

            _carController = new CarController();
            _fightController = new FightController(placeForUi, profilePlayer);
            _backgroundMoveController = new BackgroundMoveController(leftMove, rightMove);
            var inputGameController = new InputGameController(leftMove, rightMove, profilePlayer.CurrentCar);
            var abilityRepository = new AbilityRepository();
            var abilitiesController = new AbilitiesController(_carController, inventoryModel, abilityRepository, placeForUi);

            AddGameObjects(_view.gameObject);
            AddController(_carController);
            AddController(_backgroundMoveController);
            AddController(inputGameController);
            AddController(abilitiesController);
        }

        private void GoToFight()
        {
            _profilePlayer.CurrentState.Value = GameState.Fight;
        }

        public void Hide()
        {
            HideAll();
        }

        public void Show()
        {
            _carController.Show();
            _backgroundMoveController.Show();
            _view.Show();
            _fightController.Hide();
        }

        public void ShowFight()
        {
            HideAll();
            _fightController.Show();
        }

        private void HideAll()
        {
            _carController.Hide();
            _backgroundMoveController.Hide();
            _view.Hide();
            _fightController.Hide();
        }
    }
}
