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
        maxHealth = maxhealth;
        health = maxhealth;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
    }

    public StatData Add(StatData add)
    {
        maxHealth += add.maxHealth;
        health += add.health;
        speed += add.speed;
        attackSpeed += add.attackSpeed;
        return this;
    }

    public StatData Multiply(StatData add)
    {
        maxHealth *= add.maxHealth;
        health *= add.health;
        speed *= add.speed;
        attackSpeed *= add.attackSpeed;
        return this;
    }

    public StatData Subtract(StatData add)
    {
        maxHealth -= add.maxHealth;
        health -= add.health;
        speed -= add.speed;
        attackSpeed -= add.attackSpeed;
        return this;
    }
}
