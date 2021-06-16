namespace Upgrades
{
    public class SpeedUpgradeCarHandler : IUpgradeCarHandler
    {
        #region Fields

        private readonly float _speed;

        #endregion


        #region ClassLifeCycles

        public SpeedUpgradeCarHandler(float speed)
        {
            _speed = speed;
        }

        #endregion


        #region IUpgradeHandler

        public IUpgradableCar Upgrade(IUpgradableCar upgradableCar)
        {
            upgradableCar.Speed = _speed;
            return upgradableCar;
        }

        #endregion

    }
}
