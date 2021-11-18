using System;
using UnityEngine;

[Serializable]
public class Attack
{
    public string name = null;
    public string sprite;
    public float lifetime;
    public float speed;
    public int projectileCount = 1;
    public int angleGap = 0;
    public bool onMouse = false;
    public float[] xOffsets;
    public float[] yOffsets;

    public MultiplierData acceleration = null;

    private float[] FillOffsets(float[] one, float[] two)
    {
        for (int i = 0; i < projectileCount; ++i)
        {
            if (i < two.Length) one[i] = two[i];
            else one[i] = 0f;
        }

        return one;
    }

    public void Shoot(Character character, ObjectPool pool)
    {
        if (projectileCount > 0)
        {
            Vector3 position = onMouse ? MouseUtil.GetMouseWorldPos() : character.transform.position;
            float angle = MouseUtil.GetMouseAngle(position);
            if (angle < 0) angle += 360f;
            if (projectileCount > 1) angle -= angleGap * (((projectileCount - 1f) / 2f) + 1);

            for (int i = 0; i < projectileCount; ++i)
            {
                GameObject obj = pool.GetObject();
                if (obj != null)
                {
                    if (xOffsets != null) position.x += xOffsets[i];
                    if (yOffsets != null) position.y += yOffsets[i];
                    obj.GetComponent<Projectile>().SetProperties(position, this, MathUtil.GetDirection(position, angle += angleGap));
                    obj.SetActive(true);
                }
            }
        }
    }
}
