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
    
    /// <summary>
    /// Возвращает копию данного вектора, повёрнутую на angleDeg относительно начала
    /// </summary>
    public static Vector3 TurnedAroundOrigin(this Vector2 originalVector, float angleDeg)
    {
        float angleRad = angleDeg * Mathf.Deg2Rad;
        float x1 = originalVector.x;
        float y1 = originalVector.y;
        float x2 = Mathf.Cos(angleRad) * x1 - Mathf.Sin(angleRad) * y1;
        float y2 = Mathf.Sin(angleRad) * x1 + Mathf.Cos(angleRad) * y1;
        return new Vector2(x2, y2);
    }

    /// <summary>
    /// Поворачивает данный вектор на angleDeg относительно начала
    /// </summary>
    public static void RotateAroundOrigin(this ref Vector2 originalVector, float angleDeg)
    {
        originalVector = originalVector.TurnedAroundOrigin(angleDeg);
    }

    public static void DecreaseCooldown(this ref float cooldown, DecreaseCooldownMode decreaseCooldownMode)
    {
        float deltaTime = 0;
        switch(decreaseCooldownMode)
        {
            case DecreaseCooldownMode.Update:
                deltaTime = Time.deltaTime;
                break;
            case DecreaseCooldownMode.FixedUpdate:
                deltaTime = Time.fixedDeltaTime;
                break;
            case DecreaseCooldownMode.UpdateUnscaled:
                deltaTime = Time.unscaledDeltaTime;
                break;
            case DecreaseCooldownMode.FixedUpdateUnscaled:
                deltaTime = Time.fixedUnscaledDeltaTime;
                break;
        }
        cooldown -= deltaTime;
        if (cooldown < 0)
            cooldown = 0;
    }
}
