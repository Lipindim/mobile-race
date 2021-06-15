using Models;
using Tools;
using Tools.Ads;
using UnityEngine;


namespace Controllers
{
    internal class MainController : BaseController
    {
        private readonly MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly ProfilePlayer _profilePlayer;

        public MainController(Transform placeForUi, IAdsShower adsShower, Camera camera)
        {
            _profilePlayer = new ProfilePlayer(1.0f);
            _profilePlayer.CurrentState.SubscribeOnChange(OnStateChange);
            var cameraTool = new CameraTool(camera);
            _mainMenuController = new MainMenuController(placeForUi, _profilePlayer, cameraTool);
            AddController(_mainMenuController);
        }

        private void OnStateChange(GameState newState)
        {
            if (newState == GameState.Game)
            {
                _mainMenuController.Dispose();
                _gameController = new GameController(_profilePlayer);
                AddController(_gameController);
            }

        }
    }
}
