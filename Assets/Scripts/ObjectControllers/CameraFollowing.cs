using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpArgument;

    private void LateUpdate()
    {
        Vector2 newPosition2D = Vector2.Lerp(transform.position, _target.position, _lerpArgument);
        transform.position = new Vector3(newPosition2D.x, newPosition2D.y, transform.position.z);
    }
}
