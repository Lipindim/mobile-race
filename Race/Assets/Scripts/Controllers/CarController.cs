using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    internal class CarController : BaseController
    {
        private CarView _view;

        private string _viewPath = "Prefabs/Car";

        public CarController()
        {
            _view = LoadView();
        }
        private CarView LoadView()
        {
            GameObject objView = GameObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }
    }
}
