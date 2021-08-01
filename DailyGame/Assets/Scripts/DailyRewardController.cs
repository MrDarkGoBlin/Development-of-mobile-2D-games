using System.Collections.Generic;
using UnityEngine;

public class DailyRewardController
{
    private DailyRewardView _dailyRewardView;
    private CurrencyView _currencyView;
    private Saveinformation _saveinformation;
    private List<ContainerSlotRewardView> _containerSlotRewardViews = new List<ContainerSlotRewardView>();
    private float _nextRewardTimer;
    private float _fillAmount = 0;
    private bool _isFillAmount;
    private int _currentDay = 0;
    private bool _isGetReward;

    public DailyRewardController(DailyRewardView dailyRewardView, CurrencyView currencyView)
    {
        _dailyRewardView = dailyRewardView;
        _dailyRewardView.RewardButton.onClick.AddListener(CheckReward);
        _dailyRewardView.ResetButton.onClick.AddListener(ResetAll);
        _nextRewardTimer = _dailyRewardView.TimeCooldown;
        _currencyView = currencyView;
        _saveinformation = new Saveinformation();
    }

    public void RefrashView()
    {
        InitSlts();
    }

    private void InitSlts()
    {
        for (int i = 0; i < _dailyRewardView.Rewards.Count; i++)
        {
            var instanceSlot = GameObject.Instantiate(_dailyRewardView.ContainerSlotRewardView, _dailyRewardView.MountRootSlotSpawn, false);
            _containerSlotRewardViews.Add(instanceSlot);
        }
        for (int i = 0; i < _containerSlotRewardViews.Count; i++)
        {
            _containerSlotRewardViews[i].SetData(_dailyRewardView.Rewards[i],i+1, _dailyRewardView.TimeDeadline);
            _containerSlotRewardViews[i].IsActive = false; // почему то не ставился сразу
        }
        Load();
        ResetAll();
        
    }

    public void Load()
    {
        _nextRewardTimer = _saveinformation.NextRewardTime;
        _currencyView.AddBook(_saveinformation.CurrentPoisen);
        _currencyView.AddBook(_saveinformation.CurrentBook);
        _currentDay = _saveinformation.CurrentDay;
        List<bool> isActive = _saveinformation.ActivesRewards;
        for (int i = 0; i < _containerSlotRewardViews.Count; i++)
        {
            _containerSlotRewardViews[i].IsActive = isActive[i];
        }
        isActive.Clear();
    }

    public void Update()
    {
        FillAmount();
        SlotsWork();
        TimerWork();
    }

    private void FillAmount()
    {
        if (_fillAmount > 1)
            _isFillAmount = true;
        if (_fillAmount < 0)
            _isFillAmount = false;
        if (_isFillAmount)
        {
            _fillAmount -= 0.5f * Time.deltaTime;
        }
        else
        {
            _fillAmount += 0.5f * Time.deltaTime;
        }
    }

    private void TimerWork()
    {
        _dailyRewardView.TimerNewReward.text = TimerInterpritator.InterpritationTime(_nextRewardTimer);
        if (_nextRewardTimer <= 0)
        {            
            _containerSlotRewardViews[_currentDay].IsActive = true;
            _nextRewardTimer = _dailyRewardView.TimeCooldown;
            _currentDay += 1;
        }
        _nextRewardTimer -= Time.deltaTime;
    }
    private void SlotsWork()
    {
        foreach (var item in _containerSlotRewardViews)
        {
            if (item.IsActive == true)
            {
                item.SelectBackground.fillAmount = _fillAmount;
                if (item.DeadTimer <= 0)
                {
                    item.SelectBackground.fillAmount = 0;
                    item.IsActive = false;

                }
                item.DeadTimer -= Time.deltaTime;
            }
        }
        _containerSlotRewardViews[_currentDay].SelectBackground.fillAmount = (_dailyRewardView.TimeCooldown - _nextRewardTimer) / _dailyRewardView.TimeCooldown;
    }

    private void CheckReward()
    {
        foreach (var item in _containerSlotRewardViews)
        {
            for (int i = 0; i < _containerSlotRewardViews.Count; i++)
            {
                if (_containerSlotRewardViews[i].IsActive)
                {
                    switch (_dailyRewardView.Rewards[i].RewardType)
                    {
                        case RewardType.Book:
                            _currencyView.AddBook(_dailyRewardView.Rewards[i].CountCurrency);
                            break;
                        case RewardType.Poison:
                            _currencyView.AddPoison(_dailyRewardView.Rewards[i].CountCurrency);
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
        _saveinformation.Save(_currencyView.Poison, _currencyView.Book, _nextRewardTimer, _currentDay, _containerSlotRewardViews);
    }

    private void ResetAll()
    {
        foreach (var item in _containerSlotRewardViews)
        {
            item.DeadTimer = _dailyRewardView.TimeDeadline;
            item.IsActive = false;
            item.SelectBackground.fillAmount = 0;
        }
        _currencyView.ResetText();
        _currentDay = 0;
        _nextRewardTimer = _dailyRewardView.TimeCooldown;
        PlayerPrefs.DeleteAll();
    }
}
