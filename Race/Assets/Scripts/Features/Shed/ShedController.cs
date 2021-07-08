using Configs;
using Controllers;
using Inventory;
using Items;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Upgrades;


namespace Shed
{
    public class ShedController : BaseController, IShowable
    {

        #region Fields

        private readonly ProfilePlayer _profilePlayer;
        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly IShowable _inventoryController;

        #endregion


        #region ClassLifeCycles

        public ShedController( List<UpgradeItemConfig> upgradeItemConfigs,
            ProfilePlayer profilePlayer,
            Transform placeForUi,
            IInventoryModel inventoryModel)
        {
            _profilePlayer = profilePlayer;
            _upgradeHandlersRepository
                = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddController(_upgradeHandlersRepository);

            _upgradeItemsRepository
                = new ItemsRepository(upgradeItemConfigs.Select(value => value.itemConfig).ToList());
            AddController(_upgradeItemsRepository);

            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _inventoryController
                = new InventoryController(_inventoryModel, _upgradeItemsRepository, placeForUi, profilePlayer);
        }

        private void UpgradeCarWithEquippedItems(
           IUpgradableCar upgradableCar,
           IReadOnlyList<IItem> equippedItems,
           IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                    handler.Upgrade(upgradableCar);
            }
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            UpgradeCarWithEquippedItems(
                _profilePlayer.CurrentCar, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
            Debug.Log($"Exit: car has speed : {_profilePlayer.CurrentCar.Speed}");
            _inventoryController.Hide();
        }

        public void Show()
        {
            _inventoryController.Show();
            Debug.Log($"Enter: car has speed : {_profilePlayer.CurrentCar.Speed}");
        }

        #endregion

    }
}
