using System;
using UnityEngine;

[Serializable]
public class WeaponItem : Item
{
    public float rateOfFire;
    public Attack[] attacks;

    private float attackTime = 0f;

    public WeaponItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils, Attack[] attacks, float rateOfFire) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.rateOfFire = rateOfFire;
        this.attacks = attacks;
    }

    public void Use(Character character)
    {
        if (attackTime >= 5f / character.stats.attackSpeed / rateOfFire)
        {
            foreach (Attack attack in attacks)
            {
                attack.Shoot(character, character.pool);
            }
            attackTime = 0f;
        }
    }

    public void IncrementAttackTime(float f)
    {
        attackTime += f;
    }
}
