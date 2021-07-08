using Controllers;
using UnityEngine;


public class Main : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
    private Camera _camera;

    private MainController _mainController;

    private void Start()
    {
        _mainController = new MainController(_placeForUi, _camera);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }

}
