using Items;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField]
        private Button _exitButton;
        [SerializeField]
        private ItemView[] _items;

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        private List<IItem> _itemInfoCollection;


        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;

            for (int i = 0; i < _items.Length && i < itemInfoCollection.Count ; i++)
            {
                _items[i].Display(itemInfoCollection[i]);
                _items[i].Selected += OnSelected;
                _items[i].Deselected += OnDeselected;
            }
        }

        protected virtual void OnSelected(object sender, IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(object sender, IItem e)
        {
            Deselected?.Invoke(this, e);
        }

        public void Initialize(UnityAction exit)
        {
            _exitButton.onClick.AddListener(exit);
            _exitButton.onClick.AddListener(Unsubscribe);
        }

        private void Unsubscribe()
        {
            foreach (ItemView item in _items)
            {
                item.Selected -= OnSelected;
                item.Deselected -= OnDeselected;
            }

            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
