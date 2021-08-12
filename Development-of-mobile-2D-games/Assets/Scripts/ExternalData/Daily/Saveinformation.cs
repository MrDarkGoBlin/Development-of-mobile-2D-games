using System.Collections.Generic;
using UnityEngine;


public class Saveinformation
{
    private static string CurrentPoisonSave = nameof(CurrentPoisonSave);
    private static string CurrentBookSave = nameof(CurrentBookSave);
    private static string NextRewardTimeSave = nameof(NextRewardTimeSave);
    private static string CurrentDaySave = nameof(CurrentDaySave);
    private static string CurrentCountListActiveRewards = nameof(CurrentCountListActiveRewards);

    private int _currentPoisen;
    private int _currentBook;
    private float _nextRewardTime;
    private int _currentDay;
    private List<bool> _activesRewards = new List<bool>();

    public int CurrentPoisen { get => PlayerPrefs.GetInt(CurrentPoisonSave, 0); }
    public int CurrentBook { get => PlayerPrefs.GetInt(CurrentPoisonSave, 0); }
    public float NextRewardTime { get => PlayerPrefs.GetFloat(CurrentPoisonSave, 86400); }
    public int CurrentDay { get => PlayerPrefs.GetInt(CurrentPoisonSave, 0); }
    public List<bool> ActivesRewards { get 
        {
            int count = PlayerPrefs.GetInt(CurrentCountListActiveRewards, 8);
            for (int i = 0; i < count; i++)
            {
                int isActive = PlayerPrefs.GetInt(CurrentCountListActiveRewards + $"{i}", 0);
                _activesRewards.Add(isActive == 1 ? true : false);
            }
            return _activesRewards;
        } 
    }

    public void Save(int currentPoisen, int currentBook, float nextRewardTime, int currentDay, List<ContainerSlotRewardView> activesRewards)
    {
        _currentPoisen = currentPoisen;
        _currentBook = currentBook;
        _nextRewardTime = nextRewardTime;
        _currentDay = currentDay;
        _activesRewards = new List<bool>();
        foreach (var item in activesRewards)
        {
            _activesRewards.Add(item.IsActive);
        }
        PlayerPrefs.SetInt(CurrentPoisonSave, _currentPoisen);
        PlayerPrefs.SetInt(CurrentBookSave, _currentBook);
        PlayerPrefs.SetFloat(NextRewardTimeSave, _nextRewardTime);
        PlayerPrefs.SetInt(CurrentDaySave, _currentDay);
        PlayerPrefs.SetInt(CurrentCountListActiveRewards, _activesRewards.Count);
        for (int i = 0; i < _activesRewards.Count; i++)
        {
            int isActiv = _activesRewards[i] ? 1 : 0;
            PlayerPrefs.SetInt(CurrentCountListActiveRewards + $"{i}", isActiv);
        }
        _activesRewards.Clear();
    }

}

