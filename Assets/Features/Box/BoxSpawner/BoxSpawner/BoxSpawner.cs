using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _box;
    [SerializeField] private AnimationCurve _boxSizingAnimationCurve;
    [SerializeField] private BoxObjectCreator _boxObjectCreator;

    private BoxSpawningBehaviour _boxSpawningBehaviour;

    private IBoxSpawningInput _input = new BoxSpawnerInputs();

    private float _duration = 1;
    private float _expiredTime;

    private void Awake()
    {
        _boxSpawningBehaviour = new BoxSpawningBehaviour(_box, Mathf.RoundToInt(gameObject.transform.position.y), _boxObjectCreator);
    }

    private void Update()
    {
        if (_input.GetResizingInput())
        {
            _expiredTime += Time.deltaTime;

            if (_expiredTime > _duration)
                _expiredTime = 0;

            float progress = _expiredTime / _duration;

            _boxSpawningBehaviour.CurrentBoxSpawningState.CreateBox();
            _boxSpawningBehaviour.CurrentBoxSpawningState.ResizeBox(_boxSizingAnimationCurve.Evaluate(progress));
            return;
        }

        _boxSpawningBehaviour.CurrentBoxSpawningState.ReleaseBox();
    }
}
