using Profile;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Transform _placeForUi;
    private UnityAdsTools _unityAdsTools;

    private MainController _mainController;

    private void Awake()
    {
        _unityAdsTools = new UnityAdsTools();
        var profilePlayer = new ProfilerPlayer(15f, _unityAdsTools);
        profilePlayer.CurrentState.Value = GameState.Start;
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    protected void OnDestroy()
    {
        _mainController?.Dispose();
    }
}
