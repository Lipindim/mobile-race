using System;


namespace Inventory
{
    public interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }
}
