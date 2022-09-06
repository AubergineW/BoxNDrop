using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxObjectCreator : MonoBehaviour, IBoxObjectCreator
{
    public event UnityAction<Box> OnBoxObjectCreated;

    public Box CreateBox(Box box, Vector3 position, Quaternion rotation)
    {
        OnBoxObjectCreated?.Invoke(box);
        return Instantiate(box, position, rotation);
    }
}
