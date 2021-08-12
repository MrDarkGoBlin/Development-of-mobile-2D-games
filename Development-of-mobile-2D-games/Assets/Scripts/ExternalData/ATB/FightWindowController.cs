using System.Collections;
using Profile;
using System.Collections.Generic;
using UnityEngine;

public class FightWindowController : BaseController
{
    private FightWindowView _fightVindowView;
    private ProfilePlayer _profilePlayer;

    private int _allCountHealth;
    private int _allCountPhysicalDefanse;
    private int _allCountMagicDefanse;
    private int _crimeLevel;

    private Enemy _enemy;

    private Health _health;
    private PhysicalDefence _physicalDefence;
    private MagicDefence _magicDefence;
    private TypeButtle _typeButtle;

    public FightWindowController(Transform placeForUI, ProfilePlayer profilePlayer, FightWindowView fightWindowView)
    {
        _profilePlayer = profilePlayer;
        _fightVindowView = Object.Instantiate(fightWindowView, placeForUI);
        AddGameObject(_fightVindowView.gameObject);
    }

    public void RefreshView()
    {

        _typeButtle = TypeButtle.Physical;
        Debug.Log($"Type Buttle {_typeButtle}");
        _enemy = new Enemy("Sepheroth", _fightVindowView.EnemyNormalDemage, _typeButtle);
        _health = new Health(nameof(Health));
        _health.Atach(_enemy);
        _physicalDefence = new PhysicalDefence(nameof(PhysicalDefence));
        _physicalDefence.Atach(_enemy);
        _magicDefence = new MagicDefence(nameof(MagicDefence));
        _magicDefence.Atach(_enemy);
        SubscribeButtons();

    }

    private void SubscribeButtons()
    {
        _fightVindowView.AddHealthButton.onClick.AddListener(() => ChangeValue(true, DataType.Health));
        _fightVindowView.MinusHealthButton.onClick.AddListener(() => ChangeValue(false, DataType.Health));

        _fightVindowView.AddPhysicalDefanseButton.onClick.AddListener(() => ChangeValue(true, DataType.PhysicalDefence));
        _fightVindowView.MinusPhysicalDefanseButton.onClick.AddListener(() => ChangeValue(false, DataType.PhysicalDefence));

        _fightVindowView.AddMagicDefansePlayerButton.onClick.AddListener(() => ChangeValue(true, DataType.MagicDefence));
        _fightVindowView.MinusMagicDefansePlayerButton.onClick.AddListener(() => ChangeValue(false, DataType.MagicDefence));

        _fightVindowView.AddCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLaevel(true));
        _fightVindowView.MinusCrimeLevelButton.onClick.AddListener(() => ChangeCrimeLaevel(false));

        _fightVindowView.FightButton.onClick.AddListener(Fight);
        _fightVindowView.EscapeButton.onClick.AddListener(Escape);
        _fightVindowView.ChangeButtleButton.onClick.AddListener(ChangeButtleType);
    }
    protected override void OnDispose()
    {
        base.OnDispose();
        _fightVindowView.AddHealthButton.onClick.RemoveAllListeners();
        _fightVindowView.MinusHealthButton.onClick.RemoveAllListeners();

        _fightVindowView.AddPhysicalDefanseButton.onClick.RemoveAllListeners();
        _fightVindowView.MinusPhysicalDefanseButton.onClick.RemoveAllListeners();

        _fightVindowView.AddMagicDefansePlayerButton.onClick.RemoveAllListeners();
        _fightVindowView.MinusMagicDefansePlayerButton.onClick.RemoveAllListeners();

        _fightVindowView.AddCrimeLevelButton.onClick.RemoveAllListeners();
        _fightVindowView.MinusCrimeLevelButton.onClick.RemoveAllListeners();

        _fightVindowView.FightButton.onClick.RemoveAllListeners();
        _fightVindowView.EscapeButton.onClick.RemoveAllListeners();
        _fightVindowView.ChangeButtleButton.onClick.RemoveAllListeners();

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
        _fightVindowView.PowerEnemyText.text = $"Enemy Power : {_enemy.Power}";
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
        _fightVindowView.CrimeLevelText.text = $"Crime Level : {_crimeLevel}";
        CanToEscape(_crimeLevel);
    }

    private void CanToEscape(int value)
    {
        if (value <= 2)
        {
            _fightVindowView.EscapeButton.interactable = true;
        }
        else
        {
            _fightVindowView.EscapeButton.interactable = false;
        }
    }

    private void ChangeDataWindow(DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Health:
                _fightVindowView.HealthPlayerText.text = $"Health Player : {_allCountHealth}";
                _health.Health = _allCountHealth;
                break;

            case DataType.PhysicalDefence:
                _fightVindowView.PhysicalDefansePlayerText.text = $"Physical Defense Player : {_allCountPhysicalDefanse}";
                _physicalDefence.PhysicalDefence = _allCountPhysicalDefanse;
                break;

            case DataType.MagicDefence:
                _fightVindowView.MagicDefansePlayerText.text = $"Physical Magic Player : {_allCountMagicDefanse}";
                _magicDefence.MagicDefence = _allCountMagicDefanse;
                break;

            default:
                break;
        }

        _fightVindowView.PowerEnemyText.text = $"Enemy Power : {_enemy.Power}";
    }

    private void Fight()
    {
        Debug.Log(_allCountHealth >= _enemy.Power ? "Win" : "Lose");
    }

    private void Escape()
    {
        Debug.Log("You are escaped!");
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}
