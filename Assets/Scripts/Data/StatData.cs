using System;

[Serializable]
public class StatData
{
    public float maxHealth;
    public float health;
    public float speed;
    public float attackSpeed;

    public StatData(float maxhealth, float speed, float attackSpeed)
    {
        this.maxHealth = maxhealth;
        this.health = maxhealth;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
    }
}
