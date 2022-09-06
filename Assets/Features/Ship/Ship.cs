using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private LayerMask _shipLayer;
    private float _size;
    private float _speed;

    private const int SPEED_MULTIPLIER = 5;
    private const float PERFECT_SIZE_DIFFERENCE = 0.2f;

    public void Init(float size, float speed)
    {
        _size = size;
        _speed = speed;

        SetProperties(_size);
    }

    public float GetSize()
    {
        return _size;
    }

    public BoxLanding TakeBox(Box box)
    {
        RaycastHit2D hit = Physics2D.Raycast(box.transform.position, Vector2.down, 16, _shipLayer);
        box.transform.parent = gameObject.transform;

        if (hit.collider == null)
            return BoxLanding.NotCentered;

        if (box.GetSize() > _size)
            return BoxLanding.OverSized;

        if (Mathf.Abs(box.GetSize() - _size) >= PERFECT_SIZE_DIFFERENCE)
            return BoxLanding.Perfect;

        return BoxLanding.Satisfied;
    }

    public void Release()
    {
        MultiplySpeed(SPEED_MULTIPLIER);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(transform.position + new Vector3(_speed, 0, 0) * Time.deltaTime);
    }

    private void SetProperties(float size)
    {
        _transform.localScale *= new Vector2(size, _transform.localScale.y);
    }

    private void MultiplySpeed(float multiplier)
    {
        _speed *= multiplier;
    }
}
