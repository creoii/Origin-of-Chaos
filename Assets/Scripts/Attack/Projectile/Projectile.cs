using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Attack attack;
    public Vector3 direction;
    private float life;

    public Projectile SetProperties(Vector3 position, Attack attack, Vector3 direction)
    {
        transform.position = position;
        this.attack = attack;
        this.direction = direction;
        return this;
    }

    void Update()
    {
        transform.Translate(direction * attack.speed * Time.deltaTime);
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
