using Controllers;
using Items;
using Models;
using System;
using System.Linq;
using UnityEngine;


namespace Inventory
{
    public class InventoryController : BaseController, IShowable
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/Inventory";

        #endregion


        #region Fields

        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;
        private readonly ProfilePlayer _profilePlayer;

        #endregion


        #region ClassLifeCycles

        public InventoryController(
            IInventoryModel inventoryModel,
            IItemsRepository itemsRepository,
            Transform placeForUi,
            ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            if (placeForUi == null)
                throw new ArgumentNullException(nameof(placeForUi));

            _inventoryView = LoadView<IInventoryView>(VIEW_PATH, placeForUi);

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
            _inventoryView.Selected += EquipItem;
            _inventoryView.Deselected += UnequipItem;
            _inventoryView.Exit.onClick.AddListener(GoToMenu);
        }

        private void GoToMenu()
        {
            _profilePlayer.CurrentState.Value = GameState.Menu;
        }

        private void Unsubscribe()
        {
            _inventoryView.Selected -= EquipItem;
            _inventoryView.Deselected -= UnequipItem;
        }

        private void UnequipItem(object sender, IItem e)
        {
            _inventoryModel.UnequipItem(e);
        }

        private void EquipItem(object sender, IItem e)
        {
            _inventoryModel.EquipItem(e);
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            _inventoryView.Hide();
        }

        public void Show()
        {
            _inventoryView.Display(_itemsRepository.Items.Values.ToList());
            _inventoryView.Show();
        }

        #endregion

    }
}
