using Items;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {

        #region Fields

        [SerializeField]
        private AbilityView[] _abilityViews;

        #endregion


        #region IAbilityCollectionView

        public event EventHandler<IItem> UseRequested;

        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            for (int i = 0; i < _abilityViews.Length && i < abilityItems.Count; i++)
            {
                _abilityViews[i].Display(abilityItems[i]);
                _abilityViews[i].Activated += ActivatedAbility;
                _abilityViews[i].Show();
            }

            for (int i = abilityItems.Count; i < _abilityViews.Length; i++)
            {
                _abilityViews[i].Hide();
            }
        }

        #endregion


        #region Methods

        private void ActivatedAbility(object sender, IItem e)
        {
            UseRequested?.Invoke(this, e);
        }

        #endregion

    }
}
