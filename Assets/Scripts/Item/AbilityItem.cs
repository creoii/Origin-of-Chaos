using System;
using UnityEngine;

[Serializable]
public class AbilityItem : Item
{
    public float cooldown;
    public Attack[] attacks;

    private float attackTime = 0f;

    public AbilityItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils, Attack[] attacks, float cooldown) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.cooldown = cooldown;
        this.attacks = attacks;
    }

    public void Activate(Character character)
    {
        if (attackTime >= cooldown)
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
