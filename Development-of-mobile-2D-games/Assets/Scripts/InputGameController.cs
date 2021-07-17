using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    public class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/MobileSingleStickControl" };
        private BaseInputView _view;
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private BaseInputView LoadView()
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefabs(_viewPath));
            AddGameObject(objectView);
            return objectView.GetComponent<BaseInputView>();
        }
    }
}
