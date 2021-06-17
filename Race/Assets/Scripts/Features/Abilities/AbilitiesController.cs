using Controllers;
using Inventory;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Abilities
{
    public class AbilitiesController : BaseController
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/Abilities";

        #endregion


        #region Fields

        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        #endregion


        #region ClassLifeCycles

        public AbilitiesController(
            IAbilityActivator abilityActivator,
            IInventoryModel inventoryModel,
            IAbilityRepository abilityRepository,
            Transform placeForUi)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));

            _abilityCollectionView = LoadView<IAbilityCollectionView>(VIEW_PATH, placeForUi);
            _abilityCollectionView.Display(GetAbilities());
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        }

        #endregion


        #region Methods

        private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.AbilityMapByItemId.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }

        private IReadOnlyList<IItem> GetAbilities()
        {
            int[] abilitieIds = _abilityRepository.AbilityMapByItemId.Keys.ToArray();
            
            return _inventoryModel.GetEquippedItems()
                .Where(x => abilitieIds.Contains(x.Id))
                .ToList();
        }

        #endregion

    }
}
