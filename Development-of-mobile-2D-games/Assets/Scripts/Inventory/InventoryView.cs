using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour, IInventoryView
{
    private List<IItem> _itemInfoCollection;

    public event EventHandler<IItem> Selected;
    public event EventHandler<IItem> Deselected;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void Display(List<IItem> items)
    {
        _itemInfoCollection = items;


    }
    protected virtual void OnSelected(IItem e)
    {
        Selected?.Invoke(this, e);
    }

    protected virtual void OnDeselected(IItem e)
    {
        Deselected?.Invoke(this, e);
    }

}
