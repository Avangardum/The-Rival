using UnityEngine;

public static class Extensions
{
    public static void LookAt2D(this Transform transform, Vector2 target)
    {
        Vector2 diff = target - (Vector2)transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    public static void LookAt2D(this Transform transform, Transform target) => LookAt2D(transform, target.position);

    public static void LookFrom2D(this Transform transform, Vector2 target)
    {
        transform.LookAt2D(target);
        transform.Rotate(0, 0, 180);
    }

    public static void LookFrom2D(this Transform transform, Transform target) => LookFrom2D(transform, target.position);

    public static Vector3 RotateAroundOrigin(this Vector2 originalVector, float angleDeg)
    {
        float angleRad = angleDeg * Mathf.Deg2Rad;
        float x1 = originalVector.x;
        float y1 = originalVector.y;
        float x2 = Mathf.Cos(angleRad) * x1 - Mathf.Sin(angleRad) * y1;
        float y2 = Mathf.Sin(angleRad) * x1 + Mathf.Cos(angleRad) * y1;
        return new Vector2(x2, y2);
    }
}
