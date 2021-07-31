using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AIWindowView : MonoBehaviour
{
    [SerializeField]
    private int _enemyNormalDemage;
    [SerializeField]
    private TMP_Text _healthPlayerText;
    [SerializeField]
    private TMP_Text _physicalDefansePlayerText;
    [SerializeField]
    private TMP_Text _magicDefansePlayerText;
    [SerializeField]
    private TMP_Text _crimeLevelText;
    [SerializeField]
    private TMP_Text _powerEnemyText;
    [SerializeField]
    private Button _addHealthButton;
    [SerializeField]
    private Button _minusHealthButton;
    [SerializeField]
    private Button _addPhysicalDefanseButton;
    [SerializeField]
    private Button _minusPhysicalDefanseButton;
    [SerializeField]
    private Button _addMagicDefansePlayerButton;
    [SerializeField]
    private Button _minusMagicDefansePlayerButton;
    [SerializeField]
    private Button _fightButton;
    [SerializeField]
    private Button _escapeButton;
    [SerializeField]
    private Button _changeButtleButton;
    [SerializeField]
    private Button _addCrimeLevelButton;
    [SerializeField]
    private Button _minusCrimeLevelButton;

    private int _allCountHealth;
    private int _allCountPhysicalDefanse;
    private int _allCountMagicDefanse;
    private int _crimeLevel;

    private Enemy _enemy;

    private Health _health;
    private PhysicalDefence _physicalDefence;
    private MagicDefence _magicDefence;
    private TypeButtle _typeButtle;
    private void Start()
    {

        _typeButtle = TypeButtle.Physical;
        Debug.Log($"Type Buttle {_typeButtle}");
        _enemy = new Enemy("Sepheroth", _enemyNormalDemage, _typeButtle);
        _health = new Health(nameof(Health));
        _health.Atach(_enemy);
        _physicalDefence = new PhysicalDefence(nameof(PhysicalDefence));
        _physicalDefence.Atach(_enemy);
        _magicDefence = new MagicDefence(nameof(MagicDefence));
        _magicDefence.Atach(_enemy);

        _addHealthButton.onClick.AddListener(() => ChangeValue(true, DataType.Health));
        _minusHealthButton.onClick.AddListener(() => ChangeValue(false, DataType.Health));

        _addPhysicalDefanseButton.onClick.AddListener(() => ChangeValue(true, DataType.PhysicalDefence));
        _minusPhysicalDefanseButton.onClick.AddListener(() => ChangeValue(false, DataType.PhysicalDefence));

        _addMagicDefansePlayerButton.onClick.AddListener(() => ChangeValue(true, DataType.MagicDefence));
        _minusMagicDefansePlayerButton.onClick.AddListener(() => ChangeValue(false, DataType.MagicDefence));

        _addCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLaevel(true));
        _minusCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLaevel(false));

        _fightButton.onClick.AddListener(Fight);
        _escapeButton.onClick.AddListener(Escape);
        _changeButtleButton.onClick.AddListener(ChangeButtleType);

    }

    private void OnDestroy()
    {
        _addHealthButton.onClick.RemoveAllListeners();
        _minusHealthButton.onClick.RemoveAllListeners();

        _addPhysicalDefanseButton.onClick.RemoveAllListeners();
        _minusPhysicalDefanseButton.onClick.RemoveAllListeners();

        _addMagicDefansePlayerButton.onClick.RemoveAllListeners();
        _minusMagicDefansePlayerButton.onClick.RemoveAllListeners();

        _addCrimeLevelButton.onClick.RemoveAllListeners();
        _minusCrimeLevelButton.onClick.RemoveAllListeners();

        _fightButton.onClick.RemoveAllListeners();
        _escapeButton.onClick.RemoveAllListeners();
        _changeButtleButton.onClick.RemoveAllListeners();

        _health.Detach(_enemy);
        _physicalDefence.Detach(_enemy);
        _magicDefence.Detach(_enemy);
    }

    private void ChangeValue(bool isAdd, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:                
                if (isAdd)
                {
                    _allCountHealth++;
                }
                else
                {
                    _allCountHealth--;
                }
                break;

            case DataType.PhysicalDefence:
                if (isAdd)
                {

                    _allCountPhysicalDefanse++;
                }
                else
                {
                    _allCountPhysicalDefanse--;
                }
                break;

            case DataType.MagicDefence:
                if (isAdd)
                {
                    _allCountMagicDefanse++;
                }
                else
                {
                    _allCountMagicDefanse--;
                }
                break;

            default:
                break;
        }

        ChangeDataWindow(dataType);
    }

    private void ChangeButtleType()
    {
        switch (_typeButtle)
        {
            case TypeButtle.Physical:
                _typeButtle = TypeButtle.Magic;       
                break;
            case TypeButtle.Magic:
                _typeButtle = TypeButtle.Physical;
                break;
            default:
                break;
        }

        Debug.Log($"Type Buttle {_typeButtle}");
        _enemy.ChangeTypeButtle(_typeButtle);
        _powerEnemyText.text = $"Enemy Power : {_enemy.Power}";
    }

    private void ChangeCrimeLaevel(bool isAdd)
    {
        if (isAdd)
        {
            _crimeLevel++;
        }
        else
        {
            _crimeLevel--;
        }
        if (_crimeLevel < 0)
        {
            _crimeLevel = 0;
        }
        else if (_crimeLevel > 5)
        {
            _crimeLevel = 5;
        }
        _crimeLevelText.text = $"Crime Level : {_crimeLevel}";
        CanToEscape(_crimeLevel);
    }

    private void CanToEscape(int value)
    {
        if (value <= 2)
        {
            _escapeButton.interactable = true;
        }
        else
        {
            _escapeButton.interactable = false;
        }
    }

    private void ChangeDataWindow(DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _healthPlayerText.text = $"Health Player : {_allCountHealth}";
                _health.Health = _allCountHealth;
                break;

            case DataType.PhysicalDefence:
                _physicalDefansePlayerText.text = $"Physical Defense Player : {_allCountPhysicalDefanse}";
                _physicalDefence.PhysicalDefence = _allCountPhysicalDefanse;
                break;

            case DataType.MagicDefence:
                _magicDefansePlayerText.text = $"Physical Magic Player : {_allCountMagicDefanse}";
                _magicDefence.MagicDefence = _allCountMagicDefanse;
                break;

            default:
                break;
        }

        _powerEnemyText.text = $"Enemy Power : {_enemy.Power}";
    }

    private void Fight()
    {
        Debug.Log(_allCountHealth >= _enemy.Power ? "Win" : "Lose");
    }

    private void Escape()
    {
        Debug.Log("You are escaped!");
    }
}
