using Inventory;
using Models;
using System;
using Tools;
using UnityEngine;


namespace Controllers
{
    internal class MainController : BaseController
    {

        #region Fields

        private readonly MainMenuController _mainMenuController;

        private readonly ProfilePlayer _profilePlayer;
        private readonly Transform _placeForUi;

        private IInventoryModel _inventoryModel;
        private GameController _gameController;

        #endregion


        #region ClassLifeCycles

        public MainController(Transform placeForUi, Camera camera)
        {
            _placeForUi = placeForUi;
            _profilePlayer = new ProfilePlayer(1.0f);
            _profilePlayer.CurrentState.SubscribeOnChange(OnStateChange);
            var cameraTool = new CameraTool(camera);
            _inventoryModel = new InventoryModel();
            _mainMenuController = new MainMenuController(placeForUi, _profilePlayer, cameraTool, _inventoryModel);
            AddController(_mainMenuController);
            _gameController = new GameController(_profilePlayer, _inventoryModel, _placeForUi);
            AddController(_gameController);

            _profilePlayer.CurrentState.Value = GameState.Menu;
        }

        #endregion


        #region Methods

        private void OnStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.Menu:
                    _mainMenuController.Show();
                    _gameController.Hide();
                    break;
                case GameState.Game:
                    _mainMenuController.Hide();
                    _gameController.Show();
                    break;
                case GameState.Reward:
                    _mainMenuController.ShowReward();
                    _gameController.Hide();
                    break;
                case GameState.Fight:
                    _mainMenuController.Hide();
                    _gameController.ShowFight();
                    break;
                case GameState.Shed:
                    _gameController.Hide();
                    _mainMenuController.ShowShed();
                    break;
                default:
                    throw new ArgumentException($"Unkonwn state: {newState}");
            }
        }

        #endregion

    }
}
