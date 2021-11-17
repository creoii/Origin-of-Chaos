using System;

[Serializable]
public class AccessoryItem : Item
{
    public AccessoryItem(string name, string description, ItemType itemType, ItemRarity rarity, int maxSigils) : base(name, description, itemType.ToString(), rarity.ToString(), maxSigils)
    {

    }
}
