using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipSpawnersMediator : MonoBehaviour
{
    public bool IsAvailable = true;
    [SerializeField] private List<ShipSpawner> _shipSpawners;
    [SerializeField] private List<EndPoint> _endPoints;

    public void SpawnShip(float size, float speed)
    {
        if (IsAvailable == false)
            return;

        _shipSpawners[UnityEngine.Random.Range(0, _shipSpawners.Count)].SpawnShip(size, speed);
        IsAvailable = false;
    }

    private void SetAvailability()
    {
        IsAvailable = true;
    }

    private void OnEnable()
    {
        foreach (EndPoint endPoint in _endPoints)
            endPoint.OnShipReachedEndPoint += SetAvailability;
    }

    private void OnDisable()
    {
        foreach (EndPoint endPoint in _endPoints)
            endPoint.OnShipReachedEndPoint -= SetAvailability;
    }
}
