using JoostenProductions;
using Tools;
using UnityEngine;

public class TrailController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath() { PathResource = "Prefabs/Trail" };
    private TrailView _trailView;
    private TrailRenderer _trailRenderer;
    private Camera _mainCamera;
    private Vector3 _setPosition;
    private bool _stateMouse;
    public TrailController()
    {
        _trailView = LoadView();
        _trailRenderer = _trailView.GetComponent<TrailRenderer>();
        UpdateManager.SubscribeToUpdate(Move);
        _mainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        UpdateManager.UnsubscribeFromUpdate(Move);
        base.OnDispose();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _stateMouse = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _stateMouse = false;
            _trailView.transform.position = new Vector3(-20, -20, -20);
        }
        if (_stateMouse)
        {
            _setPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _setPosition.z = 0;
            _trailView.transform.position = _setPosition;
        }
    }

    

    private TrailView LoadView()
    {
        var objectMainMenu = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath));
        AddGameObject(objectMainMenu);

        return objectMainMenu.GetComponent<TrailView>();
    }
}
