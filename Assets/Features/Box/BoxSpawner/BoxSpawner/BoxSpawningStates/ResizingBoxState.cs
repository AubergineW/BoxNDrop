using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResizingBoxState : IBoxSpawningBaseState
{
    private IBoxSpawningStateSwitcher _stateSwitcher;
    private Box _box;
    private Box _boxObject;
    private Transform _boxTransform;
    private int _positionY;
    private BoxObjectCreator _boxObjectCreator;

    public ResizingBoxState(IBoxSpawningStateSwitcher stateSwitcher, Box box, int positionY, BoxObjectCreator boxObjectCreator)
    {
        _stateSwitcher = stateSwitcher;
        _box = box;
        _positionY = positionY;
        _boxObjectCreator = boxObjectCreator;
    }

    public void CreateBox()
    {
        return;
    }

    public Box GetBoxObject()
    {
        return _boxObject;
    }

    public void ReleaseBox()
    {
        _boxObject.Init(_boxTransform.localScale.x);
        _stateSwitcher.SwitchBoxSpawningState<NoBoxState>();
    }

    public void ResizeBox(float resizeSpeed)
    {
        _boxTransform.localScale += new Vector3(resizeSpeed, resizeSpeed, 1);
        _boxTransform.position = new Vector2(0, _positionY);

        if (_boxTransform.localScale.x >= 6)
            ReleaseBox();
    }

    public void Start()
    {
        _boxObject = _boxObjectCreator.CreateBox(_box, new Vector3(0, 5, 0), Quaternion.identity);
        _boxTransform = _boxObject.GetComponent<Transform>();
    }

    public void Stop()
    {

    }
}
