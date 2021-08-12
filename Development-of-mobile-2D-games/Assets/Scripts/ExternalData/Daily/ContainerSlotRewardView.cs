using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContainerSlotRewardView : MonoBehaviour
{
    [SerializeField]
    private Image _selectBackground;
    [SerializeField]
    private Image _iconCurrency;
    [SerializeField]
    private TMP_Text _textDay;
    [SerializeField]
    private TMP_Text _countReward;

    private float _deadTimer;
    private bool _isActive;

    public float DeadTimer { get => _deadTimer; set => _deadTimer = value; }
    public bool IsActive { get => _isActive; set => _isActive = value; }
    public Image SelectBackground  => _selectBackground;

    public void SetData(Reward reward, int countDay, float deadTimer)
    {
        _iconCurrency.sprite = reward.IconCurrency;
        _textDay.text = $"Day: {countDay}";
        _countReward.text = reward.CountCurrency.ToString();
        _deadTimer = deadTimer;
        _isActive = false;
    }

    
}
