using Items;
using System.Collections.Generic;


namespace Inventory
{
    public class InventoryModel : IInventoryModel
    {

        #region Fields

        private readonly List<IItem> _items = new List<IItem>();

        #endregion


        #region Methods

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _items;
        }

        public void EquipItem(IItem item)
        {
            if (!_items.Contains(item)) 
                _items.Add(item);
        }

        public void UnequipItem(IItem item)
        {
            if (_items.Contains(item))
                _items.Remove(item);
        }

        #endregion

    }
}
