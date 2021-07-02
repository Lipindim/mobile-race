using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Controllers
{
    public class DailyRewardController : BaseController, IShowable
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/RewardWindow";
        private readonly ProfilePlayer _profilePlayer;

        #endregion


        #region Fields

        private readonly DailyRewardView _view;
        private readonly CurrencyController _currencyController;

        private List<ContainerSlotRewardView> _slots;

        private bool _isGetReward;

        #endregion


        #region ClassLifeCycles

        public DailyRewardController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<DailyRewardView>(VIEW_PATH, placeForUi);
            _currencyController = new CurrencyController(placeForUi, profilePlayer);
            AddController(_currencyController);
            AddGameObjects(_view.gameObject);

            InitSlots();
            SubscribeButtons();
        }
        protected override void OnDispose()
        {
            UnsubscribeButtons();
        }

        #endregion


        #region Methods

        public void RefreshView()
        {
            _view.StartCoroutine(RewardsStateUpdater());
            RefreshUi();
        }

        private void InitSlots()
        {
            _slots = new List<ContainerSlotRewardView>();

            for (var i = 0; i < _view.Rewards.Count; i++)
            {
                var instanceSlot = GameObject.Instantiate(_view.ContainerSlotRewardView,
                    _view.MountRootSlotsReward, false);

                _slots.Add(instanceSlot);
            }
        }

        private IEnumerator RewardsStateUpdater()
        {
            while (true)
            {
                RefreshRewardsState();
                yield return new WaitForSeconds(1);
            }
        }

        private void RefreshRewardsState()
        {
            _isGetReward = true;

            if (_view.TimeGetReward.HasValue)
            {
                var timeSpan = DateTime.UtcNow - _view.TimeGetReward.Value;

                if (timeSpan.TotalSeconds > _view.TimeDeadline)
                {
                    _view.TimeGetReward = null;
                    _view.CurrentSlotInActive = 0;
                }
                else if (timeSpan.TotalSeconds < _view.TimeCooldown)
                {
                    _isGetReward = false;
                }
            }

            RefreshUi();
        }

        private void RefreshUi()
        {
            _view.GetRewardButton.interactable = _isGetReward;

            if (_isGetReward)
            {
                _view.SliderNewReward.value = 1.0f;
            }
            else
            {
                if (_view.TimeGetReward != null)
                {
                    var nextClaimTime = _view.TimeGetReward.Value.AddSeconds(_view.TimeCooldown);
                    var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                    _view.SliderNewReward.value = (_view.TimeCooldown - (float)currentClaimCooldown.TotalSeconds) / _view.TimeCooldown;
                }
            }

            for (var i = 0; i < _slots.Count; i++)
                _slots[i].SetData(_view.Rewards[i], i + 1, i == _view.CurrentSlotInActive);
        }

        private void SubscribeButtons()
        {
            _view.GetRewardButton.onClick.AddListener(ClaimReward);
            _view.BackButton.onClick.AddListener(MoveBack);
        }

        private void UnsubscribeButtons()
        {
            _view.GetRewardButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();
        }

        private void ClaimReward()
        {
            if (!_isGetReward)
                return;

            var reward = _view.Rewards[_view.CurrentSlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.Wood:
                    _currencyController.AddCurrency(reward.CountCurrency, 0);
                    break;
                case RewardType.Diamond:
                    _currencyController.AddCurrency(0, reward.CountCurrency);
                    break;
            }

            _view.TimeGetReward = DateTime.UtcNow;
            _view.CurrentSlotInActive = (_view.CurrentSlotInActive + 1) % _view.Rewards.Count;

            RefreshRewardsState();
        }

        private void MoveBack()
        {
            _profilePlayer.CurrentState.Value = GameState.Menu;
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            _view.Hide();
            _currencyController.Hide();
        }

        public void Show()
        {
            _view.Show();
            _currencyController.Show();
            RefreshView();
        }

        #endregion

    }
}
