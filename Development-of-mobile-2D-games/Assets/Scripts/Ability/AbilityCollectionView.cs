﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    private IReadOnlyList<IItem> _abilityItems;

    protected virtual void OnUseRequested(IItem e)
    {
        UseRequested?.Invoke(this, e);
    }
    public event EventHandler<IItem> UseRequested;

    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _abilityItems = abilityItems;
    }

    public void Hide()
    {
        
    }

    public void Show()
    {
        
    }
}