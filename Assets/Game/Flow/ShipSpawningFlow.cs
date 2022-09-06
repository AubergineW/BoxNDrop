using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawningFlow : MonoBehaviour
{
    [SerializeField] private AnimationCurve _gameFlowAnimationCurve;
    [SerializeField] private ShipSpawnersMediator _shipSpawner;

    private void Update()
    {
        _shipSpawner.SpawnShip(Random.Range(1.0f, 3.0f), _gameFlowAnimationCurve.Evaluate(Time.time));
    }
}
