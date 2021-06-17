using System.Collections.Generic;


namespace Abilities
{
    public interface IAbilityRepository
    {
        IReadOnlyDictionary<int, IAbility> AbilityMapByItemId { get; }
    }

}
