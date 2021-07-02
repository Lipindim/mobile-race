using Configs;
using Inventory;
using Models;
using Shed;
using System;
using System.Linq;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class MainMenuController : BaseController, IShowable
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/mainMenu";
        private const string UPGRADES_CONFIG_PATH = "Configs/Upgrades/UpgradeItemConfigDataSource";

        #endregion


        #region Fields

        private readonly DailyRewardController _rewardController;
        private readonly IInventoryModel _inventoryModel;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ShedController _shedController;
        private readonly MainMenuView _view;

        #endregion


        #region ClassLifeCycles

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer, ICameraTool cameraTool, IInventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            _view = LoadView<MainMenuView>(VIEW_PATH, placeForUi);
            _view.Init(cameraTool);
            _rewardController = new DailyRewardController(placeForUi, profilePlayer);
            var upgradesConfig = Resources.Load<UpgradeItemConfigDataSource>(UPGRADES_CONFIG_PATH);
            _shedController = new ShedController(upgradesConfig.ItemConfigs.ToList(), _profilePlayer, _placeForUi, _inventoryModel);

            Subscribe();
        }

        protected override void OnDispose()
        {
            Unsubscribe();
        }

        #endregion


        #region Methods

        private void Subscribe()
        {
            _view.ButtonStart.onClick.AddListener(StartGame);
            _view.ButtonShed.onClick.AddListener(OpenShed);
            _view.ButtonReward.onClick.AddListener(OpenReward);
        }

        private void Unsubscribe()
        {
            _view.ButtonStart.onClick.RemoveAllListeners();
            _view.ButtonShed.onClick.RemoveAllListeners();
            _view.ButtonReward.onClick.RemoveAllListeners();
        }

        private void OpenShed()
        {
            _profilePlayer.CurrentState.Value = GameState.Shed;
        }

        private void StartGame()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
            _profilePlayer.AnalyticTools.SendMessage("start_game");
        }

        private void OpenReward()
        {
            _profilePlayer.CurrentState.Value = GameState.Reward;
        }

        public void ShowReward()
        {
            HideAll();
            _rewardController.Show();
        }

        public void ShowShed()
        {
            HideAll();
            _shedController.Show();
        }

        private void HideAll()
        {
            _view.Hide();
            _shedController.Hide();
            _rewardController.Hide();
        }

        #endregion


        #region IShowable

        public void Show()
        {
            HideAll();
            _view.Show();
        }

        public void Hide()
        {
            HideAll();
        }

        #endregion


    }
}