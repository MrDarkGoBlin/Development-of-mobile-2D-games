using System;
namespace Tools
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscribeAction);
        void UnSubscriptionOnChange(Action<T> UnSubscribeAction);
    }
}
