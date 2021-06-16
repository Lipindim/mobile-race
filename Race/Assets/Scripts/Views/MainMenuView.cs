using JetBrains.Annotations;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Views
{
    public class MainMenuView : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField]
        private Button _buttonStart;
        [SerializeField]
        private Button _buttonBuy;
        [SerializeField]
        private Button _buttonShed;
        [SerializeField]
        private GameObject _trail;

        private GameObject _trailInstanse;
        private ICameraTool _cameraTool;

        private void Awake()
        {
            _trailInstanse = Instantiate(_trail);
            _trailInstanse.SetActive(false);
        }

        public void Init(UnityAction startGame, UnityAction buyAction, UnityAction openShed, ICameraTool cameraTool)
        {
            _cameraTool = cameraTool;
            _buttonStart.onClick.AddListener(startGame);
            _buttonBuy.onClick.AddListener(buyAction);
            _buttonShed.onClick.AddListener(openShed);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 touchPosition = _cameraTool.ScreenToWorldPoint(eventData.position);
            _trailInstanse.transform.position = new Vector3(touchPosition.x, touchPosition.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 touchPosition = _cameraTool.ScreenToWorldPoint(eventData.position);
            _trailInstanse.transform.position = new Vector3(touchPosition.x, touchPosition.y);
            _trailInstanse.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _trailInstanse.SetActive(false);
        }


        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonBuy.onClick.RemoveAllListeners();
        }

        
    }
}