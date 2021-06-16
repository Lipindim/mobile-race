using Items;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Inventory
{
    public class ItemView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Text _title;
        [SerializeField]
        private Image _borderImage;

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        private IItem _item;
        private bool _selected;

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
    }
}
