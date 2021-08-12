using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWindowView : MonoBehaviour
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

    public int EnemyNormalDemage => _enemyNormalDemage;
    public TMP_Text HealthPlayerText  => _healthPlayerText; 
    public TMP_Text PhysicalDefansePlayerText => _physicalDefansePlayerText; 
    public TMP_Text MagicDefansePlayerText  => _magicDefansePlayerText; 
    public TMP_Text CrimeLevelText => _crimeLevelText;
    public TMP_Text PowerEnemyText => _powerEnemyText; 
    public Button AddHealthButton  => _addHealthButton; 
    public Button MinusHealthButton  => _minusHealthButton; 
    public Button AddPhysicalDefanseButton  => _addPhysicalDefanseButton; 
    public Button MinusPhysicalDefanseButton  => _minusPhysicalDefanseButton; 
    public Button AddMagicDefansePlayerButton => _addMagicDefansePlayerButton;
    public Button MinusMagicDefansePlayerButton  => _minusMagicDefansePlayerButton; 
    public Button FightButton  => _fightButton; 
    public Button EscapeButton => _escapeButton; 
    public Button ChangeButtleButton  => _changeButtleButton;
    public Button AddCrimeLevelButton => _addCrimeLevelButton; 
    public Button MinusCrimeLevelButton => _minusCrimeLevelButton; 
}
