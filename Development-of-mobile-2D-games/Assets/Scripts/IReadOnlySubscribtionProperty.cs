using System;

public interface IReadOnlySubscribtionProperty<T>
{
    T Value { get; }
    void SubscribeOnChange(Action<T> subscribeAction);
    void UnSubscribeOnChange(Action<T> UnSubscribeAction);
}
