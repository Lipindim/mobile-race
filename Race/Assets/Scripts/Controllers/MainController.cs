using Models;
using Tools.Ads;
using UnityEngine;


namespace Controllers
{
    internal class MainController : BaseController
    {
        private readonly MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly ProfilePlayer _profilePlayer;
        private IAdsShower _adsShower;

        public MainController(Transform placeForUi, IAdsShower adsShower)
        {
            _adsShower = adsShower;
            _profilePlayer = new ProfilePlayer(1.0f);
            _profilePlayer.CurrentState.SubscribeOnChange(OnStateChange);
            _mainMenuController = new MainMenuController(placeForUi, _profilePlayer);
            AddController(_mainMenuController);
        }

        private void OnStateChange(GameState newState)
        {
            if (newState == GameState.Game)
            {
                _adsShower.ShowInterstitial();
                _mainMenuController.Dispose();
                _gameController = new GameController(_profilePlayer);
                AddController(_gameController);
            }

        }
    }
}
