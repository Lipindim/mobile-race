using Items;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Views;


namespace Inventory
{
    public class ItemView : MonoBehaviour, IPointerDownHandler, IView
    {

        #region Fields

        [SerializeField]
        private Text _title;
        [SerializeField]
        private Image _borderImage;

        private IItem _item;
        private bool _selected;

        #endregion


        #region Events

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        #endregion


        #region Methods

        public void Display(IItem item)
        {
            _item = item;
            _title.text = item.Info.Title;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _selected = !_selected;
            ChangeBorderColor();

            if (_selected)
                Selected?.Invoke(this, _item);
            else
                Deselected?.Invoke(this, _item);
        }

        private void ChangeBorderColor()
        {
            if (_selected)
                _borderImage.color = Color.green;
            else
                _borderImage.color = Color.gray;
        }

        #endregion


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
