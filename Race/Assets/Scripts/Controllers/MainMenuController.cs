using Configs;
using Inventory;
using Models;
using Shed;
using System.Linq;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class MainMenuController : BaseController
    {
        private const string VIEW_PATH = "Prefabs/mainMenu";
        private const string UPGRADES_CONFIG_PATH = "Configs/Upgrades/UpgradeItemConfigDataSource";
       
        private readonly IInventoryModel _inventoryModel;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;

        private MainMenuView _view;
        private GameObject _viewObject;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, ICameraTool cameraTool, IInventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame, Buy, OpenShed, cameraTool);
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

        private void OpenShed()
        {
            var upgradesConfig = Resources.Load<UpgradeItemConfigDataSource>(UPGRADES_CONFIG_PATH);
            ShedController shedController = new ShedController(upgradesConfig.ItemConfigs.ToList(), _profilePlayer.CurrentCar, _placeForUi, _inventoryModel);
            Hide();
            shedController.Enter(Show);
        }

        private void Hide()
        {
            _viewObject.SetActive(false);
        }

        private void Show()
        {
            _viewObject.SetActive(true);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            var prefab = ResourceLoader.LoadPrefab(VIEW_PATH);
            _viewObject = Object.Instantiate(prefab, placeForUi, false);
            AddGameObjects(_viewObject);
            return _viewObject.GetComponent<MainMenuView>();
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