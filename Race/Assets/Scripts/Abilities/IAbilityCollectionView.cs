using Items;
using System;
using System.Collections.Generic;


namespace Abilities
{
    public interface IAbilityCollectionView
    {
        event EventHandler<IItem> UseRequested;
        void Display(IReadOnlyList<IItem> abilityItems);
    }
}
