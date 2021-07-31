using UnityEngine;

public class Enemy : IEnemy
{

    private string _name;

    private TypeButtle _typeButtle;

    private int _countHealth;
    private int _countPhysicalDefence;
    private int _countMagicDefence;
    private int _normalDamage;
    public Enemy(string name, int normalDamage, TypeButtle typeButtle)
    {
        _name = name;
        _normalDamage = normalDamage;
        _typeButtle = typeButtle;
    }
    public void Update(DataPlayer dataPlayer, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _countHealth = dataPlayer.Health;
                break;
            case DataType.PhysicalDefence:
                _countPhysicalDefence = dataPlayer.PhysicalDefence;
                break;
            case DataType.MagicDefence:
                _countMagicDefence = dataPlayer.MagicDefence;
                break;
            default:
                break;
        }
        Debug.Log($"Update date {dataType}, for Enemy {_name}");
    }

    public void ChangeTypeButtle(TypeButtle typeButtle)
    {
        _typeButtle = typeButtle;

    }

    public int Power 
    { 
        get
        {
            int health = _countHealth <= 0 ? health = 0 : health = _countHealth;
            int physical = _countPhysicalDefence <= 0 ? physical = 1 : physical = _countPhysicalDefence;
            int magic = _countMagicDefence <= 0 ? magic = 1 : magic = _countMagicDefence;
            int power;
            switch (_typeButtle)
            {
                case TypeButtle.Physical:
                    power = (_normalDamage * magic) / (physical + health);
                    break;
                case TypeButtle.Magic:
                    power = (_normalDamage + physical) /  (magic * health);
                    break;
                default:
                    power = 0;
                    break;
            }
            
            return power;
        } 
    }
}

