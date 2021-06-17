using Inventory;
using Models;
using Tools;
using Tools.Ads;
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

        public MainController(Transform placeForUi, IAdsShower adsShower, Camera camera)
        {
            _placeForUi = placeForUi;
            _profilePlayer = new ProfilePlayer(1.0f);
            _profilePlayer.CurrentState.SubscribeOnChange(OnStateChange);
            var cameraTool = new CameraTool(camera);
            _inventoryModel = new InventoryModel();
            _mainMenuController = new MainMenuController(placeForUi, _profilePlayer, cameraTool, _inventoryModel);
            AddController(_mainMenuController);
        }

        #endregion


        #region Methods

        private void OnStateChange(GameState newState)
        {
            if (newState == GameState.Game)
            {
                _mainMenuController.Dispose();
                _gameController = new GameController(_profilePlayer, _inventoryModel, _placeForUi);
                AddController(_gameController);
            }

        }

        #endregion

    }
}
