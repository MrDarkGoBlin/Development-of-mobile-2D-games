using Tools;

namespace Profile
{
    public class ProfilerPlayer
    {
        public ProfilerPlayer(float speed)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speed);
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }
    }
}
