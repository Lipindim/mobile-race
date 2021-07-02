using Models;
using UnityEngine;


namespace Controllers
{
    public class CurrencyController : BaseController, IShowable
    {
        private const string VIEW_PATH = "Prefabs/CurrencyWindow";

        private readonly ProfilePlayer _profilePlayer;
        private readonly CurrencyView _view;


        public CurrencyController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<CurrencyView>(VIEW_PATH, placeForUi);
            _view.SetCurrency(profilePlayer.Currencies.WoodCount, profilePlayer.Currencies.DiamondCount);
        }

        public void AddCurrency(int woods, int diamonds)
        {
            int newWoodsCount = _profilePlayer.Currencies.WoodCount + woods;
            int newDiamondsCount = _profilePlayer.Currencies.DiamondCount + diamonds;
            _profilePlayer.Currencies.SetCurrencies(newWoodsCount, newDiamondsCount);
            _view.SetCurrency(newWoodsCount, newDiamondsCount);
        }

        public void Hide()
        {
            _view.Hide();
        }

        public void Show()
        {
            _view.Show();
        }
    }
}
