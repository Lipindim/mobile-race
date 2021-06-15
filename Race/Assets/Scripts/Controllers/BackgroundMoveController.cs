using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class BackgroundMoveController : BaseController
    {
        private BackgroundView _view;
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;

        private readonly string _viewPath = "Prefabs/background";

        public BackgroundMoveController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            _leftMove = leftMove;
            _rightMove = rightMove;
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            _view.Move(-value);
        }

        private BackgroundView LoadView()
        {
            var objView = GameObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<BackgroundView>();
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
        }
    }
}
