using Controllers;
using Models;
using UnityEngine;


public class Main : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;

    private void Awake()
    {
        MainController mainController = new MainController(_placeForUi);
    }

}
