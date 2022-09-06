using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBoxSpawningStateSwitcher
{
    void SwitchBoxSpawningState<T>() where T : IBoxSpawningBaseState;
}
