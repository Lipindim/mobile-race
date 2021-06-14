using Controllers;
using System;
using Tools.Ads;
using UnityEngine;


public class Main : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    [SerializeField]
    private UnityAdsShower _unityAdsShower;
    [SerializeField]
    private Camera _camera;

    private MainController _mainController;

    private void Start()
    {
        if (_placeForUi == null)
            throw new ArgumentNullException(nameof(_placeForUi));
        if (_unityAdsShower == null)
            throw new ArgumentNullException(nameof(_unityAdsShower));
        if (_camera == null)
            throw new ArgumentNullException(nameof(_camera));

        _mainController = new MainController(_placeForUi, _unityAdsShower, _camera);
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }

}
