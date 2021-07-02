using Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Views
{
    public class MainMenuView : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IShowable
    {

        #region Fields

        [SerializeField]
        private Button _buttonStart;
        [SerializeField]
        private Button _buttonShed;
        [SerializeField]
        private Button _buttonReward;
        [SerializeField]
        private GameObject _trail;

        private GameObject _trailInstanse;
        private ICameraTool _cameraTool;

        #endregion


        #region Properties

        public Button ButtonStart => _buttonStart;
        public Button ButtonShed => _buttonShed;
        public Button ButtonReward => _buttonReward;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _trailInstanse = Instantiate(_trail);
            _trailInstanse.SetActive(false);
        }

        #endregion


        #region Methods

        public void Init(ICameraTool cameraTool)
        {
            _cameraTool = cameraTool;
        }

        #endregion


        #region IDragHandler

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 touchPosition = _cameraTool.ScreenToWorldPoint(eventData.position);
            _trailInstanse.transform.position = new Vector3(touchPosition.x, touchPosition.y);
        }

        #endregion


        #region IPointerDownHandler

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 touchPosition = _cameraTool.ScreenToWorldPoint(eventData.position);
            _trailInstanse.transform.position = new Vector3(touchPosition.x, touchPosition.y);
            _trailInstanse.SetActive(true);
        }

        #endregion


        #region IPointerUpHandler

        public void OnPointerUp(PointerEventData eventData)
        {
            _trailInstanse.SetActive(false);
        }

        #endregion


        #region IShowable

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        #endregion

    }
}