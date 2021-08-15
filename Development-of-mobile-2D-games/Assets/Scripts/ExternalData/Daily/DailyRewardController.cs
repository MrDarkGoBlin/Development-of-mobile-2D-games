using System;
using Profile;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using JoostenProductions;

public class DailyRewardController : BaseController
{
    private DailyRewardView _dailyRewardView;
    private CurrencyView _currencyView;
    private Saveinformation _saveinformation;
    private List<ContainerSlotRewardView> _containerSlotRewardViews = new List<ContainerSlotRewardView>();
    private CurrencyController _currencyController;
    private ProfilePlayer _profilePlayer;
    private NotificationView _notificationView;

    private float _nextRewardTimer;
    private float _speedFillAmount = 0.5f;
    private float _fillAmount = 0;
    private int _currentDay = 0;

    public DailyRewardController(Transform placeForUI , ProfilePlayer profilePlayer, GameObject dailyRewardView, GameObject currencyView)
    {
        _profilePlayer = profilePlayer;
        _dailyRewardView = Object.Instantiate(dailyRewardView, placeForUI).GetComponent<DailyRewardView>();
        AddGameObject(_dailyRewardView.gameObject);
        _currencyController = new CurrencyController(placeForUI, currencyView);
        AddController(_currencyController);
        SubscribeButtons();
        _nextRewardTimer = _dailyRewardView.TimeCooldown;
        _currencyView = currencyView.GetComponent<CurrencyView>();
        _saveinformation = new Saveinformation();
        _notificationView = new NotificationView();
    }

    private void SubscribeButtons()
    {
        _dailyRewardView.RewardButton.onClick.AddListener(CheckReward);
        _dailyRewardView.ResetButton.onClick.AddListener(ResetAll);
        _dailyRewardView.CloseButton.onClick.AddListener(CloseWindow);
        UpdateManager.SubscribeToUpdate(Update);

    }
    
    protected override void OnDispose()
    {
        base.OnDispose();
        _dailyRewardView.RewardButton.onClick.RemoveAllListeners();
        _dailyRewardView.ResetButton.onClick.RemoveAllListeners();
        _dailyRewardView.CloseButton.onClick.RemoveAllListeners();
        UpdateManager.UnsubscribeFromUpdate(Update);
    }

    private void CloseWindow()
    {
        _currencyController?.Dispose();
        _profilePlayer.CurrentState.Value = GameState.Start;
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
            _speedFillAmount *= -1;
        if (_fillAmount < 0)
            _speedFillAmount *= -1;

            _fillAmount += _speedFillAmount * Time.deltaTime;
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
        _notificationView.CreatNotification();
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
