using Models;
using System;
using UnityEngine;


namespace Controllers
{
    public class FightController : BaseController, IShowable
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/Fight";

        #endregion


        #region Fields

        private readonly ProfilePlayer _profilePlayer;
        private readonly FightView _view;
        private readonly Money _money;
        private readonly Health _heath;
        private readonly Power _power;
        private readonly Enemy _enemy;

        #endregion


        #region ClassLifeCycles

        public FightController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<FightView>(VIEW_PATH, placeForUi);

            _enemy = new Enemy("Enemy Skull");

            _money = new Money(nameof(Money));
            _money.Attach(_enemy);

            _heath = new Health(nameof(Health));
            _heath.Attach(_enemy);

            _power = new Power(nameof(Power));
            _power.Attach(_enemy);

            Subscribe();
        }

        protected override void OnDispose()
        {
            Unsubscribe();

            _money.Detach(_enemy);
            _heath.Detach(_enemy);
            _power.Detach(_enemy);
        }

        #endregion


        #region Methods

        private void Subscribe()
        {
            _view.IncreaseMoney.onClick.AddListener(() => IncreaseValue(_money));
            _view.DecreaseMoney.onClick.AddListener(() => DecreaseValue(_money));

            _view.IncreaseHealth.onClick.AddListener(() => IncreaseValue(_heath));
            _view.DecreaseHealth.onClick.AddListener(() => DecreaseValue(_heath));

            _view.IncreasePower.onClick.AddListener(() => IncreaseValue(_power));
            _view.DecreasePower.onClick.AddListener(() => DecreaseValue(_power));

            _view.Fight.onClick.AddListener(Fight);
            _view.Exit.onClick.AddListener(GoToRace);
        }

        private void GoToRace()
        {
            _profilePlayer.CurrentState.Value = GameState.Game;
        }

        private void Unsubscribe()
        {
            _view.IncreaseMoney.onClick.RemoveAllListeners();
            _view.DecreaseMoney.onClick.RemoveAllListeners();

            _view.IncreaseHealth.onClick.RemoveAllListeners();
            _view.DecreaseHealth.onClick.RemoveAllListeners();

            _view.IncreasePower.onClick.RemoveAllListeners();
            _view.DecreasePower.onClick.RemoveAllListeners();

            _view.Fight.onClick.RemoveAllListeners();
        }

        private void IncreaseValue(DataPlayer dataPlayer)
        {
            dataPlayer.Value++;
            ChangeDataWindow(dataPlayer);
        }

        private void DecreaseValue(DataPlayer dataPlayer)
        {
            dataPlayer.Value--;
            ChangeDataWindow(dataPlayer);
        }

        private void Fight()
        {
            Debug.Log(_power.Value >= _enemy.Power
               ? "<color=#07FF00>Win!!!</color>"
               : "<color=#FF0000>Lose!!!</color>");
        }

        private void PassPeacefully()
        {
            Debug.Log("<color=#07FF00>Passed peacefully!!!</color>");
        }

        private void ChangeDataWindow(DataPlayer dataPlayer)
        {
            switch (dataPlayer.DataType)
            {
                case DataType.Money:
                    _view.PlayerMoney.text = $"Money: {dataPlayer.Value}";
                    break;

                case DataType.Health:
                    _view.PlayerHealth.text = $"Health: {dataPlayer.Value}";
                    break;

                case DataType.Power:
                    _view.PlayerPower.text = $"Power: {dataPlayer.Value}";
                    break;

                default:
                    throw new ArgumentException($"Unsupported data type: {dataPlayer.DataType}");
            }

            _view.EnemyPower.text = $"Enemy Power: {_enemy.Power}";
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            _view.Hide();
        }

        public void Show()
        {
            _view.Show();
        }

        #endregion

    }
}
