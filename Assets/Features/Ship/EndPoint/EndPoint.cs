using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class EndPoint : MonoBehaviour
{
    public event UnityAction<Box> OnBoxReachedEndPoint;
    public event UnityAction OnShipReachedEndPoint;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ship>())
        {
            Destroy(collision.gameObject);
            OnShipReachedEndPoint?.Invoke();
            OnBoxReachedEndPoint?.Invoke(collision.gameObject.GetComponentInChildren<Box>());
        }
    }
}
