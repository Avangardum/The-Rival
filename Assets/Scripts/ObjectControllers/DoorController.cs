using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform _rotationPivot;
    [SerializeField] private bool _isLocked;
    [SerializeField] private bool _clockwise;

    private bool _isOpened = false;

    public event Action DoorOpened;

    public void Open()
    {
        if (_isLocked || _isOpened)
            return;
        float angle = _clockwise ? -90 : 90;
        transform.RotateAround(_rotationPivot.position, Vector3.forward, angle);
        _isOpened = true;
        DoorOpened?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Open();
    }
}
