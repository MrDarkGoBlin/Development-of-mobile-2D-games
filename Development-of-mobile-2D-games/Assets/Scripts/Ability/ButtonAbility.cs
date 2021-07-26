using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAbility : MonoBehaviour
{
    [SerializeField]
    private AbilityType _abilityType;
    [SerializeField]
    private Button _buttonAbility;
    private AbilitiesController _abilitiesController;

    public AbilityType AbilityType => _abilityType;

    public Button Button => _buttonAbility;

    public void Init(AbilityType abilityType, AbilitiesController abilitiesController, Image imageAbility)
    {
        _abilityType = abilityType;
        _buttonAbility.image = imageAbility;
        _buttonAbility.onClick.AddListener(ButtonClick);
        _abilitiesController = abilitiesController;
    }

    private void ButtonClick()
    {
        _abilitiesController.AbilityActive(_abilityType);
    }

}
