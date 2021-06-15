using Upgrades;

namespace Models
{
    public class Car : IUpgradableCar
    {

        #region Fields

        private readonly float _defaultSpeed;

        #endregion


        #region ClassLifeCycles

        public Car(float speed)
        {
            _defaultSpeed = speed;
            Restore();
        }

        #endregion


        #region IUpgradableCar

        public float Speed { get; set; }

        public void Restore()
        {
            Speed = _defaultSpeed;
        }

        #endregion
    }
}