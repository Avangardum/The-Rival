using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public bool IsEnabled;

    [SerializeField] private float _maxSpeed;

    private Rigidbody2D _rigidbody2d;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (PauseController.Instance.IsPaused || !IsEnabled)
            return;
        _rigidbody2d.velocity = _velocity;
    }

    public void SetDirection(Vector2 direction)
    {
        _velocity = direction.normalized * _maxSpeed;
    }
}
