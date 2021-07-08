using Items;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {

        #region Fields

        [SerializeField]
        private Button _exitButton;
        [SerializeField]
        private ItemView[] _items;

        private List<IItem> _itemInfoCollection;

        #endregion


        #region Properties

        public Button Exit => _exitButton;

        #endregion


        #region IInventoryView

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        public void Display(List<IItem> itemInfoCollection)
        {
            _itemInfoCollection = itemInfoCollection;

            for (int i = 0; i < _items.Length && i < itemInfoCollection.Count ; i++)
            {
                _items[i].Display(itemInfoCollection[i]);
                _items[i].Selected += OnSelected;
                _items[i].Deselected += OnDeselected;
                _items[i].Show();
            }

            for (int i = itemInfoCollection.Count; i < _items.Length; i++)
                _items[i].Hide();
        }


        #endregion

        protected virtual void OnSelected(object sender, IItem e)
        {
            Selected?.Invoke(this, e);
        }

        protected virtual void OnDeselected(object sender, IItem e)
        {
            Deselected?.Invoke(this, e);
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

        #region IView

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        #endregion

    }
}
