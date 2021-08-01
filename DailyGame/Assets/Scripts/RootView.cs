using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootView : MonoBehaviour
{
    [SerializeField]
    private DailyRewardView _dailyRewardView;
    [SerializeField]
    private CurrencyView _currencyView;

    private DailyRewardController _dailyRewardController;
    

    private void Awake()
    {
        _dailyRewardController = new DailyRewardController(_dailyRewardView, _currencyView);
    }

    private void Start()
    {
        _dailyRewardController.RefrashView();
    }

    private void Update()
    {
        _dailyRewardController.Update();
    }

}
