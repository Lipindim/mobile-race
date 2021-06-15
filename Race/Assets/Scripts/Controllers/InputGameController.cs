using Models;
using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class InputGameController : BaseController
    {
        private BaseInputView _view;

        private readonly string _viewPath = "Prefabs/acceleration";
        

        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            var objView = GameObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<BaseInputView>();
        }
    }

}
