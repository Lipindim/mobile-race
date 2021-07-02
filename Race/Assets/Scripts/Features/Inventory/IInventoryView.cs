using Items;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Views;


namespace Inventory
{
    public interface IInventoryView : IView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> items);
        Button Exit { get; }
    }
}
