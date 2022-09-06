using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipInteracter : MonoBehaviour
{
    private ShipInteracterObservable _shipInteracterObservable;
    private void Start()
    {
        _shipInteracterObservable = FindObjectOfType<ShipInteracterObservable>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var box = gameObject.GetComponent<Box>();
        var ship = collision.gameObject.GetComponent<Ship>();

        if (ship == null)
            return;

        switch(ship.TakeBox(box))
        {
            case BoxLanding.NotCentered:
                _shipInteracterObservable.CallOnFailedEvent(box, ship);
                break;
            case BoxLanding.OverSized:
                _shipInteracterObservable.CallOnFailedEvent(box, ship);
                break;
            case BoxLanding.Perfect:
                _shipInteracterObservable.CallOnLandedEvent(box, ship, Successfulness.Perfect);
                break;
            case BoxLanding.Satisfied:
                _shipInteracterObservable.CallOnLandedEvent(box, ship, Successfulness.Perfect);
                break;
        }

        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        ship.Release();
    }
}
