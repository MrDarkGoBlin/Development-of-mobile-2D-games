using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityCollectionView : MonoBehaviour
{
    [SerializeField]
    private List<ButtonAbility> _buttonsAbility;
        
    public List<ButtonAbility> ButtonsAbility => _buttonsAbility;
}
