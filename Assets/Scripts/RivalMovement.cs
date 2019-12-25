using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RivalMovement : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Vector2 _currentVelocity;

    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(_currentVelocity.magnitude > _maxSpeed)
            _currentVelocity = _currentVelocity.normalized * _maxSpeed;
        _rigidbody2d.velocity = _currentVelocity;
    }
}
