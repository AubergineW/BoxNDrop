using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoxSpawningBaseState
{
    void Start();
    void CreateBox();
    void ResizeBox(float resizeSpeed);
    void ReleaseBox();
    void Stop();
}
