using System;
using UnityEngine;

[Serializable]
public class WeaponItem : Item
{
    public float rateOfFire;
    public Attack[] attacks;

    public SigilItem[] sigils;
    private float attackTime = 0f;

    public WeaponItem(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils, Attack[] attacks, float rateOfFire) : base(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
        this.rateOfFire = rateOfFire;
        this.attacks = attacks;
        sigils = new SigilItem[maxSigils];
    }

    public void Start()
    {
        for (int i = 0; i < attacks.Length; ++i)
        {
            if (attacks[i].name != null)
            {
                foreach (Attack attack1 in AttackPresetBuilder.attacks)
                {
                    if (attacks[i].name == attack1.name) attacks[i] = attack1;
                }
            }
        }
        sigils = new SigilItem[maxSigils];
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
        for (int i = 0; i < sigils.Length; ++i)
        {
            if (sigils[i] != null) sigils[i].TryActivate(character, character.pool);
        }
    }

    public void IncrementAttackTime(float f)
    {
        for (int i = 0; i < sigils.Length; ++i)
        {
            if (sigils[i] != null) sigils[i].IncrementAttackTime(f);
        }
        attackTime += f;
    }
}
