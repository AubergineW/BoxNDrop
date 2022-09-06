using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private ShipDirection _shipDirection;
    private Ship _shipObject;

    private const int LEFT_SHIP_SPEED_DIFFERENCE = 1;

    public void SpawnShip(float size, float speed)
    {
        _shipObject = Instantiate(_ship, transform.position, Quaternion.identity);
        _shipObject.Init(size, _shipDirection == ShipDirection.Left ? -speed - LEFT_SHIP_SPEED_DIFFERENCE : speed);
    }

}
