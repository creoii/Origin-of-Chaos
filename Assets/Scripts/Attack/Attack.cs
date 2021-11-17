using System;
using UnityEngine;

[Serializable]
public class Attack
{
    public float lifetime;
    public float speed;
    public int projectileCount = 1;
    public int angleGap = 0;
    public string sprite;

    public Attack(float lifetime, float speed, int projectileCount, int angleGap, string sprite)
    {
        this.lifetime = lifetime;
        this.speed = speed;
        this.projectileCount = projectileCount;
        this.angleGap = angleGap;
        this.sprite = sprite;
    }

    public Attack(float lifetime, float speed, string sprite) : this(lifetime, speed, 1, 0, sprite)
    {

    }

    public void Shoot(Character character, ObjectPool pool)
    {
        if (projectileCount > 0)
        {
            Vector3 position = character.transform.position;
            float angle = MouseUtil.GetMouseAngle(position);
            if (angle < 0) angle += 360f;
            if (projectileCount > 1) angle -= angleGap * (((projectileCount - 1f) / 2f) + 1);

            for (int i = 0; i < projectileCount; ++i)
            {
                GameObject obj = pool.GetObject();
                if (obj != null)
                {
                    obj.GetComponent<Projectile>().SetProperties(position, this, MouseUtil.GetMouseDirection(position, angle += angleGap));
                    obj.SetActive(true);
                }
            }
        }
    }
}
