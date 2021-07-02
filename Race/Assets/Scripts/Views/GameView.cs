using UnityEngine;
using UnityEngine.UI;


public class GameView : BaseShowableView
{

    [SerializeField] private Button _goToFight;

    public Button GoToFight => _goToFight;

}

