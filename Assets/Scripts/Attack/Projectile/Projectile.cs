using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Attack attack;
    public Vector3 direction;
    public float speed;
    public float angle;
    private float life;

    public Projectile SetProperties(Vector3 position, Attack attack, Vector3 direction)
    {
        transform.position = position;
        this.attack = attack;
        speed = attack.speed;
        angle = 0f;
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
                if (life >= attack.acceleration.offset) speed += attack.acceleration.rate * .01f;
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
