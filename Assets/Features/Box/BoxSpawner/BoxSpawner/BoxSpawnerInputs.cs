using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnerInputs : IBoxSpawningInput
{
    public bool GetResizingInput()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
