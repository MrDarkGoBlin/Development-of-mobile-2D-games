using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardView : MonoBehaviour
{
    #region Fields

    private const string CurrensySlotActiveKey = nameof(CurrensySlotActiveKey);
    private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

    [SerializeField]
    private float _timeCooldown = 86400;
    [SerializeField]
    private float _timeDeadline = 172800;
    [SerializeField]
    private List<Reward> _rewards;
    [SerializeField]
    private TMP_Text _timerNewReward;
    [SerializeField]
    private Transform _mountRootSlotSpawn;
    [SerializeField]
    private ContainerSlotRewardView _containerSlotRewardView;
    [SerializeField]
    private Button _rewardButton;
    [SerializeField]
    private Button _resetButton;
    [SerializeField]
    private Button _closeButton;

    #endregion

    public float TimeCooldown => _timeCooldown; 
    public float TimeDeadline => _timeDeadline;
    public List<Reward> Rewards  => _rewards; 
    public TMP_Text TimerNewReward  => _timerNewReward; 
    public Transform MountRootSlotSpawn  => _mountRootSlotSpawn;
    public ContainerSlotRewardView ContainerSlotRewardView  => _containerSlotRewardView;
    public Button RewardButton  => _rewardButton;
    public Button ResetButton => _resetButton;
    public Button CloseButton => _closeButton;



    public int CurrentSlotInActive
    {
        get => PlayerPrefs.GetInt(CurrensySlotActiveKey, 0);
        set => PlayerPrefs.SetInt(CurrensySlotActiveKey, value);
    }

    public DateTime? TimeGetReward
    {
        get
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKey, null);
            if (!string.IsNullOrEmpty(data))
                return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
            {
                PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
            }
            else
            {
                PlayerPrefs.DeleteKey(TimeGetRewardKey);
            }
        }
    }
}
