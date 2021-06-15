using Configs;
using Controllers;
using System.Collections.Generic;


namespace Items
{
    public class ItemsRepository : BaseController, IItemsRepository
    {

        #region Properties
        
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;

        #endregion


        #region Fields

        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        #endregion


        #region ClassLifeCycles

        public ItemsRepository(
            List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _itemsMapById, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            _itemsMapById.Clear();
            _itemsMapById = null;
        }

        #endregion


        #region Methods

        private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType, List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (!upgradeHandlersMapByType.ContainsKey(config.Id)) 
                    upgradeHandlersMapByType.Add(config.Id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                Id = config.Id,
                Info = new ItemInfo 
                { 
                    Title = config.Title 
                }
            };
        }

        #endregion

    }
}
