using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Attack attack;
    public Vector3 direction;
    public float speed;
    public float rate;
    private float life;

    public Projectile SetProperties(Vector3 position, Attack attack, Vector3 direction)
    {
        transform.position = position;
        this.attack = attack;
        speed = attack.speed;
        rate = attack.acceleration.rate;
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (attack.acceleration != null)
        {
            if (attack.acceleration.rate != 0f)
            {
                if (life >= attack.acceleration.offset)
                {
                    speed += rate * attack.acceleration.multiplier;
                }
            }
        }

        life += Time.deltaTime;
    }

    void OnEnable()
    {
        SpriteUtil.SetSpriteRenderer(GetComponent<SpriteRenderer>(), "Sprites/Projectiles/" + attack.sprite);
        Invoke("Disable", attack.lifetime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        life = 0;
    }
}
