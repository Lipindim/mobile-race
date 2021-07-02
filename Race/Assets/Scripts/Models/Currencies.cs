public class Currencies
{
    public int WoodCount { get; private set; }
    public int DiamondCount { get; private set; }

    public void SetCurrencies(int woods, int diamonds)
    {
        WoodCount = woods;
        DiamondCount = diamonds;
    }
}

