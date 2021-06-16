using Items;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Inventory
{
    public interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(List<IItem> items);
        void Initialize(UnityAction exit);
    }
}
