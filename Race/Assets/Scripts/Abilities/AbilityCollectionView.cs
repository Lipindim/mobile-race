using Items;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Abilities
{
    public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
    {
        [SerializeField]
        private AbilityView[] _abilityViews;

        public event EventHandler<IItem> UseRequested;

        public void Display(IReadOnlyList<IItem> abilityItems)
        {
            for (int i = 0; i < _abilityViews.Length && i < abilityItems.Count; i++)
            {
                _abilityViews[i].Display(abilityItems[i]);
                _abilityViews[i].Activated += ActivatedAbility;
            }
        }

        private void ActivatedAbility(object sender, IItem e)
        {
            UseRequested?.Invoke(this, e);
        }
    }
}
