using UnityEngine;

public class MathUtil
{
    public const float Deg2Rad = .01745329f;

    public static float ToAngle(Vector3 vec)
    {
        return Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
    }
}
