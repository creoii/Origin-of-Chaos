using System;

[Serializable]
public class StatData
{
    public float maxHealth;
    public float health;
    public float maxMana;
    public float mana;
    public float speed;
    public float attackSpeed;
    public float healthRegeneration;
    public float manaRegeneration;
    public float armor;
    public float attack;

    public StatData(float maxHealth, float maxMana, float speed, float attackSpeed, float healthRegeneration, float manaRegeneration, float armor, float attack)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.maxMana = maxMana;
        mana = maxMana;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
        this.healthRegeneration = healthRegeneration;
        this.manaRegeneration = manaRegeneration;
        this.armor = armor;
        this.attack = attack;
    }

    public StatData Add(StatData add)
    {
        maxHealth += add.maxHealth;
        health += add.health;
        maxMana += add.maxMana;
        mana += add.mana;
        speed += add.speed;
        attackSpeed += add.attackSpeed;
        healthRegeneration += add.healthRegeneration;
        manaRegeneration += add.manaRegeneration;
        armor += add.armor;
        attack += add.attack;
        return this;
    }

    public StatData Multiply(StatData add)
    {
        maxHealth *= add.maxHealth;
        health *= add.health;
        maxMana *= add.maxMana;
        mana *= add.mana;
        speed *= add.speed;
        attackSpeed *= add.attackSpeed;
        healthRegeneration *= add.healthRegeneration;
        manaRegeneration *= add.manaRegeneration;
        armor *= add.armor;
        attack *= add.attack;
        return this;
    }

    public StatData Subtract(StatData add)
    {
        maxHealth -= add.maxHealth;
        health -= add.health;
        maxMana -= add.maxMana;
        mana -= add.mana;
        speed -= add.speed;
        attackSpeed -= add.attackSpeed;
        healthRegeneration -= add.healthRegeneration;
        manaRegeneration -= add.manaRegeneration;
        armor -= add.armor;
        attack -= add.attack;
        return this;
    }
}
