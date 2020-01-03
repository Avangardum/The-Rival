using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StartingVelocity : MonoBehaviour
{
    [SerializeField] Vector2 _startingVelocity;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = _startingVelocity;
    }
}
