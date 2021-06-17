using Abilities;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class CarController : BaseController, IAbilityActivator
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/Car";

        #endregion


        #region Fields

        private CarView _view;

        #endregion


        #region ClassLifeCycles

        public CarController()
        {
            _view = LoadView<CarView>(VIEW_PATH);
        }

        #endregion


        #region IAbilityActivator

        public GameObject GetViewObject()
        {
            return _view.gameObject;
        }

        #endregion

    }
}
