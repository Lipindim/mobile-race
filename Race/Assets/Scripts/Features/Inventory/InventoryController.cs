using Controllers;
using Items;
using System;
using System.Linq;
using Tools;
using UnityEngine;


namespace Inventory
{
    public class InventoryController : BaseController, IInventoryController
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/Inventory";

        #endregion


        #region Fields

        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;
        private readonly Transform _placeForUi;

        private Action _callback;

        #endregion


        #region ClassLifeCycles

        public InventoryController(
            IInventoryModel inventoryModel,
            IItemsRepository itemsRepository,
            Transform placeForUi)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _placeForUi = placeForUi ?? throw new ArgumentNullException(nameof(_placeForUi));

            _inventoryView = LoadView<IInventoryView>(VIEW_PATH, placeForUi);
            _inventoryView.Initialize(HideInventory);

            HideInventory();
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

        public void HideInventory()
        {
            _inventoryView.Hide();
            _callback?.Invoke();
        }

        public void ShowInventory(Action callback)
        {
            _callback = callback;
            _inventoryView.Display(_itemsRepository.Items.Values.ToList());
            _inventoryView.Show();
        }

        #endregion

    }
}
