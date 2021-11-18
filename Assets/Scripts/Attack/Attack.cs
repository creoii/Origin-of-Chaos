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
    public int angleOffset = 0;
    public int angleGap = 0;
    public bool onMouse = false;

    public MultiplierData acceleration = null;

    public Attack(string sprite, float lifetime, float speed, int projectileCount, int angleOffset, int angleGap, bool onMouse, MultiplierData acceleration)
    {
        this.sprite = sprite;
        this.lifetime = lifetime;
        this.speed = speed;
        this.projectileCount = projectileCount;
        this.angleOffset = angleOffset;
        this.angleGap = angleGap;
        this.onMouse = onMouse;
        this.acceleration = acceleration;
    }

    public Attack(string sprite, float lifetime, float speed) : this(sprite, lifetime, speed, 1, 0, 0, false, null)
    {

    }

    public static Attack Override(Attack one, Attack two)
    {
        return new Attack(
            two.sprite == null ? one.sprite : two.sprite,
            two.lifetime == 0 ? one.lifetime : two.lifetime,
            two.speed == 0 ? one.speed : two.speed,
            two.projectileCount == 0 ? one.projectileCount : two.projectileCount,
            two.angleOffset == 0 ? one.angleOffset : two.angleOffset,
            two.angleGap == 0 ? one.angleGap : two.angleGap,
            two.onMouse,
            MultiplierData.Override(one.acceleration, two.acceleration)
        );
    }

    public void Shoot(Character character, ObjectPool pool)
    {
        if (projectileCount > 0)
        {
            Vector3 position = onMouse ? MouseUtil.GetMouseWorldPos() : character.transform.position;
            float angle = MouseUtil.GetMouseAngle(position) + angleOffset;
            if (angle < 0) angle += 360f;
            if (projectileCount > 1) angle -= angleGap * (((projectileCount - 1f) / 2f) + 1);

            for (int i = 0; i < projectileCount; ++i)
            {
                GameObject obj = pool.GetObject();
                if (obj != null)
                {
                    obj.GetComponent<Projectile>().SetProperties(position, this, MathUtil.GetDirection(position, angle += angleGap).normalized);
                    obj.SetActive(true);
                }
            }
        }
    }
}
