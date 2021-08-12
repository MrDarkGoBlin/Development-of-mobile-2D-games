using UnityEngine;

public class CurrencyController : BaseController
{
    public CurrencyController(Transform placeForUI, CurrencyView currencyView)
    {
        var instanceCurrencyView = Object.Instantiate(currencyView, placeForUI);
        AddGameObject(instanceCurrencyView.gameObject);
    }
}
