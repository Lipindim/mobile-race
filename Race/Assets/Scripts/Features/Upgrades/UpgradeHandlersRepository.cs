using Configs;
using Controllers;
using Enums;
using System.Collections.Generic;


namespace Upgrades
{
    public class UpgradeHandlersRepository : BaseController
    {

        #region Fields

        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();

        #endregion


        #region Properties

        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;

        #endregion


        #region ClassLifeCycles

        public UpgradeHandlersRepository(
            List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }

        protected override void OnDispose()
        {
            _upgradeItemsMapById.Clear();
            _upgradeItemsMapById = null;
        }

        #endregion


        #region Methods

        private void PopulateItems(ref Dictionary<int, IUpgradeCarHandler> upgradeHandlersMapByType,
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (!upgradeHandlersMapByType.ContainsKey(config.Id))
                    upgradeHandlersMapByType.Add(config.Id, CreateHandlerByType(config));
            }
        }

        private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.type)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.Value);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }

        #endregion
    }

}
