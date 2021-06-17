using Items;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using Views;

namespace Inventory
{
    public interface IInventoryView : IView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> items);
        void Initialize(UnityAction exit);
    }
}
