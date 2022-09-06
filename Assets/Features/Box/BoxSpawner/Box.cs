using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private float _size;

    public void Init(float size)
    {
        _size = size;
    }

    public float GetSize()
    {
        return _size;
    }
}
