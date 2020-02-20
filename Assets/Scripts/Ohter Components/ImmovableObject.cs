using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmovableObject : MonoBehaviour
{
    private Vector3 _position;

    private void Awake()
    {
        _position = transform.position;
    }

    private void Update()
    {
        transform.position = _position;
    }
}
