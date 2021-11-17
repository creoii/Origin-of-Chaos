using System;
using UnityEngine;

[Serializable]
public class WeaponItem : Item
{
    public float rateOfFire;
    public Attack[] attacks;

    private float attackTime = 0f;

    public WeaponItem(string name, string description, ItemType itemType, ItemRarity rarity, int maxSigils, Attack[] attacks) : base(name, description, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.attacks = attacks;
    }

    public void Use(Character character)
    {
        if (attackTime >= 5f / character.stats.AttackSpeed / rateOfFire)
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
