using Tools;
using Profile;
using Game.InputLogic;

public class GameController : BaseController
{
    public GameController(ProfilerPlayer profilePlayer)
    {
        var leftMoveDiff = new SubscriptionProperty<float>();
        var rightMoveDiff = new SubscriptionProperty<float>();

        var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(tapeBackgroundController);

        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);

        var carController = new CarController();
        AddController(carController);
    }
}
