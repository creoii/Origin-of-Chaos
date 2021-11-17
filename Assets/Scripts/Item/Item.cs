using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string name;
    public string description;
    public string itemType;
    public string rarity;
    public int maxSigils;

    public Item(string name, string description, string itemType, string rarity, int maxSigils)
    {
        this.name = name;
        this.description = description;
        this.itemType = itemType;
        this.rarity = rarity;
        this.maxSigils = maxSigils;
    }

    public Item(string name, string description, ItemType itemType, ItemRarity rarity, int maxSigils)
    {
        this.name = name;
        this.description = description;
        this.itemType = itemType.ToString().ToLower();
        this.rarity = rarity.ToString().ToLower();
        this.maxSigils = maxSigils;
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
