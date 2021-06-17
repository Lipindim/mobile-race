using Items;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Views;

namespace Abilities
{
    public class AbilityView : MonoBehaviour, IPointerDownHandler, IView
    {

        #region Fields

        [SerializeField]
        private Text _title;

        private IItem _item;

        #endregion


        #region Events

        public event EventHandler<IItem> Activated;

        #endregion


        #region Methods

        public void Display(IItem item)
        {
            _item = item;
            _title.text = item.Info.Title;
        }

        #endregion


        #region IPointerDownHandler

        public void OnPointerDown(PointerEventData eventData)
        {
            Activated?.Invoke(this, _item);
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
