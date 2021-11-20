using System;
using UnityEngine;

[Serializable]
public class PositionData
{
    public float x;
    public float y;
    public float z;

    public PositionData(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static PositionData Override(PositionData one, PositionData two)
    {
        return new PositionData(
            two.x == 0 ? one.x : two.x,
            two.y == 0 ? one.y : two.y,
            two.z == 0 ? one.z : two.z
        );
    }

    public Vector3 GetAsVector3()
    {
        return new Vector3(x, y, z);
    }
}
