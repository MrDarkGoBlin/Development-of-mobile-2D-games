using System.Collections.Generic;

public class DataPlayer 
{
    private string _titleData;

    private int _countHealth;
    private int _countPhysicalDefence;
    private int _countMagicDefence;

    private List<IEnemy> _enemies = new List<IEnemy>();

    public DataPlayer(string titleData)
    {
        _titleData = titleData;
    }

    public int Health
    {
        get { return _countHealth; }
        set
        {
            if (_countHealth != value)
            {
                _countHealth = value;
                Notifier(DataType.Health);
            }
        }
    }

    public int PhysicalDefence
    {
        get { return _countPhysicalDefence; }
        set
        {
            if (_countPhysicalDefence != value)
            {
                _countPhysicalDefence = value;
                Notifier(DataType.PhysicalDefence);
            }
        }
    }

    public int MagicDefence
    {
        get { return _countMagicDefence; }
        set
        {
            if (_countMagicDefence != value)
            {
                _countMagicDefence = value;
                Notifier(DataType.MagicDefence);
            }
        }
    }

    public string TitleData => _titleData;


    public void Atach(IEnemy enemy)
    {
        _enemies.Add(enemy);
    }
    public void Detach(IEnemy enemy)
    {
        _enemies.Remove(enemy);
    }

    private void Notifier(DataType dataType)
    {
        foreach (var enemie in _enemies)
        {
            enemie.Update(this, dataType);
        }
    }

}

class Health : DataPlayer
{
    public Health(string titleData) : base(titleData)
    {

    }

}
class PhysicalDefence : DataPlayer
{
    public PhysicalDefence(string titleData) : base(titleData)
    {

    }

}
class MagicDefence : DataPlayer
{
    public MagicDefence(string titleData) : base(titleData)
    {

    }

}
