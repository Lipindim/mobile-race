using System.Collections.Generic;

public abstract class DataPlayer
{
    private readonly DataType _dataType;
    private readonly string _titleData;
    private readonly List<INotifiable> _enemies;

    private int _value;

    protected DataPlayer(string titleData, DataType dataType)
    {
        _enemies = new List<INotifiable>();
        _dataType = dataType;
        _titleData = titleData;
    }

    public void Attach(INotifiable enemy)
    {
        _enemies.Add(enemy);
    }

    public void Detach(INotifiable enemy)
    {
        _enemies.Remove(enemy);
    }

    protected void Notify()
    {
        foreach (var investor in _enemies)
            investor.Notify(this);
    }

    public string TitleData => _titleData;

    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                Notify();
            }
        }
    }

    public DataType DataType => _dataType;
}

public class Money : DataPlayer
{
    public Money(string titleData)
        : base(titleData, DataType.Money)
    {
    }
}

public class Health : DataPlayer
{
    public Health(string titleData)
        : base(titleData, DataType.Health)
    {
    }
}

public class Power : DataPlayer
{
    public Power(string titleData)
        : base(titleData, DataType.Power)
    {
    }
}

