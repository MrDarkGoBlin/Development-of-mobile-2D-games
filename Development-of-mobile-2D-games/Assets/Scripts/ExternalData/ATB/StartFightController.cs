using Profile;
using UnityEngine;

public class StartFightController : BaseController
{
    private StartFightView _startFightView;
    private ProfilePlayer _profilePlayer;

    public StartFightController(Transform placeForUI, ProfilePlayer profilePlayer, StartFightView startFightView)
    {
        _profilePlayer = profilePlayer;
        _startFightView = Object.Instantiate(startFightView, placeForUI);
        AddGameObject(_startFightView.gameObject);
    }

    public void RefrashView()
    {
        _startFightView.StartFightButton.onClick.AddListener(StartFight);
    }

    private void StartFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        _startFightView.StartFightButton.onClick.RemoveAllListeners();
    }
}
