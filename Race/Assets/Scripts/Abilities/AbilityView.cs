using Items;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Abilities
{
    public class AbilityView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Text _title;

        public event EventHandler<IItem> Activated;

        private IItem _item;

        public void Display(IItem item)
        {
            _item = item;
            _title.text = item.Info.Title;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Activated?.Invoke(this, _item);
        }
    }
}
