using UnityEngine;

public class CarController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/Car" };
    private CarView _carView;

    public CarController()
    {
        _carView = LoadView();
    }

    public GameObject GetViewObject()
    {
        return _carView.gameObject;
    }

    private CarView LoadView()
    {
        var objectCar = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath));
        AddGameObject(objectCar);

        return objectCar.GetComponent<CarView>();
    }
}
