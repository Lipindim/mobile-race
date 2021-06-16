using Controllers;
using Inventory;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;


namespace Abilities
{
    public class AbilitiesController : BaseController
    {
        private const string VIEW_PATH = "Prefabs/Abilities";

        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        public AbilitiesController(
            IAbilityActivator abilityActivator,
            IInventoryModel inventoryModel,
            IAbilityRepository abilityRepository,
            Transform placeForUi)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));

            _abilityCollectionView = LoadView(placeForUi);
            _abilityCollectionView.Display(GetAbilities());
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        }

        private IAbilityCollectionView LoadView(Transform placeForUi)
        {
            var viewObject = GameObject.Instantiate(ResourceLoader.LoadPrefab(VIEW_PATH), placeForUi);
            AddGameObjects(viewObject);
            return viewObject.GetComponent<IAbilityCollectionView>();
        }

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

    }

}
