using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticFunctions
{
    public static Vector2 GetWorldMousePositions()
    {
        return Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
    }
}
