using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class BoxDetector : MonoBehaviour
{
    public event UnityAction<Box> OnBoxMissed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var box = collision.gameObject.GetComponent<Box>();

        if (box == null)
            return;

        OnBoxMissed?.Invoke(box);
        Destroy(collision.gameObject);
    }
}
