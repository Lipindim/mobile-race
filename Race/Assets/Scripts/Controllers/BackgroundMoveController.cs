using Tools;
using UnityEngine;
using Views;


namespace Controllers
{
    public class BackgroundMoveController : BaseController, IShowable
    {

        #region Constants

        private const string VIEW_PATH = "Prefabs/background";

        #endregion


        #region Fields

        private BackgroundView _view;
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;

        #endregion


        #region ClassLifeCycles

        public BackgroundMoveController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove)
        {
            _view = LoadView<BackgroundView>(VIEW_PATH);
            _leftMove = leftMove;
            _rightMove = rightMove;
            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscriptionOnChange(Move);
            _rightMove.UnSubscriptionOnChange(Move);
        }

        #endregion


        #region Methods

        private void Move(float value)
        {
            _view.Move(-value);
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            _view.Hide();
        }

        public void Show()
        {
            _view.Show();
        }

        #endregion


    }
}
