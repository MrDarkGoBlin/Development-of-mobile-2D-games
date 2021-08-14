using UnityEngine;

public class CurrencyController : BaseController
{
    public CurrencyController(Transform placeForUI, GameObject currencyView)
    {
        var instanceCurrencyView = Object.Instantiate(currencyView, placeForUI).GetComponent<CurrencyView>();
        AddGameObject(instanceCurrencyView.gameObject);
    }
}
