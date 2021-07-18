using Tools;
using UnityEngine.Advertisements;

namespace Profile
{
    public class ProfilerPlayer
    {
        public ProfilerPlayer(float speed, UnityAdsTools unityAdsTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speed);
            AnaliticsTools = new UnityAnaliticsTools();
            AdsShower = unityAdsTools;
            AdsListener = unityAdsTools;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
        public IAnaliticsTools AnaliticsTools { get; }
        public IAdsShower AdsShower { get; }
        public IUnityAdsListener AdsListener { get; }
    }
}
