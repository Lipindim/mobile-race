using Controllers;
using Tools.Ads;
using UnityEngine;


public class Main : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
    private UnityAdsShower _unityAdsShower;

    private MainController _mainController;

    private void Start()
    {
        _mainController = new MainController(_placeForUi, _unityAdsShower);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }

}
