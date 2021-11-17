using UnityEngine;

public class MouseUtil
{
    public static Vector3 GetMouseWorldPos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        return new Vector3(pos.x, pos.y, 0f);
    }

    public static Vector3 GetMouseDirection(Vector3 reference, float angle)
    {
        return (new Vector3(reference.x + Mathf.Cos(angle * Mathf.Deg2Rad), reference.y + Mathf.Sin(angle * Mathf.Deg2Rad)) - GetMouseWorldPos()).normalized;
    }

    public static float GetMouseAngle(Vector3 reference)
    {
        return MathUtil.ToAngle(GetMouseWorldPos() - reference);
    }
}