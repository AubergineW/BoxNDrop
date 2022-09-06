using System;
using UnityEngine;
using UnityEngine.Events;

public class ShipInteracterObservable : MonoBehaviour
{
    public event UnityAction<Box, Ship> OnFailed;
    public event UnityAction<Box, Ship, Successfulness> OnLanded;

    public void CallOnFailedEvent(Box box, Ship ship)
    {
        OnFailed?.Invoke(box, ship);
    }

    public void CallOnLandedEvent(Box box, Ship ship, Successfulness successfulness)
    {
        OnLanded?.Invoke(box, ship, successfulness);
    }
}