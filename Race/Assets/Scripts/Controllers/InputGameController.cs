using Models;
using Tools;
using Views;


namespace Controllers
{
    public class InputGameController : BaseController
    {

        private const string VIEW_PATH = "Prefabs/acceleration";


        private BaseInputView _view;


        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView<BaseInputView>(VIEW_PATH);
            _view.Init(leftMove, rightMove, car.Speed);
        }

    }
}
