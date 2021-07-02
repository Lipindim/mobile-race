using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FightView : BaseShowableView
{
    [SerializeField]
    private TMP_Text _playerMoney;

    [SerializeField]
    private TMP_Text _playerHealth;

    [SerializeField]
    private TMP_Text _playerPower;

    [SerializeField]
    private TMP_Text _enemyPower;


    [SerializeField]
    private Button _increaseMoney;

    [SerializeField]
    private Button _decreaseMoney;


    [SerializeField]
    private Button _increaseHealth;

    [SerializeField]
    private Button _decreaseHealth;


    [SerializeField]
    private Button _increasePower;

    [SerializeField]
    private Button _decreasePower;

    [SerializeField]
    private Button _fight;

    [SerializeField]
    private Button _exit;


    public TMP_Text PlayerMoney  => _playerMoney;
    public TMP_Text PlayerHealth => _playerHealth;
    public TMP_Text PlayerPower => _playerPower;

    public TMP_Text EnemyPower => _enemyPower;

    public Button IncreaseMoney => _increaseMoney;
    public Button DecreaseMoney => _decreaseMoney;
    public Button IncreaseHealth => _increaseHealth;
    public Button DecreaseHealth => _decreaseHealth;
    public Button IncreasePower => _increasePower;
    public Button DecreasePower => _decreasePower;

    public Button Fight => _fight;
    public Button Exit => _exit;

}
