using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Views
{
    internal class MainMenuView : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField]
        private Button _buttonStart;
        [SerializeField]
        private GameObject _trail;

        private GameObject _trailInstanse;

        private void Awake()
        {
            _trailInstanse = GameObject.Instantiate(_trail);
            _trailInstanse.SetActive(false);
        }

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            _trailInstanse.transform.position = new Vector3(touchPosition.x, touchPosition.y);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(eventData.position);
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
        }

        
    }
}