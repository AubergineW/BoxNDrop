using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBoxState : IBoxSpawningBaseState
{
    private IBoxSpawningStateSwitcher _stateSwitcher;
    private Box _box;
    public NoBoxState(IBoxSpawningStateSwitcher stateSwitcher, Box box)
    {
        _stateSwitcher = stateSwitcher;
        _box = box;
    }

    public void CreateBox()
    {
        _stateSwitcher.SwitchBoxSpawningState<ResizingBoxState>();
    }

    public void ResizeBox(float resizeSpeed)
    {
        return;
    }

    public void ReleaseBox()
    {
        return;
    }

    public void Start()
    {
        return;
    }

    public void Stop()
    {
        return;
    }
}
