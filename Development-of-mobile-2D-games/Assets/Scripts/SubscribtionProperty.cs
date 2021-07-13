using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribtionProperty<T> : IReadOnlySubscribtionProperty<T>
{
    private T _value;
    private Action<T> _onChangeValue;
    public T Value 
    { 
        get => _value;
        set
        {
            _value = value;
            _onChangeValue?.Invoke(_value);
        }
    }

    public void SubscribeOnChange(Action<T> subscribeAction)
    {
        _onChangeValue += subscribeAction;
    }

    public void UnSubscribeOnChange(Action<T> unSubscribeAction)
    {
        _onChangeValue += unSubscribeAction;
    }
}
