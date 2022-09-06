using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoxSpawningBehaviour : IBoxSpawningStateSwitcher
{
    public IBoxSpawningBaseState CurrentBoxSpawningState;
    private List<IBoxSpawningBaseState> _allBoxSpawningStates;

    public BoxSpawningBehaviour(Box box, int positionY, BoxObjectCreator boxObjectCreator)
    {
        _allBoxSpawningStates = new List<IBoxSpawningBaseState>()
        {
            new NoBoxState(this, box),
            new ResizingBoxState(this, box, positionY, boxObjectCreator),
        };
        CurrentBoxSpawningState = _allBoxSpawningStates[0];
    }

    public void SwitchBoxSpawningState<T>() where T : IBoxSpawningBaseState
    {
        var state = _allBoxSpawningStates.FirstOrDefault(s => s is T);
        CurrentBoxSpawningState.Stop();
        state.Start();
        CurrentBoxSpawningState = state;
    }
}
