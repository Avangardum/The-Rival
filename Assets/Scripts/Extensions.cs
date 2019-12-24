using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void LookAt2D(this Transform transform, Transform target) => LookAt2D(transform, target.position);

    public static void LookAt2D(this Transform transform, Vector2 target)
    {
        Vector2 diff = target - (Vector2)transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
