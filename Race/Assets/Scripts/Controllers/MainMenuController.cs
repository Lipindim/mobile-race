using Models;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    internal class MainMenuController : BaseController
    {
        private readonly string _viewPath = "Prefabs/mainMenu";

        private readonly ProfilePlayer _profilePlayer;
        private MainMenuView _view;

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, ICameraTool cameraTool)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, Buy, cameraTool);
            _profilePlayer.Shop.OnSuccessPurchase.SubscribeOnChange(PurchaseCompleted);
        }

        private void PurchaseCompleted()
        {
            Debug.Log("Покупка совершена.");
        }

        private void Buy()
        {
            _profilePlayer.Shop.Buy("1");
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            var prefab = ResourceLoader.LoadPrefab(_viewPath);
            var objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObjects(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }

        protected override void OnDispose()
        {
            _profilePlayer.Shop.OnSuccessPurchase.UnSubscriptionOnChange(PurchaseCompleted);
        }
    }
}