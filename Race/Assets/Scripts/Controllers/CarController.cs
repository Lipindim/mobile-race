using Abilities;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class CarController : BaseController, IAbilityActivator
    {
        private CarView _view;
        private GameObject _gameObject;

        private string _viewPath = "Prefabs/Car";

        public CarController()
        {
            _view = LoadView();
        }

        public GameObject GetViewObject()
        {
            return _gameObject;
        }

        private CarView LoadView()
        {
            var objView = GameObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }
    }
}
