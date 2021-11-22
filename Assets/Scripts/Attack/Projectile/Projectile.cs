using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Attack attack;
    public Vector3 direction;
    public float speed;
    public float rate;
    private float damage;
    private float life;

    public Projectile SetProperties(Vector3 position, Attack attack, Vector3 direction, float damage)
    {
        transform.position = position;
        this.attack = attack;
        speed = attack.speed;
        rate = attack.acceleration.rate;
        this.damage = damage;
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
        SpriteUtil.SetSprite(GetComponent<SpriteRenderer>(), "Sprites/Projectiles/" + attack.sprite);
        Invoke("Disable", attack.lifetime);
    }

    void Disable()
    {
        gameObject.SetActive(false);
        life = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Character") && gameObject.tag.Equals("EnemyProjectile"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            character.Damage(damage - character.stats.armor);
            if (attack.statusEffects != null)
            {
                foreach (StatusEffect effect in attack.statusEffects)
                {
                    character.AddStatusEffect(effect);
                }
            }
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag.Equals("Enemy") && gameObject.tag.Equals("PlayerProjectile"))
        {
            Enemy enemy= collision.gameObject.GetComponent<Entity>().enemy;
            enemy.Damage(damage - enemy.stats.armor);
            if (attack.statusEffects != null)
            {
                foreach (StatusEffect effect in attack.statusEffects)
                {
                    enemy.AddStatusEffect(effect);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
