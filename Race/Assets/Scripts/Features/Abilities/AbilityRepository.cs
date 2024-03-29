﻿using Configs;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Abilities
{
    public class AbilityRepository : IAbilityRepository
    {

        #region Constants

        private const string ABILITIES_CONFIG = "Configs/Abilities/AbilityItemCollectionConfig";

        #endregion


        #region Fields

        private Dictionary<int, IAbility> _abilityMapByItmId;

        #endregion


        #region IAbilityRepository

        public IReadOnlyDictionary<int, IAbility> AbilityMapByItemId => _abilityMapByItmId;

        #endregion


        #region ClassLifeCycles

        public AbilityRepository()
        {
            _abilityMapByItmId = new Dictionary<int, IAbility>();
            var config = Resources.Load<AbilityItemCollectionConfig>(ABILITIES_CONFIG);

            foreach (AbilityItemConfig abilityConfig in config.Abilities)
                CreateAbility(abilityConfig);
        }

        #endregion


        #region Methods

        private void CreateAbility(AbilityItemConfig abilityConfig)
        {
            switch (abilityConfig.Type)
            {
                case Enums.AbilityType.Gun:
                    var ability = new GunAbility(abilityConfig.View, abilityConfig.Value);
                    _abilityMapByItmId.Add(abilityConfig.Id, ability);
                    break;
                default:
                    throw new ArgumentException($"Unsupported ability type: {abilityConfig.Type}");
            }
        }

        #endregion

    }
}
