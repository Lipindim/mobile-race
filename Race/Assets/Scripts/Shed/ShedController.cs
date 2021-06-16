using Configs;
using Controllers;
using Inventory;
using Items;
using JetBrains.Annotations;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Upgrades;


namespace Shed
{
    public class ShedController : BaseController, IShedController
    {
        private readonly Car _car;

        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly IInventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;

        private Action _callback;


        #region ClassLifeCycles

        public ShedController( List<UpgradeItemConfig> upgradeItemConfigs,
            Car car,
            Transform placeForUi,
            IInventoryModel inventoryModel)
        {
            if (upgradeItemConfigs == null) 
                throw new ArgumentNullException(nameof(upgradeItemConfigs));

            _car = car ?? throw new ArgumentNullException(nameof(car));

            _upgradeHandlersRepository
                = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddController(_upgradeHandlersRepository);

            _upgradeItemsRepository
                = new ItemsRepository(upgradeItemConfigs.Select(value => value.itemConfig).ToList());
            AddController(_upgradeItemsRepository);

            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));

            _inventoryController
                = new InventoryController(_inventoryModel, _upgradeItemsRepository, placeForUi);
            AddController(_inventoryController);
        }

        #endregion


        #region IShedController

        public void Enter(Action callback)
        {
            _callback = callback;
            _inventoryController.ShowInventory(Exit);
            Debug.Log($"Enter: car has speed : {_car.Speed}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _car, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
            Debug.Log($"Exit: car has speed : {_car.Speed}");
            _callback?.Invoke();
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

    }
}
