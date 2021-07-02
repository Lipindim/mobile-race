using TMPro;
using UnityEngine;

public class CurrencyView : BaseShowableView
{
    [SerializeField]
    private TMP_Text _currentCountWood;

    [SerializeField]
    private TMP_Text _currentCountDiamond;

    public void SetCurrency(int woods, int diamonds)
    {
        _currentCountWood.text = woods.ToString();
        _currentCountDiamond.text = diamonds.ToString();
    }
}
