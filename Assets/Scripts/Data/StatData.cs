using System;

[Serializable]
public class StatData
{
    public float maxHealth;
    public float health;
    public float speed;
    public float attackSpeed;
    public float healthRegeneration;

    public StatData(float maxhealth, float speed, float attackSpeed, float healthRegeneration)
    {
        maxHealth = maxhealth;
        health = maxhealth;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
        this.healthRegeneration = healthRegeneration;
    }

    public StatData Add(StatData add)
    {
        maxHealth += add.maxHealth;
        health += add.health;
        speed += add.speed;
        attackSpeed += add.attackSpeed;
        healthRegeneration += add.healthRegeneration;
        return this;
    }

    public StatData Multiply(StatData add)
    {
        maxHealth *= add.maxHealth;
        health *= add.health;
        speed *= add.speed;
        attackSpeed *= add.attackSpeed;
        healthRegeneration *= add.healthRegeneration;
        return this;
    }

    public StatData Subtract(StatData add)
    {
        maxHealth -= add.maxHealth;
        health -= add.health;
        speed -= add.speed;
        attackSpeed -= add.attackSpeed;
        healthRegeneration -= add.healthRegeneration;
        return this;
    }
}
