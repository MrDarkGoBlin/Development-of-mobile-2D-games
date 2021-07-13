using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfiler
{
    public PlayerProfiler(float speed)
    {
        CurrentState = new SubscribtionProperty<GameState>();
        CurrentCar = new Car(speed);
    }

    public SubscribtionProperty<GameState> CurrentState { get; }

    public Car CurrentCar { get; }
}
