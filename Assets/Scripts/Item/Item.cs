using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string name;
    public string description;
    public string sprite;
    public string itemType;
    public string rarity;
    public int maxSigils;

    public Item(string name, string description, string sprite, string itemType, string rarity, int maxSigils)
    {
        this.name = name;
        this.description = description;
        this.sprite = sprite;
        this.itemType = itemType;
        this.rarity = rarity;
        this.maxSigils = maxSigils;
    }

    public Item(string name, string description, string sprite, ItemType itemType, ItemRarity rarity, int maxSigils) : this(name, description, sprite, itemType.ToString(), rarity.ToString(), maxSigils)
    {
    }

    public class ItemTypeAttribute : Attribute
    {
        public EquipType equipType;

        public ItemTypeAttribute(EquipType equipType)
        {
            this.equipType = equipType;
        }
    }

    public enum EquipType
    {
        Weapon,
        Ability,
        Armor,
        Accessory,
        Miscellaneous
    }
}
