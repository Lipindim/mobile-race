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
        private const string VIEW_PATH = "Prefabs/Inventory";

        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;
        private readonly Transform _placeForUi;

        private GameObject _viewObject;
        private Action _callback;

        public InventoryController(
            IInventoryModel inventoryModel,
            IItemsRepository itemsRepository,
            Transform placeForUi)
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _placeForUi = placeForUi ?? throw new ArgumentNullException(nameof(_placeForUi));

            _inventoryView = LoadView();
            _inventoryView.Initialize(HideInventory);

            HideInventory();

            _inventoryView.Selected += EquipItem;
            _inventoryView.Deselected += UnequipItem;
        }

        protected override void OnDispose()
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

        private InventoryView LoadView()
        {
            _viewObject = GameObject.Instantiate(ResourceLoader.LoadPrefab(VIEW_PATH), _placeForUi);
            AddGameObjects(_viewObject);
            return _viewObject.GetComponent<InventoryView>();
        }

        public void HideInventory()
        {
            _viewObject.SetActive(false);
            _callback?.Invoke();
        }

        public void ShowInventory(Action callback)
        {
            _callback = callback;
            _inventoryView.Display(_itemsRepository.Items.Values.ToList());
            _viewObject.SetActive(true);
        }
    }

}
